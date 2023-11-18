import { Periodo } from "./Periodo";
import { Veiculo } from "./Veiculo";

export class Ticket{

    _idTicket: number =0;
    _codTicket: string="";
    _Placa?: Veiculo | undefined;
    _idPeriodo?: Periodo |undefined;
}