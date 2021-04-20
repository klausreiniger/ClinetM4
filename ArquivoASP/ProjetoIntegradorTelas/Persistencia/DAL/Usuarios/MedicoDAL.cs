using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Usuarios;
using Modelo.ComponentesClinica;
using System.Data.Entity;
using Persistencia.Contexts;

namespace Persistencia.DAL.Usuarios
{
    public class MedicoDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Medico> ObterMedicosOrdenadosPorNome() {
            return context.Medicos.OrderBy(m => m.nome);
        }
        public IQueryable<Medico> ObterMedicosDisponiveisEmClinica(long id) { 
            IQueryable<HorarioDisponivel> poshs = context.HorariosDisponiveis.Where(h => h.ClinicaID == id).Include(h => h.MedicoID).OrderBy(h => h.horario);
            IQueryable<Medico> medids = (from item in poshs select ObterMedicoPorId((long)item.MedicoID)).Distinct();
            return medids;
        }
        public Medico ObterMedicoPorId(long id) {
            return context.Medicos.Where(m => m.medicoID == id).First();
        }
        public void GravarMedico(Medico medico) {
            if (medico.medicoID == null)
            {
                context.Medicos.Add(medico);
            }
            else {
                context.Entry(medico).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Medico DeletarMedico(long id) {
            Medico medico = ObterMedicoPorId(id);
            context.Medicos.Remove(medico);
            context.SaveChanges();
            return medico;
        }
    }
}
