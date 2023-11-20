
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



    [ApiController]
    [Route("[controller]")]
    public class ServicoController : ControllerBase
    {

        //--------------------------------------------------------------------//

        //injeção de dependencia para a acesso ao banco de dados sqlite;

        private EstacionamentoDbContext _context;
        public ServicoController(EstacionamentoDbContext context)
        {
            _context = context;
        }

        //--------------------------------------------------------------------//



        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Servico>>> Listar()

        {
            if (_context is null) return BadRequest();
            if (_context.servico is null) return BadRequest();
            return await _context.servico.ToListAsync();

        }

        //--------------------------------------------------------------------//

        [HttpGet()]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Servico>> Buscar(int id)
        {
            if (_context is null) return BadRequest();
            if (_context.servico is null) return BadRequest();
            var servico1 = await _context.servico.FindAsync(id);
            if (servico1 is null) return BadRequest();
            return servico1;
        }

        //--------------------------------------------------------------------//


        [HttpPost()]
        [Route("cadastrar")]
        public async Task<IActionResult> Cadastrar(Servico servico)
        {
             if (_context is null) return BadRequest();
            await _context.AddAsync(servico);
            await _context.SaveChangesAsync();
            return Created("",servico);
            
        }

        //--------------------------------------------------------------------//
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Servico servico)
    {
        if (_context is null) return BadRequest();
        if (_context.servico is null) return BadRequest();
        var marcaTemp = await _context.servico.FindAsync(servico._idServico);
        if (marcaTemp is null) return BadRequest();
        
        marcaTemp._tipoServico = servico._tipoServico;
        marcaTemp._valorServico = servico._valorServico;
        marcaTemp._Pagamento = servico._Pagamento;
        await _context.SaveChangesAsync();
        return Ok();
    }

        //--------------------------------------------------------------------//
        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<IActionResult> excluir(int id)
        {
            if (_context is null) return BadRequest();
            if (_context.servico is null) return BadRequest();
            var servico = await _context.servico.FindAsync(id);
            if (servico is null) return BadRequest();
            _context.Remove(servico);
            await _context.SaveChangesAsync();
            return Ok();
        }


        //--------------------------------------------------------------------//




    }

