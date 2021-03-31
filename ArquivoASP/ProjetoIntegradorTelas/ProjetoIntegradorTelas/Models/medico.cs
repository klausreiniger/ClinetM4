using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoIntegradorTelas.Models
{
    public class medico
    {
        [Key]
        public int medicoID { get; set; }
        public int CRM { get; set; }
        public string nome { get; set; }
        public string especialidade { get; set; }
        public string telefone { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}