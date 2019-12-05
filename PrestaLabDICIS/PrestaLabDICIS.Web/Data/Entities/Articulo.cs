namespace PrestaLabDICIS.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Articulo : IEntity
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} only can contain a maximum {1} characters")]
        [Required]
        public string Nombre { get; set; }

        public string TipoArticulo { get; set; }

        public string InfoArticulo { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Disponible")]
        public bool Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)] 
        public double Stock { get; set; }

        public User User { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImageUrl))
                {
                    return null;
                }

                return $"https://prestalabdicis.azurewebsites.net{this.ImageUrl.Substring(1)}";
            }
        }

    }
}
