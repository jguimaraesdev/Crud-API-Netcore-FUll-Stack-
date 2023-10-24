using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private EstacionamentoDbContext _context;
    public ClienteController(EstacionamentoDbContext context)
    {
        _context = context;
    }

    [HttpGet()]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
    {
        if (_context.cliente is null) return NotFound();
        return await _context.cliente.ToListAsync();
    }

    [HttpGet()]
    [Route("buscar/{cpf}")]
    public async Task<ActionResult<Cliente>> Buscar([FromRoute] string Cpf)
    {
        if (_context.cliente is null) return NotFound();
        var cliente = await _context.cliente.FindAsync(Cpf);
        return cliente;
    }

    [HttpPost()]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Cliente cliente)
    {
        await _context.AddAsync(cliente);
        await _context.SaveChangesAsync();
        return Created("", cliente);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Cliente cliente)
    {
        _context.cliente.Update(cliente);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("excluir/{cpf}")]
    public async Task<IActionResult> excluir(int Id)
    {
        var cliente = await _context.cliente.FindAsync(Id);
        if (_context.cliente is null) return NotFound();
        _context.cliente.Remove(cliente);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch]
    [Route("modificaremail/{cpf}")]
    public async Task<IActionResult> ModificarEmail(string Cpf, [FromForm] string newEmail)
    {
        var cliente = await _context.cliente.FindAsync(Cpf);
        if (_context.cliente is null) return NotFound();
        cliente._Email = newEmail;
        await _context.SaveChangesAsync();
        return Ok();
    }

   
}