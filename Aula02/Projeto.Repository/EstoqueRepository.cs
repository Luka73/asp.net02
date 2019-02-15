using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using System.Data.SqlClient;
using System.Data;

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

        public void Atualizar(Estoque estoque)
        {
            string query = "update Estoque set Nome = @Nome where IdEstoque = @IdEstoque";

            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@Nome", estoque.Nome);
            Command.Parameters.AddWithValue("@IdEstoque", estoque.IdEstoque);
            Command.ExecuteNonQuery();
        }

        public void Excluir(int idEstoque)
        {
            string query = "delete from Estoque where IdEstoque = @IdEstoque";

            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@IdEstoque", idEstoque);
            Command.ExecuteNonQuery();
        }

        public List<Estoque> ObterTodos()
        {
            string query = "select * from Estoque";

            SqlDataAdapter sqlAdp = new SqlDataAdapter(query, Connection);
            DataSet dataSet = new DataSet();
            sqlAdp.Fill(dataSet);

            var list = dataSet.Tables[0].AsEnumerable().Select(r => new Estoque()
            {
                IdEstoque = (int)r["IdEstoque"],
                Nome = (string)r["Nome"]
            }
            ).Where( w => w.IdEstoque > 1 ).ToList();

            return list;

            /*
             Command = new SqlCommand(query, Connection);
             DataReader = Command.ExecuteReader();

             List<Estoque> lista = new List<Estoque>();

             while (DataReader.Read())
             {
                Estoque estoque = new Estoque();
                estoque.IdEstoque = Convert.ToInt32(DataReader["IdEstoque"]);
                estoque.Nome = Convert.ToString(DataReader["Nome"]);

                lista.Add(estoque);
             }

            return lista;

            */
        }

        public Estoque ObterPorId(int idEstoque)
        {
            string query = "select * from Estoque where IdEstoque = @IdEstoque";

            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@IdEstoque", idEstoque);
            DataReader = Command.ExecuteReader();

            Estoque estoque = null;

            if(DataReader.Read())
            {
                estoque = new Estoque();

                estoque.IdEstoque = Convert.ToInt32(DataReader["IdEstoque"]);
                estoque.Nome = Convert.ToString(DataReader["Nome"]);
            }

            return estoque;
        }
    }
}
