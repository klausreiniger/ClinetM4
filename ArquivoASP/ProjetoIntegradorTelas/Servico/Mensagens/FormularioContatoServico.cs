using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL.Mensagens;
using Modelo.Mensagens;
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

namespace Servico.Mensagens
{
    public class FormularioContatoServico
    {
        private FormularioContatoDAL formularioContatoDAL = new FormularioContatoDAL();
        public IQueryable<FormularioContato> ObterFormulariosPorDataEnvio()
        {
            return formularioContatoDAL.ObterFormulariosPorDataEnvio();
        }
        public void GravarFormularioContato(FormularioContato formularioContato)
        {
            formularioContatoDAL.GravarFormularioContato(formularioContato);
        }
        public long GeradorId()
        {
            return formularioContatoDAL.GeradorId();
        }
    }
}
