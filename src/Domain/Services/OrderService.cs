using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Services
{
    public static class OrderService
    {
        // Solo para pruebas, no recomendado en producción
        public static List<Order> LastOrders { get; } = new List<Order>();

        public static Order CreateOrder(string customer, string product, int qty, decimal price)
        {
            // Generar ID único de forma más robusta
            var o = new Order
            {
                Id = Guid.NewGuid().GetHashCode(), // mejor que Random.Next
                CustomerName = customer,
                ProductName = product,
                Quantity = qty,
                UnitPrice = price
            };

            LastOrders.Add(o);

            // ⚠️ El dominio no debería loguear directamente.
            // El logging debería hacerse en Application o Infrastructure.
            // Aquí solo devolvemos la entidad.
            return o;
        }
    }
}