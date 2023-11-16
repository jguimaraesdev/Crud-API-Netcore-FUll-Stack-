import { Periodo } from "./Periodo";
import { Veiculo } from "./Veiculo";

export class Ticket{
    _codTicket: number = 0;
    _Placa?: Veiculo | undefined;
    _idPeriodo?: Periodo |undefined;
}