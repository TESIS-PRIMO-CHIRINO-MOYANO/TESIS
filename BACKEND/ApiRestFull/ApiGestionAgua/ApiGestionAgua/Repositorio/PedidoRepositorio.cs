using ApiGestionAgua.Data;
using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using ApiGestionAgua.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;

namespace ApiGestionAgua.Repositorio
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly AppDbContext _bd;

        public PedidoRepositorio(AppDbContext bd)
        {
            _bd = bd;
        }

        public Pedido GetPedido(int IdPedido)
        {
            return _bd.Pedido.FirstOrDefault(p => p.IdPedido == IdPedido);
        }

        public PedidoDTO GetPedidoPorIdPedido(int IdPedido)
        {
            var pedido = _bd.Pedido
           .Include(p => p.Cliente)
           .Include(p => p.Vehiculo)
           .Include(p => p.Barrio)
           .Include(p => p.Estado)
           .FirstOrDefault(p => p.IdPedido == IdPedido);

            var productosPedido = _bd.ProductoPedido
              .Where(pp => pp.IdPedido == IdPedido)
              .ToList();

            if (pedido == null)
            {
                return null; // o manejar de alguna manera el pedido no encontrado
            }

            var pedidoDTO = new PedidoDTO
            {
                IdPedido = pedido.IdPedido,
                FechaPedido = pedido.FechaPedido,
                ImporteTotal = pedido.ImporteTotal,
                IdCliente = pedido.IdCliente,
                IdPatente = pedido.IdPatente,
                IdBarrio = pedido.IdBarrio,
                IdEstado = pedido.IdEstado,
                productosPedidoDTO = productosPedido
                .Where(pp => pp.IdPedido == pedido.IdPedido)
                .Select(pp => new ProductosPedidoDTO
                {
                    Cantidad = pp.Cantidad,
                    EsExtra = pp.EsExtra,
                    Total = pp.Total,
                    IdPedido = pp.IdPedido,
                    IdProducto = pp.IdProducto,


                })
                .ToArray()
            };

            return pedidoDTO;
        }


        public List<PedidoDTO> GetPedidoCliente(int IdCliente)
        {
            var pedidos = _bd.Pedido
            .Where(p => p.IdCliente == IdCliente)
            .ToList();
            var idPedidos = pedidos.Select(p => p.IdPedido).ToList();
            var productosPedido = _bd.ProductoPedido
                .Where(pp => idPedidos.Contains(pp.IdPedido))
                .ToList();
            var pedidosDTO = pedidos.Select(pedido => new PedidoDTO
            {
                IdPedido = pedido.IdPedido,
                FechaPedido = pedido.FechaPedido,
                ImporteTotal = pedido.ImporteTotal,
                IdCliente = pedido.IdCliente,
                IdPatente = pedido.IdPatente,
                IdBarrio = pedido.IdBarrio,
                IdEstado = pedido.IdEstado,
                productosPedidoDTO = productosPedido
                .Where(pp => pp.IdPedido == pedido.IdPedido)
                .Select(pp => new ProductosPedidoDTO
                {
                    Cantidad = pp.Cantidad,
                    EsExtra = pp.EsExtra,
                    Total = pp.Total,
                    IdPedido = pp.IdPedido,
                    IdProducto = pp.IdProducto,
                })
                .ToArray()
            }).ToList();
            return pedidosDTO;
        }

        public async Task<Pedido> CrearPedido(PedidoDTO pedidoDTO)
        {
            Pedido pedido = new Pedido()
            {
                FechaPedido = pedidoDTO.FechaPedido,
                ImporteTotal = pedidoDTO.ImporteTotal,
                IdCliente = pedidoDTO.IdCliente,
                IdPatente = pedidoDTO.IdPatente,
                IdEstado = pedidoDTO.IdEstado,
                IdBarrio = pedidoDTO.IdBarrio,
            };
            _bd.Pedido.Add(pedido);
            await _bd.SaveChangesAsync();
            foreach (ProductosPedidoDTO productoDTO in pedidoDTO.productosPedidoDTO)
            {
                ProductoPedido productoPedido = new ProductoPedido()
                {
                    IdPedido = pedido.IdPedido,
                    IdProducto = productoDTO.IdProducto,
                    Cantidad = productoDTO.Cantidad,
                    Total = productoDTO.Total,
                    EsExtra = false,
                };

                _bd.ProductoPedido.Add(productoPedido);
            }
            await _bd.SaveChangesAsync();
            //Calculop de la deuda
            var cuentaCorriente = _bd.CuentaCorriente.FirstOrDefault(c => c.IdCliente == pedidoDTO.IdCliente);

            if (cuentaCorriente != null)
            {
                cuentaCorriente.Monto = cuentaCorriente.Monto - pedidoDTO.ImporteTotal ;
                
                _bd.SaveChanges();
            }
            return pedido;
        }

        public bool borrarPedido(int IdPedido)
        {
            

            var pedidoExistente = _bd.Pedido.Find(IdPedido);

            if (pedidoExistente == null)
            {
                return false;
            }

            var productosAEliminar = _bd.ProductoPedido.Where(pp => pp.IdPedido == IdPedido);
            _bd.ProductoPedido.RemoveRange(productosAEliminar);

            // Eliminar el pedido de la base de datos
            _bd.Pedido.Remove(pedidoExistente);

            // Guardar cambios en la base de datos
            _bd.SaveChanges();

            return true;

        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }

        public bool ModificarPedido(PedidoDTO pedido)
        {
            
            var pedidoExistente = _bd.Pedido.Find(pedido.IdPedido);

            if (pedidoExistente == null)
            {
                return false; // Manejar el caso en que el pedido no existe
            }

            // Modificar propiedades del pedido existente con la información del pedido modificado
            pedidoExistente.FechaPedido = pedido.FechaPedido;
            pedidoExistente.ImporteTotal = pedido.ImporteTotal;
            pedidoExistente.IdCliente = pedido.IdCliente;
            pedidoExistente.IdPatente = pedido.IdPatente;
            pedidoExistente.IdBarrio = pedido.IdBarrio;
            pedidoExistente.IdEstado = pedido.IdEstado;
            // Actualizar, agregar y eliminar ProductosPedido
            ActualizarProductosPedido(pedido);


            // Guardar cambios en la base de datos
            return _bd.SaveChanges() >= 0;
        }
        private void ActualizarProductosPedido(PedidoDTO pedidoModificado)
        {
            
            ProductosPedidoDTO[] productosModificados = pedidoModificado.productosPedidoDTO;
            ProductosPedidoDTO[] productosExistentes = _bd.ProductoPedido
             .Where(pp => pp.IdPedido == pedidoModificado.IdPedido)
             .Select(pp => new ProductosPedidoDTO
             {
                 Cantidad = pp.Cantidad,
                 EsExtra = pp.EsExtra,
                 Total = pp.Total,
                 IdPedido = pp.IdPedido,
                 IdProducto = pp.IdProducto             
             })
             .ToArray();
            foreach (var productoModificado in productosModificados)
            {
                // Buscar el producto modificado en los existentes
                var productoExistente = productosExistentes.FirstOrDefault(pe => pe.IdProducto == productoModificado.IdProducto);

                if (productoExistente != null)
                {
                    // Caso 1: NO SE HACE NADA ES UN PRODUCTO QU EYA ESTBA Y NO SE MODIFICO

                    // Caso 2: SE MODIFICO ALGUN CAMPO DEL PRODUCTO
                    if (!SonIguales(productoExistente, productoModificado))
                    {
                        //ES EL REGISTRO EN LA BD al hacer el save se modifica
                        var productoEnBase = _bd.ProductoPedido.FirstOrDefault(pe => pe.IdProducto == productoModificado.IdProducto);
                        if (productoEnBase != null)
                        {
                            productoEnBase.Cantidad = productoModificado.Cantidad;
                            productoEnBase.EsExtra = productoModificado.EsExtra;
                            productoEnBase.Total = productoModificado.Total;
                            _bd.SaveChanges();
                        }
                    }
                }
                else
                {
                    // Caso 3: SE AGREGO UN NUEVO PRODUCTO
                  
                    var nuevoProducto = new ProductoPedido
                    {
                        Cantidad = productoModificado.Cantidad,
                        EsExtra = productoModificado.EsExtra,
                        Total = productoModificado.Total,
                        IdProducto = productoModificado.IdProducto,
                        IdPedido = pedidoModificado.IdPedido
                        
                    };

                    _bd.ProductoPedido.Add(nuevoProducto);
                    _bd.SaveChanges();
                }
            }

            
            foreach (var productoExistente in productosExistentes)
            {
                var productoModificado = productosModificados.FirstOrDefault(pm => pm.IdProducto == productoExistente.IdProducto);

                // Caso 4: SE BORRO UN PRODUCTO DEL PEDIDO
                if (productoModificado == null)
                {
                    
                    var productoEnBase = _bd.ProductoPedido.FirstOrDefault(pe => pe.IdProducto == productoExistente.IdProducto);
                    if (productoEnBase != null)
                    {
                        _bd.ProductoPedido.Remove(productoEnBase);
                        _bd.SaveChanges();
                    }
                }
            }
        }

        //LO USO PARA VER SI SE MODIFICO O NO UN PRODUCTOR
        private bool SonIguales(ProductosPedidoDTO producto1, ProductosPedidoDTO producto2)
        {            
            return producto1.Cantidad == producto2.Cantidad
                && producto1.EsExtra == producto2.EsExtra
                && producto1.Total == producto2.Total;
        }


    }
}
