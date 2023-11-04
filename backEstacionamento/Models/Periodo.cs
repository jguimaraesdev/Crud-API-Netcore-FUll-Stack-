using System.ComponentModel.DataAnnotations;


public class Periodo
{
    [Key]
    public String? _Placa{get; set;}
    public DateTime? _HoraEntrada {get;set;} 
    public DateTime? _HoraSaida {get;set;} 




    //----------------------------------------------------------------

    private Veiculo? Veiculo {get; set;}

    private List<Veiculo>? Veiculos{get;set;}

    //----------------------------------------------------------------


}

    


