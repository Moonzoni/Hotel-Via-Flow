using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace HOtelViaFlow
{
    public class Funcoes

    {
        public static Locacao SelecH(Hotel hotel)
        {
            Console.WriteLine("Selecione o Hospede");
            for (int i = 0; i < hotel.locacoes.Count; i++)
            {
                Console.WriteLine(i + " - " + hotel.locacoes[i].quarto.Numero + " - " + hotel.locacoes[i].hospede.Nome);
            }
            Console.Write("\nEscolha o hospede: ");

            int indice = int.Parse(Console.ReadLine());
            Locacao locacao = hotel.locacoes[indice];
            locacao.servicosConsumidos.ForEach(servico =>
            {
                Console.WriteLine(servico.Nome + " - " + servico.Preco);
            });
            Console.WriteLine("Valor do Quarto: " + hotel.locacoes[indice].quarto.Preco);
            Console.WriteLine("Comanda: " + locacao.ValorTotal());
            return locacao;


        }

        public static Locacao FechaC(Hotel hotel)
        {
            Console.WriteLine("Selecione o Hospede");
            for (int i = 0; i < hotel.locacoes.Count; i++)
            {
                Console.WriteLine(i + " - " + hotel.locacoes[i].quarto.Numero + " - " + hotel.locacoes[i].hospede.Nome);
            }
            Console.Write("\nEscolha o hospede: ");

            int indice = int.Parse(Console.ReadLine());
            Console.WriteLine("\nFechamento de conta do quarto {0} em nome de {1}\n", hotel.locacoes[indice].quarto.Numero, hotel.locacoes[indice].hospede.Nome);
            Locacao locacao = hotel.locacoes[indice];
            locacao.servicosConsumidos.ForEach(servico =>
            {
                Console.WriteLine(servico.Nome + " - $" + servico.Preco);
            });
            Console.WriteLine("Valor do Quarto: $" +hotel.locacoes[indice].quarto.Preco);
            double comanda = locacao.ValorTotal();
            Console.WriteLine("Comanda: $" + locacao.ValorTotal());
            Console.WriteLine("Desejar encerrar a conta?\n0 - Não, 1 - Sim\n");
            int asw = int.Parse(Console.ReadLine());

            if (asw == 1)
            {
                hotel.locacoes.RemoveAt(indice);
                Console.WriteLine("\nCONTA ENCERRADA\n");
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("luiz.perez@acad.pucrs.br");
                    mail.To.Add(locacao.hospede.Email);
                    mail.Subject = "Fechamento de conta do Hotel ViaFlow";
                    mail.Body = "\nObrigado " + locacao.hospede.Nome + " por utilizar os serviços do nosso Hotel.\nSua conta fechou em $" + locacao.ValorTotal() + ".\nVolte sempre!\n\nAtt," +
                        "\nGerencia do Hotel ViaFlow";

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("luiz.perez@acad.pucrs.br", "viaflow2019");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    //MessageBox.Show("mail Send");
                    return locacao;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nProblemas de conexão no momento do envio do email.\n" +
                        "Favor enviar manualmente um regisro do fechamento de conta para o hospede " + locacao.hospede.Nome + ".");
                    return locacao;
                }
                
            }
            else
            {
                Console.WriteLine("\nRetornando ao menu");
                return locacao;
            }
            
            



        }

        public static void Menu()
        {
            Console.WriteLine("--//--//--//--//--//--//--//--//--//--//" +
                "\n                  MENU\n");
            Console.WriteLine("1- Cadastrar Hospede\n" +
                "2- Cadastrar Quarto\n" +
                "3- Cadastrar Serviço\n" +
                "4- Mostrar Hospedes\n" +
                "5- Mostrar Quartos\n" +
                "6- Mostrar Quartos Disponiveis\n" +
                "7- Mostrar Serviços\n" +
                "8- Locar Quarto\n" +
                "9- Mostrar Locações\n" +
                "10- Consumir Serviço\n" +
                "11- Mostrar Serviços Consumidos\n" +
                "12- Fechar Comanda\n" +
                "13- Relatório de Serviços\n" +
                "14- Relatório de Quartos\n" +
                "15- Sair");
            Console.WriteLine("--//--//--//--//--//--//--//--//--//--//");
        }

        public static void QuartosDisp(Hotel hotel)
        {
            Console.WriteLine("\nQuartos disponiveis no hotel neste momento: \n");
            List<Quarto> quartosDisponiveis = hotel.quartosDisponiveis();

            for (int i = 0; i < quartosDisponiveis.Count; i++)
            {
                Console.WriteLine("\n"+ i + " - " + quartosDisponiveis[i].Numero + 
                    " - " + quartosDisponiveis[i].tipoQuarto + " - $" + quartosDisponiveis[i].Preco);
            }


        }

        

        public static void Clear()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n");
        }

        public static void retorna()
        {
            Console.Write("\nENTER retorna ao menu");
            Console.ReadKey();
        }

        
    }

}
