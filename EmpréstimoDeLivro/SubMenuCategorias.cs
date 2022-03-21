using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoDeLivro
{
    internal class SubMenuCategorias
    {
        public SubMenuRevistas RevistaCategoria;
        public int contadorCategoria = 0;
        string opcaoCategoria = "0";
        public Categorias[] registroDeCategorias = new Categorias[10];
        

        public void MenuCategorias()
        {
            while (true)
            {


                Console.WriteLine("Menu categorias");
                Console.WriteLine("---------------------");
                Console.WriteLine("1- Cadastrar categoria");
                Console.WriteLine("2- Visualizar categorias");
                Console.WriteLine("3- Visualizar revistas da categoria");
                Console.WriteLine("s- Para sair");

                if (opcaoCategoria== "1")
                {
                    Console.Clear();
                    CadastrarCategoria();
                }
                else if (opcaoCategoria=="2")
                {
                    Console.Clear();
                    VisualizarCategoria();
                    Console.WriteLine("Pressione enter para continuar");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if(opcaoCategoria=="3")
                {
                    Console.Clear();
                    VisualizarCategoria();
                    Console.WriteLine("Digite o Id Da categoria para visualizar");
                    int idvisualizarcategoria = Convert.ToInt32(Console.ReadLine());

                    registroDeCategorias[idvisualizarcategoria].MostrarRevistasNaCategoria();
                }
                else if (opcaoCategoria == "s")
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

        public void CadastrarCategoria()
        {
            registroDeCategorias[contadorCategoria] = new Categorias();

            Console.WriteLine("Digite o nome da categoria");
            registroDeCategorias[contadorCategoria].nome=Console.ReadLine();

            Console.WriteLine("Digite a quantidade de dias do Empréstimo");
            registroDeCategorias[contadorCategoria].diasDeEmprestimo=Convert.ToInt32(Console.ReadLine());

        }

        public void VisualizarCategoria()
        {
            if(contadorCategoria==0)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Não existem categorias");
                Console.ResetColor();
                Console.WriteLine("Pressione enter para continuar");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            for (int i = 0; i < contadorCategoria; i++)
            {
                Console.WriteLine("Nome da categoria: " + registroDeCategorias[i].nome);
                Console.WriteLine("Dias totais de emprestimo: " + registroDeCategorias[i].diasDeEmprestimo);
                //revistas na categoria
                for (int j = 0; j < registroDeCategorias[i].contadorDeRevistasNaCategoria; j++)
                {
                    if (registroDeCategorias[i].contadorDeRevistasNaCategoria==0)
                    {
                        break;
                    }
                    Console.WriteLine("revista: " + registroDeCategorias[j].qualrevista.colecao);
                }
            }
        }
    }
}
