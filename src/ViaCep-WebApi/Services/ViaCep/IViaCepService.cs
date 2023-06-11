using ViaCep_WebApi.Models;

namespace ViaCep_WebApi.Services.ViaCep;

public interface IViaCepService
{
    Task<Endereco> GetCep(string cepCode);
}
