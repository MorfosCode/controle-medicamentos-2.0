using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    internal class TelaMedicamento : TelaBase
    {
        public TelaFornecedor telafornecedor = null;
        public RepositorioFornecedor repositorioFornecedor = null;

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Medicamentos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -20}",
                "Id", "Nome uncionario", "Fornecedor","Quantidade"
            );

            EntidadeBase[] medicamentosCadastrados = repositorio.SelecionarTodos();

            foreach (Medicamento medicamento in medicamentosCadastrados)
            {
                if (medicamento == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20}",
                    medicamento.Id, medicamento.Nome, medicamento.Fornecedor, medicamento.Quantidade
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nomeFuncionario: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite o lote: ");
            string lote = Console.ReadLine();

            Console.Write("Digite a data de validade: ");
            DateTime dataValidade = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite a quantidade disponivel do medicamento: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            telafornecedor.VisualizarRegistros(false);
            Console.Write("Digite o ID do Fornecedor da medicação: ");
            int idFornecedor = Convert.ToInt32(Console.ReadLine());

            Fornecedor fornecedorSelecinado = (Fornecedor)repositorioFornecedor.SelecionarPorId(idFornecedor);



            Medicamento medicamento = new Medicamento(nome, descricao, lote, dataValidade, idFornecedor,quantidade);

            return medicamento;
        }
    }
}
