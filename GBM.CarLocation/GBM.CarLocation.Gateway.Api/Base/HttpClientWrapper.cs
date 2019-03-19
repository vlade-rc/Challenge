using ERMX.Infrastructure.Utils.Serializer;
using GBM.CarLocation.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GBM.CarLocation.Gateway.Api.Base
{
    /// <summary>
    /// La clase permite concentrar y gestionar los distintos métodos o verbos HTTP que se van a utlizar a través de <see cref="HttpClient"/> 
    /// para consumir los servicios de la Web Api de Edenred
    /// </summary>
    public class HttpClientWrapper<TRequest, TResponse> where TRequest : class where TResponse : class, new()
    {
        private static HttpClient client;

        public async Task<ResponseWithStatus<CarLocationResponseDto>> PostJsonAsync(Uri baseAddress, string methodAddress, TRequest request)
        {
            
            if (ReferenceEquals(client, null))
            {
                client = new HttpClient()
                {
                    BaseAddress = baseAddress
                };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            var serializedRequest = Serializers.JsonSerializer(request);
            
            var requestContent = new StringContent(serializedRequest, Encoding.Unicode, "application/json");

            var responseMessage = await client.PostAsync(methodAddress, requestContent).ConfigureAwait(false);

            var responseContent =await responseMessage.Content.ReadAsStringAsync();
            ResponseWithStatus<CarLocationResponseDto> result = new ResponseWithStatus<CarLocationResponseDto>();
            result.Response = Serializers.JsonDeserializer<CarLocationResponseDto>(responseContent);
            ResponseWithStatus<CarLocationResponseDto> returnValue = new ResponseWithStatus<CarLocationResponseDto> { Response = result.Response, StatusCode = responseMessage.StatusCode };
            return returnValue;
        }

        public async Task<ResponseWithStatus<CarLocationResponseDto>> PutJsonAsync(Uri baseAddress, string methodAddress, TRequest request)
        {

            if (ReferenceEquals(client, null))
            {
                client = new HttpClient()
                {
                    BaseAddress = baseAddress
                };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            var serializedRequest = Serializers.JsonSerializer(request);

            var requestContent = new StringContent(serializedRequest, Encoding.Unicode, "application/json");

            var responseMessage = await client.PutAsync(methodAddress, requestContent).ConfigureAwait(false);

            var responseContent = await responseMessage.Content.ReadAsStringAsync();
            ResponseWithStatus<CarLocationResponseDto> result = new ResponseWithStatus<CarLocationResponseDto>();
            result.Response = Serializers.JsonDeserializer<CarLocationResponseDto>(responseContent);
            ResponseWithStatus<CarLocationResponseDto> returnValue = new ResponseWithStatus<CarLocationResponseDto> { Response = result.Response, StatusCode = responseMessage.StatusCode };
            return returnValue;
        }



    }
}