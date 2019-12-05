namespace PrestaLabDICIS.Common.Models
{
    using Newtonsoft.Json;
    public class Product
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("tipoArticulo")]
        public object TipoArticulo { get; set; }

        [JsonProperty("infoArticulo")]
        public string InfoArticulo { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("stock")]
        public long Stock { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("imageFullPath")]
        public object ImageFullPath { get; set; }
    }
}
