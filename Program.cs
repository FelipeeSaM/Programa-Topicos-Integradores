using System;
using System.Timers;

namespace Trabalho_topicos
{
    class Program
    {
        public static void Main(string[] args) {
            int atualPedidos = 0;
            int maxPedidos = 0;
            string[] arrayPedidos = new string[10];
            string opcaoUsuario = obterOpcaoUsuario();
            
            while (opcaoUsuario != "6") {
                switch (opcaoUsuario) {
                    case "1":
                        incluirPedido();
                        break;
                    case "2":
                        liberarPedido();
                        break;
                    case "3":
                        listarPedidos();
                        break;
                    case "4":
						pesquisarPedido();
						break;
                    case "5":
						menuSair();
						break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = obterOpcaoUsuario();
            }


           void incluirPedido() {
                if(atualPedidos < 10) {
                Console.WriteLine("Insira um novo pedido:");
                string pedidoString = Console.ReadLine();
                arrayPedidos[atualPedidos] = pedidoString;
                atualPedidos++;
                maxPedidos++;
                Console.WriteLine(" ");
                } else {
                    Console.WriteLine("Há pedidos demais, favor aguardar liberação.");
                }
           }


           void liberarPedido() {
                if(atualPedidos == 0) {
                    Console.WriteLine("Lista de pedidos vazia. Impossível retirar pedido.\n");
                } else {
                    Console.WriteLine("Qual o número do pedido a ser retirado?");
                    int pedidoRetirado = int.Parse(Console.ReadLine());
                    Console.WriteLine($"O pedido {arrayPedidos[pedidoRetirado]} foi retirado com sucesso!");
                    for(int i = 1; i <= 10; i++) {
                        if (pedidoRetirado < 10) {
                            arrayPedidos[pedidoRetirado-1] = arrayPedidos[pedidoRetirado];
                            pedidoRetirado++;
                        }
                    }
                if(atualPedidos >= 1) {
                    atualPedidos--;
                }
                }
           }


            void pesquisarPedido(){
				Console.WriteLine("Digite o número do pedido:\n");
                int pedidoPesquisado = int.Parse(Console.ReadLine());
                if(pedidoPesquisado <= atualPedidos) {
                    Console.WriteLine($"\nO pedido de número {pedidoPesquisado} é o {arrayPedidos[pedidoPesquisado-1]}.\n");
                } else {
					Console.WriteLine($"O pedido de número {pedidoPesquisado} está inválido em nosso sistema.\n");
				}

			}


           void listarPedidos() {
               Console.WriteLine("Listagem dos pedidos: \n");
               int num = 1;
               foreach(string str in arrayPedidos) {
                   if (str != null) {
                       Console.WriteLine($"{num} - {str}");
                       num++;
                   }
               }
               Console.ReadKey();
               Console.WriteLine(" \n");
           }


           void menuSair() {
           if (atualPedidos != 0) {
			   Console.WriteLine($"Impossível realizar operação. Ainda existem {atualPedidos} a serem retirados.");
		   } else {
			        Console.WriteLine($"O número total de pedidos atendidos pela casa foi de {maxPedidos}\n" +
                    $"Obrigado por utilizar os nossos serviços. Dark o rei das trevas SA.\n");
                    Console.Clear();
		          }
		   }
        }

        private static string obterOpcaoUsuario() {
            Console.WriteLine("Lanchonete tópicos entregadores SA, em que posso ajudar?");
            Console.WriteLine("###### LANCHONETE ######\n# 1 - Incluir pedido   #\n# 2 - Atender pedido   #\n# 3 - Listar pedidos   #");
            Console.WriteLine("# 4 - Pesquisar pedido #\n# 5 - Encerrar         #\n########################\n");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine(" ");
            return opcaoUsuario;
        }
    }

}

