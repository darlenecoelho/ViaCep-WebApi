using Newtonsoft.Json;
using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using ViaCep_WebApi.Models;
using ViaCep_WebApi.Services.Http;

namespace ViaCep_WebApi.Services.ViaCep;

public class ViaCepService : IViaCepService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpService _httpService;
    private readonly AsyncRetryPolicy<string> _retryPolicy;
    private readonly AsyncCircuitBreakerPolicy<string> _circuitBreakerPolicy;

    public ViaCepService(IConfiguration configuration, IHttpService httpService)
    {
        _configuration = configuration;
        _httpService = httpService;

        // Configure the retry policy with exponential backoff
        _retryPolicy = Policy<string>
            .Handle<HttpRequestException>()
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        // Configure the circuit breaker policy
        _circuitBreakerPolicy = Policy<string>
            .Handle<HttpRequestException>()
            .AdvancedCircuitBreakerAsync(
                failureThreshold: 0.5, // 50% of requests failing
                samplingDuration: TimeSpan.FromSeconds(30), // Duration for calculating the failure rate
                minimumThroughput: 10, // Minimum number of requests in the sampling duration
                durationOfBreak: TimeSpan.FromSeconds(60) // Duration of the circuit breaker open state
            );
    }

    public async Task<Endereco> GetCep(string cepCode)
    {
        var viaCepUrl = BuildViaCepUrl(cepCode);
        var viaCepResponse = await ExecuteWithRetryAndBreaker(() => _httpService.GetAsync(viaCepUrl));
        return DeserializeEndereco(viaCepResponse);
    }

    private string BuildViaCepUrl(string cepCode)
    {
        return $"{_configuration["ViaCepApi:BaseUrl"]}{cepCode}/json";
    }

    private async Task<string> ExecuteWithRetryAndBreaker(Func<Task<string>> action)
    {
        return await _retryPolicy.WrapAsync(_circuitBreakerPolicy).ExecuteAsync(action);
    }

    private Endereco DeserializeEndereco(string json)
    {
        return JsonConvert.DeserializeObject<Endereco>(json);
    }
}
