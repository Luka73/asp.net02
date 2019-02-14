using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Presentation.Models;
using Projeto.Entities;
using Projeto.Business;

namespace Projeto.Presentation.Controllers
{
    public class EstoqueController : Controller
    {
        // GET: Estoque
        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Consulta()
        {
            return View();
        }

        public ActionResult Edicao()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarEstoque(EstoqueCadastroViewModel model)
        {
            if(ModelState.IsValid)
            {
                Estoque estoque = new Estoque();
                estoque.Nome = model.Nome;

                try
                {
                    EstoqueBusiness business = new EstoqueBusiness();
                    business.Cadastrar(estoque);

                    ViewBag.Mensagem = "Estoque cadastrado com sucesso!";
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }

            return View("Cadastro");
        }
    }
}