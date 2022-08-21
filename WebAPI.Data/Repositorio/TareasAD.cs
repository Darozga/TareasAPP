using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Interfaz;
using WebAPI.Model.Modelos;

namespace WebAPI.Data.Repositorio
{
    /// <summary>        
    /// Clase AD Tareas     
    /// </summary>
    public class TareasAD : ITareasAD
    {
        private PostgreSQLConfiguracion _connectionString;
        public TareasAD(PostgreSQLConfiguracion connectionString)
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        /// <summary>        
        /// Metodo para obtener todas las tareas de la BD       
        /// </summary>
        public Respuesta<IEnumerable<ModelTarea>> ObtenerTareas()
        {
            Respuesta<IEnumerable<ModelTarea>> objRespuesta = new Respuesta<IEnumerable<ModelTarea>>();

            try
            {
                var db = dbConnection();
                var sql = @"SELECT t.id, t.descripcion, c.nombre as colaborador, t.colaborador_id, e.estado,  t.estado_id, 
                                   p.prioridad, t.prioridad_id, t.fecha_inicio, t.fecha_fin, t.notas
                                   FROM tareas t
                                   LEFT JOIN colaborador c
                                   ON t.colaborador_id = c.id
                                   INNER JOIN estado e
                                   ON t.estado_id = e.id
                                   INNER JOIN prioridad p
                                   ON t.prioridad_id = p.id
                                   ORDER BY t.fecha_inicio ASC;
                        ";


                objRespuesta.ValorRetorno = db.Query<ModelTarea>(sql, new { });


            }
            catch (Exception)
            {
                throw;
            }

            return objRespuesta;
        }

        /// <summary>        
        /// Metodo para filtrar las tareas        
        /// </summary>
        public Respuesta<IEnumerable<ModelTarea>> FiltroTareas(FiltroTareas filtros)
        {
            Respuesta<IEnumerable<ModelTarea>> objRespuesta = new Respuesta<IEnumerable<ModelTarea>>();

            try
            {
                var db = dbConnection();
                var sql = @"SELECT t.id, t.descripcion, c.nombre as colaborador, t.colaborador_id, e.estado,  t.estado_id, 
                                   p.prioridad, t.prioridad_id, t.fecha_inicio, t.fecha_fin, t.notas
                                   FROM tareas t
                                   LEFT JOIN colaborador c
                                   ON t.colaborador_id = c.id
                                   INNER JOIN estado e
                                   ON t.estado_id = e.id
                                   INNER JOIN prioridad p
                                   ON t.prioridad_id = p.id
                                   Where (@IdColaborador IS NULL OR t.colaborador_id = @IdColaborador) AND
                                         (@IdEstado IS NULL OR t.estado_id = @IdEstado) AND
                                         (@IdPrioridad IS NULL OR t.prioridad_id =@IdPrioridad) AND
                                         (t.fecha_inicio >= @FechaInicio and t.fecha_fin <= @FechaFin)
                                   ORDER BY t.fecha_inicio ASC;
                        ";


                objRespuesta.ValorRetorno = db.Query<ModelTarea>(sql, new {IdColaborador=filtros.Colaborador, IdEstado = filtros.Estado, 
                                                                            IdPrioridad = filtros.Prioridad, FechaInicio = filtros.FechaInicio, FechaFin = filtros.FechaFin});


            }
            catch (Exception)
            {
                throw;
            }

            return objRespuesta;
        }

        /// <summary>        
        /// Metodo para eliminar las tareas       
        /// </summary>
        public Respuesta<bool> EliminarTarea(int id)
        {
            Respuesta<bool> objRespuesta = new Respuesta<bool>();

            try
            {
                var db = dbConnection();
                var sql = @"DELETE FROM tareas WHERE id = @Id ";


                objRespuesta.ValorRetorno = db.Execute(sql, new {Id = id}) > 0;


            }
            catch (Exception)
            {
                throw;
            }

            return objRespuesta;
        }

        /// <summary>        
        /// Metodo para actualizar las tareas      
        /// </summary>
        public Respuesta<bool> ActualizarTarea(ModelTarea tarea)
        {
            Respuesta<bool> objRespuesta = new Respuesta<bool>();

            try
            {
                var db = dbConnection();
                var sql = @"UPDATE public.tareas
	                        SET descripcion=@Descripcion, 
                                colaborador_id=@Colaborador_Id, 
                                estado_id=@Estado_Id, 
                                prioridad_id=@Prioridad_Id, 
                                fecha_inicio=@Fecha_Inicio, 
                                fecha_fin=@Fecha_Fin, 
                                notas=@Notas
	                        WHERE id = @Id;
                        ";


                var result = db.Execute(sql, new { tarea.Descripcion, tarea.Colaborador_Id, tarea.Estado_Id, tarea.Prioridad_Id, tarea.Fecha_Inicio, tarea.Fecha_Fin, tarea.Notas, tarea.Id });

                objRespuesta.ValorRetorno = result > 0;

            }
            catch (Exception)
            {
                throw;
            }

            return objRespuesta;
        }

        /// <summary>        
        /// Metodo para crear una nueva tarea en la BD      
        /// </summary>
        public Respuesta<bool> CrearTarea(ModelTarea tarea)
        {
            Respuesta<bool> objRespuesta = new Respuesta<bool>();

            try
            {
                var db = dbConnection();
                var sql = @"INSERT INTO public.tareas(descripcion, colaborador_id, estado_id, prioridad_id, fecha_inicio, fecha_fin, notas)
	                        VALUES (@Descripcion, @Colaborador_Id, @Estado_Id, @Prioridad_Id, @Fecha_Inicio, @Fecha_Fin, @Notas);
                        ";


                var result = db.Execute(sql, new { tarea.Descripcion, tarea.Colaborador_Id, tarea.Estado_Id, tarea.Prioridad_Id, tarea.Fecha_Inicio, tarea.Fecha_Fin, tarea.Notas});

                objRespuesta.ValorRetorno = result > 0;
                
            }
            catch (Exception)
            {
                throw;
            }

            return objRespuesta;
        }

        /// <summary>        
        /// Metodo para obtener el detalle de una tarea en especifico      
        /// </summary>
        public Respuesta<ModelTarea> ObtenerTareaDetalle(int id)
        {
            Respuesta<ModelTarea> objRespuesta = new Respuesta<ModelTarea>();

            try
            {
                var db = dbConnection();
                var sql = @"SELECT t.id, t.descripcion, c.nombre as colaborador, t.colaborador_id, e.estado,  t.estado_id, 
                                   p.prioridad, t.prioridad_id, t.fecha_inicio, t.fecha_fin, t.notas
                                   FROM tareas t
                                   LEFT JOIN colaborador c
                                   ON t.colaborador_id = c.id
                                   INNER JOIN estado e
                                   ON t.estado_id = e.id
                                   INNER JOIN prioridad p
                                   ON t.prioridad_id = p.id
                                   WHERE t.id = @Id
                                   ORDER BY t.fecha_inicio ASC;";


                objRespuesta.ValorRetorno = db.QueryFirstOrDefault<ModelTarea>(sql, new { Id = id });


            }
            catch (Exception)
            {
                throw;
            }

            return objRespuesta;
        }
    }
}
