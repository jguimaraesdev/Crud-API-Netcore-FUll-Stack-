
using System.ComponentModel.DataAnnotations;
public class ClienteVeiculo
{
    [Key]
    
    public string? Clientes_Cpf {get; set;}
    public string? Veiculos_Placa {get; set;}
    

    //-------------------------------------------------------------------------
    
    public Veiculo? Veiculo {get;set;}

    public Cliente? Cliente {get;set;}
}