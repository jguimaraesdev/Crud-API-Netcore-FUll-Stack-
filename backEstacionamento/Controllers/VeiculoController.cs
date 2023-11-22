using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("[controller]")]
public class VeiculoController : ControllerBase
{
    private EstacionamentoDbContext _context;
    public VeiculoController(EstacionamentoDbContext context)
    {
        _context = context;
    }

    //--------------------------------------------------------------------//

    [HttpGet()]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Veiculo>>> Listar()
    {
        if (_context is null) return BadRequest();
        if (_context.veiculo is null) return BadRequest();
        return await _context.veiculo.ToListAsync();
    }

    //--------------------------------------------------------------------//

    [HttpGet()]
    [Route("buscar/{placa}")]
    public async Task<ActionResult<Veiculo>> Buscar([FromRoute] string placa)
    {
        if (_context is null) return BadRequest();
        if (_context.veiculo is null) return BadRequest();
        var veiculotemp = await _context.veiculo.FindAsync(placa);
        if(veiculotemp is null) return BadRequest();
        return veiculotemp;
    }

    //--------------------------------------------------------------------//

    [HttpPost()]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Veiculo veiculo)
    {
        if(_context is null) return BadRequest();
        await _context.AddAsync(veiculo);
        await _context.SaveChangesAsync();
        return Created("", veiculo);
    }

    //--------------------------------------------------------------------//

    [HttpPut]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Veiculo veiculo)
        {
        if (_context is null)
        {
        return BadRequest("Contexto não encontrado.");
        }

        if (veiculo is null)
        {
        return BadRequest("O serviço fornecido é inválido.");
        }

        var servicoTemp = await _context.veiculo.AsNoTracking().FirstOrDefaultAsync(s => s._Placa == veiculo._Placa);

        if (servicoTemp == null)
        {
        return NotFound($"Serviço com ID {veiculo._Placa} não encontrado.");
        }

        try
        {
        // Atualize as propriedades necessárias
        servicoTemp._Placa = veiculo._Placa;
        servicoTemp._Cor = veiculo._Cor;
        servicoTemp._idModelo = veiculo._idModelo;
       
        // Atualize outras propriedades conforme necessário

        _context.veiculo.Update(servicoTemp);
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
    [Route("excluir/{placa}")]
    public async Task<IActionResult> excluir(string placa)
    {
        if(_context is null) return BadRequest();
        if(_context.veiculo is null) return BadRequest();
        var veiculo = await _context.veiculo.FirstOrDefaultAsync(x => x._Placa == placa);
        if (veiculo is null) return BadRequest();
        _context.Remove(veiculo);
        await _context.SaveChangesAsync();
        return Ok();
    }
    //--------------------------------------------------------------------//
    /*
    [HttpPatch]
    [Route("modificardescricao/{placa}")]
    public async Task<IActionResult> ModificarDescricao(string placa, [FromForm] string Descricao)
    {
        var veiculo = await _context.veiculo.FindAsync(placa);
        if (_context.veiculo is null) return NotFound();
        veiculo._Descricao = Descricao;
        await _context.SaveChangesAsync();
        return Ok();
    }

    */
}