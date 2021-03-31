using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Modelo.Acesso;

namespace Modelo.Usuarios
{
    public class MedicoV2
    {
        [Key]
        public long? medicoID { get; set; }
        public int CRM { get; set; }
        public string especialidade { get; set; }

        [ForeignKey("RegistroUsuario")]
        public string User { get; set; }
        public RegistroUsuario RegistroUsuario { get; set; }
    }
}
