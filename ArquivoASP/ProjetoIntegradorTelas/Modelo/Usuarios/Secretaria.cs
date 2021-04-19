using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Modelo.ComponentesClinica;

namespace Modelo.Usuarios
{
    public class Secretaria
    {
        [Key]
        public long? secretariaID { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }
        public string provclinica { get; set; }
        public string rg { get; set; }
        public string telefone { get; set; }
        public DateTime datanasc { get; set; }
        [ForeignKey("Clinica")]
        public long? ClinicaID { get; set; }
        public Clinica Clinica { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
