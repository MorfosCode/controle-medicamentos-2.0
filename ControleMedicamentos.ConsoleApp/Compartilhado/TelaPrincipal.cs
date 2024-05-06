namespace ControleMedicamentos.ConsoleApp.Compartilhado
{
    internal static class TelaPrincipal
    {
        public static char ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|       Controle de Medicamentos       |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Cadastro de Funcionarios");
            Console.WriteLine("2 - Cadastro de Fornecedor");
            Console.WriteLine("3 - Cadastro de Medicamento");
            Console.WriteLine("4 - Cadastro de Paciente");
            Console.WriteLine("5 - Cadastro de Requisições de Entrada");
            Console.WriteLine("6 - Cadastro de Requisicões de Saida");
            Console.WriteLine();
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");

            char opcaoEscolhida = Console.ReadLine()[0];

            return opcaoEscolhida;
        }
    }
}
