using System;

public class Prefeitura : Entidade
{
	int beneficiarios = 55;
	int beneficio = 1000;

    public Prefeitura(int beneficiarios, int beneficio,String nome,int empregados, double salarios)
    {
		this.Nome = nome;
		this.Grana = 0;
		this.Empregados = empregados;
		this.Salarios = salarios;
        this.beneficiarios = beneficiarios;
        this.beneficio = beneficio;
    }

    public void ReceberArrecadacao(double valor)
	{
		Grana += valor;
	}
	public double pagarBeneficiarios()
	{
		Grana -= beneficiarios * beneficio;
		return beneficio;
	}
    public double passarMes()
    {
		pagarEmpregado();
		return pagarBeneficiarios();
    }

}
