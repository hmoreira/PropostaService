using Microsoft.AspNetCore.Mvc;
using PropostaService.Api.DTOs;
using PropostaService.Core.Application.DTOs;
using PropostaService.Core.Application.Interfaces;
using PropostaService.Core.Domain.Exceptions;

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
        private readonly IObtemStatusPropostaUseCase _obtemStatusProposta;
        public PropostaController(ICriarPropostaUseCase criarProposta, IListarPropostasUseCase propostasUseCase, 
                                  IAlterarStatusPropostaUseCase alterarStatusProposta,
                                  IObtemStatusPropostaUseCase obtemStatusProposta)
        {
            _criarProposta = criarProposta;             
            _propostasUseCase = propostasUseCase;   
            _alterarStatusProposta = alterarStatusProposta;
            _obtemStatusProposta = obtemStatusProposta;
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

        [HttpGet("{id}/status")]
        public async Task<IResult> GetStatusProposta(Guid id)
        {
            try
            {
                var ret = await _obtemStatusProposta.ExecuteAsync(id);
                if (ret == null)
                    throw new DomainException($"A proposta {id} não pode ser encontrada");
                else
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
                var criarProposta = new CriarPropostaDto
                {
                    ClienteId = propostaObj.ClienteId,
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
                await _alterarStatusProposta.ExecuteAsync(alterarStatusProposta.PropostaId, alterarStatusProposta.Status);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }
    }
}
