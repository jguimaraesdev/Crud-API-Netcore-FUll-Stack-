using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

public class Veiculo
{
    [Key]

    public int? _idVeiculo{get; set;}
    public string? _Placa {get; set;}
    public string? _Descricao {get; set;}
    

 
}
