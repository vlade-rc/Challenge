namespace GBM.Infrastructure.UnitOfWork
{
    using Domain;
    using GBM.Infrastructure.Repository;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using Enums;
    using System.Transactions;
    using GBM.CarLocation.Repository;
    using MongoDB.Driver;

    /// <summary>Clase de la unidad de trabajo de Ado Sql</summary>
    public class CarLocationUnitOfWork : UnitOfWorkBase
    {
        public CarLocationUnitOfWork() : base()
        {
            this.Context = new MongoClient()
               .GetDatabase("CarLocationDB");
        }

        public override void DisposeContext()
        {
            this.Context = null;
            GC.Collect();
        }
    }
}