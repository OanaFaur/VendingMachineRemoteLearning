using System.Diagnostics;


namespace iQuest.VendingMachine.Logger
{
    internal class EventViewerErrorWriter : IEventViewerWriter
    {
        public void EventLogger(string message)
        {
            EventLog eventLog = new EventLog();

            eventLog.Source = "Vending-Machine";

            int eventID = 9;

            eventLog.WriteEntry(message,
                                EventLogEntryType.Error,
                                eventID);

            eventLog.Close();
        }
    }
}
