using DataAccess.Repositories;
using iQuest.VendingMachine.PurchaseLogic;
using System;
using System.Linq;
using System.Xml.Linq;

namespace iQuest.VendingMachine.Serialization.ReportSerializers
{
    internal class XmlReportSerializer : IReportSerializer
    {
        private readonly IProductService productService;
        private readonly IFileService fileService;
        private readonly IDispensedProductRepository dispensedProductRepo;

        private const string fileFormat = "Xml";

        private enum FolderNames
        {
            StockReports,
            SaleReports,
            VolumeReports
        }

        public XmlReportSerializer(IProductService productService, IFileService fileService, IDispensedProductRepository dispensedProductRepo)
        {
            this.dispensedProductRepo = dispensedProductRepo;
            this.productService = productService;
            this.fileService = fileService;
        }

        public void CreateStockReport()
        {
            DateTime now = DateTime.Now;

            string dateFormat = now.ToString("yyyy MM dd HHmmss");

            string folderName = FolderNames.StockReports.ToString();

            var xmlResult = new XElement("Products", productService.GetProductList()
                .Select(p => new XElement("Product",
                new XElement("name", p.Name),
                new XElement("Quantity", p.Quantity)
                )));

            fileService.Save(xmlResult.ToString(), fileFormat, folderName, dateFormat);
        }

        public void CreateSalesReport(DateTime startDate, DateTime endDate)
        {

            DateTime now = DateTime.Now;

            string date = now.ToString("yyyy MM dd HHmmss");

            string folderName = FolderNames.SaleReports.ToString();

            var xmlResult = new XElement("SaleReport", dispensedProductRepo.GetProductsByDates(startDate, endDate).Select(p => new XElement("Sales",
                 new XElement("Date", p.Date),
                 new XElement("Name", p.Name),
                 new XElement("Price", p.Price),
                 new XElement("PaymentMethod", p.PaymentMethod)
                 )));


            fileService.Save(xmlResult.ToString(), fileFormat, folderName, date);
        }

        public void CreateVolumeReport(DateTime startTime, DateTime endTime)
        {

            DateTime now = DateTime.Now;

            string date = now.ToString("yyyy MM dd HHmmss");

            string folderName = FolderNames.VolumeReports.ToString();

            var xmlResult = new XElement("VolumeReport",
                               new XElement("StartDate", startTime),
                               new XElement("EndDate", endTime),
                               dispensedProductRepo.GetProductsByDates(startTime, endTime).GroupBy(p => p.Name).Select(p => new XElement("Sales",
                                         new XElement("Name", p.Key),
                                         new XElement("Quantity", p.Count())
                                         )));

            fileService.Save(xmlResult.ToString(), fileFormat, folderName, date);
        }
    }
}
