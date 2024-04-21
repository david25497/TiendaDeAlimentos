namespace TiendaDeAlimentos.Core.Application.DTOs.SystemConfig.Config
{
    public class TokenConfigDTO
    {
        public string key { get; set; }
        public string durationInMinutes { get; set; }
        public string issuer { get; set; }
        public string audience { get; set; }

    }
}
