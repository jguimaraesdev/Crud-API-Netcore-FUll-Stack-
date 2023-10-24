//Autor: Jhonny Guimarães

using System.ComponentModel.DataAnnotations;
public class Servico
{
	[Key]
	public int _idServico { get; set; }
	public string? _descricaoServico { get; set; }
	public double _valorHora { get; set; }
	public double? _valorPagar { get; set; }
	

	
	//----------------------------------------------------------------

	


}
