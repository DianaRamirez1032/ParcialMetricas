namespace Domain.Entities
{
    // Esta clase encapsula los datos esenciales de una orden y pertenece a la capa de dominio.
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // Método que calcula el total de la orden y registra el resultado en el sistema de logging.
        public void CalculateTotalAndLog()
        {
            var total = Quantity * UnitPrice;
            Infrastructure.Logging.Logger.Log("Total (maybe): " + total);
        }
    }
}