using Autofac;
using ECommerce.Core.Interfaces;
using ECommerce.Core.Services;
using ECommerce.Domain.Contexts;

namespace ECommerce.WebApi
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ECommerceContext>();

            containerBuilder.RegisterType<RegisterService>().As<IRegisterService>();
            containerBuilder.RegisterType<EmailService>().As<IEmailService>();
            containerBuilder.RegisterType<LoginService>().As<ILoginService>();
            containerBuilder.RegisterType<PasswordService>().As<IPasswordService>();
            containerBuilder.RegisterType<UserService>().As<IUserService>();
            containerBuilder.RegisterType<CategoryService>().As<ICategoryService>();
            containerBuilder.RegisterType<ProductService>().As<IProductService>();
            containerBuilder.RegisterType<CartService>().As<ICartService>();

        }
    }
}
