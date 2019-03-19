﻿using GBM.CarLocation.Domain.Messages;
using GBM.CarLocation.Track.Query.Api.Filters;
using GBM.CarLocation.Track.Query.Api.IoC;
using GBM.Infrastructure.Domain;
using GBM.Infrastructure.IoC;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Routing;

namespace GBM.CarLocation.Track.Query.Apis
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Filters.Add(new ExceptionFilter());
            GlobalConfiguration.Configuration.Services.Replace(typeof(IExceptionHandler), new TraceExceptionHandler());
            IoCFactory.SetIoCProvider(new ActofactProvider());
            CarLocationMessageFactory.Instance.Initialize();
            InitializaMongoDb();
        }

        protected void InitializaMongoDb()
        {
            BsonClassMap.RegisterClassMap<EntityBase>(m =>
            {
                m.AutoMap();
                m.SetIdMember(m.GetMemberMap(c => c.Identifier));
            });

        }
    }
}
