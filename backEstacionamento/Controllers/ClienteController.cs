
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private EstacionamentoDbContext _dbContext;
    public ClienteController(EstacionamentoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    //--------------------------------------------------------------------//

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Cliente>>>Listar()
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.cliente is null) return BadRequest();
        return await _dbContext.cliente.ToListAsync();
    }

     //--------------------------------------------------------------------//

    [HttpGet]
    [Route("buscar/{cpf}")]
    public async Task<ActionResult<Cliente>>Buscar(string cpf)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.cliente is null) return BadRequest();
        var clienteTemp = await _dbContext.cliente.FindAsync(cpf);
        if(clienteTemp is null) return BadRequest();
        return clienteTemp;
    }

    //--------------------------------------------------------------------//

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult>Cadastrar(Cliente cliente)
    {
       if (_dbContext is null) return BadRequest();
        await _dbContext.AddAsync(cliente);
        await _dbContext.SaveChangesAsync();
        return Created("", cliente);
    }

    //--------------------------------------------------------------------//

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult>Alterar(Cliente cliente)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.cliente is null) return BadRequest();
        var clienteTemp = await _dbContext.cliente.FindAsync(cliente);
        if(clienteTemp is null) return BadRequest();
        clienteTemp._Cpf = cliente._Cpf;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

     //--------------------------------------------------------------------//


    [HttpDelete()]
    [Route("excluir/{cpf}")]
    public async Task<ActionResult>Excluir(string  cpf)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.cliente is null) return BadRequest();
        var clienteTemp = await _dbContext.cliente.FindAsync(cpf);
        if(clienteTemp is null) return BadRequest();
        _dbContext.Remove(clienteTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

     //--------------------------------------------------------------------//
}