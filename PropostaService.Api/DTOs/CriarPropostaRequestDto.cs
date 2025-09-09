namespace PropostaService.Api.DTOs
{
    public class CriarPropostaRequestDto
    {
        //[JsonPropertyName("clienteId")]
        public Guid ClienteId { get; set; }
        //[JsonPropertyName("valor")]
        public decimal Valor { get; set; }
    }
}
