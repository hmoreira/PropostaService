using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PropostaService.Api.DTOs;
using PropostaService.Core.Application.DTOs;
using PropostaService.Core.Application.Interfaces;
using PropostaService.Core.Domain.Entities;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropostaService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropostaController : ControllerBase
    {
        private readonly ICriarPropostaUseCase _criarProposta;
        private readonly IMapper _mapper;
        private readonly IListarPropostasUseCase _propostasUseCase;
        private readonly IAlterarStatusPropostaUseCase _alterarStatusProposta;
        public PropostaController(ICriarPropostaUseCase criarProposta, IListarPropostasUseCase propostasUseCase, 
                                  IAlterarStatusPropostaUseCase alterarStatusProposta, IMapper mapper)
        {
            _criarProposta = criarProposta; 
            _mapper = mapper;
            _propostasUseCase = propostasUseCase;   
            _alterarStatusProposta = alterarStatusProposta;
        }

        [HttpGet]
        public async Task<IResult> GetAll()
        {
            try
            {
                await _propostasUseCase.ExecuteAsync();
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }
        
        
        [HttpPost]
        public async Task<IResult> Post([FromBody] CriarPropostaRequestDto proposta)
        {
            try
            {
                await _criarProposta.ExecuteAsync(_mapper.Map<CriarPropostaDto>(proposta));
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
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
                return Results.BadRequest(ex);
            }
        }
    }
}
