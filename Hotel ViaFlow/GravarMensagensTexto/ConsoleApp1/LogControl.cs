using GravarMensagensTexto.Enum;
using GravarMensagensTexto.Interface;
using GravarMensagensTexto.Model;
using GravarMensagensTexto.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace GravarMensagensTexto
{
    public class LogControl
    {
        public void startSession()
        {
            bool endExecution = false;

            do
            {
                int op;
                MenuConsole.showMessage("Bem Vindo");
                MenuConsole.showMessage("1 - Gravar um novo log");
                MenuConsole.showMessage("2 - Buscar Log por ID");
                MenuConsole.showMessage("3 - Buscar Log por Nome do Arquivo");
                MenuConsole.showMessage("0 - Sair");

                try
                {
                    op = MenuConsole.getInt("Digite a operação desejada");

                    switch (op)
                    {
                        case 1:
                            gravarNovoLog();
                            break;
                        case 2:
                            buscarLogID();
                            break;
                        case 3:
                            buscarLogNomeArquivo();
                            break;
                        case 0:
                            endExecution = true;
                            MenuConsole.showMessage("Até Logo!");
                            break;
                        default:
                            MenuConsole.showMessage("opção inválida");
                            break;
                    }
                }
                catch (Exception e)
                {
                    MenuConsole.showMessage("Tente novamente");
                }

            } while (endExecution == false);
        }

        private int getTipoLog()
        {
            MenuConsole.showMessage("0 - Informação");
            MenuConsole.showMessage("1 - Alerta");
            MenuConsole.showMessage("2 - Erro");
            MenuConsole.showMessage("3 - Fatal");
            return MenuConsole.getInt("Digite o Tipo do Log");
        }

        private void gravarNovoLog()
        {
            int op = 1;
            do
            {
                MenuConsole.showMessage("Geração de Logs");
                MenuConsole.showMessage("1 - Gravar no CSV");
                MenuConsole.showMessage("2 - Gravar no Banco de Dados");
                MenuConsole.showMessage("0 - Voltar");

                try
                {
                    op = MenuConsole.getInt("Digite a operação desejada");

                    switch (op)
                    {
                        case 1:
                            ILogService logCSVService = new LogCSVService();

                            Log logCsv = new Log();
                            logCsv.data = DateTime.Now;
                            logCsv.nomeArquivo = MenuConsole.getString("Digite o nome do Arquivo");
                            logCsv.mensagem = MenuConsole.getString("Digite a mensagem do Log");
                            logCsv.tipoLog = (TipoLog)getTipoLog();

                            logCSVService.gravarLog(logCsv);

                            MenuConsole.showMessage(logCsv.ToString());
                            break;
                        case 2:
                            ILogService logDBService = new LogDataBaseService();

                            Log logDB = new Log();
                            logDB.data = DateTime.Now;
                            logDB.nomeArquivo = MenuConsole.getString("Digite o nome do Arquivo");
                            logDB.mensagem = MenuConsole.getString("Digite a mensagem do Log");
                            logDB.tipoLog = (TipoLog)getTipoLog();

                            logDBService.gravarLog(logDB);

                            MenuConsole.showMessage(logDB.ToString());
                            break;
                        case 0:
                            MenuConsole.showMessage("Voltando ao Menu anterior");
                            break;
                        default:
                            MenuConsole.showMessage("opção inválida");
                            break;
                    }
                }
                catch (Exception e)
                {
                    MenuConsole.showMessage("Tente novamente");
                }

            } while (op != 0);
        }

        private void buscarLogID()
        {
            int op = 1;
            do
            {
                MenuConsole.showMessage("Busca de Logs");
                MenuConsole.showMessage("1 - Buscar no CSV");
                MenuConsole.showMessage("2 - Buscar no Banco de Dados");
                MenuConsole.showMessage("0 - Voltar");

                try
                {
                    op = MenuConsole.getInt("Digite a operação desejada");

                    switch (op)
                    {
                        case 1:
                            ILogService logCSVService = new LogCSVService();
                            MenuConsole.showMessage(logCSVService.buscarLog(MenuConsole.getInt("Digite o ID")).ToString());
                            break;
                        case 2:
                            ILogService logDBService = new LogDataBaseService();
                            MenuConsole.showMessage(logDBService.buscarLog(MenuConsole.getInt("Digite o ID")).ToString());
                            break;
                        case 0:
                            MenuConsole.showMessage("Voltando ao Menu anterior");
                            break;
                        default:
                            MenuConsole.showMessage("opção inválida");
                            break;
                    }
                }
                catch (Exception e)
                {
                    MenuConsole.showMessage("Tente novamente");
                }

            } while (op != 0);
        }

        private void buscarLogNomeArquivo()
        {
            int op = 1;
            do
            {
                MenuConsole.showMessage("Busca de Logs");
                MenuConsole.showMessage("1 - Buscar no CSV");
                MenuConsole.showMessage("2 - Buscar no Banco de Dados");
                MenuConsole.showMessage("0 - Voltar");

                try
                {
                    op = MenuConsole.getInt("Digite a operação desejada");

                    switch (op)
                    {
                        case 1:
                            ILogService logCSVService = new LogCSVService();
                            MenuConsole.showMessage(logCSVService.buscarLog(MenuConsole.getString("Digite o nome do Arquivo")).ToString());
                            break;
                        case 2:
                            ILogService logDBService = new LogDataBaseService();
                            MenuConsole.showMessage(logDBService.buscarLog(MenuConsole.getString("Digite o nome do Arquivo")).ToString());
                            break;
                        case 0:
                            MenuConsole.showMessage("Voltando ao Menu anterior");
                            break;
                        default:
                            MenuConsole.showMessage("opção inválida");
                            break;
                    }
                }
                catch (Exception e)
                {
                    MenuConsole.showMessage("Tente novamente");
                }

            } while (op != 0);
        }

    }
}
