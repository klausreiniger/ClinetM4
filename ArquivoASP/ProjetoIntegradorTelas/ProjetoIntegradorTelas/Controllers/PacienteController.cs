using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo.Usuarios;
using Servico.Usuarios;
using Servico.ComponentesClinicas;
using Modelo.ComponentesClinica;

namespace ProjetoIntegradorTelas.Controllers
{
    public class PacienteController : Controller
    {
        private PacienteServico pacienteServico = new PacienteServico();
        private ClinicaServico clinicaServico = new ClinicaServico();
        private AgendamentoServico agendamentoServico = new AgendamentoServico();
        private HorarioDisponivelServico horarioDisponivelServico = new HorarioDisponivelServico();
        private MedicoServico medicoServico = new MedicoServico();
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
            if (valid)
            {
                Paciente paciente_ = pacienteServico.ObterPacientePorUsername(paciente.username);
                return RedirectToAction("PacientePaginaInicial", "Paciente", new { username = paciente.username });
            }
            else return RedirectToAction("LoginCadastroPaciente", "Paciente");
        }
        public ActionResult PacientePaginaInicial(string username)
        {
            Paciente paciente = pacienteServico.ObterPacientePorUsername(username);
            return View(paciente);
        }

        public ActionResult PacienteDadosPessoais(string username)
        {
            Paciente paciente = pacienteServico.ObterPacientePorUsername(username);
            return View(paciente);
        }
        [HttpPost]
        public ActionResult PacienteDadosPessoais(Paciente paciente)
        {
            return RedirectToAction("PacienteEdit","Paciente", paciente.username);
        }
        public ActionResult PacienteEdit(string username)
        {
            Paciente paciente = pacienteServico.ObterPacientePorUsername(username);
            return View(paciente);
        }
        [HttpPost]
        public ActionResult PacienteEdit2(Paciente paciente) {
            pacienteServico.GravarPaciente(paciente);
            return RedirectToAction("PacientePaginaInicial", new { username = paciente.username });
        }

        public ActionResult PacienteMarcacao(string  username)
        {
            TempData["paciente_username"] = username;
            TempData.Keep();
            IEnumerable<Clinica> clinicas = clinicaServico.DisplayClinicasPorNome();
            return View(clinicas);
        }
        public ActionResult PacienteMarcacaoStep2(string username, long? clinicaID) {
            Agendamento agendamento = new Agendamento();
            Paciente paciente = pacienteServico.ObterPacientePorUsername(username);
            Clinica clinica = clinicaServico.ObterClinicaPorID((long)clinicaID);
            agendamento.PacienteID = paciente.UserID;
            agendamento.ClinicaID = clinica.ClinicaID;
            agendamento.confirmada = false;
            agendamento.finalizada = false;
            ViewBag.HorarioDisponivelID = new SelectList(horarioDisponivelServico.ObterHorariosPorClinica((long)clinicaID), "HorarioDisponivelID", "horario", agendamento.HorarioDisponivelID);
            TempData["paciente_username"] = username;
            return View(agendamento);
        }
        public ActionResult PacienteHistoricoConsultas(string username)
        {
            Paciente paciente = pacienteServico.ObterPacientePorUsername(username);
            return View(paciente);
        }
    }
}