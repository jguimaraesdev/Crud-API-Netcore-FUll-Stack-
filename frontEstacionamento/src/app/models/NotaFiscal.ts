import { Cliente } from "./Cliente";
import { Servico } from "./Servico";

export class NotaFiscal
{
    _NumeroNota?: number;
    _ValorDaNota: number = 0.0;
    _Cpf: Cliente = new Cliente();
    _idServico?: Servico = new Servico();
}