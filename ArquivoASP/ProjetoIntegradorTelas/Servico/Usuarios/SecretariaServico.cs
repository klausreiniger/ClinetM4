using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL.Usuarios;
using Modelo.Usuarios;

namespace Servico.Usuarios
{
    public class SecretariaServico
    {
        private SecretariaDAL secretariaDAL = new SecretariaDAL();
        public IEnumerable<Secretaria> ObterSecretariaOrdenadasPorNome()
        {
            return secretariaDAL.ObterSecretariaOrdenadasPorNome();
        }
        public IEnumerable<Secretaria> ObterSecretariasEmClinica(long id)
        {
            return secretariaDAL.ObterSecretariasEmClinica(id);
        }
        public Secretaria ObterSecretariaPorId(long id)
        {
            return secretariaDAL.ObterSecretariaPorId(id);
        }
        public Secretaria ObterSecretariaPorUsername(string username) {
            return secretariaDAL.ObterSecretariaPorUsername(username);
        }
        public void GravarSecretaria(Secretaria secretaria)
        {
            secretariaDAL.GravarSecretaria(secretaria);
        }
        public Secretaria DeletarSecretaria(long id)
        {
            return secretariaDAL.DeletarSecretaria(id);
        }
        public bool ValidarSecretaria(Secretaria secretaria) {
            return secretariaDAL.ValidarSecretaria(secretaria);
        }
    }
}
