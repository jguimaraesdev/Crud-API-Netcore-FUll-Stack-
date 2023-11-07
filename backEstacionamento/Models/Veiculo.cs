using System.ComponentModel.DataAnnotations;
using System.Configuration;
//using System.ComponentModel.DataAnnotations.Schema;

public class Veiculo
{
    [Key]

    public string? _Placa {get; set;}
    public String? _Cor { get; set; }
    public int? _idModelo {get; set;}
    //-------------------------------------------------------------------------
    public Modelo? Modelo {get; set;}
    
    //-------------------------------------------------------------------------
    public List<Cliente>? Clientes {get;set;}
    public List<Servico>? Servicos{get;set;}
    public List<Periodo>? Periodos{get;set;}
    public List<Ticket>? Tickets{get;set;}
    //-------------------------------------------------------------------------
 




}



