using iQuest.VendingMachine.Serialization.ReportSerializers;

namespace iQuest.VendingMachine.UseCases
{
    internal class StockReportUseCase : IUseCase
    {
       
        private IReportSerializer reportSerializer;

        public StockReportUseCase(IReportSerializer reportSerializer)
        {
          
            this.reportSerializer = reportSerializer;
           
        }

        public void Execute()
        {

            CreateStockReport();
        }

        private void CreateStockReport()
        {
            reportSerializer.CreateStockReport();
           
        }
    }
}
