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
    /// Clase AD Colaborador      
    /// </summary>
    public class ColaboradorAD : IColaboradorAD
    {
        private PostgreSQLConfiguracion _connectionString;

        public ColaboradorAD(PostgreSQLConfiguracion connectionString)
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        /// <summary>        
        /// Metodo para obtener todos los colaboradores registrados en la BD      
        /// </summary>
        public Respuesta<IEnumerable<ModelColaborador>> ObtenerColaboradores()
        {
            Respuesta<IEnumerable<ModelColaborador>> objRespuesta = new Respuesta<IEnumerable<ModelColaborador>>();

            try
            {
                var db = dbConnection();
                var sql = @"SELECT id, nombre 
                        FROM public.colaborador
                        ";


                objRespuesta.ValorRetorno = db.Query<ModelColaborador>(sql, new { });

               
            }
            catch (Exception)
            {
                throw;
            }
 
            return objRespuesta;

        }
    }
}
