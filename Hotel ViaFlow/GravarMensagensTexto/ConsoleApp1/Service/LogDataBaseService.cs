using GravarMensagensTexto.Interface;
using GravarMensagensTexto.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GravarMensagensTexto.Service
{
    public class LogDataBaseService : ILogService
    {
        public Log buscarLog(string nomeArquivo)
        {
            return new Log()
            {
                nomeArquivo = nomeArquivo,
                data = DateTime.Now,
                idLog = new Random().Next(),
                mensagem = "DataBase Mensagem",
                tipoLog = Enum.TipoLog.Erro
            };
        }

        public Log buscarLog(int idLog)
        {
            return new Log()
            {
                nomeArquivo = "logServico.txt",
                data = DateTime.Now,
                idLog = idLog,
                mensagem = "Database Mensagem",
                tipoLog = Enum.TipoLog.Fatal
            };
        }

        public void gravarLog(Log logObject)
        {
        }
    }
}
