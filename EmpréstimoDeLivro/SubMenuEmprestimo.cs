using System;

namespace EmprestimoDeLivro
{
    internal class SubMenuEmprestimo
    {
        public SubMenuAmigos AmigosEmprestimo;
        public SubMenuRevistas RevistasEmprestimos;
        public int contadorEmprestimo = 0;
        public Emprestimos[] registroDeEmprestimo = new Emprestimos[100];
        string opcaoSubMenu = "0";
        int seletorDeRevista;
        public int contadorDivida = 0;
        DateTime hoje = DateTime.Now;

        public void MenuEmprestimo()
        {
            while (true)
            {
                Console.WriteLine("Menu de Empréstimos");
                Console.WriteLine("----------------------");
                Console.WriteLine("1- Para Agendar empréstimo");
                Console.WriteLine("2- Para visualiza empréstimo ");
                Console.WriteLine("3- Para visualiza empréstimos por mes ");
                Console.WriteLine("4- Para cadastrar empréstimo");
                Console.WriteLine("5- Para cadastrar devolução");
                Console.WriteLine("6- Para Retirada do Agendamento");
                Console.WriteLine("7- Para excluir emprestimo/agendamento");

                Console.WriteLine("s- Para sair");
                opcaoSubMenu = Console.ReadLine();

                if (opcaoSubMenu == "1")
                {
                    Console.Clear();
                    AgendarEmprestimo();
                }
                else if (opcaoSubMenu == "2")
                {
                    Console.Clear();
                    MostrarEmprestimo();
                    Console.WriteLine("Pressione enter para continuar");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (opcaoSubMenu == "3")
                {
                    Console.Clear();
                    EmprestimosMensais();
                }
                else if (opcaoSubMenu == "4")
                {
                    Console.Clear();
                    CadastraEmprestimo();
                }
                else if (opcaoSubMenu == "5")
                {
                    Console.Clear();
                    CadastrarDevolucão();
                }
                else if (opcaoSubMenu == "6")
                {
                    Console.Clear();
                    CadastrarRetirada();
                }
                else if (opcaoSubMenu == "7")
                {
                    Console.Clear();
                    MostrarEmprestimo();
                    Console.WriteLine("Digite o id para excluir: ");
                    int idexclui = Convert.ToInt32(Console.ReadLine());
                    ExcluirEmprestimo(idexclui);
                }
                else if (opcaoSubMenu == "s")
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção inválida");
                    Console.ResetColor();
                    Console.WriteLine("pressione enter para continuar ");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

            }
        }


        //só pode fazer agendamentos para dias futuros
        public void AgendarEmprestimo()
        {
            registroDeEmprestimo[contadorEmprestimo] = new Emprestimos();

            Console.WriteLine("Digite a data do empréstimo: (dd/mm/aaaa)");
            string emprestimos = Console.ReadLine();

            string[] dataSeparadaEmprestimo = emprestimos.Split("/");
            int diaEmprestimo = int.Parse(dataSeparadaEmprestimo[0]);
            int mesEmprestimo = int.Parse(dataSeparadaEmprestimo[1]);
            int anoEmprestimo = int.Parse(dataSeparadaEmprestimo[2]);

            registroDeEmprestimo[contadorEmprestimo].DataAgendada = new DateTime(anoEmprestimo,
                mesEmprestimo, diaEmprestimo);

            //agendamentos só para dias futuros
            if (registroDeEmprestimo[contadorEmprestimo].DataAgendada <= hoje)
            {
                Console.WriteLine("Agendamento de empréstimos só podem ser feitos para dias futuros");
                Console.WriteLine("Pressione enter para continuar");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            if (AmigosEmprestimo.contadorAmigo > 0)
            {
                

                Console.Clear();
                AmigosEmprestimo.MostrarAmigos();

                Console.WriteLine("Digite o id do amigo selecionado: ");
                int seletorDeAmigos = Convert.ToInt32(Console.ReadLine());
               
                
                //validação da multa
                if (AmigosEmprestimo.registroDeAmigos[seletorDeAmigos].temMulta == false)
                {
                    //validação de emprestimo existente
                    if (AmigosEmprestimo.registroDeAmigos[seletorDeAmigos].temEmprestimo == false)
                    {
                        registroDeEmprestimo[contadorEmprestimo].amigo = AmigosEmprestimo.registroDeAmigos[seletorDeAmigos];
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Esse amigo já tem um empréstimo");
                        Console.ResetColor();
                        Console.WriteLine("Pressione enter para continuar");
                        Console.Clear();
                        return;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Esse amigo tem uma multa em aberto");
                    Console.ResetColor();
                    Console.WriteLine("Pressione enter para continuar");
                    Console.Clear();
                    return;
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não existem amigos cadastrados");
                Console.ResetColor();
                Console.WriteLine("Pressione enter para continuar");
                Console.Clear();
                return;
            }
            Console.Clear();
            Console.WriteLine("O amigo selecionado é: " + AmigosEmprestimo.registroDeAmigos[contadorEmprestimo].nome);
            Console.WriteLine("");


            if (RevistasEmprestimos.contadorRevista > 0)
            {
                RevistasEmprestimos.MostrarRevista();
                Console.WriteLine("Digite o id da revista selecionada: ");
                int seletorDeRevista = Convert.ToInt32(Console.ReadLine());
                
                //revista ja foi emprestada
                if (registroDeEmprestimo[seletorDeRevista].revista.taEmprestada == false)
                {
                    registroDeEmprestimo[contadorEmprestimo].revista = RevistasEmprestimos.registroDeRevista[seletorDeRevista];
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Essa revista ja foi emprestada");
                    Console.ResetColor();
                    Console.WriteLine("Pressione enter para continuar");
                    Console.Clear();
                    return;
                }
            }
            else
            {
                Console.WriteLine("Não existem revistas cadastradas");
                return;
            }

            Console.Clear();
            Console.WriteLine("O amigo selecionado é: " + AmigosEmprestimo.registroDeAmigos[contadorEmprestimo].nome);
            Console.WriteLine("A revista selecionada é: " + RevistasEmprestimos.registroDeRevista[contadorEmprestimo].colecao);
            Console.WriteLine("Pressione enter para continuar");
            Console.ReadKey();
            Console.Clear();

            registroDeEmprestimo[contadorEmprestimo].dataLimite.AddDays(RevistasEmprestimos.
                registroDeRevista[seletorDeRevista].qualCategoria.diasDeEmprestimo);
            //colocando amigo como tem emprestimo
            AmigosEmprestimo.registroDeAmigos[contadorEmprestimo].temEmprestimo = true;
            //colocando emprestimo como eberto
            registroDeEmprestimo[contadorEmprestimo].aberto = false;

            contadorEmprestimo++;
        }

        public void MostrarEmprestimo()
        {

            if (contadorEmprestimo == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não existem Empréstimos");
                Console.ResetColor();
                Console.WriteLine("Pressione enter para continuar");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            for (int i = 0; i < contadorEmprestimo; i++)
            {
                Console.WriteLine("Id: " + i);
                Console.WriteLine("Amigo: " + registroDeEmprestimo[i].amigo.nome);
                Console.WriteLine("Revista: " + registroDeEmprestimo[i].revista.colecao);
                Console.WriteLine("Data de empréstimo: " + registroDeEmprestimo[i].DataAgendada);
                Console.WriteLine("Data de devolução: " + registroDeEmprestimo[i].dataLimite);
            }
        }

        public void EmprestimosMensais()
        {
            //contador de possições
            if (contadorEmprestimo == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não existem Empréstimos");
                Console.ResetColor();
                Console.WriteLine("Pressione enter para continuar");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            int marcador = 0;
            Console.WriteLine("Emprestimos mensais");
            Console.WriteLine("--------------------");
            Console.WriteLine("Digite o mes que quer ver:  (mm)");
            int mesDigitado = Convert.ToInt32(Console.ReadLine());

            while (marcador > contadorEmprestimo)
            {
                if (registroDeEmprestimo[marcador].DataAgendada.Year == hoje.Year)
                {
                    if (registroDeEmprestimo[marcador].DataAgendada.Month == mesDigitado)
                    {
                        Console.WriteLine("Amigo: " + registroDeEmprestimo[marcador].amigo);
                        Console.WriteLine("Revista: " + registroDeEmprestimo[marcador].revista);
                        Console.WriteLine("Data agendada para retirada: " + registroDeEmprestimo[marcador].DataAgendada);
                        Console.WriteLine("Data de devolução: " + registroDeEmprestimo[marcador].dataLimite);

                    }
                }
                marcador++;
            }


        }

        public void MostrarDiario()
        {

            if (contadorEmprestimo == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não existem Empréstimos");
                Console.ResetColor();
                Console.WriteLine("Pressione enter para continuar");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            int marcador = 0;
            Console.WriteLine("Emprestimos Diário");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Digite o dia que quer ver:  (dd)");
            int diaDigitado = Convert.ToInt32(Console.ReadLine());

            while (marcador > contadorEmprestimo)
            {
                if (registroDeEmprestimo[marcador].DataAgendada.Year == hoje.Year &&
                    registroDeEmprestimo[marcador].DataAgendada.Month == hoje.Month &&
                    registroDeEmprestimo[marcador].DataAgendada.Day == diaDigitado)
                {

                    if (registroDeEmprestimo[marcador].aberto)
                    {
                        Console.WriteLine("Amigo: " + registroDeEmprestimo[marcador].amigo);
                        Console.WriteLine("Revista: " + registroDeEmprestimo[marcador].revista);
                        Console.WriteLine("Data de empréstimo: " + registroDeEmprestimo[marcador].
                            DataAgendada);
                        Console.WriteLine("Data de devolução: " + registroDeEmprestimo[marcador].
                            dataLimite);
                    }

                }
                marcador++;
            }
        }

        public void CadastraEmprestimo()
        {
            registroDeEmprestimo[contadorEmprestimo] = new Emprestimos();
            registroDeEmprestimo[contadorEmprestimo].DataAgendada = hoje;
            
            if (AmigosEmprestimo.contadorAmigo > 0)
            {
                AmigosEmprestimo.MostrarAmigos();

                Console.WriteLine("Digite o id do amigo selecionado: ");
                int seletorDeAmigos = Convert.ToInt32(Console.ReadLine());
               
                //validação da multa
                if (AmigosEmprestimo.registroDeAmigos[seletorDeAmigos].temMulta == false)
                {

                    //validação de emprestimo
                    if (AmigosEmprestimo.registroDeAmigos[seletorDeAmigos].temEmprestimo == false)
                    {
                        registroDeEmprestimo[contadorEmprestimo].amigo = AmigosEmprestimo.registroDeAmigos[seletorDeAmigos];
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Esse amigo tem empréstimo");
                        Console.ResetColor();
                        Console.WriteLine("Pressione enter para continuar");
                        Console.Clear();
                        return;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Esse amigo tem multa");
                    Console.ResetColor();
                    Console.WriteLine("Pressione enter para continuar");
                    Console.Clear();
                    return;
                }

            }
            else
            {
                Console.WriteLine("Ñão existem amigos cadastrados");
                return;
            }
            Console.Clear();
            Console.WriteLine("O amigo selecionado é: " + AmigosEmprestimo.registroDeAmigos[contadorEmprestimo].nome);
            Console.WriteLine("");


            if (RevistasEmprestimos.contadorRevista > 0)
            {
                RevistasEmprestimos.MostrarRevista();
                Console.WriteLine("Digite o id da revista selecionada: ");
                int seletorDeRevista = Convert.ToInt32(Console.ReadLine());
                
                //revista ja foi emprestada
                if (registroDeEmprestimo[seletorDeRevista].revista.taEmprestada == false)
                {
                    registroDeEmprestimo[contadorEmprestimo].revista = RevistasEmprestimos.registroDeRevista[seletorDeRevista];
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Essa revista ja foi emprestada");
                    Console.ResetColor();
                    Console.WriteLine("Pressione enter para continuar");
                    Console.Clear();
                    return;
                }
            }
            else
            {
                Console.WriteLine("Não existem revistas cadastradas");
                return;
            }

            Console.Clear();
            Console.WriteLine("O amigo selecionado é: " + AmigosEmprestimo.registroDeAmigos[contadorEmprestimo].nome);
            Console.WriteLine("A revista selecionada é: " + RevistasEmprestimos.registroDeRevista[contadorEmprestimo].colecao);


            registroDeEmprestimo[contadorEmprestimo].dataLimite = registroDeEmprestimo[contadorEmprestimo].dataLimite.AddDays(RevistasEmprestimos.
                registroDeRevista[contadorEmprestimo].qualCategoria.diasDeEmprestimo);
            //colocando amigo como tem empréstimo
            AmigosEmprestimo.registroDeAmigos[contadorEmprestimo].temEmprestimo = true;
            //colocando emprestimo como aberto
            registroDeEmprestimo[contadorEmprestimo].aberto = true;
            //colocando que a revista está emprestada
            registroDeEmprestimo[contadorEmprestimo].revista.taEmprestada = true;

            contadorEmprestimo++;

            Console.Clear();

        }

        public void CadastrarDevolucão()
        {
            if (contadorEmprestimo == 0)
            {
                Console.WriteLine("não existem empréstimos");
                Console.WriteLine("Digite enter para continuar");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            MostrarEmprestimo();

            Console.WriteLine("Digite o Id do emprestimo");
            int IDSelecionado = Convert.ToInt32(Console.ReadLine());


            Console.Clear();

            Console.WriteLine("Digite a data de devolução: (dd/mm/aaaa)");
            registroDeEmprestimo[IDSelecionado].entregaReal = DateTime.Parse(Console.ReadLine());
           
            //safe point
            /* string EntregaDigitada = Console.ReadLine();

            string[] dataSeparadaEntrega = EntregaDigitada.Split("/");
            int diaEmprestimo = int.Parse(dataSeparadaEntrega[0]);
            int mesEmprestimo = int.Parse(dataSeparadaEntrega[1]);
            int anoEmprestimo = int.Parse(dataSeparadaEntrega[2]);

            registroDeEmprestimo[IDSelecionado].entregaReal = new DateTime(anoEmprestimo,
                mesEmprestimo, diaEmprestimo);*/

            if (registroDeEmprestimo[IDSelecionado].entregaReal >
                registroDeEmprestimo[IDSelecionado].dataLimite)
            {
                registroDeEmprestimo[IDSelecionado].amigo.temMulta = true;
                registroDeEmprestimo[IDSelecionado].amigo.Vacilo.diasDeMulta =
                    registroDeEmprestimo[IDSelecionado].entregaReal.Day - registroDeEmprestimo[IDSelecionado].dataLimite.Day;
                registroDeEmprestimo[IDSelecionado].amigo.Vacilo.valorDaMulta = registroDeEmprestimo[IDSelecionado].amigo.Vacilo.diasDeMulta * 0.5;
                contadorDivida++;
            }
            //fechando o emprestimo
            registroDeEmprestimo[IDSelecionado].aberto = false;
            //tirando o emprestimo do amigo
            AmigosEmprestimo.registroDeAmigos[IDSelecionado].temEmprestimo = false;
        }

        public void CadastrarRetirada()
        {
            MostrarEmprestimo();

            Console.WriteLine("Digite o id do empréstimo:");
            int IDRetirada = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite a data da retirada: (dd/mm/aaaa");
            string RetiradaDigitada = Console.ReadLine();

            string[] dataSeparadaEntrega = RetiradaDigitada.Split("/");
            int diaEmprestimo = int.Parse(dataSeparadaEntrega[0]);
            int mesEmprestimo = int.Parse(dataSeparadaEntrega[1]);
            int anoEmprestimo = int.Parse(dataSeparadaEntrega[2]);

            registroDeEmprestimo[IDRetirada].DataDaRetirada = new DateTime(anoEmprestimo,
                mesEmprestimo, diaEmprestimo);

            if (registroDeEmprestimo[IDRetirada].DataDaRetirada >
                registroDeEmprestimo[IDRetirada].DataAgendada.AddDays(2))
            {
                Console.WriteLine("Agendamento Expirado");
                Console.WriteLine("Digite enter para continuar");
                Console.ReadKey();
                Console.Clear();
                ExcluirEmprestimo(IDRetirada);

                return;
            }

            registroDeEmprestimo[IDRetirada].dataLimite= registroDeEmprestimo[IDRetirada].DataDaRetirada.AddDays(
                registroDeEmprestimo[IDRetirada].revista.qualCategoria.diasDeEmprestimo);

            registroDeEmprestimo[IDRetirada].DataAgendada = registroDeEmprestimo[IDRetirada].DataDaRetirada;


        }

        public void ExcluirEmprestimo(int IDExclusão)
        {
            if (contadorEmprestimo == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não existem Empréstimos");
                Console.ResetColor();
                Console.WriteLine("Pressione enter para continuar");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            for (int i = 0; i < contadorEmprestimo; i++)
            {

                for (int y = IDExclusão; y < contadorEmprestimo; y++)
                {

                    registroDeEmprestimo[y].amigo.nome = registroDeEmprestimo[y + 1].amigo.nome;
                    registroDeEmprestimo[y].revista.colecao = registroDeEmprestimo[y + 1].revista.colecao;
                    registroDeEmprestimo[y].dataLimite = registroDeEmprestimo[y + 1].dataLimite;
                    registroDeEmprestimo[y].dataLimite = registroDeEmprestimo[y + 1].dataLimite;
                }

                contadorEmprestimo--;

                Console.WriteLine("Excluido com sucesso");

            }
        }
    }
}
