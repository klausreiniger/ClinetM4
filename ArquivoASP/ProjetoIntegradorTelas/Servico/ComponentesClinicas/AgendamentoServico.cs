using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Usuarios;
using Modelo.ComponentesClinica;
using Persistencia.DAL.ComponentesClinica;
namespace Servico.ComponentesClinicas
{
    public class AgendamentoServico
    {
        private AgendamentoDAL agendamentoDAL = new AgendamentoDAL();
        public IEnumerable<Agendamento> DisplayAgendamentos()
        {
            return agendamentoDAL.DisplayAgendamentos();
        }
        public IQueryable<Agendamento> ObterAgendamentosEmClinica(long id)
        {
            return agendamentoDAL.ObterAgendamentosEmClinica(id);
        }
        public IQueryable<Agendamento> ObterAgendamentosPorMedico(long id)
        {
            return agendamentoDAL.ObterAgendamentosPorMedico(id);
        }
        public IQueryable<Agendamento> ObterAgendamentosPorPaciente(long id)
        {
            return agendamentoDAL.ObterAgendamentosPorPaciente(id);
        }
        public Agendamento ObterAgendamentoPorID(long id)
        {
            return agendamentoDAL.ObterAgendamentoPorID(id);
        }
        public void GravarAgendamento(Agendamento agendamento)
        {
            agendamentoDAL.GravarAgendamento(agendamento);
        }
        public Agendamento DeletarAgendamento(long id)
        {
            return agendamentoDAL.DeletarAgendamento(id);
        }
    }
}
