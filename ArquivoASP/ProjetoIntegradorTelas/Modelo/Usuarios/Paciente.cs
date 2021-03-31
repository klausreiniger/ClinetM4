using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Usuarios
{
    public class Paciente
    {
        [Key]
        public long? UserID { get; set; }
        public string nomecompleto { get; set; }
        public string telefone { get; set; }
        public string datanasc { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
