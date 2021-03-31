using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Modelo.Usuarios;
using Servico.Usuarios;

namespace ProjetoIntegradorTelas.Controllers
{
    public class SecretariaAcoesController : Controller
    {
        private MedicoServico medicoServico = new MedicoServico();
        // GET: SecretariaAcoes
        public ActionResult GravarMedico(Medico medico) {
            try
            {
                if (ModelState.IsValid)
                {
                    medicoServico.GravarMedico(medico);
                    return RedirectToAction("SecretariaPaginaInicial", "SecretariaAcoes");
                }
                return View(medico);
            }
            catch {
                return View(medico);
            }
        }
        public ActionResult ListarMedico()
        {
            return View(medicoServico.ObterMedicosOrdenadosPorNome());
        }
        public ActionResult CadastrarMedico()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarMedico(Medico medico)
        {
            return GravarMedico(medico);
        }
        public ActionResult CRUDMedicoReduzido(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Medico medico = medicoServico.ObterMedicoPorId((long)id);
            if (medico == null) return HttpNotFound();
            return View(medico);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarMedico(Medico medico)
        {
            return GravarMedico(medico);
        }
        public ActionResult EditMedico(long? id) {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Medico medico = medicoServico.ObterMedicoPorId((long)id);
            if (medico == null) return HttpNotFound();
            return View(medico);
        }
        public ActionResult ApagarMedico(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Medico medico = medicoServico.ObterMedicoPorId((long)id);
            if (medico == null) return HttpNotFound();
            medicoServico.DeletarMedico((long)id);
            return RedirectToAction("SecretariaPaginaInicial", "SecretariaAcoes");
        }
        public ActionResult SecretariaPaginaInicial()
        {
            return View();
        }
    }
}