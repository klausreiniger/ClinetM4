using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoIntegradorTelas.Models
{
    public class paciente
    {
        [Key]
        public int UserID { get; set; }
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