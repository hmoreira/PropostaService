using PropostaService.Core.Domain.Enums;

namespace PropostaService.Api.DTOs
{
    public class AlterarStatusPropostaRequestDto
    {
        public required string PropostaId { get; set; }
        public StatusPropostaEnum Status { get; set; }
    }
}
