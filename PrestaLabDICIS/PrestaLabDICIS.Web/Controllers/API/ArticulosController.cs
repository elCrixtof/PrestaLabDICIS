namespace PrestaLabDICIS.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using PrestaLabDICIS.Web.Data;

    [Route("api/[Controller]")]
    public class ArticulosController : Controller
    {
        private readonly IArticuloRepository articuloRepository;

        public ArticulosController(IArticuloRepository articuloRepository)
        {
            this.articuloRepository = articuloRepository;
        }

        [HttpGet]
        public IActionResult GetArticulos()
        {
            return Ok(this.articuloRepository.GetAllWithUsers());
        }
    }
}
