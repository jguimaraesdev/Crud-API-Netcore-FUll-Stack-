
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
    public async Task<ActionResult<IEnumerable<Periodo>>> GetListarAsync()

    {
        if (_context.periodo is null) return NotFound();
        return await _context.periodo.ToListAsync();

    }



    [HttpGet()]
    [Route("buscar/{periodo}")]
    public async Task<ActionResult<Periodo>> Buscar([FromRoute] int idperiodo)
    {
        if (_context.periodo is null) return NotFound();
        var periodo = await _context.periodo.FindAsync(idperiodo);
        return periodo;
    }

    //--------------------------------------------------------------------//


    [HttpPost()]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Periodo periodo)
    {
        await _context.periodo.AddAsync(periodo);
        await _context.SaveChangesAsync();
        return Created("",periodo);
    }

    //--------------------------------------------------------------------//

    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Periodo periodo)
    {
        _context.periodo.Update(periodo);
        await _context.SaveChangesAsync();
        return Ok();
    }


    //--------------------------------------------------------------------//
    [HttpDelete]
    [Route("excluir/{Periodo}")]
    public async Task<IActionResult> excluir(int idperiodo)
    {
        var periodo = await _context.periodo.FindAsync(idperiodo);
        if (_context.periodo is null) return NotFound();
        _context.periodo.Remove(periodo);
        await _context.SaveChangesAsync();
        return Ok();
    }


    //--------------------------------------------------------------------//

}
