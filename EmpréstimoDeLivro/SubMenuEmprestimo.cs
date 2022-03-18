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
                }
                else if (opcaoSubMenu == "3")
                {
                    Console.Clear();
                    EmprestimosMensais();
                }
                else if(opcaoSubMenu =="4")
                {
                    Console.Clear();
                    CadastraEmprestimo();
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




        public void AgendarEmprestimo()
        {


            if (AmigosEmprestimo.contadorAmigo > 0)
            {
                registroDeEmprestimo[contadorEmprestimo] = new Emprestimos();

                AmigosEmprestimo.MostrarAmigos();

                Console.WriteLine("Digite o id do amigo selecionado: ");
                int seletorDeAmigos = Convert.ToInt32(Console.ReadLine());

                if (AmigosEmprestimo.registroDeAmigos[seletorDeAmigos].temEmprestimo == false)
                {
                    registroDeEmprestimo[contadorEmprestimo].amigo = AmigosEmprestimo.registroDeAmigos[seletorDeAmigos];
                }
                else
                {
                    Console.WriteLine("Esse amigo já tem um empréstimo");
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

                registroDeEmprestimo[contadorEmprestimo].revista = RevistasEmprestimos.registroDeRevista[seletorDeRevista];
            }
            else
            {
                Console.WriteLine("Não existem revistas cadastradas");
                return;
            }

            Console.Clear();
            Console.WriteLine("O amigo selecionado é: " + AmigosEmprestimo.registroDeAmigos[contadorEmprestimo].nome);
            Console.WriteLine("A revista selecionada é: " + RevistasEmprestimos.registroDeRevista[contadorEmprestimo].colecao);

            Console.WriteLine("Digite a data do empréstimo: ");
            string emprestimos = Console.ReadLine();

            string[] dataSeparadaEmprestimo = emprestimos.Split("/");
            int diaEmprestimo = int.Parse(dataSeparadaEmprestimo[0]);
            int mesEmprestimo = int.Parse(dataSeparadaEmprestimo[1]);
            int anoEmprestimo = int.Parse(dataSeparadaEmprestimo[2]);

            registroDeEmprestimo[contadorEmprestimo].dataDoEmprestimo = new DateTime(anoEmprestimo,
                mesEmprestimo, diaEmprestimo);

            DateTime entrega = registroDeEmprestimo[contadorEmprestimo].dataDoEmprestimo.AddDays(RevistasEmprestimos.
                registroDeRevista[contadorEmprestimo].qualCategoria.diasDeEmprestimo);

            AmigosEmprestimo.registroDeAmigos[contadorEmprestimo].temEmprestimo = true;

            if (registroDeEmprestimo[contadorEmprestimo].dataDaDevolucao < hoje)
            {
                registroDeEmprestimo[contadorEmprestimo].aberto = false;
            }
            else
            {
                registroDeEmprestimo[contadorEmprestimo].aberto = true;
            }

            contadorEmprestimo++;

            Console.Clear();
        }

        public void MostrarEmprestimo()
        {
            
            if (contadorEmprestimo==0)
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
                Console.WriteLine("Amigo: " + registroDeEmprestimo[i].amigo.nome);
                Console.WriteLine("Revista: " + registroDeEmprestimo[i].revista.colecao);
                Console.WriteLine("Data de empréstimo: " + registroDeEmprestimo[i].dataDoEmprestimo);
                Console.WriteLine("Data de devolução: " + registroDeEmprestimo[i].dataDaDevolucao);
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
                if (registroDeEmprestimo[marcador].dataDoEmprestimo.Year == hoje.Year)
                {
                    if (registroDeEmprestimo[marcador].dataDoEmprestimo.Month == mesDigitado)
                    {
                        Console.WriteLine("Amigo: " + registroDeEmprestimo[marcador].amigo);
                        Console.WriteLine("Revista: " + registroDeEmprestimo[marcador].revista);
                        Console.WriteLine("Data de empréstimo: " + registroDeEmprestimo[marcador].dataDoEmprestimo);
                        Console.WriteLine("Data de devolução: " + registroDeEmprestimo[marcador].dataDaDevolucao);

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
            Console.WriteLine("Digite o dia que quer ver:  (mm)");
            int diaDigitado = Convert.ToInt32(Console.ReadLine());

            while (marcador > contadorEmprestimo)
            {
                if (registroDeEmprestimo[marcador].dataDoEmprestimo.Year == hoje.Year &&
                    registroDeEmprestimo[marcador].dataDoEmprestimo.Month == hoje.Month && 
                    registroDeEmprestimo[marcador].dataDoEmprestimo.Day == diaDigitado)
                {

                    if (registroDeEmprestimo[marcador].aberto)
                    {
                        Console.WriteLine("Amigo: " + registroDeEmprestimo[marcador].amigo);
                        Console.WriteLine("Revista: " + registroDeEmprestimo[marcador].revista);
                        Console.WriteLine("Data de empréstimo: " + registroDeEmprestimo[marcador].
                            dataDoEmprestimo);
                        Console.WriteLine("Data de devolução: " + registroDeEmprestimo[marcador].
                            dataDaDevolucao);
                    }

                }
                marcador++;
            }
        }

        public void CadastraEmprestimo()
        {

        }
    }
}
