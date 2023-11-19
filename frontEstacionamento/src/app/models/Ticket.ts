import { Periodo } from "./Periodo";
import { Veiculo } from "./Veiculo";

export class Ticket{

    _idTicket: number =0;
    _codTicket: string="";
    _Placa?: Veiculo = new Veiculo();
    _idPeriodo?: Periodo = new Periodo();
}