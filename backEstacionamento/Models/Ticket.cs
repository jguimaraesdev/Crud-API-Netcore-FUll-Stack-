//Autor: Jhonny Guimarães

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
public class Ticket
{   
    [Key]
    public  int? _codTicket {get; set;}
    public string? _Placa {get; set;}
    
    
    //-------------------------------------------------------------------------

    private Veiculo? Veiculo {get;set;}
    private Periodo? Periodo {get;set;}
    

    //-------------------------------------------------------------------------

    private List<Servico>? Servico{get;set;}

    


}

