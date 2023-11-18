import { Marca } from "./Marca";

export class Modelo {
    _idModelo?: number;
    _nomeModelo: String = "";
    _AnoModelo: number=0;
    _TipoModelo: String = "";
    _idMarca: Marca | undefined;
}

