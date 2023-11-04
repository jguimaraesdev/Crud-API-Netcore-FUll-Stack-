
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;





[ApiController]
[Route("[controller]")]
public class PeriodoController : ControllerBase

{

    //--------------------------------------------------------------------//

    //injeção de dependencia para a acesso ao banco de dados sqlite;

    private EstacionamentoDbContext _context;
    public PeriodoController(EstacionamentoDbContext context)
    {
        _context = context;
    }

    //--------------------------------------------------------------------//



    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Periodo>>> Listar()

    {   
        if (_context is null) return BadRequest();
        if (_context.periodo is null) return BadRequest();
        return await _context.periodo.ToListAsync();

    }



    [HttpGet()]
    [Route("buscar/{placa}")]
    public async Task<ActionResult<Periodo>> Buscar(String placa)
    {
        if (_context is null) return BadRequest();
        if (_context.periodo is null) return BadRequest();
        var periodo = await _context.periodo.FirstOrDefaultAsync(x => x._Placa == placa);
        if (periodo is null) return BadRequest();
        return periodo;
    }

    //--------------------------------------------------------------------//


    [HttpPost()]
    [Route("cadastrar/entrada")]
    public async Task<IActionResult> Cadastrar(Periodo periodo)
    {
        if (_context is null) return BadRequest();
        await _context.AddAsync(periodo);
        await _context.SaveChangesAsync();
        updateEntrada(periodo._Placa);//para inserir a data de entrada automaticamente
        return Created("",periodo);
        
    }

    //--------------------------------------------------------------------//
    //ESSE ESTA PRIVADO, POIS JÁ ESTA SENDO CHAMADO NA HORA DO CADASTRO PARA ATUALIZAR A ENTRADA;
    
    [HttpPut]
    [Route("update/entrada")]
    private async Task<IActionResult> updateEntrada(String placa)
    {
        if (_context is null) return BadRequest();
        if (_context.periodo is null) return BadRequest();
        var periodotemp = await _context.periodo.FirstOrDefaultAsync(x => x._Placa == placa);
        if (periodotemp is null) return BadRequest();
        periodotemp._HoraEntrada = DateTime.Now;
        await _context.SaveChangesAsync();
        return Ok();
    }


    //--------------------------------------------------------------------//

    

    [HttpPut]
    [Route("update/saida")]
    public async Task<IActionResult> updateSaida(String placa)
    {
        if (_context is null) return BadRequest();
        if (_context.periodo is null) return BadRequest();
        var periodotemp = await _context.periodo.FirstOrDefaultAsync(x => x._Placa == placa);
        if (periodotemp is null) return BadRequest();
        periodotemp._HoraSaida = DateTime.Now;
        await _context.SaveChangesAsync();
        return Ok();
    }


    //--------------------------------------------------------------------//

    [HttpDelete]
    [Route("excluir/{periodo}")]
    public async Task<IActionResult> excluir(string placa)
    {
        if (_context is null) return BadRequest();
        if (_context.periodo is null) return BadRequest();
        var periodotemp = await _context.periodo.FirstOrDefaultAsync(x => x._Placa == placa);
        if (periodotemp is null) return NotFound();
        _context.Remove(periodotemp);
        await _context.SaveChangesAsync();
        return Ok();
    }


    //--------------------------------------------------------------------//

}
