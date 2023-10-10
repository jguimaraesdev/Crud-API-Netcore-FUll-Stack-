using System.ComponentModel.DataAnnotations;

public class Modelo
{
    [Key]
    public int? _idModelo {get; set;}
    public string? _nomeModelo {get; set;}
    public String _Tamanho {get; set;}
    public string _motor {get;set;}
    public int _qtdPortas {get; set;}
    public enum Cor {Vermelho, Branco, Preto, Prata}
    public Cor _CorExterna {get; set;}

    
}
