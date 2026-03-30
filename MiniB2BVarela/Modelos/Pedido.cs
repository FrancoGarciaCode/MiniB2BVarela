using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniB2BVarela.Modelos
{
    public class Pedido
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<ItemPedido> Items { get; set; }
        public string Estado { get; set; }

        public decimal Total => Items.Sum(item => item.Subtotal);

        public Pedido(int id, Cliente cliente)
        {
            Id = id;
            Cliente = cliente;
            Fecha = DateTime.Now;
            Items = new List<ItemPedido>();
            Estado = "Pendiente";
        }

        public void AgregarItem(Producto producto, int cantidad)
        {
            var itemExistente = Items.FirstOrDefault(i => i.Producto.Id == producto.Id);

            if (itemExistente != null)
            {
                itemExistente.Cantidad += cantidad;
            }
            else
            {
                Items.Add(new ItemPedido(producto, cantidad));
            }
        }

        public bool Confirmar()
        {
            if (Items.Count == 0)
            {
                Estado = "Rechazado";
                return false;
            }

            if (!Cliente.TieneCredito(Total))
            {
                Estado = "Rechazado";
                return false;
            }

            Cliente.SaldoUtilizado += Total;
            Estado = "Confirmado";
            return true;
        }

        public override string ToString()
        {
            return $"Pedido #{Id} | {Cliente.Nombre} | {Fecha:dd/MM/yyyy HH:mm} | Total: ${Total:N2} | {Estado}";
        }
    }
}
