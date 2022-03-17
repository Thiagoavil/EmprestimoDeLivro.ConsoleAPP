using System;

namespace EmpréstimoDeLivro
{
    internal class SubMenuRevistas
    {
        public SubMenuCaixa CaixaUtilizada;
        public int contadorRevista = 0;
        public Revista[] registroDeRevista = new Revista[100];
        string opcaoSubMenu = "0";

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
                else if (opcaoSubMenu=="2")
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
            if (CaixaUtilizada.contadorCaixa == 0)
            {
                Console.WriteLine("Não existem caixas criadas");
            }
            else
            {
                registroDeRevista[contadorRevista] = new Revista();

                Console.WriteLine("Digite a coleção da revista: ");
                registroDeRevista[contadorRevista].colecao = Console.ReadLine();

                Console.WriteLine("Digite a edição da revista: ");
                registroDeRevista[contadorRevista].edicao = Console.ReadLine();

                Console.WriteLine("Digite o ano de lançamento da revista: ");
                registroDeRevista[contadorRevista].anoDeLancamento = Console.ReadLine();

                while (true)
                {
                    CaixaUtilizada.MostrarCaixa();

                    Console.WriteLine("Digite o Id da caixa onde irá guardar");
                    int seletorDaCaixa = Convert.ToInt32(Console.ReadLine());
                    if (CaixaUtilizada.registroDeCaixas[seletorDaCaixa].contadorDeRevistasNaCaixa == 10)
                    {
                        Console.WriteLine("Essa caixa está cheia, selecione outra caixa");
                        continue;
                    }
                    else
                    {
                        registroDeRevista[contadorRevista].qualCaixa = CaixaUtilizada.registroDeCaixas[seletorDaCaixa];
                        break;
                    }


                }
                contadorRevista++;
            }
            Console.Clear();
        }
        public void MostrarRevista()
        {
            for (int i = 0; i < contadorRevista; i++)
            {
                Console.WriteLine("id: " + i);
                Console.WriteLine("Coleção: " + registroDeRevista[i].colecao);
                Console.WriteLine("Edição: " + registroDeRevista[i].edicao);
                Console.WriteLine("Ano de lançamento: " + registroDeRevista[i].anoDeLancamento);
                Console.WriteLine("Cor/numero da caixa: " + registroDeRevista[i].qualCaixa.cor+"/"+registroDeRevista[i].qualCaixa.numero);
                Console.WriteLine("");
            }
        }
    }
}
