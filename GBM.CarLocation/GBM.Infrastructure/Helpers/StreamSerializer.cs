namespace ERHANA.KRAKEN.Infrastructure.Helpers
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>Clase para serializar un objeto</summary>
    public static class StreamSerializer
    {
        /// <summary>Método para serializar un objeto en formato binario</summary>
        /// <param name="graph">Hace referencia al objeto a serializar</param>
        /// <returns>Hace referencia al objeto serializado</returns>
        public static byte[] Serialize(object graph)
        {
            byte[] serializedData = null;
            MemoryStream stream = new MemoryStream();

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, graph);
                serializedData = stream.ToArray();
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                }
            }

            return serializedData;
        }

        /// <summary>Método para deserializar un objeto del tipo byte[]</summary>
        /// <param name="serializedData">Hace referencia al objeto a deserializar</param>
        /// <returns>Hace referencia al objeto deserializado</returns>
        public static object Deserialize(byte[] serializedData)
        {
            object graph = null;
            if (serializedData == null)
            {
                return graph;
            }

            MemoryStream stream = new MemoryStream();

            try
            {
                for (int index = 0; index < serializedData.Length; index++)
                {
                    stream.WriteByte(serializedData[index]);
                }
                stream.Position = 0;
                BinaryFormatter formatter = new BinaryFormatter();
                graph = formatter.Deserialize(stream);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                }
            }

            return graph;
        }
    }
}
