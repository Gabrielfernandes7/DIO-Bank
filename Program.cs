using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {

        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args){

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "x"){
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas(); 
                        break;
                    case "2":
                        InserirContas(); 
                        break;
                    case "3":
                        Transferir(); 
                        break;
                    case "4":
                        Sacar(); 
                        break;
                    case "5": 
                        Depositar(); 
                        break;
                    case "C": Console.Clear(); break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utiçizar os nossos serviços");
            Console.ReadLine();
        }


        private static void Transferir(){
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de origem: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }
        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());
        }

        private static void Sacar(){
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Deposite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }
        private static void InserirContas()
        {
            Console.WriteLine("Inserir nova conta");

            // Tipo da conta
            Console.Write("Digite 1 para Conta Física ou 2 para conta Jurídica");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            // Nome do cliente
            Console.Write("Digite o nome do clinte");
            string entradaNome = Console.ReadLine();

            // Saldo inicial
            Console.Write("Digite o saldo inicial");
            double entradaSaldo = double.Parse(Console.ReadLine());

            // Crédito
            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());


            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            listContas.Add(novaConta);
        }
        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listContas.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++){
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario(){

            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor");
            Console.WriteLine("Informe a opcao desejada");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("6 - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;
        }
    }
}