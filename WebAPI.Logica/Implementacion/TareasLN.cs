using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Interfaz;
using WebAPI.Logica.Interfaz;
using WebAPI.Model.Modelos;

namespace WebAPI.Logica.Implementacion
{
    /// <summary>        
    /// Logica para administrar las tareas      
    /// </summary>
    public class TareasLN : ITareasLN
    {
        private readonly ITareasAD _tareas;
        public TareasLN(ITareasAD tareas)
        {
            _tareas = tareas;
        }

        /// <summary>        
        /// Metodo para actualizar una tarea      
        /// </summary>
        public Respuesta<bool> ActualizarTarea(ModelTarea tarea)
        {
            Respuesta<bool> objRespuesta = new Respuesta<bool>();
            try
            {
                objRespuesta = _tareas.ActualizarTarea(tarea);
                objRespuesta.Exito();
            }
            catch (Exception ex)
            {
                objRespuesta.Error(ex);
            }
            return objRespuesta;
        }

        /// <summary>        
        /// Metodo para crear una tarea nueva       
        /// </summary>
        public Respuesta<bool> CrearTarea(ModelTarea tarea)
        {
            Respuesta<bool> objRespuesta = new Respuesta<bool>();
            try
            {
                objRespuesta = _tareas.CrearTarea(tarea);
                objRespuesta.Exito();
            }
            catch (Exception ex)
            {
                objRespuesta.Error(ex);
            }
            return objRespuesta;
        }
        /// <summary>        
        /// Metodo para eliminar una tarea        
        /// </summary>
        public Respuesta<bool> EliminarTarea(int id)
        {
            Respuesta<bool> objRespuesta = new Respuesta<bool>();
            try
            {
                objRespuesta = _tareas.EliminarTarea(id);
                objRespuesta.Exito();
            }
            catch (Exception ex)
            {
                objRespuesta.Error(ex);
            }
            return objRespuesta;
        }

        /// <summary>        
        /// Metodo que me permite filtrar las tareas      
        /// </summary>
        public Respuesta<IEnumerable<ModelTarea>> FiltroTareas(FiltroTareas filtros)
        {
            Respuesta<IEnumerable<ModelTarea>> objRespuesta = new Respuesta<IEnumerable<ModelTarea>>();
            try
            {
                objRespuesta = _tareas.FiltroTareas(filtros);
                objRespuesta.Exito();
            }
            catch (Exception ex)
            {
                objRespuesta.Error(ex);
            }
            return objRespuesta;
        }

        /// <summary>        
        /// Metodo para obtener una tarea en específico      
        /// </summary>
        public Respuesta<ModelTarea> ObtenerTareaDetalle(int id)
        {
            Respuesta<ModelTarea> objRespuesta = new Respuesta<ModelTarea>();
            try
            {
                objRespuesta = _tareas.ObtenerTareaDetalle(id);
                objRespuesta.Exito();
            }
            catch (Exception ex)
            {
                objRespuesta.Error(ex);
            }
            return objRespuesta;
        }

        /// <summary>        
        /// Metodo para obtener todas las tareas registradas en la base de datos       
        /// </summary>
        public Respuesta<IEnumerable<ModelTarea>> ObtenerTareas()
        {
            Respuesta<IEnumerable<ModelTarea>> objRespuesta = new Respuesta<IEnumerable<ModelTarea>>();
            try
            {
                objRespuesta = _tareas.ObtenerTareas();
                objRespuesta.Exito();
            }
            catch (Exception ex)
            {
                objRespuesta.Error(ex);
            }
            return objRespuesta;
        }
    }
}
