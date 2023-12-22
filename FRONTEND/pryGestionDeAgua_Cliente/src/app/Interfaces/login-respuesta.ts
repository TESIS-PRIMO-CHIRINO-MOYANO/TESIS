export interface User {
    idUsuario: number;
    dni: string;
    nombre: string;
    apellido: string;
    sexo: string;
    mail: string;
    password: string;
    fechaNacimiento: string;
    fechaAlta: string;
    idRol: number;
    rol: any; 
}

export interface LoginResponse {
    statusCode: number;
    isSucces: boolean;
    errorMessages: string[];
    result: {
        usuario: User;
        token: string;
    };
}
