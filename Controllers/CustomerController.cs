using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Route("/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly DatabaseContext context;

    public CustomerController(DatabaseContext context)
    {
        this.context = context;
    }

    [HttpGet] //get
    public ActionResult<IEnumerable<Customer>> GetCustomer()
    {
        return this.context.Customer.ToList(); // ta pegando o usuario e senha, pegando a tabela, e ai vai pegar todos os registros da tabela e vai converter pra lista
    }


    [HttpGet("{id}")]
    public ActionResult<Customer> GetCustomer(int id)
    {
        var customer = this.context.Customer.Find(id); // aqui faz um select from
        if(customer == null)
        {
            return NotFound(); // erro 404
        }
        return customer;
    }




    [HttpPost] //post
    public ActionResult<Customer> CreateCustomer(Customer customer) // post, inserir um novo registro no BD
    {
        if (customer == null)
        {
            return BadRequest();
        }
        this.context.Customer.Add(customer);
        this.context.SaveChanges();

        return CreatedAtAction(nameof(GetCustomer), new {id = customer.CustomerId}, customer); // aqui 
    }



    [HttpDelete("{id}")] //delete
    public ActionResult<Customer> DeleteCustomer(int id)
    {
    var customer = this.context.Customer.Find(id); // encontrar o cliente pelo ID
    if (customer == null)
    {
        return NotFound(); 
    }
    this.context.Customer.Remove(customer); 
    this.context.SaveChanges(); 

    return Ok(customer); 
    }

}

// vamos usar na prova, save changes