using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Presentation.Models;
using Projeto.Entities;
using Projeto.Business;
using AutoMapper;

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
            List<EstoqueConsultaViewModel> model = new List<EstoqueConsultaViewModel>();

            try
            {
                EstoqueBusiness business = new EstoqueBusiness();
                model = Mapper.Map<List<EstoqueConsultaViewModel>>(business.ObterTodos());
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }

            return View(model);
        }

        public ActionResult Edicao(int id)
        {
            EstoqueEdicaoViewModel model = new EstoqueEdicaoViewModel();

            try
            {
                EstoqueBusiness business = new EstoqueBusiness();
                Estoque estoque = business.ObterPorId(id);

                model = Mapper.Map<EstoqueEdicaoViewModel>(estoque);
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = "Ocorreu um erro: " + e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult CadastrarEstoque(EstoqueCadastroViewModel model)
        {
            if(ModelState.IsValid)
            {
                Estoque estoque = Mapper.Map<Estoque>(model);

                try
                {
                    EstoqueBusiness business = new EstoqueBusiness();
                    business.Cadastrar(estoque);

                    ViewBag.Mensagem = "Estoque cadastrado com sucesso!";
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }

            return View("Cadastro");
        }

        [HttpPost]
        public ActionResult AtualizarEstoque(EstoqueEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Estoque estoque = Mapper.Map<Estoque>(model);

                    EstoqueBusiness business = new EstoqueBusiness();
                    business.Atualizar(estoque);

                    ViewBag.Mensagem = "Estoque atualizando com sucesso!";
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = "Ocorreu um erro: " + e.Message;
                }
            }
            return View("Edicao");
        }
    }
}