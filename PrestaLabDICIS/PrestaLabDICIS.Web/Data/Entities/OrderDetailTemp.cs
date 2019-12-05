using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestaLabDICIS.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class OrderDetailTemp : IEntity
    {
        public int Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Articulo Product { get; set; }


        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Quantity { get; set; }


    }

}
