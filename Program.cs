using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("\nObrigado por utilizar o DIO Séries!.");
            Console.ReadLine();
        }

        private static void ExcluirSerie()
		{
			Console.Write("\nDigite o ID da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);

            Console.WriteLine("\n\nSérie excluída!\n\n");
		}

        private static void VisualizarSerie()
		{
			Console.Write("\nDigite o ID da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("\nDigite o ID da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);

            Console.WriteLine("\n\nSérie atualizada com sucesso!\n\n");
		}

        private static void InserirSerie()
		{
			Console.WriteLine("\nInserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("({0}) {1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("\nDigite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);

            Console.WriteLine("\n\nSérie inserida com sucesso!\n\n");
		}

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Series");
            
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("\nNenhuma série cadastrada.\n");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }

            Console.WriteLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("\nSeja bem-vindo ao DIO Séries!\n");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("\nInforme a opção deseja:\n");

            Console.WriteLine("(1) Listar séries");
            Console.WriteLine("(2) Inserir nova série");
            Console.WriteLine("(3) Atualizar série");
            Console.WriteLine("(4) Excluir série");
            Console.WriteLine("(5) Visualizar série");
            Console.WriteLine("(C) Limpar tela");
            Console.WriteLine("(X) Sair");
            Console.WriteLine("\n-----------------------------------------");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }     
}