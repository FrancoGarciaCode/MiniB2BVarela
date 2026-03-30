# MiniB2B Varela

Simulador de plataforma de pedidos B2B desarrollado en C# (.NET 8), inspirado en el modelo operativo de BEES (Quilmes).

## ¿Qué hace este proyecto?

Modela el flujo completo de una plataforma de comercio B2B entre una distribuidora y comercios minoristas:

- Catálogo de productos con stock y precios
- Gestión de clientes con límite de crédito
- Procesamiento de pedidos con validación de crédito disponible
- Historial de pedidos por cliente
- Reportes de ventas

## Arquitectura

El proyecto sigue una arquitectura en capas:

MiniB2BVarela/
├── Modelos/          # Entidades del dominio (Producto, Cliente, Pedido, ItemPedido)
├── Servicios/        # Lógica de negocio (GestionServicio)
├── Helpers/          # Utilidades de presentación y formato
└── Program.cs        # Punto de entrada y menú principal

## Stack técnico

- Lenguaje: C# 12
- Framework: .NET 8
- IDE: Visual Studio 2022
- Versionado: Git / GitHub

## Estado del proyecto

🚧 En desarrollo activo