namespace GBM.Infrastructure.Specifications.Base
{
    /// <summary>Contrato para la especificación</summary>
    public interface ISpecification
    {
        /// <summary>Método que evalua si un objeto cumple con la espeficiación</summary>
        /// <param name="candidate">Hace referencia al objeto que se evaluara</param>
        bool IsSatisfiedBy(object candidate);
    }
}
