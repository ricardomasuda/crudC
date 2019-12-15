using CrudFuncionario.Dados;
using CrudFuncionario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudFuncionario.Controllers
{
    public class FuncionarioController : Controller
    {
        private FuncionarioRepositorio _repositorio;
        // GET: Funcionario
        public ActionResult ObterFuncionarios()
        {
            _repositorio = new FuncionarioRepositorio();
            ModelState.Clear();
            return View(_repositorio.ObterFuncionarios());
        }

        public ActionResult IncluirFuncionario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirFuncionario(Funcionario funcionario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new FuncionarioRepositorio();

                    if (_repositorio.AdicionarFuncionario(funcionario))
                    {
                        ViewBag.Mensagem = "Funcionario Cadastrado com Sucesso!";
                    }
                }
                return RedirectToAction("ObterFuncionarios");
            }
            catch (Exception e)
            {
                return View();

            }

        }

        public ActionResult EditarFuncionario(int id)
        {
            _repositorio = new FuncionarioRepositorio();

            return View(_repositorio.ObterFuncionarios().Find(l => l.FuncionarioId == id));
        }

        [HttpPost]
        public ActionResult EditarFuncionario(int id, Funcionario funcionario)
        {

            try
            {
                _repositorio = new FuncionarioRepositorio();

                _repositorio.AtualizarFuncionario(funcionario);

            }catch(Exception er)
            {

            }
            return RedirectToAction("ObterFuncionarios");


        }

        public ActionResult ExcluirFuncionario(int id)
        {

            try
            {

                _repositorio = new FuncionarioRepositorio();

                _repositorio.ExcluiFuncionario(id);

            }
            catch (Exception e)
            {

            }
            return RedirectToAction("ObterFuncionarios");

        }

        public ActionResult VisualizarDependentes(int id)
        {
            return RedirectToAction("ObterDependentes", "Dependente", new { idFuncionario = id });
        }


    }
}