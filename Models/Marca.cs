using System.ComponentModel.DataAnnotations;

public class Marca
{
    [Key]
    public int? _idMarca {get; set;}
    public string? _DescricaoMarca {get; set;}
    public string _Segmento {get; set;}
    
}
