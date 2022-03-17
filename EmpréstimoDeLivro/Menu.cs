using System;

namespace EmprestimoDeLivro
{
    internal class Menu
    {
     
        static void Main(string[] args)
        {
            string opcaoMenu = "0";
            SubMenuAmigos subMenuAmigos = new SubMenuAmigos();
            SubMenuCaixa subMenuCaixa = new SubMenuCaixa();
            SubMenuRevistas subMenuRevistas = new SubMenuRevistas();
            SubMenuEmprestimo subMenuEmprestimo= new SubMenuEmprestimo();
            SubMenuCategorias subMenuCategorias = new SubMenuCategorias();
            subMenuEmprestimo.AmigosEmprestimo = subMenuAmigos;
            subMenuEmprestimo.RevistasEmprestimos = subMenuRevistas;
            subMenuRevistas.CaixaRevista = subMenuCaixa;
            subMenuCategorias.RevistaCategoria = subMenuRevistas;
            subMenuRevistas.CategoriaRevistas= subMenuCategorias;




            while (true)
            {
                Console.WriteLine("Clube da Leitura");
                Console.WriteLine("Menu de Opções");
                Console.WriteLine("___________________");
                Console.WriteLine("1- Menu de amigo");
                Console.WriteLine("2- Menu de caixa");
                Console.WriteLine("3- Menu de revista");
                Console.WriteLine("4- Menu de empréstimo");
                
                opcaoMenu =Console.ReadLine();

                if(opcaoMenu=="1")
                {
                    Console.Clear();
                    subMenuAmigos.MenuAmigos();
                }
                else if(opcaoMenu=="2")
                {
                    Console.Clear();
                    subMenuCaixa.MenuCaixa();
                }
                else if (opcaoMenu == "3")
                {
                    Console.Clear();
                    subMenuRevistas.MenuRevista();
                }
                else if(opcaoMenu == "4")
                {
                    Console.Clear();
                    subMenuEmprestimo.MenuEmprestimo();
                }
                else if(opcaoMenu =="5")
                {
                    subMenuCategorias.MenuCategorias();
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
    }
}
