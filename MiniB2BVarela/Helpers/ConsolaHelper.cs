using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniB2BVarela.Helpers
{
    public static class ConsolaHelper
    {
        public static void MostrarExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✓ {mensaje}");
            Console.ResetColor();
        }

        public static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"✗ {mensaje}");
            Console.ResetColor();
        }

        public static void MostrarTitulo(string titulo)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n═══════════════════════════════════════");
            Console.WriteLine($"  {titulo}");
            Console.WriteLine($"═══════════════════════════════════════");
            Console.ResetColor();
        }
    }
}