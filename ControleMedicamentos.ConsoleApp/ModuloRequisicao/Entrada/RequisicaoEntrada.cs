using System;
using System.Collections;
using System.Collections.Generic;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao.Entrada
{
    internal class RequisicaoEntrada : EntidadeBase
    {

        public Medicamento medicamento { get; set; }

        public Funcionario funcionario { get; set; }
        public DateTime DataRequisicao { get; set; }
        public int QuantidadeEntrada { get; set; }


        public RequisicaoEntrada(Medicamento medicamento, Funcionario funcionario, int quantidade)
        {
            this.medicamento = medicamento;
            this.funcionario = funcionario;
            QuantidadeEntrada = quantidade;

            DataRequisicao = DateTime.Now;
        }

        public override ArrayList Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;

            if (medicamento == null)
                erros[contadorErros++] = "O medicamento precisa ser preenchido";

            if (funcionario == null)
                erros[contadorErros++] = "O funcionario precisa ser informado";

            if (QuantidadeEntrada < 1)
                erros[contadorErros++] = "Por favor informe uma quantidade válida";

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }

        public void EntradaMedicamento()
        {
            medicamento.Quantidade += QuantidadeEntrada;
        }
    }
}
