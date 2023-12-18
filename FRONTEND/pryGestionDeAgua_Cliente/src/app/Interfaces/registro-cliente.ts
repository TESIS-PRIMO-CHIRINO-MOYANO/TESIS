export interface RegistroClienteInterface {
    dni: string;
    nombre: string;
    apellido: string;
    mail: string;
    password: string;
    fechaNacimiento: string;
    idRol?: number;
    calle?: string;
    piso?: string;
    depto?: string;
    telefono?: string;
    idBarrio: number;
}
