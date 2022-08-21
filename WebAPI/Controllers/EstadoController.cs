using Microsoft.AspNetCore.Mvc;
using WebAPI.Logica.Interfaz;

namespace WebAPI.Controllers
{
    /// <summary>        
    /// Controlador Estado      
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : Controller
    {
        private readonly IEstadoLN _estado;

        public EstadoController(IEstadoLN estado)
        {
            _estado = estado;
        }

        /// <summary>        
        /// Metodo Get para obtener todos los estados       
        /// </summary>
        [HttpGet]
        public JsonResult ObtenerEstados()
        {
            var objRespuesta = _estado.ObtenerEstados();
            return Json(objRespuesta);


        }
    }
}
