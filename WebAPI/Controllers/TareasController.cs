using Microsoft.AspNetCore.Mvc;
using WebAPI.Logica.Interfaz;
using WebAPI.Model.Modelos;

namespace WebAPI.Controllers
{
    /// <summary>        
    /// Controlador Tareas       
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : Controller
    {
        private readonly ITareasLN _tareas;

        public TareasController(ITareasLN tareas)
        {
            _tareas = tareas;
        }

        /// <summary>        
        /// Metodo get para devolver todas las tareas registradas en la BD      
        /// </summary>
        [HttpGet]
        public JsonResult ObtenerTareas()
        {
            var objRespuesta = _tareas.ObtenerTareas();
            return Json(objRespuesta);

        }

        /// <summary>        
        /// Metodo Post para filtrar las tareas       
        /// </summary>
        [HttpPost]
        [Route("filtro")]
        public JsonResult filtroTareas([FromBody] FiltroTareas filtros)
        {
            var objRespuesta = _tareas.FiltroTareas(filtros);
            return Json(objRespuesta);

        }

        /// <summary>        
        /// Metodo Get para obtener el detalle de una tarea       
        /// </summary>
        [HttpGet("{id}")]
        public JsonResult ObtenerTareadetalle(int id)
        {
            var objRespuesta = _tareas.ObtenerTareaDetalle(id);
            return Json(objRespuesta);

        }

        /// <summary>        
        /// Metodo Post para crear una nueva tarea       
        /// </summary>
        [HttpPost]
        public JsonResult CrearTarea([FromBody] ModelTarea tarea)
        {
            var objRespuesta = _tareas.CrearTarea(tarea);
            return Json(objRespuesta);

        }

        /// <summary>        
        /// Metodo Put para actualizar una tarea       
        /// </summary>
        [HttpPut]
        public JsonResult ActualizarTarea([FromBody] ModelTarea tarea)
        {
            var objRespuesta = _tareas.ActualizarTarea(tarea);
            return Json(objRespuesta);

        }

        /// <summary>        
        /// Metodo delete para eliminar una tarea      
        /// </summary>
        [HttpDelete("{id}")]
        public JsonResult EliminarTarea(int id)
        {
            var objRespuesta = _tareas.EliminarTarea(id);
            return Json(objRespuesta);

        }


    }
}
