using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Modelo.Usuarios;


namespace Modelo.ComponentesClinica
{
    public class Agendamento
    {
        [Key]
        public long? AgendamentoID { get; set; }
        [ForeignKey("Paciente")]
        public long? PacienteID { get; set; }
        public Paciente Paciente { get; set; }
        [ForeignKey("Clinica")]
        public long? ClinicaID { get; set; }
        public Clinica Clinica { get; set; }
        [ForeignKey("Medico")]
        public long? MedicoID { get; set; }
        public Medico Medico { get; set; }
        [ForeignKey("HorarioDisponivel")]
        public long? HorarioDisponivelID { get; set; }
        public HorarioDisponivel HorarioDisponivel { get; set; }
        public bool confirmada { get; set; }
        public bool finalizada { get; set; }
    }
}
