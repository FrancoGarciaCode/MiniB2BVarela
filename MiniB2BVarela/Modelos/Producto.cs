using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniB2BVarela.Modelos
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; }

        public Producto(int id, string nombre, decimal precio, int stock, string categoria)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
            Categoria = categoria;
        }

        public override string ToString()
        {
            return $"[{Id}] {Nombre} | ${Precio:N2} | Stock: {Stock} | {Categoria}";
        }
    }
}
