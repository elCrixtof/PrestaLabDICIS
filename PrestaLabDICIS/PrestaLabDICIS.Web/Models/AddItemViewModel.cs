using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestaLabDICIS.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddItemViewModel
    {
        [Display(Name = "Articulo")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a article.")]
        public int ProductId { get; set; }

        [Range(0.0001, double.MaxValue, ErrorMessage = "The quantiy must be a positive number")]
        public double Quantity { get; set; }

        public IEnumerable<SelectListItem> Products { get; set; }
    }

}
