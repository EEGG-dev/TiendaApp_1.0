using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRopaApp
{
    public class Tienda
    {
        private List<Producto> productosDisponibles;

        public Tienda()
        {
            productosDisponibles = new List<Producto>
            {
                new Producto {Nombre = "Camisa", Descripcion = "Camisa de algodon", Precio = 25.00m, CantidadEnInventario =10},
                new Producto {Nombre = "Pantalon", Descripcion = "Pantalon de mezclilla", Precio = 35.00m, CantidadEnInventario = 5},
                new Producto {Nombre = "Sudadera", Descripcion= "Sudadera con capucha", Precio = 45.00m, CantidadEnInventario = 2}
            };
        }
        public void Ejecutar()
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("Bienvenido a la tienda");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Editar producto");
                Console.WriteLine("3. Eliminar producto");
                Console.WriteLine("4. Mostrar informacion de un producto");
                Console.WriteLine("5. Hacer Venta");
                Console.WriteLine("6. Salir");

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarProducto();
                        break;
                    case 2:
                        EditarProducto();
                        break;
                    case 3:
                        EliminarProducto();
                        break;
                    case 4:
                        MostrarInformacionProducto();
                        break;
                    case 5:
                        HacerVenta();
                        break;
                    case 6:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
            }
        }
        private void AgregarProducto()
        {
            Console.WriteLine("Agregar Producto");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Descripcion: ");
            string descripcion = Console.ReadLine();
            Console.Write("Precio: ");
            decimal precio = decimal.Parse(Console.ReadLine());
            Console.Write("Cantidad en inventario: ");
            int cantidadEnInvenario = int.Parse(Console.ReadLine());

            Producto nuevoProducto = new Producto
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Precio = precio,
                CantidadEnInventario = cantidadEnInvenario
            };

            productosDisponibles.Add(nuevoProducto);

            Console.WriteLine("Producto agregado correctamente");
        }
        private void EditarProducto()
        {
            Console.WriteLine("Editar Producto");
            for (int i = 0; i < productosDisponibles.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {productosDisponibles[i].Nombre}");
            }
            Console.WriteLine("Seleccione el producto a editar: ");
            int indiceProducto = int.Parse(Console.ReadLine()) - 1;

            Producto productoAEditar = productosDisponibles[indiceProducto];

            Console.WriteLine("Nuevo nombre (dejar en blanco para no cambiar):");
            string nuevoNombre = Console.ReadLine();

            if (!string.IsNullOrEmpty(nuevoNombre))
            {
                productoAEditar.Nombre = nuevoNombre;
            }
            Console.WriteLine("Nueva descripcion(dejar en blanco para no cambiar): ");
            string nuevaDescripcion = Console.ReadLine();

            if (!string.IsNullOrEmpty(nuevaDescripcion))
            {
                productoAEditar.Descripcion = nuevaDescripcion;
            }
            Console.WriteLine("Nuevo precio(dejar en blanco para no cambiar): ");
            string nuevoPrecioString = Console.ReadLine();

            if (!string.IsNullOrEmpty(nuevoPrecioString))
            {
                decimal nuevoPrecio = decimal.Parse(nuevoPrecioString);
                productoAEditar.Precio = nuevoPrecio;
            }
            Console.WriteLine("Nueva cantidad en inventario (dejar en blanco para no cambiar): ");
            string nuevaCantidadEnInventarioString = Console.ReadLine();

            if (!string.IsNullOrEmpty(nuevaCantidadEnInventarioString))
            {
                int nuevaCantidadEnInventario = int.Parse(nuevaCantidadEnInventarioString);
                productoAEditar.CantidadEnInventario = nuevaCantidadEnInventario;
            }
            Console.WriteLine("Producto actualizado correctamente.");
        } 
        private void EliminarProducto()
        {
            Console.WriteLine("Eliminar Prodducto");
            for (int i = 0; 1 < productosDisponibles.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {productosDisponibles[i].Nombre}");
            }

            Console.Write("Seleccione el producto a eliminar: ");
            int indiceProductoAEliminar = int.Parse(Console.ReadLine()) - 1;

            productosDisponibles.RemoveAt(indiceProductoAEliminar);

            Console.WriteLine("producto eliminado correctamente.");
        }
        private void MostrarInformacionProducto()
        {
            Console.WriteLine("Mostrar informacion de un producto");
            for (int i = 0; i < productosDisponibles.Count;i++)
            {
                Console.WriteLine($"{i + 1}. {productosDisponibles[i].Nombre}");
            }

            Console.WriteLine("Seleccione el producto del que desea ver la informacion: ");
            int indiceProductoAMostrar = int.Parse(Console.ReadLine()) - 1;

            Producto productoAMostrar = productosDisponibles[indiceProductoAMostrar];
            Console.WriteLine($"Nombre: {productoAMostrar.Nombre}");
            Console.WriteLine($"Descripcion: {productoAMostrar.Descripcion}");
            Console.WriteLine($"Precio: {productoAMostrar.Precio}");
            Console.WriteLine($"Cantidad en inventario: {productoAMostrar.CantidadEnInventario}");
        }

        private void HacerVenta()
        {
            Console.WriteLine("Realizar una venta");

            List<Producto> productosAComprar = new List<Producto>();
            List<int> cantidadesAComprar = new List<int>();

            while (true)
            {
                Console.WriteLine("Lista de productos disponibles.");
                for(int i = 0;i < productosDisponibles.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {productosDisponibles[i].Nombre} - Precio: {productosDisponibles[i].Precio}, " +
                        $"Cantidad en inventario: {productosDisponibles[i].CantidadEnInventario}");
                }

                Console.WriteLine("Ingrese el numero del producto que desea comprar (0 para terminar): ");
                int indiceProducto = int.Parse(Console.ReadLine()) - 1;
                if (indiceProducto == -1)
                {
                    break;
                }
                Console.WriteLine("Ingrese la cantidad que desea comprar: ");
                int cantidadAComprar = int.Parse(Console.ReadLine());

                Producto productoAComprar = productosDisponibles[indiceProducto];

                if (cantidadAComprar > productoAComprar.CantidadEnInventario)
                {
                    Console.WriteLine($"No hay suficiente cantidad en inventario. Hay{productoAComprar.CantidadEnInventario}" +
                        $"unidades disponibles");
                    continue;
                }

                productosAComprar.Add(productoAComprar);
                cantidadesAComprar.Add(cantidadAComprar);

                Console.WriteLine($"Producto {productoAComprar.Nombre} agregado a la venta");
            }

            decimal totalAPagar = 0;

            for(int i = 0; i < productosAComprar.Count; i++)
            {
                Producto productoAComprar = productosAComprar[i];
                int cantidadAComprar = cantidadesAComprar[i];

                productoAComprar.CantidadEnInventario -= cantidadAComprar;
                totalAPagar += productoAComprar.Precio * cantidadAComprar;

            }
            Console.WriteLine($"Total a pagar: {totalAPagar}");
        }

    }
  
}
