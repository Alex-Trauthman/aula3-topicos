using System;

public class Prefeitura
{
	double grana =0;
	int empregados = 125;
	int salarios = 20000;
	int beneficiarios = 55;
	int beneficios = 1000;

	public double recolher impostoRenda()
	{
		grana += (empregados * salarios * 0.25)
	}
}
