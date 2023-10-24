using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("[controller]")]
public class MotoController : ControllerBase
{
    private EstacionamentoDbContext _context;
    public MotoController(EstacionamentoDbContext context)
    {
        _context = context;
    }

    [HttpGet()]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Moto>>> Listar()
    {
        if (_context.moto is null) return NotFound();
        return await _context.moto.ToListAsync();
    }

    [HttpGet()]
    [Route("buscar/{placa}")]
    public async Task<ActionResult<Moto>> Buscar([FromRoute] string placa)
    {
        if (_context.moto is null) return NotFound();
        var placamoto = await _context.moto.FindAsync(placa);
        return placamoto;
    }

    [HttpPost()]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Moto moto)
    {
        await _context.AddAsync(moto);
        await _context.SaveChangesAsync();
        return Created("", moto);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Moto moto)
    {
        _context.moto.Update(moto);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("excluirMoto/{placa}")]
    public async Task<IActionResult> excluirMoto(string placa)
    {
        var moto = await _context.moto.FindAsync(placa);
        if (_context.moto is null) return NotFound();
        _context.moto.Remove(moto);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch]
    [Route("modificardescricao/{placa}")]
    public async Task<IActionResult> ModificarDescricao(string placa, [FromForm] string Descricao)
    {
        var moto = await _context.moto.FindAsync(placa);
        if (_context.moto is null) return NotFound();
        moto.Veiculo._Descricao = Descricao;
        await _context.SaveChangesAsync();
        return Ok();
    }
}