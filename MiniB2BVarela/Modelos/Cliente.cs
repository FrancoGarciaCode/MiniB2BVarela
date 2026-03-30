using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniB2BVarela.Modelos
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CUIT { get; set; }
        public string Direccion { get; set; }
        public decimal LimiteCredito { get; set; }
        public decimal SaldoUtilizado { get; set; }

        public decimal CreditoDisponible => LimiteCredito - SaldoUtilizado;

        public Cliente(int id, string nombre, string cuit, string direccion, decimal limiteCredito)
        {
            Id = id;
            Nombre = nombre;
            CUIT = cuit;
            Direccion = direccion;
            LimiteCredito = limiteCredito;
            SaldoUtilizado = 0;
        }

        public bool TieneCredito(decimal monto)
        {
            return CreditoDisponible >= monto;
        }

        public override string ToString()
        {
            return $"[{Id}] {Nombre} | CUIT: {CUIT} | Crédito disponible: ${CreditoDisponible:N2}";
        }
    }
}

