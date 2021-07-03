import { MatTableDataSource } from "@angular/material/table";
import { IVacante } from "./vacante";

export interface ICategoriaVacante {
    idCategoria: number,
    nombre: string,
    vacante: IVacante[]
}