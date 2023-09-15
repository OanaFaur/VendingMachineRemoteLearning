using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Serialization.ReportSerializers;
using System;

namespace iQuest.VendingMachine.UseCases
{

    internal class VolumeReportUseCase : IUseCase
    {
        private IReportView reportView;


        private IReportSerializer reportSerializer;

        public VolumeReportUseCase(IReportSerializer reportSerializer, IReportView reportView)
        {

            this.reportView = reportView;
            this.reportSerializer = reportSerializer;
        }
        public void Execute()
        {
            CreateVolumeReport();
        }

        private void CreateVolumeReport()
        {
            DateTime startDate = reportView.AskForStartDate();
            DateTime endDate = reportView.AskForEndDate();

            reportSerializer.CreateVolumeReport(startDate, endDate);
        }
    }
}
