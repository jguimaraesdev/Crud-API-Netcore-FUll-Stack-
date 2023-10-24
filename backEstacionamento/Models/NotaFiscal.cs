using System.ComponentModel.DataAnnotations;

public class NotaFiscal
{
    [Key]
    public int _idNota {get; set;}
    public string? _NumeroNota { get; set; }
    public double _ValorDaNota { get; set; }
    
    public int _idServico {  get; set; }
    public int _idCliente {  get; set; }


    public Servico? Servico { get; set; }
    public Cliente? Cliente { get; set; }


    



    public void EmiteNF(string CPF, double ValorAPagar)
    {
        _ValorDaNota = ValorAPagar;
    }
}

