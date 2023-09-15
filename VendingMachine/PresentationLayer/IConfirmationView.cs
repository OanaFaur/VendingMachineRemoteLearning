namespace iQuest.VendingMachine.PresentationLayer
{
    public interface IConfirmationView
    {
        void IsSelectionConfirmed();
        string UserConfirmation();
    }
}