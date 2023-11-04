
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;




    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {

            //--------------------------------------------------------------------//

            //injeção de dependencia para a acesso ao banco de dados sqlite;

            private EstacionamentoDbContext _context;
            public TicketController(EstacionamentoDbContext context)
            {
                _context = context;
            }

            //--------------------------------------------------------------------//




            [HttpGet()]
            [Route("listarticket")]
            public async Task<ActionResult<IEnumerable<Ticket>>> Listar()
            {
                if (_context is null) return BadRequest();
                if (_context.ticket is null) return BadRequest();
                return await _context.ticket.ToListAsync();
            }


            //--------------------------------------------------------------------//

            [HttpGet()]
            [Route("buscar/{COD}")]
            public async Task<ActionResult<Ticket>> Buscar(int COD)
            {
                if (_context is null) return BadRequest();
                if (_context.ticket is null) return BadRequest();
                var tickettemp = await _context.ticket.FirstOrDefaultAsync(X =>X._codTicket == COD);
                if (tickettemp is null) return BadRequest();
                return tickettemp;
            }


            //--------------------------------------------------------------------//
            [HttpPost()]
            [Route("cadastrar")]
            public async Task<IActionResult> Cadastrar(Ticket newTicket)
            {
                if (_context is null) return BadRequest();
                if(_context.ticket is null) return BadRequest();
                await _context.AddAsync(newTicket);
                await _context.SaveChangesAsync();
                return Created("",newTicket);
            }
            

            //--------------------------------------------------------------------//


            [HttpPut]
            [Route("alterar")]
            public async Task<IActionResult> Alterar(Ticket inputTicket)
            {
                if (_context is null) return BadRequest();
                if (_context.ticket is null) return BadRequest();
                var tickettemp = await _context.ticket.FindAsync(inputTicket._codTicket);
                if (tickettemp is null) return BadRequest();
                tickettemp._codTicket = inputTicket._codTicket;
                await _context.SaveChangesAsync();
                return Ok();
            }

            //--------------------------------------------------------------------//

            [HttpDelete]
            [Route("excluir/{COD}")]
            public async Task<IActionResult> Excluir(int codTicket)
            {
                if (_context is null) return BadRequest();
                if (_context.ticket is null) return BadRequest();
                var ticketemp = await _context.ticket.FindAsync(codTicket);
                if (ticketemp is null) return NotFound();
                _context.Remove(ticketemp);
                await _context.SaveChangesAsync();
                return Ok();
            }

            //--------------------------------------------------------------------//





            



            
        
    }

