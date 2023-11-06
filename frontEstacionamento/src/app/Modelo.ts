import { Marca } from "./Marca";

export class Modelo {
    _idModelo: number = 0;
    _nomeModelo: String = "";
    _motor: String = "";
    _qtdPortas: Number = 0;
    _AnoModelo: number = 0;
    _TipoModelo: String = "";
    _idMarca: Marca | undefined;
}

