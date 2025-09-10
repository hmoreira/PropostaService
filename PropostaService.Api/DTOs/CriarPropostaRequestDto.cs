namespace PropostaService.Api.DTOs
{
    public class CriarPropostaRequestDto
    {
        //[JsonPropertyName("clienteId")]
        public required string ClienteId { get; set; }
        //[JsonPropertyName("valor")]
        public decimal Valor { get; set; }
    }
}
