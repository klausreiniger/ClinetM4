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
        public long? AgendamentoID;
        [ForeignKey("Paciente")]
        public long? PacienteID;
        public Paciente paciente;
        [ForeignKey("Clinica")]
        public long? ClinicaID;
        public Clinica clinica;
        [ForeignKey("Medico")]
        public long? MedicoID;
        public Medico medico;
        [Required]
        public DateTime horario_consulta;
        public DateTime horario_agendamento;
        public bool confirmada;
        public bool finalizada;
    }
}
