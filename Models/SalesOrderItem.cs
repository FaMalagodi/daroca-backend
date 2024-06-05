public class SalesOrderItem 
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public  int Quantity { get; set; }
    public required decimal UnitPrice { get; set; }
}

//metodo q calcula um preço total de um pedido
//criariamos um metodo que percorreria a lista de pedidos e calcule o preço total