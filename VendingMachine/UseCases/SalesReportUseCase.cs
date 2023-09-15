using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Serialization.ReportSerializers;
using System;

namespace iQuest.VendingMachine.UseCases
{
    internal class SalesReportUseCase : IUseCase
    {
        private IReportView reportView;

        private IReportSerializer reportSerializer;

        public SalesReportUseCase(IReportSerializer reportSerializer, IReportView reportView)
        {
            this.reportView = reportView;
            this.reportSerializer = reportSerializer;
        }

        public void Execute()
        {
            CreateSalesReport();
        }

        private void CreateSalesReport()
        {

            DateTime startDate = reportView.AskForStartDate();
            DateTime endDate = reportView.AskForEndDate();
            
            reportSerializer.CreateSalesReport(startDate, endDate);
           
        }
    }
}
