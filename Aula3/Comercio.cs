using System;
using System.Security.Cryptography.X509Certificates;

public class Comercio : Entidade
{
    //Custo de reposição de estoque: R$ 75,00 por item adquirido da Indústria
    private double custoCompra = 75 ;
    //Preço de venda de cada item no comércio: R$ 203,00
    private double precoVenda = 203 ;
    //Usado para parar a execução em caso de impossibilidade de venda para população economicamente ativa
    private Boolean executavel = true;
    private double impostoPagoMensal;
    private double impostoPagoAnual;
    public int quantidadeMes =0;

    public Boolean Executavel { get { return executavel; } }
    public double ImpostoPagoMensal { get => impostoPagoMensal; set => impostoPagoMensal = value; }

    public double ImpostoPagoAnual { get => impostoPagoAnual; set => impostoPagoAnual = value; }
    override public double pagarEmpregado()
    {
        //Para cada colaborador, a Indústria e o Comércio recolhem 61% de impostos e/ou obrigações sobre o salário bruto.
        Grana -= Empregados * Salarios * 1.61;
        ImpostoPagoMensal += Empregados * Salarios * 0.61;
        return Salarios;
    }
    //Todos os membros da sociedade gastam todo o seu salário comprando itens no Comércio.
    public double[] reporEstoque(double[] dinheiroClasse, int[] pessoasClasse, Industria industria)
    {
        
        double[] restoSalario = new double[4];
        int quantidadeBeneficiario =0;
        //Pode ser ordem diferente, mas de preferência 0 funcionário prefeitura, 1 industria, 2 comercio ,porém, 3 sempre será beneficiário.
        for(int i = 0; i<=3; i++)
        {
            quantidadeMes += (int)(dinheiroClasse[i]/precoVenda * pessoasClasse[i]);
            restoSalario[i] = dinheiroClasse[i]%precoVenda;
            if (i == 3)
            {
                quantidadeBeneficiario = (int)(dinheiroClasse[i] / precoVenda * pessoasClasse[i]);
            }
        }
        double total = quantidadeMes * custoCompra;

        //Se não conseguir repor o estoque, a simulação deve ser interrompida.
        if (total > Grana)
        {
            //O Comércio precisa ter estoque suficiente para atender toda a população economicamente ativa.
            //Ou seja, a simulação ainda pode durar mais, se não contarmos com os beneficiários, que estão em classe 3, contando a partir do 0.
            total = total - dinheiroClasse[3] * pessoasClasse[3];
            quantidadeMes -= quantidadeBeneficiario;
            restoSalario[3] = quantidadeBeneficiario * precoVenda;
            //Nesse caso, o comércio realmente não consegue suprir a população economicamente ativa
            if (total< Grana)
            {
                executavel = false;
            }
        }

        
        Grana -= total;
        vender(quantidadeMes);
        return restoSalario;
    }
    private void vender(int quantidadeMes)
    {
        
        //Comércio: Recolhe 38% de impostos sobre cada item vendido. 
        ImpostoPagoMensal += quantidadeMes * precoVenda * 0.38;
        Grana += quantidadeMes * precoVenda * 0.62;
    }

    override public void passarAno()
    {
        Console.WriteLine($"Nome: {Nome}\nSaldo: R$ {Grana}\nArrecadação: R$ {ImpostoPagoAnual}");

    }
    public Comercio(double custoCompra, double precoVenda, String nome, int empregados, double salario, double grana)
    {
        this.Nome = nome;
        this.Salarios = salario;
        this.Empregados = empregados;
        this.Grana = grana;
        this.custoCompra = custoCompra;
        this.precoVenda = precoVenda;
    }
}
