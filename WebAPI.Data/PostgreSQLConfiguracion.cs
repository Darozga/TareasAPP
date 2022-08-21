using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Data
{
    public class PostgreSQLConfiguracion
    {
      
        public PostgreSQLConfiguracion(string connectionString) => ConnectionString = connectionString;

        public string ConnectionString { get; set; }
    }
}
