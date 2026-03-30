using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniB2BVarela.Modelos
{
    public class ItemPedido
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public decimal Subtotal => Cantidad * PrecioUnitario;

        public ItemPedido(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
            PrecioUnitario = producto.Precio;
        }

        public override string ToString()
        {
            return $"{Producto.Nombre} x{Cantidad} | ${PrecioUnitario:N2} c/u | Subtotal: ${Subtotal:N2}";
        }
    }
}