using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.ComponentesClinica;
using Persistencia.DAL.ComponentesClinica;

namespace Servico.ComponentesClinicas
{
    public class HorarioDisponivelServico
    {
        private HorarioDisponivelDAL horariodisponivelDAL = new HorarioDisponivelDAL();
        public HorarioDisponivel ObterHorarioPorID(long id)
        {
            return horariodisponivelDAL.ObterHorarioPorID(id);
        }
        public IQueryable<HorarioDisponivel> ObterHorariosPorMedico(long id)
        {
            return horariodisponivelDAL.ObterHorariosPorMedico(id);
        }
        public IQueryable<HorarioDisponivel> ObterHorariosPorClinica(long id)
        {
            return horariodisponivelDAL.ObterHorariosPorClinica(id);
        }
        public void GravarHorarioDisponivel(HorarioDisponivel horariodisponivel)
        {
            horariodisponivelDAL.GravarHorarioDisponivel(horariodisponivel);
        }
        public HorarioDisponivel DeletarHorarioDisponivel(long id)
        {
            return horariodisponivelDAL.DeletarHorarioDisponivel(id);
        }
    }
}
