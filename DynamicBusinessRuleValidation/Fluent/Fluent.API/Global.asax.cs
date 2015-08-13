using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Fluent.ViewModels;
using Fluent.Validators;
using Fluent.WebAPI;
using FluentValidation;

namespace Fluent.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Initialise Autofac
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            builder.RegisterType<ContactUsSubjectValidator>().As<ContactUsSubjectValidator>().SingleInstance();
            builder.RegisterType<EmailValidator>().As<EmailValidator>().SingleInstance();
            //builder.RegisterType<ContactUsValidatorDefaultMessages>().As<IValidator<ContactUsViewModel>>().InstancePerRequest();
            builder.RegisterType<ContactUsValidator>().As<IValidator<ContactUsViewModel>>().InstancePerRequest();

            
            
            
            builder.RegisterType<ScopedValidatorFactory>().As<IScopedValidatorFactory>();
            builder.RegisterType<FluentValidatorProvider>().As<IFluentValidatorProvider>().SingleInstance();

            //build container and add to the runtime
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());


            GlobalConfiguration.Configure(WebApiConfig.Register);
            //replace the default filter provider with one that can order the execution of the filters
            GlobalConfiguration.Configuration.Services.Replace(typeof(System.Web.Http.Filters.IFilterProvider), new OrderedFilterProvider());

            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);
        }
    }
}
