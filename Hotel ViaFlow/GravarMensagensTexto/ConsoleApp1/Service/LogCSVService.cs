using GravarMensagensTexto.Interface;
using GravarMensagensTexto.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GravarMensagensTexto.Service
{
    public class LogCSVService : ILogService
    {
        public Log buscarLog(string nomeArquivo)
        {
            return new Log()
            {
                nomeArquivo = nomeArquivo,
                data = DateTime.Now,
                idLog = new Random().Next(),
                mensagem = "Mensagem",
                tipoLog = Enum.TipoLog.Informacao
            };
        }

        public Log buscarLog(int idLog)
        {
            return new Log()
            {
                nomeArquivo = "logServico.txt",
                data = DateTime.Now,
                idLog = idLog,
                mensagem = "Mensagem",
                tipoLog = Enum.TipoLog.Alerta
            };
        }

        public void gravarLog(Log logObject)
        {
        }
    }
}
