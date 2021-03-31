using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Acesso
{
    public class Login
    {
        [Key]
        public string User { get; set; }
        public string Senha { get; set; }
        public RegistroUsuario RegistroUsuario { get; set; }
    }
}
