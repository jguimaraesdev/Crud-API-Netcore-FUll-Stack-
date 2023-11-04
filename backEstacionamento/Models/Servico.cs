//Autor: Jhonny Guimarães

using System.ComponentModel.DataAnnotations;
public class Servico
{
    [Key]
	
	public int? _OrdemServico { get; set; }
	public string? _Placa {get; set;}
	public TipoServico? _tipoServico{get;set;}
    public double? _valorServico { get; set; }
    public double? _valorPagar { get; set; }

    public enum TipoServico {
		
		Estacionamento = 1, 
		Estetica = 2, 
		Higienizacao = 3, 
		Fornecedores = 4
		}
	
	
	//----------------------------------------------------------------

	private Veiculo? Veiculo{get;set;}
	private List<Periodo>? Periodos{get;set;}

	private List<Servico>? Servicos{get;set;}

	//-------------------------------------------------------------------------

}
