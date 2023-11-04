using System.ComponentModel.DataAnnotations;

public class NotaFiscal
{
    [Key]
    
    public string? _NumeroNota { get; set; }
    public double? _ValorDaNota { get; set; }
    public int? _Cpf{  get; set; }
    public int? _OrdemServico {  get; set; }
    

    //-------------------------------------------------------------------------
    private Cliente? Cliente { get; set; }
    private Servico? Servico{get;set;}
    //-------------------------------------------------------------------------

    private List<Servico>? Servicos {get;set;}
    

    //-------------------------------------------------------------------------

    
}

