using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Usuarios;
using Persistencia.DAL.Usuarios;

namespace Servico.Usuarios
{
    public class PacienteServico
    {
        private PacienteDAL pacienteDAL = new PacienteDAL();
        public IQueryable<Paciente> ObterPacientesPorId()
        {
            return pacienteDAL.ObterPacientesPorId();
        }
        public Paciente ObterPacientePorUsername(string username)
        {
            return pacienteDAL.ObterPacientePorUsername(username);
        }
        public Paciente SelecionarPacientePorId(long id)
        {
            return pacienteDAL.SelecionarPacientePorId(id);
        }
        public void GravarPaciente(Paciente paciente)
        {
            pacienteDAL.GravarPaciente(paciente);
        }

        public Paciente DeletarPaciente(long id)
        {
            return pacienteDAL.DeletarPaciente(id);
        }
        public bool ValidarPaciente(Paciente paciente) {
            return pacienteDAL.ValidarPaciente(paciente);
        }
    }
}
