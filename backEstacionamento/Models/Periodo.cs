

using System.ComponentModel.DataAnnotations.Schema;

[NotMapped]
public class Periodo
{
    
    public int? _idPeriodo{get;set;}
    public String? _Placa{get; set;}
    public String? _HoraEntrada {get;set;} 
    public String? _HoraSaida {get;set;} 
    
    
    //----------------------------------------------------------------

    public Veiculo? Veiculo {get; set;}

    //----------------------------------------------------------------


}

    


