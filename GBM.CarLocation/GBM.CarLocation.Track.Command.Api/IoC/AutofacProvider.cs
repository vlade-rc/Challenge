using Autofac;
using Autofac.Integration.WebApi;
using GBM.CarLocation.Domain.Command;
using GBM.CarLocation.Domain.DTO;
using GBM.CarLocation.Domain.Repository;
using GBM.CarLocation.Repository;
using GBM.CarLocation.Repository.ObjectValues;
using GBM.Infrastructure.IoC;
using GBM.Infrastructure.Logger.Base;
using GBM.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace GBM.CarLocation.Track.Command.Api.IoC
{
    public class ActofactProvider : IoCProvider
    {

        ContainerBuilder builder;
        IContainer container;
        public override void Initialize()
        {
            builder = new ContainerBuilder();
            HttpConfiguration config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            configureIoC(builder);
            container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }


        /// <summary>
        /// Configura las dependencias
        /// </summary>
        /// <param name="builder">Contenedor</param>
        private static void configureIoC(ContainerBuilder builder)
        {
            builder.RegisterType<CarLocationUnitOfWork>().As<IUnitOfWorkDbConnection>();
            builder.RegisterType<CarLocationRepository>().As<ICarLocationRepository>();
            builder.RegisterType<CarLocationEventRepository>().As<ICarLocationEventRepository>();

            builder.RegisterType<UpsertCarLocationHandlerCommand>().Named<ICarLocationHandlerCommand>(CommandOperation.UpdateLocation.ToString());

            builder.RegisterType<EventLogFake>().As<ILogger<TraceLog<object>>>();
        }


        /// <summary>
        /// Resuelve el servicio asociado al contrato
        /// </summary>
        /// <typeparam name="TDefinition">Interfaz a resolver</typeparam>
        /// <returns></returns>
        public override TDefinition Resolve<TDefinition>()
        {
            return container.Resolve<TDefinition>();
        }
      
        /// <summary>
        /// Resuelve el servico asociado por nombre
        /// </summary>
        /// <typeparam name="TDefinition"></typeparam>
        /// <param name="Name"></param>
        /// <returns></returns>
        public override TDefinition ResolveByName<TDefinition>(string Name)
        {
            return container.ResolveNamed<TDefinition>(Name);


        }

      
        public override void Dispose()
        {

            container.Dispose();
        }
    }
}