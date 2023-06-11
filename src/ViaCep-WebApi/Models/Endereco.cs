using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace ViaCep_WebApi.Models;

public class Endereco
{
    [JsonProperty("cep")]
    public string? Cep { get; set; }

    [JsonProperty("logradouro")]
    public string? Logradouro { get; set; }

    [JsonProperty("complemento")]
    public string? Complemento { get; set; }

    [JsonProperty("bairro")]
    public string? Bairro { get; set; }

    [JsonProperty("localidade")]
    public string? Localidade { get; set; }

    [JsonProperty("uf")]
    public string? Uf { get; set; }

    [JsonProperty("ibge")]
    public string? Ibge { get; set; }

    [JsonProperty("gia")]
    public string? Gia { get; set; }

    [JsonProperty("ddd")]
    public string? Ddd { get; set; }

    [JsonProperty("siafi")]
    public string? Siafi { get; set; }

    public static string ObterSomenteNumero(string numCep)
    {
        string numerosCep = Regex.Replace(numCep, "[^0-9]", "");

        return numerosCep.Length == 8 ? numerosCep : null;
    }
}
