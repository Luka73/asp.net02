using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using System.Data.SqlClient;

namespace Projeto.Repository
{
    public class EstoqueRepository : Conexao
    {
        public void Inserir(Estoque estoque)
        {
            string query = "insert into Estoque (Nome) values (@Nome)";

            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@Nome", estoque.Nome);
            Command.ExecuteNonQuery();
        }
    }
}
