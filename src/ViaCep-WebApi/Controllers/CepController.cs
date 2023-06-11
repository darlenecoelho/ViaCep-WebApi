using Microsoft.AspNetCore.Mvc;
using ViaCep_WebApi.Models;
using ViaCep_WebApi.Services.ViaCep;

namespace ViaCep_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViaCepController : ControllerBase
    {
        private readonly IViaCepService _viaCepService;

        public ViaCepController(IViaCepService viaCepService)
        {
            _viaCepService = viaCepService;
        }

        /// <summary>
        /// Recupera as informações de endereço para o CEP especificado.
        /// </summary>
        /// <param name="cepCode">The CEP code.</param>
        /// <returns>Informações de endereço.</returns>
        [HttpGet("{cepCode}")]
        public async Task<ActionResult<Endereco>> GetCep(string cepCode)
        {
            var endereco = await _viaCepService.GetCep(cepCode);

            if (endereco == null)
                return NotFound();

            return endereco;
        }
    }
}
