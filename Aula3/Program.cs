public class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("O programa será executado, no momento estamos no mês 0");
        Prefeitura prefeitura = new Prefeitura(55, 1000, "Prefeitura de Palmas", 125, 20000);
        Industria industria = new Industria(42.75, 75, "Setor Industrial de Palmas", 675, 10000, 50000000);
        Comercio comercio = new Comercio(75, 203, "Setor Comercial de Palmas", 200, 7500, 10000000);
        int contMeses = 0;

        double impostoRendaAnual = 0;

        //deduzido 25% pelo IR, com excessão de beneficiários
        double[] classesEconomicas = { 15000, 7500, 5625, 1000 };
        int[] pessoasClasse = { 125, 675, 200, 55 };
        
            while (industria.getGrana > 0 && comercio.Executavel == true)
            {
                Console.WriteLine($"Mês: {contMeses}, Grana da Indústria: {industria.getGrana}, Executável: {comercio.Executavel}");

                double impostoRendaMes = 0;
                double impostoArrecadadoMes = 0;

                contMeses++;
                classesEconomicas[3] += prefeitura.passarMes();
                double[] SobraSalario = comercio.reporEstoque(classesEconomicas, pessoasClasse, industria);
                int quantidade = comercio.quantidadeMes;
                industria.produzir(quantidade);
                industria.vender(quantidade);

                comercio.quantidadeMes = 0;

                for (int i = 0; i < 3; i++)
                {
                    classesEconomicas[i] += SobraSalario[i];
                }

                industria.pagarEmpregado();
                comercio.pagarEmpregado();

                impostoRendaMes = industria.recolherIr() + comercio.recolherIr() + prefeitura.recolherIr();
                impostoArrecadadoMes = impostoRendaMes + comercio.ImpostoPagoMensal + industria.ImpostoPagoMensal;
                prefeitura.ReceberArrecadacao(impostoArrecadadoMes);


                impostoRendaAnual += impostoRendaMes;
                industria.ImpostoPagoAnual += industria.ImpostoPagoMensal;
                comercio.ImpostoPagoAnual += comercio.ImpostoPagoMensal;
                comercio.ImpostoPagoMensal = 0;
                industria.ImpostoPagoMensal = 0;
                Console.WriteLine($"\n{contMeses }° mes se passou, confira as entidades:");
                prefeitura.passarAno();
                industria.passarAno();
                comercio.passarAno();

                if (contMeses % 12 == 0)
                {
                    Console.WriteLine($"\n{contMeses / 12}° ano se passou, confira as entidades:");
                    prefeitura.passarAno();
                    industria.passarAno();
                    comercio.passarAno();

                    arrecadacaoPopulacao(impostoRendaAnual);
                    impostoRendaAnual = 0;
                    comercio.ImpostoPagoAnual = 0;
                    industria.ImpostoPagoAnual = 0;
                }
            }
        Console.WriteLine($"\nSimulação terminada, foram {contMeses / 12} anos");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }
    public static void arrecadacaoPopulacao(double impostoRecolhido)
    {
        Console.WriteLine($" \n Imposto recolhido da população através do IR R$ {impostoRecolhido}");
    }
    

}