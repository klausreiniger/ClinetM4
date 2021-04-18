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
    public class Clinica
    {
        [Key]
        public long? clinicaID { get; set; }
        public string nome { get; set; }
        public string inicio_expediente { get; set; }
        public string fim_expediente { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string contato_clinica { get; set; }
        public string endereco { get; set; }
        public virtual ICollection<HorarioDisponivel> HorariosDisponiveis { get; set; }
        public virtual ICollection<Secretaria> Secretarias { get; set; }
    }
}
