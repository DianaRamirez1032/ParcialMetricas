using Domain.Entities;
using Domain.Services;
using Infrastructure.Data;
using Infrastructure.Logging;
using Microsoft.Data.SqlClient;

namespace Application.UseCases
{
    public class CreateOrderUseCase
    {
        public Order Execute(string customer, string product, int qty, decimal price)
        {
            Logger.Log("CreateOrderUseCase starting");

            var order = OrderService.CreateOrder(customer, product, qty, price);

            var sql = "INSERT INTO Orders(Id, Customer, Product, Qty, Price) VALUES (@Id, @Customer, @Product, @Qty, @Price)";

            try
            {
                BadDb.ExecuteNonQuery(sql, new[]
                {
                    new SqlParameter("@Id", order.Id),
                    new SqlParameter("@Customer", customer),
                    new SqlParameter("@Product", product),
                    new SqlParameter("@Qty", qty),
                    new SqlParameter("@Price", price)
                });
            }
            catch (Exception ex)
            {
                Logger.Log($"Error al insertar orden: {ex.Message}");
            }

            return order;
        }
    }
}