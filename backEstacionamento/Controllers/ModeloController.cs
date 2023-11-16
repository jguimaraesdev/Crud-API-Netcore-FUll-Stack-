
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

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Modelo modelo)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.modelo is null) return BadRequest();
        var modeloTemp = await _dbContext.modelo.FindAsync(modelo._idMarca);
        if(modeloTemp is null) return BadRequest();
        modeloTemp._nomeModelo = modelo._nomeModelo;
        await _dbContext.SaveChangesAsync();
        return Ok();
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