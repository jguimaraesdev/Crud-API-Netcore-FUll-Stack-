
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

        [HttpPut]
        [Route("alterar")]
        public async Task<IActionResult> Alterar(Servico servico)
        {
            if (_context is null) return BadRequest();
            if (_context.servico is null) return BadRequest();
            var servicotemp = await _context.servico.FindAsync(servico._idServico);
            if (servicotemp is null) return BadRequest();
            servicotemp._idServico = servico._idServico;
            await _context.SaveChangesAsync();
            
            return Ok();
        }


        //--------------------------------------------------------------------//

       

        [HttpPut]
        [Route("update/tiposervico")]
        private async Task<IActionResult> updatetiposervico(Servico servico)
        {
            if (_context is null) return BadRequest();
            if (_context.servico is null) return BadRequest();
            var servicotemp = await _context.servico.FindAsync(servico._idServico);
            if (servicotemp is null) return BadRequest();

            return Ok();
        }


        //--------------------------------------------------------------------//

        
        /*
        [HttpPut]
        [Route("update/ValorPagar")]
        public async Task<IActionResult> UpdateValorPagar(string codigoticket, double valor)
        {
            if (_context is null) return BadRequest();
            if (_context.servico is null) return BadRequest();
            var servicotemp = await _context.servico.FirstOrDefaultAsync(x =>x._idServico == ordemservico);
            if (servicotemp is null) return BadRequest();
            servicotemp._valorPagar = valor;
            await _context.SaveChangesAsync();
            return Ok();
        }

        */
        

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

