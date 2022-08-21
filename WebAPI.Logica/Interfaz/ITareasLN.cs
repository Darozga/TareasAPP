using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Model.Modelos;

namespace WebAPI.Logica.Interfaz
{
    public interface ITareasLN
    {
        Respuesta<IEnumerable<ModelTarea>> ObtenerTareas();

        Respuesta<bool> EliminarTarea(int id);

        Respuesta<bool> ActualizarTarea(ModelTarea tarea);

        Respuesta<bool> CrearTarea(ModelTarea tarea);

        Respuesta<ModelTarea> ObtenerTareaDetalle(int id);

        Respuesta<IEnumerable<ModelTarea>> FiltroTareas(FiltroTareas filtros);



    }
}
