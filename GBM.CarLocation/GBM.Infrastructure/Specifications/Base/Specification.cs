namespace GBM.Infrastructure.Specifications.Base
{
    using COR;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Clase para la Especificación</summary>
    /// <typeparam name="TCandidate">Hace referencia al tipo de objeto que se va a evaluar</typeparam>
    public class Specification<TCandidate> : ISpecification<TCandidate>
    {
        /// <summary>Hace referencia a la expresión a evaluar</summary>
        public Func<TCandidate, bool> expression { get; set; }

        /// <summary>
        /// Bandera para marcar el candidato que no cumple con las condiciones establecidad
        /// </summary>
        public bool HasError { get; set; }

        /// <summary>
        /// Mensaje de validación
        /// </summary>
        public ValidationMessage Message { get; set; }


        private List<Specification<TCandidate>> specificationList;
          
        /// <summary>
        /// Permite obtener la lista de especificaciones compuestas
        /// </summary>
        public List<Specification<TCandidate>> SpecificationList {
            get
            {
                if (specificationList == null)
                    specificationList = new List<Specification<TCandidate>>() { this};
                return specificationList;
            }
            set
            {
                specificationList = value;
            }
        }

  

        /// <summary>Inicializa un objeto del tipo especificación</summary>
        /// <param name="expression">Hace referencia al objeto que se evaluara</param>
        public Specification(Func<TCandidate, bool > expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this.expression = expression;
            }
        }

        #region ISpecification<T> Members


        /// <summary>Método que evalua si un objeto cumple con la especificación</summary>
        /// <param name="candidate">Hace referencia al objeto a evaluar</param>
        public virtual bool IsSatisfiedBy(TCandidate candidate)
        {
         return this.expression(candidate);
           
        }


        /// <summary>Método que evalua si un objeto cumple con la especificación, si no hay errores el modelo es válido</summary>
        /// <param name="candidate">Hace referencia al objeto a evaluar</param>
        public virtual bool ValidateModel(TCandidate candidate)
        {
            
            bool ok = false;
            foreach (var item in this.SpecificationList)
            {
                if (item.Message == null)
                {
                    throw new Exception("La expresión no tiene definido un mensaje para esta validación");
                }
                item.HasError = !item.expression(candidate);
               
            }
            return !this.specificationList.Any(x => x.HasError);
        }

        #endregion
    }    
}
