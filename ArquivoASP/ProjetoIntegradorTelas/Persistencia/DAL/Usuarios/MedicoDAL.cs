using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Usuarios;
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
