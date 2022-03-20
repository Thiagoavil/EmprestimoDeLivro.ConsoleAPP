using System;

namespace EmprestimoDeLivro
{
    internal class SubMenuRevistas
    {
        public SubMenuCaixa CaixaRevista;
        public SubMenuCategorias CategoriaRevistas;
        public int contadorRevista = 0;
        public Revista[] registroDeRevista = new Revista[100];
        string opcaoSubMenu = "0";
        int seletorDaCaixa;


        public void MenuRevista()
        {
            while (true)
            {
                Console.WriteLine("Menu de revistas");
                Console.WriteLine("----------------------");
                Console.WriteLine("1- Para cadastrar revista");
                Console.WriteLine("2- Para mostrar revistas");
                Console.WriteLine("s- Para sair");
                opcaoSubMenu = Console.ReadLine();

                if (opcaoSubMenu == "1")
                {
                    Console.Clear();
                    CadastrarRevistas();
                }
                else if (opcaoSubMenu == "2")
                {
                    Console.Clear();
                    MostrarRevista();
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




        public void CadastrarRevistas()
        {
            registroDeRevista[contadorRevista] = new Revista();

            //validar categoria criada
            if (CategoriaRevistas.contadorCategoria == 0)
            {
                Console.Clear();
                Console.WriteLine("Não existem categorias criadas");
                return;
            }
            //validar caixa criada
            if (CaixaRevista.contadorCaixa == 0)
            {
                Console.WriteLine("Não existem caixas criadas");
                return;
            }

            Console.WriteLine("Digite a coleção da revista: ");
            registroDeRevista[contadorRevista].colecao = Console.ReadLine();

            Console.WriteLine("Digite a edição da revista: ");
            registroDeRevista[contadorRevista].edicao = Console.ReadLine();

            Console.WriteLine("Digite o ano de lançamento da revista: ");
            registroDeRevista[contadorRevista].anoDeLancamento = Console.ReadLine();

            Console.Clear();
            CategoriaRevistas.VisualizarCategoria();

            Console.WriteLine("Digite o Id Da categoria");
            int seletorCategoria = Convert.ToInt32(Console.ReadLine());
            registroDeRevista[contadorRevista].qualCategoria = CategoriaRevistas.
                registroDeCategorias[seletorCategoria];
            Console.Clear();

            while (true)
            {
                CaixaRevista.MostrarCaixa();

                Console.WriteLine("Digite o Id da caixa onde irá guardar");
                seletorDaCaixa = Convert.ToInt32(Console.ReadLine());
                if (CaixaRevista.registroDeCaixas[seletorDaCaixa].contadorDeRevistasNaCaixa == 10)
                {
                    Console.WriteLine("Essa caixa está cheia, selecione outra caixa");
                    continue;
                }
                else
                {
                    registroDeRevista[contadorRevista].qualCaixa = CaixaRevista.registroDeCaixas[seletorDaCaixa];
                    break;
                }


            }


            while (true)
            {
                CategoriaRevistas.VisualizarCategoria();

                Console.WriteLine("Digite o Id da categoria selecionada");
                int seletorDaCategoria = Convert.ToInt32(Console.ReadLine());
                //validar se a categoria esrá cheia
                if (CategoriaRevistas.registroDeCategorias[seletorCategoria].contadorDeRevistasNaCategoria < 20)
                {
                    registroDeRevista[contadorRevista].qualCategoria = CategoriaRevistas.registroDeCategorias[seletorDaCategoria];

                    break;
                }
                else
                {
                    Console.WriteLine("Essa categoria está cheia");
                    return;

                }
            }
            
            //guardando a revista na categoria
            CategoriaRevistas.registroDeCategorias[seletorCategoria].
                InserirRevistaNaCategoria(registroDeRevista[contadorRevista]);
           
            //guardando a revista na caixa
            CaixaRevista.registroDeCaixas[seletorDaCaixa].
                InserirRevistaNaCaixa(registroDeRevista[contadorRevista]);
            
            contadorRevista++;

            Console.Clear();
        }
        public void MostrarRevista()
        {
            if (contadorRevista == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não existem Revistas");
                Console.ResetColor();
                Console.WriteLine("Pressione enter para continuar");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            for (int i = 0; i < contadorRevista; i++)
            {
                Console.WriteLine("id: " + i);
                Console.WriteLine("Coleção: " + registroDeRevista[i].colecao);
                Console.WriteLine("Edição: " + registroDeRevista[i].edicao);
                Console.WriteLine("Ano de lançamento: " + registroDeRevista[i].anoDeLancamento);
                Console.WriteLine("Cor/numero da caixa: " + registroDeRevista[i].qualCaixa.cor + "/" +
                    registroDeRevista[i].qualCaixa.numero);
                Console.WriteLine("Categoria: " + registroDeRevista[i].qualCategoria.nome);
                Console.WriteLine("");
            }
        }
    }
}
