using System.ComponentModel.DataAnnotations;

public class Cliente
{
    [Key]
    
    public string? _Cpf {get; set;}
    public string? _Nome {get; set;}
    public string? _Email {get; set;}

    //-------------------------------------------------------------------------
    private List<Veiculo>? Veiculo{get;set;}

    private List<NotaFiscal>? Nota{get;set;}
}
