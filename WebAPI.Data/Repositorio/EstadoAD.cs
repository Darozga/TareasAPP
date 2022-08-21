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
    /// Clase AD Estado       
    /// </summary>
    public class EstadoAD : IEstadoAD
    {
        private PostgreSQLConfiguracion _connectionString;


        public EstadoAD(PostgreSQLConfiguracion connectionString)
        {
            _connectionString = connectionString;
        }
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        /// <summary>        
        /// Metodo para obtener todos los estados registrados en la BD   
        /// </summary>
        public Respuesta<IEnumerable<ModelEstado>> ObtenerEstados()
        {
            Respuesta<IEnumerable<ModelEstado>> objRespuesta = new Respuesta<IEnumerable<ModelEstado>>();

            try
            {
                var db = dbConnection();
                var sql = @"SELECT id, estado 
                        FROM public.estado
                        ";


                objRespuesta.ValorRetorno = db.Query<ModelEstado>(sql, new { });


            }
            catch (Exception)
            {
                throw;
            }

            return objRespuesta;
        }
    }
}
