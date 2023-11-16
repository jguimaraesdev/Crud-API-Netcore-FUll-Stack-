import { Ticket } from "./Ticket";

export class Servico
{
    _idServico?: number;
    _codTicket: Ticket | undefined;
    _valorServico: number = 0;
}