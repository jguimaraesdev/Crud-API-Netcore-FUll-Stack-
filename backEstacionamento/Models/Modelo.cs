using System.ComponentModel.DataAnnotations;

public class Modelo
{
    [Key]
    public string? _nomeModelo {get; set;}
    public string? _motor {get;set;}
    public int? _qtdPortas {get; set;}
    public string? _nomeMarca{get;set;}
    public Tipo? _TipoModelo {get; set;}

    //-------------------------------------------------------------------------
    public enum Tipo {
        Hatch = 1, 
        Sedã = 2, 
        Suv = 3, 
        Picape = 4, 
        Perua = 5, 
        Minivan = 6, 
        Esportivo = 7, 
        Furgão = 8
    }
    

    //-------------------------------------------------------------------------
     private Marca? Marca{get;set;}
   
}
