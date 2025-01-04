import { TipoDocumento } from "./TipoDocumento";

export interface Especialidade {
  Id :number ;
  nome :string ;
  tipoDocumentoID :number ;
  tipoDocumento :TipoDocumento ;
}
