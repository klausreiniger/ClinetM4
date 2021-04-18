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
    public class HorarioDisponivelDAL
    {
        private EFContext context = new EFContext();
        public HorarioDisponivel ObterHorarioPorID(long id) {
            return context.HorariosDisponiveis.Where(h => h.HorarioDisponivelID == id).First();
        }
        public IQueryable<HorarioDisponivel> ObterHorariosPorMedico(long id) {
            return context.HorariosDisponiveis.Where(h => h.medicoID == id).Include(h => h.clinicaID);
        }
        public IQueryable<HorarioDisponivel> ObterHorariosPorClinica(long id) {
            return context.HorariosDisponiveis.Where(h => h.clinicaID == id).Include(h => h.medicoID);
        }
        public void GravarHorarioDisponivel(HorarioDisponivel horariodisponivel) {
            if (horariodisponivel.HorarioDisponivelID == null) context.HorariosDisponiveis.Add(horariodisponivel);
            else context.Entry(horariodisponivel).State = EntityState.Modified;
            context.SaveChanges();
        }
        public HorarioDisponivel DeletarHorarioDisponivel(long id) {
            HorarioDisponivel horario = ObterHorarioPorID(id);
            context.HorariosDisponiveis.Remove(horario);
            context.SaveChanges();
            return horario;
        }
    }
}
