using System.ComponentModel.DataAnnotations;

public class Cliente
{
    [Key]
    
    public int? _idCliente {get; set;}
    public string? _Cpf {get; set;}
    public string? _Nome {get; set;}
    public string? _Email {get; set;}

    

}
