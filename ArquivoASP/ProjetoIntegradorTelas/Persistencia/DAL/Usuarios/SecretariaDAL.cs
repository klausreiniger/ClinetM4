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
    public class SecretariaDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Secretaria> ObterSecretariaOrdenadasPorNome()
        {
            return context.Secretarias.OrderBy(s => s.nome);
        }
        public IQueryable<Secretaria> ObterSecretariasEmClinica(long id) {
            return context.Secretarias.Where(s => s.clinicaID == id);
        }
        public Secretaria ObterSecretariaPorId(long id)
        {
            return context.Secretarias.Where(s => s.secretariaID == id).First();
        }
        public Secretaria ObterSecretariaPorUsername(string username) {
            return context.Secretarias.Where(s => s.username == username).First();
        }
        public void GravarSecretaria(Secretaria secretaria)
        {
            if (secretaria.secretariaID == null)
            {
                context.Secretarias.Add(secretaria);
            }
            else
            {
                context.Entry(secretaria).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Secretaria DeletarSecretaria(long id)
        {
            Secretaria secretaria = ObterSecretariaPorId(id);
            context.Secretarias.Remove(secretaria);
            context.SaveChanges();
            return secretaria;
        }
        public bool ValidarSecretaria(Secretaria secretaria)
        {
            return context.Secretarias.Where(s => s.username == secretaria.username).Where(s => s.password == secretaria.password).Any();
        }
    }
}
