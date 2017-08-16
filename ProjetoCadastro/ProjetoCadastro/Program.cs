using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int[] codigoAtleta = new int[10];
        string[] nomeAtleta = new string[10];
        int opcao;
        do
        {
            Console.WriteLine("[ 1 ] Cadastrar Atleta");
            Console.WriteLine("[ 2 ] Alterar Registro");
            Console.WriteLine("[ 3 ] Excluir Registro");
            Console.WriteLine("[ 4 ] Listar Atletas");
            Console.WriteLine("[ 5 ] Sair do programa");
            Console.WriteLine("-------------------------------------");
            Console.Write("Digite uma opção: ");
            opcao = Int32.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    cadastraAtleta(ref codigoAtleta, ref nomeAtleta);
                    break;
                case 2:
                    alteraAtleta(ref codigoAtleta, ref nomeAtleta);
                    break;
                case 3:
                    excluiAtleta(ref codigoAtleta, ref nomeAtleta);
                    break;
                case 4:
                    listaAtleta(ref codigoAtleta, ref nomeAtleta);
                    break;
                default:
                    saiPrograma();
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        }
        while (opcao != 0);
    }

    private static void listaAtleta(ref int[] codigoAtleta, ref string[] nomeAtleta)
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------------------------------");
        Console.WriteLine("***************| RELATORIO DE ATLETAS |**************************");
        Console.WriteLine("----------------------------------------------------------------");
        Console.WriteLine("-------Codigo--------Atleta--------------------------------------");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("        {0}           {1}", codigoAtleta[i], nomeAtleta[i]);
        }
        Console.WriteLine("----------------------------fim relatório----------------------");
    }

    private static void excluiAtleta(ref int[] codigoAtleta, ref string[] nomeAtleta)
    {
        Console.Clear();
        int i;
        Console.WriteLine("----------------------------------------------------------------");
        Console.WriteLine("***************| EXCLUSÃO DE REGISTRO |********************");
        Console.WriteLine("----------------------------------------------------------------");
        Console.Write("Digite a posicao do vetor que deseja CANCELAR: ");
        i = Int32.Parse(Console.ReadLine());
        codigoAtleta[i] = 0;
        nomeAtleta[i] = "";
        Console.WriteLine("Registro EXCLUÍDO com Sucesso !");
    }

    private static void alteraAtleta(ref int[] codigoAtleta, ref string[] nomeAtleta)
    {
        Console.Clear();
        int i;
        Console.WriteLine("----------------------------------------------------------------");
        Console.WriteLine("***************| ALTERAÇÃO DE REGISTRO |********************");
        Console.WriteLine("----------------------------------------------------------------");
        Console.Write("Digite a posicao do vetor que deseja ALTERAR: ");
        i = Int32.Parse(Console.ReadLine());
        codigoAtleta[i] = 0;
        nomeAtleta[i] = "";
        Console.WriteLine("Registro ALTERADO com Sucesso !");
    }

    private static void saiPrograma()
    {
        Console.WriteLine();
        Console.WriteLine("Bye Bye, vc saiu do Programa. Clique qq tecla para sair...");
    }

    private static void cadastraAtleta(ref int[] codigoAtleta, ref string[] nomeAtleta)
    {
        Console.Clear();
        bool jaExiste = false;
        bool codigoEstaNoIntervalo;
        int i = 0;
        do
        {
            jaExiste = false;
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("******************| CADASTRO DE ATLETAS |***********************");
            Console.WriteLine("----------------------------------------------------------------");
            Console.Write("Digite a posicao do vetor que deseja cadastrar: ");
            i = Int32.Parse(Console.ReadLine());
            Console.Write("Código do atleta na Posição {0}: ", i);
            codigoAtleta[i] = Int32.Parse(Console.ReadLine());
            codigoEstaNoIntervalo = verificaCodigoIntervalo(codigoAtleta[i]);
            jaExiste = verificaCodigoJaExiste(codigoAtleta[i], i, codigoAtleta);

            if (jaExiste == false)
            {
                if (codigoEstaNoIntervalo == false)
                {
                    Console.WriteLine("O Código do aluno deve ser entre 1 e 1000!");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.Write("Nome do atleta na Posição {0}: ", i);
                    nomeAtleta[i] = Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("O Código do atleta {0} já existe!", codigoAtleta[i]);
                codigoAtleta[i] = 50000;
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (codigoAtleta[i] < 1 || codigoAtleta[i] > 1000);
        Console.WriteLine("Atleta cadastrado com Sucesso !");
    }

    private static bool verificaCodigoJaExiste(int codigoDigitado, int posicaoCodigoDigitado, int[] vetor)
    {
        bool jaExiste = false;
        for (int i = 0; i < vetor.Length; i++)
        {
            if (vetor[i] == codigoDigitado && i != posicaoCodigoDigitado)
            {
                jaExiste = true;
            }
        }
        return jaExiste;
    }

    private static bool verificaCodigoIntervalo(int codigo)
    {
        bool estaNoIntervalo = false;
        if (codigo > 0 && codigo <= 1000)
            estaNoIntervalo = true;
        else
            estaNoIntervalo = false;

        return estaNoIntervalo;
    }
}