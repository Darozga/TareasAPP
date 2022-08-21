using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.Repositorio;
using WebAPI.Logica.Interfaz;

namespace WebAPI.Controllers
{
    /// <summary>        
    /// Controlador colaborador       
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorLN _colaborador;

        public ColaboradorController(IColaboradorLN colaborador)
        {
            _colaborador = colaborador;
        }

        /// <summary>        
        /// Metodo Get para obtener todos los colaboradores      
        /// </summary>
        [HttpGet]
        public JsonResult ObtenerColaboradores()
        {
            var objRespuesta = _colaborador.ObtenerColaboradores();
            return Json(objRespuesta);
            
           
        }
    }
}
