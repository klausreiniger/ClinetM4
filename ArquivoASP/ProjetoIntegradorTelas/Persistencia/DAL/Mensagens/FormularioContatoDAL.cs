using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Mensagens;
using System.Data.Entity;
using Persistencia.Contexts;
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

namespace Persistencia.DAL.Mensagens
{
    public class FormularioContatoDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<FormularioContato> ObterFormulariosPorDataEnvio() {
            return context.FormulariosContato.Include(f => f.DataEnvio).Include(f => f.Nome).Include(f => f.Mensagem).OrderBy(f => f.DataEnvio);
        }
        public void GravarFormularioContato(FormularioContato formularioContato) {
            context.FormulariosContato.Add(formularioContato);
            context.SaveChanges();
        }
        public long GeradorId()
        {
            if (!context.FormulariosContato.Any()) return 1;
            return (long)context.FormulariosContato.Max(f => f.FormularioContatoId) + 1;
        }
    }
}
