namespace CRUD.Data
{
    public class ClientHttp
    {
        public HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5158/")
            };


            return httpClient;
        }
    }
}
