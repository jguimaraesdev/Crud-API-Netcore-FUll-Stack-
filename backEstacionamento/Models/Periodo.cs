using System.ComponentModel.DataAnnotations;


public class Periodo
{
    [Key]
    public int? _idPeriodo{get;set;}
    public String? _HoraEntrada {get;set;} 
    public String? _HoraSaida {get;set;} 
    public String? _Placa{get; set;}
    
    //----------------------------------------------------------------

    public Veiculo? Veiculo {get; set;}

    //----------------------------------------------------------------


}

    


