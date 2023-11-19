import { Veiculo } from "./Veiculo";

export class Periodo
{
    _idPeriodo?: number;
    _HoraEntrada: string ="";
    _HoraSaida: string = "";
    _Placa: string = "";
    _Veiculo: Veiculo = new Veiculo();

}