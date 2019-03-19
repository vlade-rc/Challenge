using Newtonsoft.Json;
using System;

namespace ERMX.Infrastructure.Utils.Serializer
{
   
    public static class Serializers
    {
        /// <summary> Método para serializar un objeto a JSON </summary>
        /// <typeparam name="T">Hace referencia al tipo de objeto a serializar</typeparam>
        /// <param name="instance">Hace referencia al objeto a serializar</param>
        /// <returns>Regresa un string con el objeto serializado</returns>
        public static string JsonSerializer<T>(T instance)
        {
            try
            {
                return JsonConvert.SerializeObject(instance);
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public static T JsonDeserializer<T>(String instance) where T: new()
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(instance);
            }
            catch (Exception e)
            {
                return new T { };
            }
        }
    }
}
