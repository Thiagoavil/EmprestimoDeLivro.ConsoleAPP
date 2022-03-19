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
                Console.WriteLine("2- vsualizar categoria");
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
                Console.WriteLine("Qual a revista: " + registroDeCategorias[i].qualrevista.colecao);
                
            }
        }
    }
}
