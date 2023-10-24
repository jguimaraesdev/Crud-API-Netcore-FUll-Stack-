using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

public class Carro
{
    [Key]

    public int _idCarro {get; set;}
    public int _idVeiculo {get;set;}
    public int _idMarca {get; set;}
    public int _idModelo{get; set;}
    public int _idCliente{get;set;}


    public Veiculo Veiculo {get;set;}
    public Marca Marca {get;set;}
    public Modelo Modelo {get; set;}
    public Cliente Cliente{get;set;}




}