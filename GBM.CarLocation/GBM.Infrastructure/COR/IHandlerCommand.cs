

namespace GBM.Infrastructure.COR
{
    using Domain;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Tipo de entrada</typeparam>
    /// <typeparam name="R">Tipo de Salida</typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public interface IHandlerCommand<in T, out R, TEntity> : IHandler
        where T : RequestCommandBaseDto<TEntity>
        where R : Task
        where TEntity : EntityBase
    {
        R Execute(T request);

        /// <summary>
        /// Se valida el Objeto, se inicializa la especificaión o se inicializan valores, si no se cumple la validación se setean los errores encontrados
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        bool Validate(T request);
    }
}
