using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Servico.Mensagens;
using Modelo.Mensagens;
using System.Threading;
using System.Globalization;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Diagnostics.Contracts;

namespace ProjetoIntegradorTelas.Controllers
{
    public class NavegacaoController : Controller
    {
        private FormularioContatoServico formularioContatoServico = new FormularioContatoServico();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contato()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contato(FormularioContato formularioContato) {
            formularioContato.DataEnvio = DateTime.Now;
            formularioContato.FormularioContatoId = formularioContatoServico.GeradorId();
            if (ModelState.IsValid)
            {
                try
                {
                    formularioContatoServico.GravarFormularioContato(formularioContato);
                    return RedirectToAction("Index", "Navegacao");
                }
                catch
                {
                    return View(formularioContato);
                }
            }
            return View(formularioContato);
        }
        public ActionResult Clinicas()
        {
            return View();
        }

        public ActionResult MedicoPaginaInicial()
        {
            return View();
        }

        public ActionResult MedicoDadosPessoais()
        {
            return View();
        }

        public ActionResult MedicoClinicas()
        {
            return View();
        }

        public ActionResult MedicoHorarios()
        {
            return View();
        }

        public ActionResult MedicoContato()
        {
            return View();
        }
    }
}