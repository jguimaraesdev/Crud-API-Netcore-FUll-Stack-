using System.ComponentModel.DataAnnotations;

public class Cliente
{
    [Key]
    
    public string? _Cpf {get; set;}
    public string? _Nome {get; set;}
    public string? _Email {get; set;}

    //-------------------------------------------------------------------------
    public List<Veiculo>? Veiculos{get;set;}

    public List<NotaFiscal>? NotaFiscais{get;set;}
}
