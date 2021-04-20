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
    public class ClinicaDAL
    {
        private EFContext context = new EFContext();
        public IEnumerable<Clinica> DisplayClinicas() {
            return context.Clinicas.ToList();
        }
        public IQueryable<Clinica> DisplayClinicasPorNome() {
            return context.Clinicas.OrderBy(c => c.nome);
        }
        public Clinica ObterClinicaPorID(long id)
        {
            return context.Clinicas.Where(c => c.ClinicaID == id).First();
        }
        public void GravarClinica(Clinica clinica)
        {
            if (clinica.ClinicaID == null) context.Clinicas.Add(clinica);
            else context.Entry(clinica).State = EntityState.Modified;
            context.SaveChanges();
        }
        public Clinica DeletarClinica(long id)
        {
            Clinica clinica = ObterClinicaPorID(id);
            context.Clinicas.Remove(clinica);
            context.SaveChanges();
            return clinica;
        }
    }
}
