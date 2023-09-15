using Autofac;
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine
{
    internal class UseCaseFactory : IUseCaseFactory
    {
        public IComponentContext _context;

        public UseCaseFactory(IComponentContext context)
        {
            _context = context;
        }

        public T Create<T>()
        {
            return _context.Resolve<T>();
        }
    }
}
