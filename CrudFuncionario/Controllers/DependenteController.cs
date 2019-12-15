using CrudFuncionario.Dados;
using CrudFuncionario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CrudFuncionario.Controllers
{
    public class DependenteController : Controller
    {
      

        private DependenteRepositorio _repositorio;
        // GET: Funcionario
        public ActionResult ObterDependentes()
        {

            if (Request.QueryString["idFuncionario"] == null)
            {
                return RedirectToAction("ObterFuncionarios", "Funcionario");
            }

            int idFuncionario = Convert.ToInt32(Request.QueryString["idFuncionario"]);
            _repositorio = new DependenteRepositorio();
            var _repositorioF = new FuncionarioRepositorio();


            ViewBag.NomeFuncionario = _repositorioF.ObterFuncionarios().Find(l => l.FuncionarioId == idFuncionario).Nome;
            

            ModelState.Clear();
            return View(_repositorio.ObterDependentes(idFuncionario));
        }

        public ActionResult IncluirDependente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirDependente(Dependente dependente)
        {
            if (Request.QueryString["idFuncionario"] == null)
            {
                return RedirectToAction("ObterFuncionarios", "Funcionario");
            }

            try
            {
                if (ModelState.IsValid)
                {

                    dependente.FuncionarioId = Convert.ToInt32(Request.QueryString["idFuncionario"]);
                    _repositorio = new DependenteRepositorio();

                    if (_repositorio.AdicionarDependente(dependente))
                    {
                        ViewBag.Mensagem = "Dependentes Cadastrado com Sucesso!";
                    }
                }
                return RedirectToAction("ObterDependentes", new { idFuncionario = Request.QueryString["idFuncionario"] });
            }
            catch (Exception e)
            {
                return View();

            }

        }

        public ActionResult EditarDependente(int id)
        {
            

            _repositorio = new DependenteRepositorio();

            return View(_repositorio.ObterDependentes(Convert.ToInt32(Request.QueryString["idFuncionario"])).Find(l => l.DependenteId == id));
        }

        [HttpPost]
        public ActionResult EditarDependente(int id, Dependente dependente)
        {

            try
            {
                dependente.FuncionarioId = Convert.ToInt32(Request.QueryString["idFuncionario"]);
                _repositorio = new DependenteRepositorio();

                _repositorio.AtualizarDependente(dependente);

                return RedirectToAction("ObterDependentes", new { idFuncionario = Request.QueryString["idFuncionario"] });
            }
            catch (Exception er)
            {
                return View("ObterDependenteos");
            }
            
        }

        public ActionResult ExcluirDependente(int id)
        {

            try
            {

                _repositorio = new DependenteRepositorio();

                _repositorio.ExcluiDependente(id);
                

                    return RedirectToAction("ObterDependentes", new { idFuncionario = Request.QueryString["idFuncionario"] });
                
            }
            catch (Exception e)
            {
                return View("ObterDependentes");

            }
        }


    }
}