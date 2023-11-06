
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



[ApiController]
[Route("[controller]")]
public class MarcaController : ControllerBase
{
    private EstacionamentoDbContext _dbContext;
    public MarcaController(EstacionamentoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
     //--------------------------------------------------------------------//

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Marca>>> Listar()
    {
        if (_dbContext is null) return BadRequest();
        if (_dbContext.marca is null) return BadRequest();
        return await _dbContext.marca.ToListAsync();
    }

     //--------------------------------------------------------------------//

    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Marca>> Buscar(int id)
    {
        if (_dbContext is null) return BadRequest();
        if (_dbContext.marca is null) return BadRequest();
        var marcaTemp = await _dbContext.marca.FindAsync(id);
        if (marcaTemp is null) return BadRequest();
        return marcaTemp;
    }

    //--------------------------------------------------------------------//

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Marca marca)
    {
        if (_dbContext is null) return BadRequest();
        await _dbContext.AddAsync(marca);
        await _dbContext.SaveChangesAsync();
        return Created("", marca);
    }

    //--------------------------------------------------------------------//
    
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Marca marca)
    {
        if (_dbContext is null) return BadRequest();
        if (_dbContext.marca is null) return BadRequest();
        var marcaTemp = await _dbContext.marca.FindAsync(marca._idMarca);
        if (marcaTemp is null) return BadRequest();
        marcaTemp._nomeMarca = marca._nomeMarca;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    //--------------------------------------------------------------------//

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if (_dbContext is null) return BadRequest();
        if (_dbContext.marca is null) return BadRequest();
        var marcaTemp = await _dbContext.marca.FindAsync(id);
        if (marcaTemp is null) return BadRequest();
        _dbContext.Remove(marcaTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

}
