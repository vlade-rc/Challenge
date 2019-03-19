
using System;

namespace GBM.Infrastructure.Specifications.Base
{
    /// <summary>Contrato para la especificación</summary>
    /// <typeparam name="TCandidate">Hace referencia al objeto que se evaluara</typeparam>
    public interface ISpecification<TCandidate>
    { 


        Func<TCandidate, bool> expression { get; set; }
        /// <summary>Método que evalua si un objeto cumple con la espeficiación, utilizado para evaluar condiciones de consulta</summary>
        /// <param name="candidate">Hace referencia al objeto que se evaluara</param>
        bool IsSatisfiedBy(TCandidate candidate);
        /// <summary>
        /// Bandera para marcar el candidato que no cumple con las condiciones establecidad
        /// </summary>
        bool HasError { get; set; }

        /// <summary>
        /// Permite Validar u Objeto con la especificación dada, utilizado para validar objetos
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        bool ValidateModel(TCandidate candidate);

    }
}
