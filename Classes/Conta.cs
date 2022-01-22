using System;

namespace DIO.Bank
{
   public class Conta{

      // Atributos da classe Conta
      // Atributos privados (encapsulamento)
      private TipoConta TipoConta { get; set; }

      private double Saldo { get; set; }

      private double Credito { get; set; }

      private string Nome { get; set; }


      // Método construtor
      // Método chamando no momento que é criado meu objeto
      public Conta(TipoConta tipoConta, double saldo, double credito, string nome){
         this.TipoConta = tipoConta;
         this.Saldo = saldo;
         this.Credito = credito;
         this.Nome = nome;
      }

      public bool Sacar(double valorSaque){
         // Validação do saldo suficiente
         /*
            Se o valor de saque for >= Credito retorne true
            Se o valor de saque for < Credtio retorne false
         */

         if (this.Saldo - valorSaque < (this.Credito *-1)){
            Console.WriteLine("Saldo Insuficiente!");
            return false;
         }

         this.Saldo = this.Saldo - valorSaque;

         Console.WriteLine("O saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

         return true;

      }

      public void Depositar(double valorDeposito){
            this.Saldo = this.Saldo + valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
      }

      public void Transferir(double valorTransferencia, Conta contaDestino){
         if(this.Sacar(valorTransferencia)){
            contaDestino.Depositar(valorTransferencia);
         }
      }

      /* 
         Como o método ToString já exite, utilizaremos
         override para sobrescrever
      */

      public override string ToString(){
         string retorno = "TipoConta " + this.TipoConta + " | ";
         retorno += "Nome " + this.Nome + " | ";
         retorno += "Saldo " + this.Saldo + " | ";
         retorno += "Crédito " + this.Credito;
         return retorno;
      }
      
   } 
}