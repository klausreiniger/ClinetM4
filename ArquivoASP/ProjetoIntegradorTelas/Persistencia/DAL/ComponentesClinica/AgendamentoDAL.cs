using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.ComponentesClinica;
using System.Data.Entity;
using Persistencia.Contexts;

namespace Persistencia.DAL.ComponentesClinica
{
    public class AgendamentoDAL
    {
        private EFContext context = new EFContext();
        public IEnumerable<Agendamento> DisplayAgendamentos()
        {
            return context.Agendamentos.ToList();
        }
        public IQueryable<Agendamento> ObterAgendamentosEmClinica(long id) {
            return context.Agendamentos.Where(a => a.ClinicaID == id);
        }
        public IQueryable<Agendamento> ObterAgendamentosPorMedico(long id) {
            return context.Agendamentos.Where(a => a.MedicoID == id);
        }
        public IQueryable<Agendamento> ObterAgendamentosPorPaciente(long id) {
            return context.Agendamentos.Where(a => a.PacienteID == id);
        }
        public IEnumerable<Agendamento> DisplayAgendamentosPorHorarioConsulta()
        {
            return context.Agendamentos.OrderBy(c => c.horario_consulta);
        }
        public Agendamento ObterAgendamentoPorID(long id)
        {
            return context.Agendamentos.Where(c => c.AgendamentoID == id).First();
        }
        public void GravarAgendamento(Agendamento agendamento)
        {
            if (agendamento.AgendamentoID == null) context.Agendamentos.Add(agendamento);
            else context.Entry(agendamento).State = EntityState.Modified;
            context.SaveChanges();
        }
        public Agendamento DeletarAgendamento(long id)
        {
            Agendamento agendamento = ObterAgendamentoPorID(id);
            context.Agendamentos.Remove(agendamento);
            context.SaveChanges();
            return agendamento;
        }
    }
}
