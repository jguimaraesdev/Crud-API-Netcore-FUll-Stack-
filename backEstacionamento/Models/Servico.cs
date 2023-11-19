//Autor: Jhonny Guimarães

using System.ComponentModel.DataAnnotations;
public class Servico
{
    [Key]
	
	public int? _idServico { get; set; }
	public  String? _codTicket {get; set;}
	public String? _tipoServico{get;set;}
    public double? _valorServico { get; set; }
	public Boolean? _Pagamento{get;set;}
	//-------------------------------------------------------------------------
	public Ticket? Ticket{get;set;}
	

	//-------------------------------------------------------------------------

	

}
