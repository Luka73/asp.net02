using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Projeto.Repository
{
    public class Conexao
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader DataReader { get; set; }

        public void AbrirConexao()
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["aula02"].ConnectionString);
            Connection.Open();
        }

        public void FecharConexao()
        {
            if(Connection != null)
            {
                Connection.Close();
            }
        }
    }
}
