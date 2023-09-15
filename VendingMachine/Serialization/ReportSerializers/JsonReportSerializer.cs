using DataAccess.Repositories;
using iQuest.VendingMachine.PurchaseLogic;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace iQuest.VendingMachine.Serialization.ReportSerializers
{
    internal class JsonReportSerializer : IReportSerializer
    {
        private readonly IProductService productService;
        private readonly IFileService fileService;
        private readonly IDispensedProductRepository dispensedProductRepo;
        private const string fileFormat= "Json";

        private enum FolderNames
        {
            StockReports,
            SalesReports,
            VolumeReports
        }

        public JsonReportSerializer(IProductService productService, IFileService fileService, IDispensedProductRepository dispensedProductRepo)
        {
            this.productService = productService;
            this.fileService = fileService;
            this.dispensedProductRepo = dispensedProductRepo;
        }

        public void CreateStockReport()
        {
            DateTime now = DateTime.Now;

            string dateFormat = now.ToString("yyyy MM dd HHmmss");

            string folderName = FolderNames.StockReports.ToString();

            var products = productService.GetProductList()
                .Select(p => new
                {
                    p.Name,
                    p.Quantity
                })
                .ToList();

            string Jsonconvert = JsonConvert.SerializeObject(products, Newtonsoft.Json.Formatting.Indented);

            fileService.Save(Jsonconvert, fileFormat, folderName, dateFormat);
        }

        public void CreateSalesReport(DateTime startDate, DateTime endDate)
        {

            DateTime now = DateTime.Now;

            string dateFormat = now.ToString("yyyy MM dd HHmmss");

            var reportToBeDisplayed = dispensedProductRepo.GetProductsByDates(startDate, endDate).Select(p => new
            {
                p.Date,
                p.Name,
                p.Price,
                p.PaymentMethod

            }).ToList();

            string folderName = FolderNames.SalesReports.ToString();

            
            string json = JsonConvert.SerializeObject(reportToBeDisplayed, Formatting.Indented);
            fileService.Save(json, fileFormat, folderName, dateFormat);
        }

        public void CreateVolumeReport(DateTime startTime, DateTime endTime)
        {

            var Products = dispensedProductRepo.GetProductsByDates(startTime, endTime).GroupBy(x => x.Name)
                .Select(p => new
                {
                    Name = p.Key,
                    Quantity = p.Count()
                });

            var finalReports = new
            {
                startTime,
                endTime,
                Products
            };

            string json = JsonConvert.SerializeObject(finalReports, Formatting.Indented);

            DateTime now = DateTime.Now;

            string dateFormat = now.ToString("yyyy MM dd HHmmss");

            string folderName = FolderNames.VolumeReports.ToString();

            fileService.Save(json, fileFormat, folderName, dateFormat);
        }

    }
}
