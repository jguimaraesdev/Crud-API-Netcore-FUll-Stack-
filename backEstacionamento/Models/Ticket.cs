//Autor: Jhonny Guimarães

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
public class Ticket
{   
    [Key]
    public int? _idTicket{get;set;}
    public string? _codTicket {get; set;}
    public string? _Placa {get; set;}
    public String? _HoraEntrada {get;set;} 
    public String? _HoraSaida {get;set;} 
    public Boolean? _Pagamento{get;set;}

    //-------------------------------------------------------------------------
    public Veiculo? Veiculo {get;set;}
   

}

