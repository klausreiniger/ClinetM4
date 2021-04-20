using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.ComponentesClinica;
using Persistencia.DAL.ComponentesClinica;

namespace Servico.ComponentesClinicas
{
    public class ClinicaServico
    {
        private ClinicaDAL clinicaDAL = new ClinicaDAL();
        public Clinica ObterClinicaPorID(long id)
        {
            return clinicaDAL.ObterClinicaPorID(id);
        }
        public void GravarClinica(Clinica clinica)
        {
            clinicaDAL.GravarClinica(clinica);
        }
        public IEnumerable<Clinica> DisplayClinicas() {
            return clinicaDAL.DisplayClinicas();
        }
        public IQueryable<Clinica> DisplayClinicasPorNome()
        {
            return clinicaDAL.DisplayClinicasPorNome();
        }
        public Clinica DeletarClinica(long id)
        {
            return clinicaDAL.DeletarClinica(id);
        }
    }
}
