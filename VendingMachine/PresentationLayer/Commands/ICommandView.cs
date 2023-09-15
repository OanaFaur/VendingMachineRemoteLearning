namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    public interface ICommandView
    {
        string Name { get; }

        string Description { get; }

        bool CanExecute { get; }

        void Execute();
    }
}
