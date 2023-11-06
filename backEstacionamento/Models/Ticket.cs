//Autor: Jhonny Guimarães

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
public class Ticket
{   
    [Key]
    public  int? _codTicket {get; set;}
    public string? _Placa {get; set;}
    public int? _idPeriodo{get;set;}

    //-------------------------------------------------------------------------
    public Veiculo? Veiculo {get;set;}
    public Periodo? Periodo{get;set;}
    //-------------------------------------------------------------------------

    public List<Servico>? Servicos{get;set;}

    


}

