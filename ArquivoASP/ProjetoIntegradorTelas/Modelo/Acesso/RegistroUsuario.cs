using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Modelo.Usuarios;

namespace Modelo.Acesso
{
    public class RegistroUsuario
    {
        [Key]
        [ForeignKey("Login")]
        public string User { get; set; }
        public string Nome { get; set; }
        public string Contato { get; set; }
        public Login Login { get; set; }
        public MedicoV2 MedicoV2 { get; set; }
        public PacienteV2 PacienteV2 { get; set; }
    }
}
