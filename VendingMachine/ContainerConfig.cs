using Autofac;
using DataAccess;
using DataAccess.Context;
using DataAccess.Repositories;
using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.Logger;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.PresentationLayer.Commands;
using iQuest.VendingMachine.PurchaseLogic;
using iQuest.VendingMachine.PurchaseLogic.PaymentMethods;
using iQuest.VendingMachine.Serialization;
using iQuest.VendingMachine.Serialization.ReportSerializers;
using iQuest.VendingMachine.UseCases;
using System.Configuration;
using System.Reflection;

namespace iQuest.VendingMachine
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<LoginView>().As<ILoginView>();
            builder.RegisterType<ShelfView>().As<IShelfView>();
            builder.RegisterType<BuyView>().As<IBuyView>();
            builder.RegisterType<MainView>().As<IMainView>();
            builder.RegisterType<ConfirmationView>().As<IConfirmationView>();
            builder.RegisterType<CardPaymentView>().As<ICardPaymentView>();
            builder.RegisterType<CashPaymentView>().As<ICashPaymentView>();
            builder.RegisterType<CreateNewProductView>().As<ICreateNewProductView>();
            builder.RegisterType<DeleteProductView>().As<IDeleteProductView>();
            builder.RegisterType<UpdateProductView>().As<IUpdateProductView>();
            builder.RegisterType<ReportView>().As<IReportView>();


            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<FileService>().As<IFileService>();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();

            builder.RegisterType<ProductContext>().AsSelf();
            builder.RegisterType<LiteDbProductRepository>().As<IProductRepository>();
            builder.RegisterType<ProductRepositoryEntityFramwork>().As<IProductRepository>();
            builder.RegisterType<DispensedProductRepoEntityFramework>().As<IDispensedProductRepository>();
            builder.RegisterType<CashMoneyRepository>().As<IMoneyRepository>();


            //Confiuration Manager

            if (ConfigurationManager.AppSettings["Format"].Equals("JSON"))
                builder.RegisterType<JsonReportSerializer>().As<IReportSerializer>();
            if (ConfigurationManager.AppSettings["Format"].Equals("XML"))
                builder.RegisterType<XmlReportSerializer>().As<IReportSerializer>();


            Assembly paymentAlgorithmAssembly = typeof(IPaymentAlgorithm).Assembly;
            builder.RegisterAssemblyTypes(paymentAlgorithmAssembly).As<IPaymentAlgorithm>();


            Assembly useCaseAssembly = typeof(IUseCase).Assembly;
            builder.RegisterAssemblyTypes(useCaseAssembly).As<IUseCase>().AsSelf();

            builder.RegisterType<UseCaseFactory>().As<IUseCaseFactory>();

            Assembly commands = typeof(ICommandView).Assembly;
            builder.RegisterAssemblyTypes(commands).As<ICommandView>();

            builder.RegisterType<PaymentUseCase>().As<IPaymentUseCase>();

            builder.RegisterType<EventViewerErrorWriter>().As<IEventViewerWriter>();
            builder.RegisterType<VendingMachineApplication>().As<IVendingMachineApplication>();
            return builder.Build();

        }
    }
}
