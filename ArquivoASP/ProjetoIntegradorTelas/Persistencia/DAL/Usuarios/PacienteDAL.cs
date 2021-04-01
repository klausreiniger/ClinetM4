using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Contexts;
using Modelo.Usuarios;
using System.Data.Entity;

namespace Persistencia.DAL.Usuarios
{
    public class PacienteDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Paciente> ObterPacientesPorId() {
            return context.Pacientes.OrderBy(p => p.UserID);
        }
        public Paciente ObterPacientePorUsername(string username) {
            return context.Pacientes.Where(p => p.username == username).First();
        }
        public Paciente SelecionarPacientePorId(long id)
        {
            return context.Pacientes.Include(p => p.UserID).Include(p => p.password).Include(p => p.username).Where(p => p.UserID == id).First();
        }
        public void GravarPaciente(Paciente paciente) {
            if (paciente.UserID == null)
            {
                context.Pacientes.Add(paciente);
            }
            else
            {
                context.Entry(paciente).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Paciente DeletarPaciente(long id) {
            Paciente paciente = SelecionarPacientePorId(id);
            context.Pacientes.Remove(paciente);
            context.SaveChanges();
            return paciente;
        }

        public bool ValidarPaciente(Paciente paciente) {
            return context.Pacientes.Where(p => p.username == paciente.username).Where(p => p.password == paciente.password).Any();
        }
    }
}
