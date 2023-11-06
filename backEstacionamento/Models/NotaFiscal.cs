using System.ComponentModel.DataAnnotations;

public class NotaFiscal
{
    [Key]
    
    public string? _NumeroNota { get; set; }
    public double? _ValorDaNota { get; set; }
    public String? _Cpf{  get; set; }
    public int? _idServico {  get; set; }
    

    //-------------------------------------------------------------------------
    public Cliente? Cliente { get; set; }
    public Servico? Servico{get;set;}
    //-------------------------------------------------------------------------

    public List<Servico>? Servicos {get;set;}
    

    //-------------------------------------------------------------------------

    
}

