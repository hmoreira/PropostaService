namespace PropostaService.Api.DTOs
{
    public class CriarPropostaRequestDto
    {
        public Guid ClienteId { get; private set; } 
        public decimal Valor { get; private set; }
    }
}
