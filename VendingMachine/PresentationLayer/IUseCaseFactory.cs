namespace iQuest.VendingMachine.PresentationLayer
{
    public interface IUseCaseFactory
    {
        T Create<T>();
    }
}
