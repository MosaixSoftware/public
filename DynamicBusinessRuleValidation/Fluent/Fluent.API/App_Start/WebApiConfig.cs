using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Fluent.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            //config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ContactUsFilterPost",
                routeTemplate: "contactusfilter/post/",
                defaults: new { controller = "ContactUsFilter", action = "Post" }
            );

            config.Routes.MapHttpRoute(
                name: "ContactUsInjectionsPost",
                routeTemplate: "contactusinjection/post/",
                defaults: new { controller = "ContactUsInjection", action = "Post" }
            );


            config.Routes.MapHttpRoute(
                name: "ContactUsEmbeddedPost",
                routeTemplate: "contactusembedded/post/",
                defaults: new { controller = "ContactUsEmbedded", action = "Post" }
            );

            config.Routes.MapHttpRoute(
               name: "ContactUsDataAnnotationsPost",
               routeTemplate: "contactusdataannotations/post/",
               defaults: new { controller = "ContactUsDataAnnotations", action = "Post" }
           );


            /* ----- COMMENT OUT THIS SECTION TO NOT FIRE FLUENT AS A FILTER ----- */
            //add the fluent validation filter to the execution pipeline
            //Runs FluentValidation
            //config.Filters.Add(new FluentValidationActionFilter());     

            //Catches FluentValidation and ModelState errors and formats them for the presentation layer(s)
            //Needed for both Fluent and ModelState based validation and if we want to abstract the ModelState.IsValid to a filter
            //config.Filters.Add(new ValidationActionFilter());     
            /* ------------------------------------------------------------------ */


            //TODO: 
            /*
             * In order to be able to handle different routes in different ways and apply fluent when desirable, we could convert the FluentValidationActionFilter
             * into a handler and create a validation pipeline which will only executed on designated routes.
             */
        }
    }
}
