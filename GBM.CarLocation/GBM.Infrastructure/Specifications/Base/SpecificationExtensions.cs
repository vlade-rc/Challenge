
using GBM.Infrastructure.COR;
using System.Collections.Generic;

namespace GBM.Infrastructure.Specifications.Base
{
    /// <summary>Clase de extención para clase especificación</summary>
    public static class SpecificationExtensions
    {
        /// <summary>Método une dos especificaciones con un operador del tipo and</summary>
        /// <typeparam name="T">Hace referencia al tipo de objeto</typeparam>
        /// <param name="left">Hace referencia a la primer especificación a unir</param>
        /// <param name="right">Hace referencia a la segunda especificiación  a unir</param>
        public static Specification<T> And<T>(this Specification<T> left, Specification<T> right)
        {
            if (left != null && right != null)
            {
                List<Specification<T>> spec = new List<Specification<T>>();
                foreach (var item in left.SpecificationList)
                {
                    spec.Add(item);
                }
                spec.Add(right);
                return new Specification<T>(target => left.IsSatisfiedBy(target) && right.IsSatisfiedBy(target)) { SpecificationList = spec };
            }
            return null;
        }
        /// <summary>Método une dos especificaciones con un operador del tipo Or</summary>
        /// <typeparam name="T">Hace referencia al tipo de entidad</typeparam>
        /// <param name="left">Hace referencia a la primer especificación</param>
        /// <param name="right">Hace referencia a la segunda especificación</param>
        public static Specification<T> Or<T>(this Specification<T> left, Specification<T> right)
        {
            if (left != null && right != null)
            {
                List<Specification<T>> spec = new List<Specification<T>>();
                foreach (var item in left.SpecificationList)
                {
                    spec.Add(item);
                }
                spec.Add(right);

                return new Specification<T>(target => left.IsSatisfiedBy(target) || right.IsSatisfiedBy(target)) { SpecificationList = spec }; 
            }
            return null;
        }
        /// <summary>Método que agrega una especificación con un operador de negación</summary>
        /// <typeparam name="T">Hace referencia al tipo de entidad</typeparam>
        /// <param name="left">Hace referencia a la especificación</param>
        public static Specification<T> Not<T>(this Specification<T> left)
        {
            if (left != null)
            {
                List<Specification<T>> spec = new List<Specification<T>>();
                foreach (var item in left.SpecificationList)
                {
                    spec.Add(item);
                }

                return new Specification<T>(target => !left.IsSatisfiedBy(target)) { SpecificationList = spec }; ;
            }
            return null;
        }

        public static Specification<T> WithMessage<T>(this ISpecification<T> spc, ValidationMessage message)
        {
            if (spc != null)
            {
                return new Specification<T>(target => spc.IsSatisfiedBy(target)) { Message = message };
            }
            return null;
        }

        public static List<ValidationMessage> GetErrrors<T>(this Specification<T> spc)
        {
            var a = spc.SpecificationList.FindAll(x => x.HasError);
            List<ValidationMessage> errors = new List<ValidationMessage>();
            foreach (var item in a)
            {
                errors.Add(item.Message);
            }
            return errors;
        
        }
    }
}
