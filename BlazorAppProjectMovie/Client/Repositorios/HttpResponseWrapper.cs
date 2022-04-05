using System.Net.Http;

namespace BlazorAppProjectMovie.Client.Repositorios
{
    public class HttpResponseWrapper<T>
    {

        public HttpResponseWrapper(T response, bool error, HttpResponseMessage httpResponseMessage)
        {
            this.Error = error;
            this.Response = response;
            this.HttpRequestMessage = httpRequestMessage;
        }

        public bool Error { get; set; }

        public T Response { get; set; }

        public HttpRequestMessage HttpRequestMessage { get; set; }

    }
}
