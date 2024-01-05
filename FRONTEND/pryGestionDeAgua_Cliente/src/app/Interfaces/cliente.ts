export interface Cliente {
    idCliente: number;
    calle:     string;
    piso:      string;
    depto:     string;
    telefono:  string;
    idUsuario: number;
    usuario:   Usuario;
    idBarrio:  number;
    barrio:    null;
}

export interface Usuario {
    idUsuario:       number;
    dni:             string;
    nombre:          string;
    apellido:        string;
    sexo:            string;
    mail:            string;
    password:        string;
    fechaNacimiento: Date;
    fechaAlta:       Date;
    idRol:           number;
    rol:             null;
}
