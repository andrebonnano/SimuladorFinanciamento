using System;
using System.Globalization;

namespace SimuladorFinanciamento
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string Name;
            double PropertyValue, Fees;
            int Plots;
            string specifier = "N";
            CultureInfo culture = CultureInfo.CreateSpecificCulture("pt-BR");

            //Greetings
            Console.WriteLine("Olá, você irá simular o financiamento do seu imóvel utilizando a Tabela SAC, mas para isso precisa responder algumas perguntas.");

            //Data Collect
            Console.Write("qual o seu nome? ");
            Name = Console.ReadLine();
            Console.Write("Qual o valor do imóvel? R$");
            PropertyValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Em quantas parcelas pretende pagar? ");
            Plots = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Qual a porcentagem dos juros informado (ex: 7.5): ");
            Fees = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //Calculations
            double BalanceDue = PropertyValue;
            double Amortization = PropertyValue / (double)Plots;
            double Installment = 15324;
            double _Fees = 0;
            double TotalPaid = 0;
            double TotalFees = 0;
            Console.WriteLine("");
            Console.WriteLine($"Olá Sr.(a) {Name}, Segue a simulação para o financiamento do seu imóvel.");

            Console.WriteLine("---------------------------------------------------------------");
            for (int i = 0; i <= Plots; i++)
            {
                if (i > 0)
                {
                    Console.WriteLine(
                        "Mes: " + i +
                        " | Saldo Devedor: R$ " + BalanceDue.ToString(specifier, culture) +
                        " | Juros: R$ " + _Fees.ToString(specifier, culture) +
                        " | Prestação: R$ " + Installment.ToString(specifier, culture));
                }

                _Fees = BalanceDue * (Fees / 100);
                Installment = Amortization + _Fees;
                BalanceDue -= Amortization;
                TotalPaid += Installment;
                TotalFees += _Fees;
            }
            Console.WriteLine("---------------------------------------------------------------");

            Console.WriteLine($"Senhor(a) {Name}, Abaixo estão os valores totais do financiamento e juros: ");
            Console.WriteLine("O Valor total pago pelo imóvel será de R$ " + TotalPaid.ToString(specifier, culture));
            Console.WriteLine("O Total de jutos pago será de R$ " + TotalFees.ToString(specifier, culture));
        }
    }
}
