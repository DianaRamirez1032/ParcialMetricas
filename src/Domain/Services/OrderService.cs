using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Services
{
    // Servicio de dominio que encapsula la lógica relacionada con la creación de órdenes.
    public static class OrderService
    {
        public static List<Order> LastOrders { get; } = new List<Order>();

        // Método que crea una nueva instancia de Order con los datos proporcionados.
        public static Order CreateOrder(string customer, string product, int qty, decimal price)
        {
            var o = new Order
            {
                Id = Guid.NewGuid().GetHashCode(),

                CustomerName = customer,
                ProductName = product,
                Quantity = qty,
                UnitPrice = price
            };
            LastOrders.Add(o);
            return o;
        }
    }
}