using System.ComponentModel.DataAnnotations;


public class Periodo
{
    [Key]
    public int? _idPeriodo {get; set;}
    public DateTime? _HoraEntrada { get; set; }
    public DateTime? _HoraSaida {get; set;}




    //----------------------------------------------------------------


    public Periodo? solicitarEntrada(Boolean entra)

    { 
        if(entra == true){
            this._HoraEntrada = DateTime.Now;
        return this;
        }
        else{
            return null;
        }
    }


    public Periodo? solicitarSaida(Boolean sair)
    { 
        if(sair == true)
        {
            this._HoraSaida = DateTime.Now;
            return this;

        }
        else{
            return null;
        }
             
     }

    public TimeSpan? processarPermanencia()
    {
        if (_HoraEntrada != default && _HoraSaida != default)
        {
            var tempo = _HoraSaida - _HoraEntrada;
            return tempo;
        }
        else
        {
            return null;
        }
    }
}


    


