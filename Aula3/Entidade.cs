using System;

public abstract class Entidade {
    private String nome;
    private double grana;
    private int empregados;
    private double salarios;
    
    protected string Nome { get => nome; set => nome = value; }
    protected double Grana { get => grana; set => grana = value; }
    protected int Empregados { get => empregados; set => empregados = value;}
    protected double Salarios { get => salarios; set => salarios = value; }

    public double getGrana { get { return grana; } }
    public double recolherIr()
    {
        //O colaborador tem 25 % do seu salário descontado como imposto.
        return salarios*empregados*0.25;
    }
    public virtual double pagarEmpregado()
    { 
        grana -= empregados * salarios;
        return salarios;
    }

    public virtual void passarAno()
    {
        Console.WriteLine($"Nome: {Nome}\nSaldo: R$ {Grana}");

    }


}
