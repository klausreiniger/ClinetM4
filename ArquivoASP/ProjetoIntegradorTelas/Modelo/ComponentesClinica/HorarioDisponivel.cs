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
    public class HorarioDisponivel
    {
        [Key]
        public long? HorarioDisponivelID { get; set; }
        [ForeignKey("Medico")]
        public long? medicoID { get; set; }
        public Medico Medico { get; set; }
        [Required]
        public DateTime horario { get; set; }
        [ForeignKey("Clinica")]
        public long? ClinicaID { get; set; }
        public Clinica Clinica { get; set; }
        public Agendamento Agendamento { get; set; }
    }
}
