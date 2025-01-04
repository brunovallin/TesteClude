import { Especialidade } from "./Especialidade";

export interface Profissional {

    id : number;
    nome : string;
    especialidadeID : number;
    especialidade : Especialidade;
    numDocumento : number;
}
