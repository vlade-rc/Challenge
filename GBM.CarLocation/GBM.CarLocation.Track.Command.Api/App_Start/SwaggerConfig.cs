﻿using System.Globalization;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using WebActivatorEx;
using GBM.CarLocation.Track.Command.Api;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace GBM.CarLocation.Track.Command.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {

            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {

                    c.SingleApiVersion("v1", "Query Example API");
                    c.DescribeAllEnumsAsStrings();
                    c.IncludeXmlComments(string.Format(@"{0}\bin\GBM.Domain.CarLocation.xml", System.AppDomain.CurrentDomain.BaseDirectory));

                })

                .EnableSwaggerUi(c =>
                {

                });
        }
    }
    
}