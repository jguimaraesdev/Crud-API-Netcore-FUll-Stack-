using System.ComponentModel.DataAnnotations;

public class Modelo
{
    [Key]
    public int? _idModelo {get;set;}
    public string? _nomeModelo {get; set;}
    public int? _AnoModelo{get;set;}
    public String? _TipoModelo {get; set;}
    public int? _idMarca{get;set;}
 
    //-------------------------------------------------------------------------
    public Marca? Marca{get;set;}

    //-------------------------------------------------------------------------
    
   
    
}
