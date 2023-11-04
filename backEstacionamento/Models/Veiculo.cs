using System.ComponentModel.DataAnnotations;
using System.Configuration;
//using System.ComponentModel.DataAnnotations.Schema;

public class Veiculo
{
    [Key]

    public string? _Placa {get; set;}
    public string? _Descricao {get; set;}
    public string? _nomeModelo {get; set;}


    public Cor _CorExterna { get; set; }

    //-------------------------------------------------------------------------
    private Modelo? Modelo {get; set;}
    
    //-------------------------------------------------------------------------
    private List<Cliente>? Clientes {get;set;}

    private List<Servico>? Servicos{get;set;}
    //-------------------------------------------------------------------------
    public enum Cor 
    {
        Vermelho = 1, 
        Branco = 2, 
        Preto = 3, 
        Prata = 4,
    }

    //-------------------------------------------------------------------------


}



