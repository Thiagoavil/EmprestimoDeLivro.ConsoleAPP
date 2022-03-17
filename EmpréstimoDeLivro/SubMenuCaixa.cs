using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoDeLivro
{
    internal class SubMenuCaixa
    {

        public int contadorCaixa = 0;
        public Caixa[] registroDeCaixas = new Caixa[10];
        string opcaoSubMenu = "0";

        public void MenuCaixa()
        {
            while (true)
            {
                Console.WriteLine("Menu de Caixas");
                Console.WriteLine("----------------------");
                Console.WriteLine("1- Para cadastrar caixa");
                Console.WriteLine("2- Para Mostrar caixa");
                Console.WriteLine("s- Para sair");
                opcaoSubMenu = Console.ReadLine();

                if (opcaoSubMenu == "1")
                {
                    Console.Clear();
                    CadastrarCaixa();
                }
                else if(opcaoSubMenu=="2")
                {
                    Console.Clear();
                    MostrarCaixa();
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



        public void CadastrarCaixa()
        {
            registroDeCaixas[contadorCaixa] = new Caixa();

            Console.WriteLine("Digite a cor da caixa:");
            registroDeCaixas[contadorCaixa].cor = Console.ReadLine();

            Console.WriteLine("Digite numero da caixa:");
            registroDeCaixas[contadorCaixa].numero = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite a etiquieta da caixa:");
            registroDeCaixas[contadorCaixa].etiquieta = Console.ReadLine();

            contadorCaixa++;
            Console.Clear();
        }

        public void MostrarCaixa()
        {
            for (int i = 0; i<contadorCaixa; i++)
            {
                Console.WriteLine("Id: "+i);
                Console.WriteLine("cor da caixa: "+registroDeCaixas[i].cor);
                Console.WriteLine("Etiquieta da Caixa: "+registroDeCaixas[i].etiquieta);
                Console.WriteLine("Numero da caixa: " + registroDeCaixas[i].numero);
                Console.WriteLine("");

            }


        }
    }
}
