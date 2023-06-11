namespace ViaCep_WebApi.Services.Http;
public interface IHttpService
{
    Task<string> GetAsync(string url);
}
