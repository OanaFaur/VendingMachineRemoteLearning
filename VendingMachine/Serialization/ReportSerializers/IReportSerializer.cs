using System;

namespace iQuest.VendingMachine.Serialization.ReportSerializers
{
    public interface IReportSerializer
    {
        void CreateVolumeReport(DateTime startDate, DateTime endTime);

        void CreateSalesReport(DateTime startDate, DateTime endTime);

        void CreateStockReport();
    }
}
