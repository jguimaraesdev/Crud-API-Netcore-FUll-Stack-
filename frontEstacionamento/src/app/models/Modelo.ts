import { Marca } from "./Marca";

export class Modelo {
    idModelo?: number;
    _nomeModelo: String = "";
    _motor: String = "";
    _qtdPortas: Number = 0;
    _AnoModelo: number=0;
    _TipoModelo: String = "";
    _idMarca: Marca | undefined;
}

