using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoDeLivro
{
    internal class SubMenuAmigos
    {

        public int contadorAmigo = 0;
        public Amigos[] registroDeAmigos = new Amigos[100];
        string opcaoSubMenu = "0";

        public void MenuAmigos()
        {
            while (true)
            {
                Console.WriteLine("Menu de Amigos");
                Console.WriteLine("----------------------");
                Console.WriteLine("1- Para cadastrar amigo");
                Console.WriteLine("2- Para Mostrar amigo");
                Console.WriteLine("3- Para quitar divida");
                Console.WriteLine("s- Para sair");
                opcaoSubMenu = Console.ReadLine();

                if (opcaoSubMenu == "1")
                {
                    Console.Clear();
                    CadastrarAmigo();
                }
                else if (opcaoSubMenu == "2")
                {
                    Console.Clear();
                    MostrarAmigos();
                }
                else if (opcaoSubMenu == "3")
                {
                    Console.Clear();
                    Quitardivida();
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



        public void CadastrarAmigo()
        {
            registroDeAmigos[contadorAmigo] = new Amigos();


            Console.WriteLine("Digite seu nome:");
            registroDeAmigos[contadorAmigo].nome = Console.ReadLine();

            Console.WriteLine("Digite o nome do responsável:");
            registroDeAmigos[contadorAmigo].nomeResponsavel = Console.ReadLine();

            Console.WriteLine("Digite seu número de telefone:");
            registroDeAmigos[contadorAmigo].telefone = Console.ReadLine();

            Console.WriteLine("Digite seu endereço:");
            registroDeAmigos[contadorAmigo].endereço = Console.ReadLine();

            registroDeAmigos[contadorAmigo].temEmprestimo = false;
            registroDeAmigos[contadorAmigo].temMulta = false;

            contadorAmigo++;

            Console.Clear();
        }

        public void MostrarAmigos()
        {
            if (contadorAmigo == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não existem Amigos");
                Console.ResetColor();
                Console.WriteLine("Pressione enter para continuar");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            for (int i = 0; i < contadorAmigo; i++)
            {
                Console.WriteLine("Id: " + i);
                Console.WriteLine("nome do amigo: " + registroDeAmigos[i].nome);
                Console.WriteLine("nome do Responsável: " + registroDeAmigos[i].nomeResponsavel);
                Console.WriteLine("Numero do telefone: " + registroDeAmigos[i].telefone);
                Console.WriteLine("O endereço: " + registroDeAmigos[i].endereço);
                if (registroDeAmigos[i].temMulta)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Tem multa");
                    Console.ResetColor();
                    Console.WriteLine("Dias de multa: " + registroDeAmigos[i].Vacilo.diasDeMulta);
                    Console.WriteLine("Valor da multa: R$" + registroDeAmigos[i].Vacilo.valorDaMulta);
                }
                Console.WriteLine("");

            }
        }

        public void Quitardivida()
        {
            for (int i = 0; i < contadorAmigo; i++)
            {
                if (registroDeAmigos[i].temMulta)
                {
                    Console.WriteLine("Id: " + i);
                    Console.WriteLine("Nome: " + registroDeAmigos[i].nome);
                    Console.WriteLine("Dias de multa: " + registroDeAmigos[i].Vacilo.diasDeMulta);
                    Console.WriteLine("Valor da multa: R$" + registroDeAmigos[i].Vacilo.valorDaMulta);
                }
                Console.WriteLine("");
            }
            
            Console.WriteLine("Digite o seu id");
            int idDaDivida=Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Digite o valor pago: ");
            double valorPago=Convert.ToDouble(Console.ReadLine());

            registroDeAmigos[idDaDivida].Vacilo.valorDaMulta = 
                registroDeAmigos[idDaDivida].Vacilo.valorDaMulta - valorPago;

            if(registroDeAmigos[idDaDivida].Vacilo.valorDaMulta==0)
            {
                registroDeAmigos[idDaDivida].temMulta = false;
                Console.WriteLine("divida quitada por completo");
                Console.WriteLine("Pressione enter para continuar");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Valor restante de multa: R$"+ registroDeAmigos[idDaDivida].Vacilo.valorDaMulta);
                Console.WriteLine("Presione enter para continuar: ");
                Console.ReadKey();
                Console.Clear();
                return;
            }
        }

    }
}
