
namespace Calculadora.ConsoleApp
{
    internal class Program
    {
        static string[] historicoOperacoes = new string[100]; //arreios
        static int contadorHistorico = 0;
        static void Main(string[] args)
        {
            while (true) // enquanto verdadeiro for verdadeiro
            {
                string opcao = ExibirMenu();

                if (OpcaoSairEscolhida(opcao) == true)
                    break;

                else if (OpcaoTabuadaFoiEscolhida(opcao))
                    ExibirTabuada();

                else if (OpcaoHistoricoFoiEscolhido(opcao))
                    ExibirHistoricoOperacoes();

                else
                    ExibirResultado(RealizarCalculo(opcao));
                
            }
        }
        static string ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Calculadora Tabajara 2025");
            Console.WriteLine("-------------------------------");

            Console.WriteLine("1 - Somar");
            Console.WriteLine("2 - Subtrair");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");
            Console.WriteLine("5 - Tabuada");
            Console.WriteLine("6 - Histórico de Operações");
            Console.WriteLine("S - Sair");

            Console.WriteLine();
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine()!.ToUpper();

            return opcao;
        }

        static bool OpcaoSairEscolhida(string opcao)
        {
            bool OpcaoSairFoiEscolhida = opcao == "S";

            return OpcaoSairFoiEscolhida;
        }

        static bool OpcaoTabuadaFoiEscolhida(string opcao)
        {
            bool OpcaoTabuadaFoiEscolhida = opcao == "5";

            return OpcaoTabuadaFoiEscolhida;
        }

        static bool OpcaoHistoricoFoiEscolhido(string opcao)
        {
            bool OpcaoHistoricoFoiEscolhido = opcao == "6";
            return OpcaoHistoricoFoiEscolhido;
        }
        static void ExibirTabuada()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Tabuada");
            Console.WriteLine("--------------------------------");

            Console.Write("Digite o número: ");
            int numeroTabuada = Convert.ToInt32(Console.ReadLine());

            for (int contador = 1; contador <= 10; contador++)
            {
                int resultadoTabuada = numeroTabuada * contador;

                Console.WriteLine($"{numeroTabuada} x {contador} = {resultadoTabuada}");
            }

            Console.ReadLine();
        }

        static void ExibirHistoricoOperacoes()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Historico de Operações");
            Console.WriteLine("--------------------------------");

            for (int contador = 0; contador < historicoOperacoes.Length; contador++)
            {
                string valorAtual = historicoOperacoes[contador];

                if (valorAtual != null)
                    Console.WriteLine(historicoOperacoes[contador]);
            }

            Console.WriteLine("Aperte ENTER para continuar");
            Console.ReadLine();
        }

        static decimal RealizarCalculo (string operacao)
        {
            Console.Write("Digite o primeiro número: ");
            decimal primeiroNumero = Convert.ToDecimal(Console.ReadLine()!);

            Console.Write("Digite o segundo número: ");
            decimal segundoNumero = Convert.ToDecimal(Console.ReadLine()!);

            decimal resultado = 0;

            if (operacao == "1")
            {
                resultado = primeiroNumero + segundoNumero;
                historicoOperacoes[contadorHistorico] = $"{primeiroNumero} + {segundoNumero} = {resultado}";
            }

            else if (operacao == "2")
            {
                resultado = primeiroNumero - segundoNumero;
                historicoOperacoes[contadorHistorico] = $"{primeiroNumero} - {segundoNumero} = {resultado}";
            }

            else if (operacao == "3")
            {
                resultado = primeiroNumero * segundoNumero;
                historicoOperacoes[contadorHistorico] = $"{primeiroNumero} * {segundoNumero} = {resultado}";
            }

            else if (operacao == "4")
            {
                while (segundoNumero == 0)
                {
                    Console.Write("Não é possível dividir por 0\n Digite o segundo número novamente -> ");

                    segundoNumero = Convert.ToDecimal(Console.ReadLine());
                }

                resultado = primeiroNumero / segundoNumero;
                historicoOperacoes[contadorHistorico] = $"{primeiroNumero} / {segundoNumero} = {resultado}";
            }

                contadorHistorico += 1;
                return resultado;
        }

        static void ExibirResultado (decimal resultado)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Resultado: " + resultado.ToString("F2"));
            Console.WriteLine("--------------------------------");

            Console.ReadLine();
        }
    }
}
