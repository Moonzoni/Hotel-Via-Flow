using GravarMensagensTexto.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GravarMensagensTexto.Interface
{
    interface ILogService
    {
        void gravarLog(Log logObject);
        Log buscarLog(string nomeArquivo);
        Log buscarLog(int idLog);
    }
}
