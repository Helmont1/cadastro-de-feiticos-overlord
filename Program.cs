using cadastro_de_series.models;
using System;

internal class Program
{
    static RepositorioFeitico repositorio = new RepositorioFeitico();

    private static void Main(string[] args)
    {

        string opcaoUsuario = ObterOpcaoUsuario();

        while (opcaoUsuario.ToUpper() != "X")
        {
            switch (opcaoUsuario)
            {
                case "1":
                    InserirFeitico();
                    break;
                case "2":
                    ListarFeiticos();
                    break;
                case "3":
                    AtualizarFeitico();
                    break;
                case "4":
                    ExcluirFeitico();
                    break;
                case "5":
                    VisualizarFeitico();
                    break;
                case "C":
                    System.Console.Clear();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Insira uma opcao valida");

            }
            opcaoUsuario = ObterOpcaoUsuario();
        }
    }

    private static void VisualizarFeitico()
    {
        System.Console.WriteLine("Digite o id do feitico que deseja visualizar");
        int indiceFeitico = int.Parse(Console.ReadLine());

        var feitico = repositorio.RetornaPorId(indiceFeitico);

        System.Console.WriteLine(feitico);
    }

    private static void ExcluirFeitico()
    {
        System.Console.WriteLine("Digite o id do feitico que deseja excluir");
        int id = int.Parse(Console.ReadLine());
        repositorio.Exclui(id);
    }

    static void AtualizarFeitico()
    {
        System.Console.WriteLine("Digite o id do feitico que deseja atualizar: ");
        int indiceFeitico = int.Parse(Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(Tier)))
        {
            System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Tier), i));
        }
        System.Console.Write("Digite o Tier entre as opcoes acima: ");
        int entradaTier = int.Parse(Console.ReadLine());

        System.Console.Write("Digite o nome do feitico: ");
        string entradaNome = Console.ReadLine();

        System.Console.Write("Digite a descricao do feitico: ");
        string entradaDescricao = Console.ReadLine();

        Feitico atualizaFeitico = new Feitico(id: indiceFeitico,
                                          tier: (Tier)entradaTier,
                                          nome: entradaNome,
                                          descricao: entradaDescricao);
        repositorio.Atualiza(indiceFeitico, atualizaFeitico);
    }

    static void ListarFeiticos()
    {
        Console.WriteLine("Lista de feiticos");

        if (repositorio.Lista().Count == 0)
        {
            Console.WriteLine("Nenhum feitico cadastrado");
            return;
        }

        foreach (var feitico in repositorio.Lista())
        {
            if(feitico.EstaExcluido())
            {
                continue;
            }
            Console.WriteLine($"ID:{feitico.retornaId()} - Nome:{feitico.retornaNome()}");
        }

    }

    static void InserirFeitico()
    {
        System.Console.WriteLine("Inserir feitico");

        foreach (int i in Enum.GetValues(typeof(Tier)))
        {
            System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Tier), i));
        }
        System.Console.Write("Digite o Tier entre as opcoes acima: ");
        int entradaTier = int.Parse(Console.ReadLine());

        System.Console.Write("Digite o nome do feitico: ");
        string entradaNome = Console.ReadLine();

        System.Console.Write("Digite a descricao do feitico: ");
        string entradaDescricao = Console.ReadLine();

        Feitico novoFeitico = new Feitico(id: repositorio.ProximoId(),
                                          tier: (Tier)entradaTier,
                                          nome: entradaNome,
                                          descricao: entradaDescricao);
        repositorio.Insere(novoFeitico);

    }

    static string ObterOpcaoUsuario()
    {
        System.Console.WriteLine();
        System.Console.WriteLine("Feiticos do Ainz Ooal Gown");
        System.Console.WriteLine("Informe a opcao desejada:");

        System.Console.WriteLine("1 - Cadastrar novo feitico");
        System.Console.WriteLine("2 - Listar feiticos");
        System.Console.WriteLine("3 - Atualizar feitico");
        System.Console.WriteLine("4 - Excluir feitico");
        System.Console.WriteLine("5 - Visualizar feitico");
        System.Console.WriteLine("C - Limpar Tela");
        System.Console.WriteLine("X - Sair");
        System.Console.WriteLine();

        string opcaoUsuario = Console.ReadLine().ToUpper();
        System.Console.WriteLine();
        return opcaoUsuario;
    }
}