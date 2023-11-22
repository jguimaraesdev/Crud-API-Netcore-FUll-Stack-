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
    public async Task<ActionResult<NotaFiscal>> Buscar(int NumeroNota)
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
        public async Task<ActionResult> Alterar(NotaFiscal nota)
        {
        if (_context is null)
        {
        return BadRequest("Contexto não encontrado.");
        }

        if (nota is null)
        {
        return BadRequest("O serviço fornecido é inválido.");
        }

        var servicoTemp = await _context.notafiscal.AsNoTracking().FirstOrDefaultAsync(s => s._NumeroNota == nota._NumeroNota);

        if (servicoTemp == null)
        {
        return NotFound($"Serviço com ID {nota._NumeroNota} não encontrado.");
        }

        try
        {
        // Atualize as propriedades necessárias
        servicoTemp._ValorDaNota = nota._ValorDaNota;
        servicoTemp._Cpf=nota._Cpf;
        servicoTemp._idServico = nota._idServico;
        // Atualize outras propriedades conforme necessário

        _context.notafiscal.Update(servicoTemp);
        await _context.SaveChangesAsync();

        return Ok(servicoTemp); // Retorna o objeto atualizado
        }
        catch (Exception ex)
        {
        return StatusCode(500, $"Erro interno ao atualizar o serviço: {ex.Message}");
        }
        }

    
    //--------------------------------------------------------------------//

    [HttpDelete]
    [Route("excluir/{numeroNota}")]
    public async Task<IActionResult> Excluir(int numeronota)
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

