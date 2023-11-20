
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {

    //--------------------------------------------------------------------//

    //injeção de dependencia para a acesso ao banco de dados sqlite;

    private EstacionamentoDbContext _dbContext;
    public TicketController(EstacionamentoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    //--------------------------------------------------------------------//



    [HttpGet()]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Ticket>>> Listar()
    {
        if (_dbContext is null) return BadRequest();
        if (_dbContext.ticket is null) return BadRequest();
        return await _dbContext.ticket.ToListAsync();
    }


    //--------------------------------------------------------------------//

    [HttpGet()]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Ticket>> Buscar(int id)
    {
        if (_dbContext is null) return BadRequest();
        if (_dbContext.ticket is null) return BadRequest();
        var tickettemp = await _dbContext.ticket.FindAsync(id);
        if (tickettemp is null) return BadRequest();
            return tickettemp;
        }

    //--------------------------------------------------------------------//

    [HttpGet()]
    [Route("buscar/{COD}")]
    public async Task<ActionResult<Ticket>> BuscarCOD(string codigo)
    {
        if (_dbContext is null) return BadRequest();
        if (_dbContext.ticket is null) return BadRequest();
        var tickettemp = await _dbContext.ticket.FirstOrDefaultAsync(x =>x._codTicket == codigo);
        if (tickettemp is null) return BadRequest();
            return tickettemp;
        }

    //--------------------------------------------------------------------//
    [HttpPost()]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Ticket ticket)
    {
        if (_dbContext is null) return BadRequest();
        if(_dbContext.ticket is null) return BadRequest();
        await _dbContext.AddAsync(ticket);
        await _dbContext.SaveChangesAsync();
        return Created("",ticket);
    }
            

    //--------------------------------------------------------------------//


    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult>alterar(Ticket ticket)
    {
        if (_dbContext is null) return BadRequest();
        if (_dbContext.ticket is null) return BadRequest();
        var tickettemp = await _dbContext.ticket.FirstOrDefaultAsync(x => x._idTicket==ticket._idTicket);
        if (tickettemp is null) return BadRequest();
        tickettemp._HoraSaida = ticket._HoraSaida;
        tickettemp._Pagamento=ticket._Pagamento;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    //--------------------------------------------------------------------//

    [HttpDelete]
    [Route("excluir/{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        if (_dbContext is null) return BadRequest();
        if (_dbContext.ticket is null) return BadRequest();
        var ticketemp = await _dbContext.ticket.FindAsync(id);
        if (ticketemp is null) return NotFound();
        _dbContext.Remove(ticketemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

     //--------------------------------------------------------------------//    

    }

