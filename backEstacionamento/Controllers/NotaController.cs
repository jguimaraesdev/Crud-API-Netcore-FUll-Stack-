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

    [HttpGet()]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<NotaFiscal>>> Listar()
    {
        if (_context.notafiscal is null) return NotFound();
        return await _context.notafiscal.ToListAsync();
    }

    [HttpGet()]
    [Route("buscar/{numeroNota}")]
    public async Task<ActionResult<NotaFiscal>> Buscar([FromRoute] string NumeroNota)
    {
        if (_context.notafiscal is null) return NotFound();
        var notaFiscal = await _context.notafiscal.FindAsync(NumeroNota);
        return notaFiscal;
    }

    [HttpPost()]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(NotaFiscal notaFiscal)
    {
        await _context.AddAsync(notaFiscal);
        await _context.SaveChangesAsync();
        return Created("", notaFiscal);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(NotaFiscal notaFiscal)
    {
        _context.notafiscal.Update(notaFiscal);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("excluir/{numeroNota}")]
    public async Task<IActionResult> Excluir(string NumeroNota)
    {
        var notaFiscal = await _context.notafiscal.FindAsync(NumeroNota);
        if (_context.notafiscal is null) return NotFound();
        _context.notafiscal.Remove(notaFiscal);
        await _context.SaveChangesAsync();
        return Ok();
    }
}

