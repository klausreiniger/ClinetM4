using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo.Usuarios;
using Servico.Usuarios;

namespace ProjetoIntegradorTelas.Controllers
{
    public class PacienteController : Controller
    {
        private PacienteServico pacienteServico = new PacienteServico();
        // GET: PacienteLoginCadastro
        public ActionResult LoginCadastroPaciente()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginCadastroPaciente(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    pacienteServico.GravarPaciente(paciente);
                }
                catch
                {
                    return View(paciente);
                }
            }
            else {
                return View(paciente);
            }
            return RedirectToAction("Index","Navegacao");
        }

        [HttpPost]
        public ActionResult LoginForm(Paciente paciente)
        {
            bool valid = pacienteServico.ValidarPaciente(paciente);
            if (valid) return RedirectToAction("PacientePaginaInicial", "Paciente");
            else return RedirectToAction("LoginCadastroPaciente","Paciente");
        }
        public ActionResult PacientePaginaInicial()
        {
            return View();
        }

        public ActionResult PacienteDadosPessoais()
        {
            return View();
        }

        public ActionResult PacienteMarcacao()
        {
            return View();
        }
        public ActionResult PacienteHistoricoConsultas()
        {
            return View();
        }
    }
}