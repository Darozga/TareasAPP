using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Model.Modelos;

namespace WebAPI.Data.Interfaz
{
    public interface ITareasAD
    {
        Respuesta<IEnumerable<ModelTarea>> ObtenerTareas();

        Respuesta<bool> EliminarTarea(int id);

        Respuesta<ModelTarea> ObtenerTareaDetalle(int id);

        Respuesta<bool> ActualizarTarea(ModelTarea tarea);

        Respuesta<bool> CrearTarea(ModelTarea tarea);

        Respuesta<IEnumerable<ModelTarea>> FiltroTareas(FiltroTareas filtros);


    }
}
