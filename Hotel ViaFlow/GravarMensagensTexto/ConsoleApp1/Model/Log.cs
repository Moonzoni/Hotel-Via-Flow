using GravarMensagensTexto.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace GravarMensagensTexto.Model
{
    public class Log
    {
        public int idLog { get; set; }
        public string nomeArquivo { get; set; }
        public TipoLog tipoLog { get; set; }
        public string mensagem { get; set; }
        public DateTime data { get; set; }

        public override string ToString()
        {
            return " idLog: " + idLog
                    + "\n nomeArquivo: " + nomeArquivo
                    + "\n TipoLog: " + tipoLog
                    + "\n mensagem: " + mensagem
                    + "\n Data: " + data.ToString();
        }
    }
}
