using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.Repository;

namespace Projeto.Business
{
    public class EstoqueBusiness
    {
        public void Cadastrar(Estoque estoque)
        {
            EstoqueRepository repository = new EstoqueRepository();

            try
            {
                repository.AbrirConexao();
                repository.Inserir(estoque);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro: " + e.Message);
            }
            finally
            {
                repository.FecharConexao();
            }
        }
    }
}
