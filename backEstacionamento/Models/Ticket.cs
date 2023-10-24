//Autor: Jhonny Guimarães

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
public class Ticket
{   
    [Key]
    public int _idTicket {get; set;}
    public  int _codTicket {get; set;}

    public int _idCarro {get; set;}//atributo para inserir dado no banco
    public int _idPeriodo{get;set;}
    public int _Servico {get;set;}
    //-------------------------------------------------------------------------

    public Carro Carro {get;set;}
    public Periodo Periodo {get;set;}
    public Servico Servico {get;set;}

    //-------------------------------------------------------------------------




}

