namespace PrestaLabDICIS.Web.Models
{

    using System.ComponentModel.DataAnnotations;
    using Data.Entities;
    using Microsoft.AspNetCore.Http;

    public class ArticuloViewModel : Articulo
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
