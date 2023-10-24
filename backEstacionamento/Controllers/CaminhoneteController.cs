using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("[controller]")]
public class CaminhoneteController : ControllerBase
{
    private EstacionamentoDbContext _context;
    public CaminhoneteController(EstacionamentoDbContext context)
    {
        _context = context;
    }

    [HttpGet()]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Caminhonete>>> Listar()
    {
        if (_context.caminhonete is null) return NotFound();
        return await _context.caminhonete.ToListAsync();
    }

    [HttpGet()]
    [Route("buscar/{placa}")]
    public async Task<ActionResult<Caminhonete>> Buscar([FromRoute] string placa)
    {
        if (_context.caminhonete is null) return NotFound();
        var buscaplaca = await _context.caminhonete.FindAsync(placa);
        return buscaplaca;
    }

    [HttpPost()]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Caminhonete caminhonete)
    {
        await _context.AddAsync(caminhonete);
        await _context.SaveChangesAsync();
        return Created("", caminhonete);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Caminhonete caminhonete)
    {
        _context.caminhonete.Update(caminhonete);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("excluir/{placa}")]
    public async Task<IActionResult> excluir(string placa)
    {
        var caminhonete = await _context.caminhonete.FindAsync(placa);
        if (_context.caminhonete is null) return NotFound();
        _context.caminhonete.Remove(caminhonete);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch]
    [Route("modificardescricao/{placa}")]
    public async Task<IActionResult> ModificarDescricao(string placa, [FromForm] string newplaca)
    {
        var caminhonete = await _context.caminhonete.FindAsync(placa);
        if (_context.caminhonete is null) return NotFound();
        caminhonete.Veiculo._Placa = newplaca;
        await _context.SaveChangesAsync();
        return Ok();
    }
}