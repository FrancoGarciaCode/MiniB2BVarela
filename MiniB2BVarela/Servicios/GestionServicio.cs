using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MiniB2BVarela.Modelos;

namespace MiniB2BVarela.Servicios
{
    public class GestionServicio
    {
        private List<Producto> productos;
        private List<Cliente> clientes;
        private List<Pedido> pedidos;
        private int contadorPedidos;

        public GestionServicio()
        {
            productos = new List<Producto>();
            clientes = new List<Cliente>();
            pedidos = new List<Pedido>();
            contadorPedidos = 1;
            CargarDatosIniciales();
        }

        private void CargarDatosIniciales()
        {
            // Productos
            productos.Add(new Producto(1, "Quilmes Clásica 1L", 1850.00m, 100, "Cerveza"));
            productos.Add(new Producto(2, "Quilmes Clásica 473ml", 950.00m, 200, "Cerveza"));
            productos.Add(new Producto(3, "Brahma 1L", 1750.00m, 80, "Cerveza"));
            productos.Add(new Producto(4, "Coca-Cola 2.25L", 1200.00m, 150, "Gaseosa"));
            productos.Add(new Producto(5, "Pepsi 2.25L", 1100.00m, 120, "Gaseosa"));
            productos.Add(new Producto(6, "Agua Villavicencio 500ml", 450.00m, 300, "Agua"));

            // Clientes
            clientes.Add(new Cliente(1, "Mercadito Pieri", "20-12345678-9", "Chile 3374-3302, Florencio Varela", 50000.00m));
            clientes.Add(new Cliente(2, "Kiosco La Esquina", "27-98765432-1", "Mitre 567, Florencio Varela", 30000.00m));
            clientes.Add(new Cliente(3, "Supermercado El Ahorro", "30-11223344-5", "San Martín 890, Florencio Varela", 100000.00m));
        }

        public List<Producto> ObtenerProductos()
        {
            return productos;
        }

        public List<Cliente> ObtenerClientes()
        {
            return clientes;
        }

        public List<Pedido> ObtenerPedidos()
        {
            return pedidos;
        }

        public Cliente BuscarCliente(int id)
        {
            return clientes.FirstOrDefault(c => c.Id == id);
        }

        public Producto BuscarProducto(int id)
        {
            return productos.FirstOrDefault(p => p.Id == id);
        }

        public Pedido CrearPedido(Cliente cliente)
        {
            var pedido = new Pedido(contadorPedidos++, cliente);
            pedidos.Add(pedido);
            return pedido;
        }

        public List<Pedido> ObtenerPedidosPorCliente(int clienteId)
        {
            return pedidos.Where(p => p.Cliente.Id == clienteId).ToList();
        }
    }
}