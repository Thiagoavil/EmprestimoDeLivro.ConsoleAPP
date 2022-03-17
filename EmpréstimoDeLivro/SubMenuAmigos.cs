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
                else if(opcaoSubMenu == "s")
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor= ConsoleColor.Red;
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
            registroDeAmigos[contadorAmigo].nome=Console.ReadLine();

            Console.WriteLine("Digite o nome do responsável:");
            registroDeAmigos[contadorAmigo].nomeResponsavel=Console.ReadLine();

            Console.WriteLine("Digite seu número de telefone:");
            registroDeAmigos[contadorAmigo].telefone=Console.ReadLine();

            Console.WriteLine("Digite seu endereço:");
            registroDeAmigos[contadorAmigo].endereço=Console.ReadLine();

            registroDeAmigos[contadorAmigo].temEmprestimo = false;
            
            contadorAmigo++;

            Console.Clear();
        }

        public void MostrarAmigos()
        {
            for (int i = 0; i < contadorAmigo; i++)
            {
                Console.WriteLine("Id: " + i);
                Console.WriteLine("nome do amigo: " + registroDeAmigos[i].nome);
                Console.WriteLine("nome do Responsável: " + registroDeAmigos[i].nomeResponsavel);
                Console.WriteLine("Numero do telefone: " + registroDeAmigos[i].telefone);
                Console.WriteLine("O endereço: " + registroDeAmigos[i].endereço);
                Console.WriteLine("");
            }
        }

    }
}
