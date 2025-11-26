using Domain.Entities;
using Domain.Services;
using Infrastructure.Data;
using Infrastructure.Logging;
using Microsoft.Data.SqlClient;

// Esta clase pertenece a la capa de aplicación y orquesta la lógica entre dominio e infraestructura.
namespace Application.UseCases
{
    public class CreateOrderUseCase
    {
        // Método principal que ejecuta el caso de uso de creación de orden.
        // Recibe los datos necesarios
        public Order Execute(string customer, string product, int qty, decimal price)
        {
            // Registro de inicio del proceso para trazabilidad.
            Logger.Log("CreateOrderUseCase starting");

            var order = OrderService.CreateOrder(customer, product, qty, price);
            var sql = "INSERT INTO Orders(Id, Customer, Product, Qty, Price) VALUES (@Id, @Customer, @Product, @Qty, @Price)";

            try
            {
                // Ejecución del comando SQL usando parámetros seguros.
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