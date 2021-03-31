using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Globalization;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Diagnostics.Contracts;

namespace Modelo.Mensagens
{
    public class FormularioContato
    {
        [Key]
        public long? FormularioContatoId { get; set; }
        [Required(AllowEmptyStrings = false,ErrorMessage = "Insira seu nome.")]
        public string Nome { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Insira seu e-mail.")]
        public string Email { get; set; }
        [Required]
        public DateTime DataEnvio { get; set; }
        public string Telefone { get; set; }
        [MaxLength(256)]
        public string Mensagem { get; set; }

    }
}
