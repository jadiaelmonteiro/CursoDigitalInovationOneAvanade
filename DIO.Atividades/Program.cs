using System;

namespace DIO.Atividades

{
    class Program
    {
        static AtividadeRepositorio repositorio = new AtividadeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarAtividade();
						break;
					case "2":
						InserirAtividade();
						break;
					case "3":
						AtualizarAtividade();
						break;
					case "4":
						ConcluirAtividade();
						break;
					case "5":
						VisualizarAtividade();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Volte sempre, obrigado.");
			Console.ReadLine();
        }

        private static void ConcluirAtividade()
		{
			Console.Write("Digite o id da atividade: ");
			int indiceAtividade = int.Parse(Console.ReadLine());

			repositorio.Conclui(indiceAtividade);
		}

        private static void VisualizarAtividade()
		{
			Console.Write("Digite o id da atividade: ");
			int indiceAtividade = int.Parse(Console.ReadLine());

			var atividade = repositorio.RetornaPorId(indiceAtividade);

			Console.WriteLine(atividade);
		}

        private static void AtualizarAtividade()
		{
			Console.Write("Digite o id da atividade: ");
			int indiceAtividade = int.Parse(Console.ReadLine());


			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero da atividade entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Atividade: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite a data de término da atividade. *exemplo 00/00/00* : ");
			string entradaData = Console.ReadLine();

			Console.Write("Digite a Descrição da Atividade: ");
			string entradaDescricao = Console.ReadLine();

			Atividade atualizaAtividade = new Atividade(id: indiceAtividade,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										data: entradaData,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceAtividade, atualizaAtividade);
		}
        private static void ListarAtividade()
		{
			Console.WriteLine("Listar atividades");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma atividade cadastrada.");
				return;
			}

			foreach (var atividade in lista)
			{
                var concluido = atividade.retornaConcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", atividade.retornaId(), atividade.retornaTitulo(), (concluido ? "*Concluido*" : ""));
			}
		}

        private static void InserirAtividade()
		{
			Console.WriteLine("Inserir nova atividade");


			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero da atividade entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Atividade: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite a data de término da atividade. *exemplo 00/00/00* : ");
			string entradaData = Console.ReadLine();

			Console.Write("Digite a Descrição da Atividade: ");
			string entradaDescricao = Console.ReadLine();

			Atividade novaAtividade = new Atividade(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										data: entradaData,
										descricao: entradaDescricao);

			repositorio.Insere(novaAtividade);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Programa de Frentes!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar atividades");
			Console.WriteLine("2- Inserir nova atividade");
			Console.WriteLine("3- Atualizar atividade");
			Console.WriteLine("4- Concluir atividade");
			Console.WriteLine("5- Visualizar atividade");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
