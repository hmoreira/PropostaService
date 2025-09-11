using Microsoft.AspNetCore.Mvc;
using PropostaService.Api.DTOs;
using PropostaService.Core.Application.DTOs;
using PropostaService.Core.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropostaService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropostaController : ControllerBase
    {
        private readonly ICriarPropostaUseCase _criarProposta;        
        private readonly IListarPropostasUseCase _propostasUseCase;
        private readonly IAlterarStatusPropostaUseCase _alterarStatusProposta;
        private readonly IObtemPropostaUseCase _obtemProposta;
        public PropostaController(ICriarPropostaUseCase criarProposta, IListarPropostasUseCase propostasUseCase, 
                                  IAlterarStatusPropostaUseCase alterarStatusProposta,
                                  IObtemPropostaUseCase obtemProposta)
        {
            _criarProposta = criarProposta;             
            _propostasUseCase = propostasUseCase;   
            _alterarStatusProposta = alterarStatusProposta;
            _obtemProposta = obtemProposta;
        }

        [HttpGet]
        public async Task<IResult> GetAll()
        {
            try
            {                
                return Results.Ok(await _propostasUseCase.ExecuteAsync());
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }

        [HttpGet("{propostaId}")]
        public async Task<IResult> ObterProposta(string propostaId)
        {
            try
            {
                Guid propostaIdG;
                if (!Guid.TryParse(propostaId, out propostaIdG))
                    return Results.BadRequest("Id da proposta inválido.");

                var ret = await _obtemProposta.ExecuteAsync(propostaIdG);
                return Results.Ok(ret);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] CriarPropostaRequestDto propostaObj)
        {
            try
            {
                Guid clienteIdG;
                if (!Guid.TryParse(propostaObj.ClienteId, out clienteIdG))
                    return Results.BadRequest("Id do cliente inválido.");

                var criarProposta = new CriarPropostaDto
                {
                    ClienteId = clienteIdG,
                    Valor = propostaObj.Valor
                };
                await _criarProposta.ExecuteAsync(criarProposta);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }
        
        [HttpPut("alterarStatus")]
        public async Task<IResult> Put([FromBody] AlterarStatusPropostaRequestDto alterarStatusProposta)
        {            
            try
            {
                Guid propostaIdG;
                if (!Guid.TryParse(alterarStatusProposta.PropostaId, out propostaIdG))
                    return Results.BadRequest("Id da proposta inválido.");
                
                await _alterarStatusProposta.ExecuteAsync(propostaIdG, alterarStatusProposta.Status);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }
    }
}
