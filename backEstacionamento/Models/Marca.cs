using System.ComponentModel.DataAnnotations;

public class Marca
{
    [Key]
    public string? _nomeMarca {get; set;}
    public Segmento? _segmento{get; set;}
    public enum Segmento {
        Automóveis = 1, 
        Motocicletas = 2, 
        Onibus = 3, 
        Caminhões = 4
        }
    
    
    //-------------------------------------------------------------------------

    private List<Modelo>? Modelo{get;set;}
}
