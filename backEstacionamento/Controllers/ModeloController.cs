
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace backEstacionamento.Controllers;

[ApiController]
[Route("[controller]")]
public class ModeloController : ControllerBase
{
    private EstacionamentoDbContext _dbContext;
    public ModeloController(EstacionamentoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    //--------------------------------------------------------------------//

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Modelo>>> Listar()
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.modelo is null) return BadRequest();
        return await _dbContext.modelo.ToListAsync();
    }

    //--------------------------------------------------------------------//

    [HttpGet]
    [Route("buscar/{id}")]

    public async Task<ActionResult<Modelo>> Buscar(int id)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.modelo is null) return BadRequest();
        var modeloTemp = await _dbContext.modelo.FindAsync(id);
        if(modeloTemp is null) return BadRequest();
        return modeloTemp;
    }

    //--------------------------------------------------------------------//

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Modelo modelo)
    {
        if(_dbContext is null) return BadRequest();
        await _dbContext.AddAsync(modelo);
        if(_dbContext.modelo is null) return BadRequest();
        await _dbContext.SaveChangesAsync();
        return Created("", modelo);
    }

    //--------------------------------------------------------------------//

        [HttpPut]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Modelo modelo)
        {
        if (_dbContext is null)
        {
        return BadRequest("Contexto não encontrado.");
        }

        if (modelo is null)
        {
        return BadRequest("O serviço fornecido é inválido.");
        }

        var servicoTemp = await _dbContext.modelo.AsNoTracking().FirstOrDefaultAsync(s => s._idModelo == modelo._idModelo);

        if (servicoTemp == null)
        {
        return NotFound($"Serviço com ID {modelo._idModelo} não encontrado.");
        }

        try
        {
        // Atualize as propriedades necessárias
        servicoTemp._nomeModelo=modelo._nomeModelo;
        servicoTemp._AnoModelo=modelo._AnoModelo;
        servicoTemp._TipoModelo=modelo._TipoModelo;
        // Atualize outras propriedades conforme necessário

        _dbContext.modelo.Update(servicoTemp);
        await _dbContext.SaveChangesAsync();

        return Ok(servicoTemp); // Retorna o objeto atualizado
        }
        catch (Exception ex)
        {
        return StatusCode(500, $"Erro interno ao atualizar o serviço: {ex.Message}");
        }
        }


    //--------------------------------------------------------------------//
    
    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.modelo is null) return BadRequest();
        var modeloTemp = await _dbContext.modelo.FindAsync(id);
        if(modeloTemp is null) return BadRequest();
        _dbContext.Remove(modeloTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    //--------------------------------------------------------------------//

    [HttpPut()]
    [Route("update/id")]
    private async Task<ActionResult> updateid(Modelo modelo)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.modelo is null) return BadRequest();
        var modeloTemp = await _dbContext.modelo.FindAsync(modelo);
        if(modeloTemp is null) return BadRequest();
        modeloTemp.Marca = modelo.Marca;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}
