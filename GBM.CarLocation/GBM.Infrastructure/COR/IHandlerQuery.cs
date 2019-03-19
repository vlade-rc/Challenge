
namespace GBM.Infrastructure.COR
{
    using Domain;
    using Filter;


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Tipo de entrada</typeparam>
    /// <typeparam name="R">Tipo de salida</typeparam>
    public interface IHandlerQuery<in T, out R, S, F> : IHandler
        where T : RequestQueryBaseDto<F>
        where S : EntityBase
        where F : IFilter

    {
        /// <summary>
        /// Ejecuta la consulta
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        R Execute(T request);

        /// <summary>
        /// Se valida el Objeto, se inicializa la especificaión o se inicializan valores, si no se cumple la validación se setean los errores encontrados
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        bool Validate(T request);

    }
}
