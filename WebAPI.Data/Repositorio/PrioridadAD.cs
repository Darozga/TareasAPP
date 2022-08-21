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
    /// Clase AD de Prioridad       
    /// </summary>
    public class PrioridadAD : IPrioridadAD
    {
        private PostgreSQLConfiguracion _connectionString;

        public PrioridadAD(PostgreSQLConfiguracion connectionString)
        {
            _connectionString = connectionString;

        }
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        /// <summary>        
        /// Metodo para obtener todas las prioridades registradas en la BD     
        /// </summary>
        public Respuesta<IEnumerable<ModelPrioridad>> ObtenerPrioridades()
        {
            Respuesta<IEnumerable<ModelPrioridad>> objRespuesta = new Respuesta<IEnumerable<ModelPrioridad>>();

            try
            {
                var db = dbConnection();
                var sql = @"SELECT id, prioridad 
                        FROM public.prioridad
                        ";


                objRespuesta.ValorRetorno = db.Query<ModelPrioridad>(sql, new { });


            }
            catch (Exception)
            {
                throw;
            }

            return objRespuesta;
        }
    }
}
