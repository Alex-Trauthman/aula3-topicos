using System;

public class Industria : Entidade
{
    private double custoProducao;
    private double precoVenda;
    private double impostoPagoMensal;
    private double impostoPagoAnual;
    public double ImpostoPagoMensal { get => impostoPagoMensal; set => impostoPagoMensal = value; }
    public double ImpostoPagoAnual { get => impostoPagoAnual; set => impostoPagoAnual = value; }

    public void produzir(int quantidade)
    {
        Grana -= quantidade * custoProducao;
    }
    public void vender(int quantidade)
    {
        //Indústria: Recolhe 18% de impostos sobre cada item vendido ao Comércio.
        Grana += quantidade * precoVenda * 0.82;
        ImpostoPagoMensal = quantidade * precoVenda * 0.18;
        Console.WriteLine($"Industria: feito {(quantidade * precoVenda * 0.82)- (quantidade *custoProducao)} esse mês");
    }
    override public double pagarEmpregado()
    {
        //Para cada colaborador, a Indústria e o Comércio recolhem 61% de impostos e/ou obrigações sobre o salário bruto.
        Grana -= Empregados * Salarios * 1.61;
        Console.WriteLine($"Industria: pago {Empregados * Salarios * 1.61} esse mês");
        ImpostoPagoMensal += Empregados * Salarios * 0.61;
        return Salarios;
    }


    override public void passarAno()
    {
        Console.WriteLine($"Nome: {Nome}\nSaldo: R$ {Grana}\nArrecadação: R$ {ImpostoPagoAnual}");

    }
    public Industria(double custoProducao, double precoVenda, String nome, int empregados, double salario, double grana)
    {
        this.Nome = nome;
        this.Salarios = salario;
        this.Empregados = empregados;
        this.Grana = grana;
        this.custoProducao = custoProducao;
        this.precoVenda = precoVenda;
    }
}
