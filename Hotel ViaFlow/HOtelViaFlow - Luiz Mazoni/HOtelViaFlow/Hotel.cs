using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HOtelViaFlow
{
    public class Hotel
    {
        public List<Hospede> hospedes = new List<Hospede>();
        public List<Quarto> quartos = new List<Quarto>();
        public List<Servico> servicos = new List<Servico>();
        public List<Locacao> locacoes = new List<Locacao>();

        public List<Quarto> quartosDisponiveis()
        {
            List<Quarto> lista = new List<Quarto>();

            foreach (var quarto in quartos)
            {
                bool find = false;
                foreach (var locacao in locacoes)
                {
                    if (quarto.Numero == locacao.quarto.Numero)
                    {
                        find = true;
                    }
                }

                if (!find)
                {
                    lista.Add(quarto);
                }
            }

            return lista;
        }

        public void start()
        {
            initialize();
            MenuOperacoes op = MenuOperacoes.None;

            Funcoes.Menu();

            do
            {
                try
                {
                    Console.Write("Escolha uma das opções: ");
                    int input = int.Parse(Console.ReadLine());
                   
                    op = (MenuOperacoes)input;
                    switch (op)
                    {
                        case MenuOperacoes.CadastrarHospede:
                            hospedes.Add(MenuPrincipal.CadastrarHospede());
                            Funcoes.retorna();
                            Funcoes.Menu();
                            Funcoes.Clear();


                            break;
                        case MenuOperacoes.MostrarHospedes:
                            hospedes.ForEach(x => Console.WriteLine("\nNome: " + x.Nome +
                                " - Idade: " + x.Idade +
                                " - Tel.: " + x.Telefone +
                                " - E-mail: " + x.Email +
                                " - Pagamento: " + x.metodoPagamento));
                            Funcoes.retorna();
                            Funcoes.Menu();
                            Funcoes.Clear();

                            break;
                        case MenuOperacoes.CadastrarQuarto:
                            quartos.Add(MenuPrincipal.CadastrarQuarto());
                            Funcoes.retorna();
                            Funcoes.Menu();
                            Funcoes.Clear();

                            break;
                        case MenuOperacoes.MostarQuartos:
                            quartos.ForEach(x => Console.WriteLine("\n" + x.Numero + " - $" + x.tipoQuarto + " - " + x.Preco));
                            Funcoes.retorna();
                            Funcoes.Menu();
                            Funcoes.Clear();
                            break;
                        case MenuOperacoes.CadastrarServico:
                            servicos.Add(MenuPrincipal.CadastrarServico());
                            Funcoes.retorna();
                            Funcoes.Menu();
                            Funcoes.Clear();
                            break;
                        case MenuOperacoes.MostarServicos:
                            Console.WriteLine("\nServiços disponiveis no hotel:");
                            servicos.ForEach(x => Console.WriteLine("\n" + x.Nome + " - $" + x.Preco));
                            Funcoes.retorna();
                            Funcoes.Menu();
                            Funcoes.Clear();
                            break;
                        case MenuOperacoes.LocarQuarto:
                            locacoes.Add(MenuPrincipal.LocarQuarto(this));
                            Funcoes.retorna();
                            Funcoes.Menu();
                            Funcoes.Clear();
                            break;
                        case MenuOperacoes.MostrarLocacoes:
                            if (locacoes.Count != 0)
                            {
                                locacoes.ForEach(locacao =>
                                {
                                    Console.WriteLine("\nQuarto: " + locacao.quarto.Numero + " - " + locacao.hospede.Nome);
                                });
                                Funcoes.retorna();
                                Funcoes.Menu();
                                Funcoes.Clear();
                            }
                            else
                            {
                                Console.WriteLine("\nNENHUM QUARTO LOCADO NO HOTEL");
                                Funcoes.retorna();
                                Funcoes.Menu();
                                Funcoes.Clear();
                            }
                            break;
                        case MenuOperacoes.ConsumirServico:
                            MenuPrincipal.ConsumirServico(this);
                            Funcoes.retorna();
                            Funcoes.Menu();
                            Funcoes.Clear();
                            break;
                        case MenuOperacoes.MostrarServicosConsumidos:
                            Funcoes.SelecH(this);
                            Funcoes.retorna();
                            Funcoes.Menu();
                            Funcoes.Clear();
                            break;
                        case MenuOperacoes.FecharComanda:
                            Funcoes.FechaC(this);
                            Funcoes.retorna();
                            Funcoes.Menu();
                            Funcoes.Clear();
                            break;
                        case MenuOperacoes.Sair:
                            Console.WriteLine("Até Logo");
                            break;
                        case MenuOperacoes.MostrarQuartoDisp:
                            Funcoes.QuartosDisp(this);
                            Funcoes.retorna();
                            Funcoes.Menu();
                            Funcoes.Clear();
                            break;

                        case MenuOperacoes.QuartosCount:
                            Console.WriteLine("Relatório de utilização dos quartos:\n ");
                            IEnumerable<Quarto> listaQ = quartos.OrderByDescending(x => x.Vezes);
                            
                            foreach (Quarto x in listaQ)
                            {
                                Console.WriteLine("{0} - {1}", x.Numero, x.Vezes);
                            }
                            Funcoes.retorna();
                            Funcoes.Menu();
                            Funcoes.Clear();
                            break;

                        case MenuOperacoes.ServicosCount:
                            Console.WriteLine("Relatório de utilização dos serviços do hotel: \n");
                            IEnumerable<Servico> listaS = servicos.OrderByDescending(x => x.Vezes);

                            foreach (Servico x in listaS)
                            {
                                Console.WriteLine("{0} - {1}", x.Nome, x.Vezes);
                            }
                            Funcoes.retorna();
                            Funcoes.Menu();
                            Funcoes.Clear();
                            break;

                        default:
                            Console.WriteLine("Opção inválida");
                            Funcoes.retorna();
                            Funcoes.Menu();
                            Funcoes.Clear();
                            break;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Opção inválida");
                }

            } while (op != MenuOperacoes.Sair);
            
        }
        
        private void initialize()
        {
            this.servicos = new List<Servico>()
            {
                new Servico()
                {
                    Nome = "café",
                    Preco = 3
                },
                new Servico()
                {
                    Nome = "refri",
                    Preco = 4
                },
                new Servico()
                {
                    Nome = "xis",
                    Preco = 10
                }



            };

            this.quartos = new List<Quarto>()
            {
                new Quarto()
                {
                    Numero = 401,
                    Preco = 200,
                    tipoQuarto = TipoQuarto.Suite
                },
                 new Quarto()
                {
                    Numero = 301,
                    Preco = 100,
                    tipoQuarto = TipoQuarto.Simples
                },
                new Quarto()
                {
                    Numero = 201,
                    Preco = 200,
                    tipoQuarto = TipoQuarto.Suite
                },
                new Quarto()
                {
                    Numero = 101,
                    Preco = 100,
                    tipoQuarto = TipoQuarto.Simples
                }
            };

            this.hospedes = new List<Hospede>()
            {
                new Hospede()
                {
                    Nome = "Luiz",
                    Idade = 27,
                    Telefone = "32165498",
                    Email = "luiz.perez@viaflow.com.br",
                    metodoPagamento = MetodoPagamento.Credito
                },
                new Hospede()
                {
                    Nome = "Joao",
                    Idade = 19,
                    Telefone = "32165498",
                    Email = "dscasdcascdl.com",
                    metodoPagamento = MetodoPagamento.Debito
                },
                new Hospede()
                {
                    Nome = "Maria",
                    Idade = 25,
                    Telefone = "32165498",
                    Email = "Masdcasdcacd",
                    metodoPagamento = MetodoPagamento.Credito
                }


            };
        }
        

    }
}


        

 