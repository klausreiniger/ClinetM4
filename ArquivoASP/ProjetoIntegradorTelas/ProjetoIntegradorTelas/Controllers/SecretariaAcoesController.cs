using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Modelo.Usuarios;
using Servico.Usuarios;
using Modelo.ComponentesClinica;
using Servico.ComponentesClinicas;

namespace ProjetoIntegradorTelas.Controllers
{
    public class SecretariaAcoesController : Controller
    {
        private MedicoServico medicoServico = new MedicoServico();
        private ClinicaServico clinicaServico = new ClinicaServico();
        private SecretariaServico secretariaServico = new SecretariaServico();
        // GET: SecretariaAcoes
        public ActionResult SecretariaCadastro() {
            ViewBag.ClinicaID = new SelectList(clinicaServico.DisplayClinicasPorNome(), "ClinicaID", "nome");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SecretariaCadastro(Secretaria secretaria) {
            if (ModelState.IsValid)
            {
                try
                {
                    secretariaServico.GravarSecretaria(secretaria);
                }
                catch
                {
                    return View(secretaria);
                }
            }
            else
            {
                return View(secretaria);
            }
            return RedirectToAction("Index", "Navegacao");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogSecretaria(Secretaria secretaria) {
            bool valid = secretariaServico.ValidarSecretaria(secretaria);
            if (valid)
            {
                Secretaria secretaria_ = secretariaServico.ObterSecretariaPorUsername(secretaria.username);
                return RedirectToAction("SecretariaPaginaInicial", "SecretariaAcoes", new { username = secretaria_.username });
            }
            else return RedirectToAction("SecretariaCadastro", "SecretariaAcoes");
        }
        public ActionResult ListarMedico(string username)
        {
            TempData["this_secretaria_nome"] = secretariaServico.ObterSecretariaPorUsername(username).nome;
            TempData["this_secretaria_username"] = username;
            return View(medicoServico.ObterMedicosOrdenadosPorNome());
        }
        public ActionResult CadastrarMedico(string username)
        {
            TempData["this_secretaria_nome"] = secretariaServico.ObterSecretariaPorUsername(username).nome;
            TempData["this_secretaria_username"] = username;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarMedico(Medico medico)
        {
            TempData.Keep();
            try
            {
                if (ModelState.IsValid)
                {
                    medicoServico.GravarMedico(medico);
                    return RedirectToAction("SecretariaPaginaInicial", "SecretariaAcoes", new { username = TempData["this_secretaria_username"]});
                }
                return View(medico);
            }
            catch
            {
                return View(medico);
            }
        }
        public ActionResult CRUDMedicoReduzido(string username, long? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Medico medico = medicoServico.ObterMedicoPorId((long)id);
            if (medico == null) return HttpNotFound();
            TempData["this_secretaria_nome"] = secretariaServico.ObterSecretariaPorUsername(username).nome;
            TempData["this_secretaria_username"] = username;
            return View(medico);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarMedico(string username, Medico medico)
        {
            TempData["this_secretaria_nome"] = secretariaServico.ObterSecretariaPorUsername(username).nome;
            TempData["this_secretaria_username"] = username;
            try
            {
                if (ModelState.IsValid)
                {
                    medicoServico.GravarMedico(medico);
                    return RedirectToAction("SecretariaPaginaInicial", "SecretariaAcoes", new { username = username});
                }
                return View(medico);
            }
            catch
            {
                return View(medico);
            }
        }
        public ActionResult EditMedico(string username,long? id) {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Medico medico = medicoServico.ObterMedicoPorId((long)id);
            if (medico == null) return HttpNotFound();
            TempData["this_secretaria_nome"] = secretariaServico.ObterSecretariaPorUsername(username).nome;
            TempData["this_secretaria_username"] = username;
            return View(medico);
        }
        public ActionResult ApagarMedico(string username,long? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Medico medico = medicoServico.ObterMedicoPorId((long)id);
            if (medico == null) return HttpNotFound();
            medicoServico.DeletarMedico((long)id);
            return RedirectToAction("SecretariaPaginaInicial", "SecretariaAcoes", new { username = username });
        }
        public ActionResult SecretariaPaginaInicial(string username)
        {
            Secretaria secretaria_ = secretariaServico.ObterSecretariaPorUsername(username);
            return View(secretaria_);
        }
        public ActionResult SecretariaDadosPessoais(string username) {
            Secretaria secretaria_ = secretariaServico.ObterSecretariaPorUsername(username);
            return View(secretaria_);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SecretariaDadosPessoais(Secretaria secretaria) {
            if (ModelState.IsValid)
            {
                try
                {
                    secretariaServico.GravarSecretaria(secretaria);
                    return RedirectToAction("SecretariaPaginaInicial", "SecretariaAcoes", new { username = secretaria.username });
                }
                catch
                {
                    return View(secretaria);
                }
            }
            else {
                return View(secretaria);
            }
        }
    }
}