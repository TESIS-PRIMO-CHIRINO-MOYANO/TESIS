export interface Pedido {
    idPedido:           number;
    fechaPedido:        Date;
    importeTotal:       number;
    idCliente:          number;
    idPatente:          number;
    idBarrio:           number;
    idEstado:           number;
    productosPedidoDTO: ProductosPedidoDTO[];
}

export interface ProductosPedidoDTO {
    idPedido:   number;
    idProducto: number;
    cantidad:   number;
    esExtra:    boolean;
    total:      number;
}