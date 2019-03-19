namespace GBM.Infrastructure.UnitOfWork
{
    using System.Data;

    /// <summary>Contrato para la unidad de trabajo con conexión a base de datos</summary>
    public interface IUnitOfWorkDbConnection : IUnitOfWork<object>
    {
       
    }
}
