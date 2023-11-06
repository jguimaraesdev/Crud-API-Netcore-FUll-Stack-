using System.ComponentModel.DataAnnotations;


public class Periodo
{
    [Key]
    public int? _idPeriodo{get;set;}
    public DateTime? _HoraEntrada {get;set;} 
    public DateTime? _HoraSaida {get;set;} 
    public String? _Placa{get; set;}
    
    //----------------------------------------------------------------

    public Veiculo? Veiculo {get; set;}

    //----------------------------------------------------------------


}

    


