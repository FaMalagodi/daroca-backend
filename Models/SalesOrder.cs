//classe de pedido
// OrderId    int    
//CustomerId    int required
//OrderDate  dateTime    required
// EstimateDdeliveryDate date
//Status string required

//não se esquecam de que sales order possui relação com Customer


public class SalesOrder 
{
    public int OrderId { get; set; }
    public required int CustomerId { get; set; }
    public required DateTime OrderDate { get; set; }
    public DateOnly EstimatedDeliveryDate { get; set; }
    public required string Status { get; set; }
}