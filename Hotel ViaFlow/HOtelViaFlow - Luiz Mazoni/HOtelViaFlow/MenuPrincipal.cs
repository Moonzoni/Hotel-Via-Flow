using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace HOtelViaFlow
{
    public class MenuPrincipal
    {

        public static Hospede CadastrarHospede()
        {
            Hospede hosp = new Hospede();
            Console.WriteLine("\nCadastro de Hospedes");
            Console.Write("\nDigite o nome: ");
            hosp.Nome = Console.ReadLine();
            Console.Write("\nDigite a idade do hospede: ");
            hosp.Idade = int.Parse(Console.ReadLine());
            Console.Write("\nDigite o telefone do hospede: ");
            hosp.Telefone = Console.ReadLine();
            Console.Write("\nDigite o email do hospede: ");
            hosp.Email = Console.ReadLine();
            Console.Write("\nFormas de pagamento:\n" +
                "0 - Crédito\n" +
                "1 - Debito\n" +
                "2 - PicPay\n" +
                "Digite: ");
            hosp.metodoPagamento = (MetodoPagamento)int.Parse(Console.ReadLine());
            Console.WriteLine("\nHOSPEDE CADASTRADO\n");
            
            return hosp;
        }

        public static Quarto CadastrarQuarto()
        {
            Quarto quarto = new Quarto();
            Console.WriteLine("\nCadastro de Quartos");
            Console.Write("\nDigite o numero: ");
            quarto.Numero = int.Parse(Console.ReadLine());

            Console.Write("\nDigite o preço: ");
            quarto.Preco = double.Parse(Console.ReadLine());

            Console.Write("\nModelos de quarto disponivel:\n" +
                "0 - Simples\n" +
                "1 - Suite\n" +
                "Escolha um: ");
            quarto.tipoQuarto = (TipoQuarto)int.Parse(Console.ReadLine());

            Console.WriteLine("\nQUARTO CADASTRADO\n");
            
            return quarto;
        }

        public static Servico CadastrarServico()
        {
            Servico servico = new Servico();
            Console.WriteLine("\nCadastro de Servicos");
            Console.Write("\nDigite o nome: ");
            servico.Nome = Console.ReadLine();

            Console.Write("\nDigite o preco: $");
            servico.Preco = double.Parse(Console.ReadLine());


            Console.WriteLine("\nSERVIÇO CADASTRADO\n");
            
            return servico;
        }

        public static Locacao LocarQuarto(Hotel hotel)
        {
            Locacao locacao = new Locacao();
            Console.WriteLine("\nLocar Quarto");
            MenuOperacoes op = MenuOperacoes.None;

            do
            {
                try
                {
                    Console.WriteLine("\nSelecione o Hospede através do ID");

                    for (int i = 0; i < hotel.hospedes.Count; i++)
                    {
                        Console.WriteLine(i + " - " + hotel.hospedes[i].Nome);
                    }
                    Console.Write("\nHospede numero: ");
                    int indice = int.Parse(Console.ReadLine());
                    locacao.hospede = hotel.hospedes[indice];

                    Console.WriteLine("\nSelecione o Quarto através do ID\n");

                    List<Quarto> quartosDisponiveis = hotel.quartosDisponiveis();

                    for (int i = 0; i < quartosDisponiveis.Count; i++)
                    {
                        Console.WriteLine(i + " - " + quartosDisponiveis[i].Numero + " - " + quartosDisponiveis[i].tipoQuarto + " - $" + quartosDisponiveis[i].Preco);
                    }
                    if (quartosDisponiveis.Count == 0)
                    {
                        Console.WriteLine("NENHUMA QUARTO DISPONIVEL");
                    }
                    else
                    {
                        Console.Write("\nQuarto numero: ");
                        indice = int.Parse(Console.ReadLine());
                        locacao.quarto = quartosDisponiveis[indice];
                        Console.WriteLine("\nAVISO - Quarto {0} locado em nome de {1}", locacao.quarto.Numero, locacao.hospede.Nome);                                                
                        locacao.quarto.Vezes = locacao.quarto.Vezes + 1;
                        op = MenuOperacoes.Sair;
                        try
                        {
                            MailMessage mail = new MailMessage();
                            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                            mail.From = new MailAddress("luiz.perez@acad.pucrs.br");
                            mail.To.Add(locacao.hospede.Email);
                            mail.Subject = "Abertura de conta do Hotel ViaFlow";
                            mail.Body = "\nObrigado " + locacao.hospede.Nome + " por utilizar os serviços do nosso Hotel.\nSeu quarto numero " + locacao.quarto.Numero + " já está disponivel para uso." +
                                "\nEsperamos que aproveite a estadia conosco\n\nAtt," +
                                "\nGerencia do Hotel ViaFlow";

                            SmtpServer.Port = 587;
                            SmtpServer.Credentials = new System.Net.NetworkCredential("luiz.perez@acad.pucrs.br", "viaflow2019");
                            SmtpServer.EnableSsl = true;

                            SmtpServer.Send(mail);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Quarto locado com sucesso porém o email de confirmação falhou. Envie manualmente para o cliente "+ locacao.hospede.Nome+".");
                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Opção inválida");
                }
                

            } while (op != MenuOperacoes.Sair);

            
            
            return locacao;
        }

        public static void ConsumirServico(Hotel hotel)
        {
            Console.WriteLine("\nConsumir Serviço");
            int op = 1;

            do
            {
                try
                {
                    Console.WriteLine("\nSelecione o Hospede\n");
                    for (int i = 0; i < hotel.locacoes.Count; i++)
                    {
                        Console.WriteLine(i + " - " + hotel.locacoes[i].hospede.Nome);
                    }
                    Console.Write("\nEscolha um hospede: ");
                    int indice = int.Parse(Console.ReadLine());

                    Locacao locacoes = hotel.locacoes[indice];

                    int locacao = -1;

                    for (int i = 0; i < hotel.locacoes.Count; i++)
                    {
                        if (hotel.locacoes[i].hospede.Nome == locacoes.hospede.Nome)
                        {
                            locacao = i;
                            break;
                        }
                        
                    }

                    if (locacao == -1)
                    {
                        Console.WriteLine("Cliente não possui quarto, favor locar um antes de consumir serviços\n");
                        return;
                    }

                    Console.WriteLine("Selecione os Servicos\n");
                    int sair;

                    do
                    {

                        for (int i = 0; i < hotel.servicos.Count; i++)
                        {
                            Console.WriteLine(i + " - " 
                                                + hotel.servicos[i].Nome 
                                                + " - $" + hotel.servicos[i].Preco);
                        }
                        Console.Write("\nEscolha o Serviço: ");
                        int indiceServico = int.Parse(Console.ReadLine());
                        Servico servico = hotel.servicos[indiceServico];
                        servico.Vezes = servico.Vezes + 1;
                        hotel.locacoes[locacao].servicosConsumidos.Add(servico);
                        Console.Write("\nDeseja adicionar mais um servico");
                        Console.Write("\n0 - Não, 1 - Sim\n");
                        Console.Write("Digite: ");
                        sair = int.Parse(Console.ReadLine());
                    } while (sair != 0);

                    Console.WriteLine("\nHospede: " + hotel.locacoes[locacao].hospede.Nome);
                    foreach (var item in hotel.locacoes[locacao].servicosConsumidos)
                    {
                        Console.WriteLine("Servico: " + item.Nome + " - $" + item.Preco);
                    }

                    op = 0;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                

            } while (op != 0);
        }
    }
}
