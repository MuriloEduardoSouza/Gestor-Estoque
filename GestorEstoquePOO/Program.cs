using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GestorEstoquePOO
{

    class Program
    {
        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }
        static void Main(string[] args)
        {
            Carregar();
            bool escolheuSair = false;

            while (escolheuSair == false)
            {
                Console.WriteLine("Sistema de Estoque");
                Console.WriteLine("1 - Listar\n2 - Adicionar\n3 - Remover\n4 - Entrada\n5 - Saida\n6 - Sair");
                int OpInt = int.Parse(Console.ReadLine());
                if (OpInt > 0 && OpInt < 7)
                {
                    Menu escolha = (Menu)OpInt;
                    switch (escolha)
                    {
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saida:
                            AdicionarSaida();
                            break;
                        case Menu.Sair:
                            escolheuSair = true;
                            break;

                    }
                }
                else
                {
                    escolheuSair = true;
                }
                Console.Clear();
            }
        }

        static void Listagem()
        {
            Console.WriteLine("Lista de Produtos: ");
            int i = 0;
            foreach(IEstoque produto in produtos)
            {
                Console.WriteLine("ID: " + i);
                produto.Exibir();
                i++;
            }
            Console.ReadLine();
        }

        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que voce deseja remover: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }
            else
            {
                Console.WriteLine("ID Inválido !");
            }
        }

        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que voce deseja dar entrada: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }
        }

        static void AdicionarSaida()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que voce deseja dar Saida: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }
        }
        static void Cadastro()
        {
            Console.WriteLine("Cadastro de Produto");
            Console.WriteLine("1 - Produto Físico\n2 - Ebook\n3 - Curso");
            string opStr = Console.ReadLine();
            int escolhaInt = int.Parse(opStr);

            switch (escolhaInt)
            {
                case 1:
                    CadastrarProdutoFisico();
                    break;
                case 2:
                    CadastrarEbook();
                    break;
                case 3:
                    CadastrarCurso();
                    break;
            }

        }


        static void CadastrarProdutoFisico()
        {
            Console.WriteLine("Cadastrando Produto Fisico: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Preco: ");
            float preco = float.Parse(Console.ReadLine());

            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());
            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
        }
            static void CadastrarEbook()
            {
                Console.WriteLine("Cadastrando Ebook: ");
                Console.WriteLine("Nome: ");
                string nome = Console.ReadLine();

                Console.WriteLine("Preco: ");
                float preco = float.Parse(Console.ReadLine());

                Console.WriteLine("Autor: ");
                string autor = Console.ReadLine();

                Ebook eb = new Ebook(nome, preco, autor);
                produtos.Add(eb);
                Salvar();
            }

            static void CadastrarCurso()
            {
                Console.WriteLine("Cadastrando Curso: ");
                Console.WriteLine("Nome: ");
                string nome = Console.ReadLine();

                Console.WriteLine("Preco: ");
                float preco = float.Parse(Console.ReadLine());

                Console.WriteLine("Autor: ");
                string autor = Console.ReadLine();

                Curso cs = new Curso(nome, preco, autor);
                produtos.Add(cs);
                Salvar();
            }

            static void Salvar()
            {
                FileStream stream = new FileStream("Produtos.dat", FileMode.OpenOrCreate);
                BinaryFormatter encoder = new BinaryFormatter();

                encoder.Serialize(stream, produtos);

                stream.Close();

            }

        static void Carregar()
        {
            FileStream stream = new FileStream("Produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);

                if(produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            }catch(Exception e)
            {
                produtos = new List<IEstoque>();
            }
            stream.Close();
        }
     }
  }

