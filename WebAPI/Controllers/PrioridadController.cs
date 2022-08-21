using Microsoft.AspNetCore.Mvc;
using WebAPI.Logica.Interfaz;

namespace WebAPI.Controllers
{
    /// <summary>        
    /// Controlador Prioridad       
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PrioridadController : Controller
    {
        private readonly IPrioridadLN _prioridad;

        public PrioridadController(IPrioridadLN prioridad)
        {
            _prioridad = prioridad;
        }

        /// <summary>        
        /// Metodo Get para obtener todas las Prioridades      
        /// </summary>
        [HttpGet]
        public JsonResult ObtenerPrioridades()
        {
            var objRespuesta = _prioridad.ObtenerPrioridades();
            return Json(objRespuesta);


        }

    }
}
