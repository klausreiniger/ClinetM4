using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Usuarios;
using Persistencia.DAL.Usuarios;

namespace Servico.Usuarios
{
    public class MedicoServico
    {
        private MedicoDAL medicoDAL = new MedicoDAL();
        public IQueryable<Medico> ObterMedicosOrdenadosPorNome()
        {
            return medicoDAL.ObterMedicosOrdenadosPorNome();
        }
        public Medico ObterMedicoPorId(long id)
        {
            return medicoDAL.ObterMedicoPorId(id);
        }
        public void GravarMedico(Medico medico)
        {
            medicoDAL.GravarMedico(medico);
        }
        public Medico DeletarMedico(long id)
        {
            return medicoDAL.DeletarMedico(id);
        }
    }
}
