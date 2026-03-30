using MiniB2BVarela.Modelos;
using MiniB2BVarela.Servicios;

var sistema = new GestionServicio();

bool salir = false;

while (!salir)
{
    Console.Clear();
    Console.WriteLine("╔════════════════════════════════════╗");
    Console.WriteLine("║        MiniB2B Varela v1.0         ║");
    Console.WriteLine("║   Plataforma de Pedidos B2B        ║");
    Console.WriteLine("╠════════════════════════════════════╣");
    Console.WriteLine("║  1. Ver catálogo de productos      ║");
    Console.WriteLine("║  2. Ver clientes                   ║");
    Console.WriteLine("║  3. Crear nuevo pedido             ║");
    Console.WriteLine("║  4. Ver historial de pedidos       ║");
    Console.WriteLine("║  5. Salir                          ║");
    Console.WriteLine("╚════════════════════════════════════╝");
    Console.Write("\nElegí una opción: ");

    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            MostrarCatalogo();
            break;
        case "2":
            MostrarClientes();
            break;
        case "3":
            CrearPedido();
            break;
        case "4":
            MostrarHistorial();
            break;
        case "5":
            salir = true;
            break;
        default:
            Console.WriteLine("\nOpción inválida. Presioná cualquier tecla para continuar...");
            Console.ReadKey();
            break;
    }
}

Console.WriteLine("\nHasta luego.");

// ─── Funciones ───────────────────────────────────────────

void MostrarCatalogo()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════");
    Console.WriteLine("           CATÁLOGO DE PRODUCTOS       ");
    Console.WriteLine("═══════════════════════════════════════");

    foreach (var producto in sistema.ObtenerProductos())
    {
        Console.WriteLine(producto);
    }

    Console.WriteLine("\nPresioná cualquier tecla para volver...");
    Console.ReadKey();
}

void MostrarClientes()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════");
    Console.WriteLine("              CLIENTES                 ");
    Console.WriteLine("═══════════════════════════════════════");

    foreach (var cliente in sistema.ObtenerClientes())
    {
        Console.WriteLine(cliente);
    }

    Console.WriteLine("\nPresioná cualquier tecla para volver...");
    Console.ReadKey();
}

void CrearPedido()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════");
    Console.WriteLine("           CREAR NUEVO PEDIDO          ");
    Console.WriteLine("═══════════════════════════════════════");

    // Seleccionar cliente
    MostrarClientes();
    Console.Clear();
    Console.Write("Ingresá el ID del cliente: ");

    if (!int.TryParse(Console.ReadLine(), out int clienteId))
    {
        Console.WriteLine("ID inválido.");
        Console.ReadKey();
        return;
    }

    Cliente cliente = sistema.BuscarCliente(clienteId);

    if (cliente == null)
    {
        Console.WriteLine("Cliente no encontrado.");
        Console.ReadKey();
        return;
    }

    Console.WriteLine($"\nCliente seleccionado: {cliente}");

    Pedido pedido = sistema.CrearPedido(cliente);

    // Agregar productos
    bool agregando = true;

    while (agregando)
    {
        Console.Clear();
        Console.WriteLine($"Pedido en curso | Cliente: {cliente.Nombre} | Total actual: ${pedido.Total:N2}");
        Console.WriteLine("═══════════════════════════════════════");
        MostrarCatalogo();

        Console.Clear();
        Console.WriteLine($"Pedido en curso | Total: ${pedido.Total:N2}");
        Console.Write("\nIngresá el ID del producto (0 para terminar): ");

        if (!int.TryParse(Console.ReadLine(), out int productoId))
        {
            Console.WriteLine("ID inválido.");
            Console.ReadKey();
            continue;
        }

        if (productoId == 0)
        {
            agregando = false;
            continue;
        }

        Producto producto = sistema.BuscarProducto(productoId);

        if (producto == null)
        {
            Console.WriteLine("Producto no encontrado.");
            Console.ReadKey();
            continue;
        }

        Console.Write($"¿Cuántas unidades de {producto.Nombre}? ");

        if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
        {
            Console.WriteLine("Cantidad inválida.");
            Console.ReadKey();
            continue;
        }

        if (cantidad > producto.Stock)
        {
            Console.WriteLine($"Stock insuficiente. Disponible: {producto.Stock}");
            Console.ReadKey();
            continue;
        }

        pedido.AgregarItem(producto, cantidad);
        Console.WriteLine($"✓ Agregado: {producto.Nombre} x{cantidad}");
        Console.ReadKey();
    }

    // Confirmar pedido
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════");
    Console.WriteLine("           RESUMEN DEL PEDIDO          ");
    Console.WriteLine("═══════════════════════════════════════");

    foreach (var item in pedido.Items)
    {
        Console.WriteLine(item);
    }

    Console.WriteLine($"\nTotal: ${pedido.Total:N2}");
    Console.WriteLine($"Crédito disponible: ${cliente.CreditoDisponible:N2}");
    Console.Write("\n¿Confirmás el pedido? (s/n): ");

    string respuesta = Console.ReadLine();

    if (respuesta?.ToLower() == "s")
    {
        bool confirmado = pedido.Confirmar();

        if (confirmado)
        {
            Console.WriteLine($"\n✓ Pedido #{pedido.Id} confirmado correctamente.");
            Console.WriteLine($"Crédito restante: ${cliente.CreditoDisponible:N2}");
        }
        else
        {
            Console.WriteLine("\n Pedido rechazado. Crédito insuficiente o pedido vacío.");
        }
    }
    else
    {
        Console.WriteLine("\nPedido cancelado.");
    }

    Console.WriteLine("\nPresioná cualquier tecla para volver...");
    Console.ReadKey();
}

void MostrarHistorial()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════");
    Console.WriteLine("         HISTORIAL DE PEDIDOS          ");
    Console.WriteLine("═══════════════════════════════════════");

    var pedidos = sistema.ObtenerPedidos();

    if (pedidos.Count == 0)
    {
        Console.WriteLine("No hay pedidos registrados.");
    }
    else
    {
        foreach (var pedido in pedidos)
        {
            Console.WriteLine(pedido);
        }
    }

    Console.WriteLine("\nPresioná cualquier tecla para volver...");
    Console.ReadKey();
}