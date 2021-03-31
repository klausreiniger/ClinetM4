using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Usuarios
{
    public class Medico
    {
        [Key]
        public long? medicoID { get; set; }
        public int CRM { get; set; }
        public string nome { get; set; }
        public string especialidade { get; set; }
        public string telefone { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
