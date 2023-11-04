using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("[controller]")]
public class NotaController : ControllerBase
{
    private readonly EstacionamentoDbContext _context;

    public NotaController(EstacionamentoDbContext context)
    {
        _context = context;
    }

    //--------------------------------------------------------------------//

    [HttpGet()]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<NotaFiscal>>> Listar()
    {   
         if (_context is null) return BadRequest();
        if (_context.notafiscal is null) return BadRequest();
        return await _context.notafiscal.ToListAsync();
    }

    //--------------------------------------------------------------------//

    [HttpGet()]
    [Route("buscar/{numeroNota}")]
    public async Task<ActionResult<NotaFiscal>> Buscar(string NumeroNota)
    {
         if (_context is null) return BadRequest();
        if (_context.notafiscal is null) return BadRequest();
        var notaFiscal = await _context.notafiscal.FindAsync(NumeroNota);
         if (notaFiscal is null) return BadRequest();
        return notaFiscal;
    }

    //--------------------------------------------------------------------//

    [HttpPost()]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(NotaFiscal notaFiscal)
    {
        
        await _context.AddAsync(notaFiscal);
        await _context.SaveChangesAsync();
        return Created("", notaFiscal);
    }

    //--------------------------------------------------------------------//

    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(NotaFiscal notafiscal)
    {
        if (_context is null) return BadRequest();
        if (_context.notafiscal is null) return BadRequest();
        var nota = await _context.notafiscal.FindAsync(notafiscal._NumeroNota);
         if (nota is null) return BadRequest();
        nota._NumeroNota = notafiscal._NumeroNota;
        
        await _context.SaveChangesAsync();
        return Ok();
    }
    
    //--------------------------------------------------------------------//

    [HttpDelete]
    [Route("excluir/{numeroNota}")]
    public async Task<IActionResult> Excluir(string numeronota)
    {
        if (_context is null) return BadRequest();
        if (_context.notafiscal is null) return BadRequest();
        var notatemp = await _context.notafiscal.FirstOrDefaultAsync(x => x._NumeroNota == numeronota);
        if (notatemp is null) return BadRequest();
        _context.Remove(notatemp);
        await _context.SaveChangesAsync();
        return Ok();
    }
}

