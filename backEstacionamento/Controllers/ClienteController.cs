
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

        [HttpPut]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Cliente cliente)
        {
        if (_dbContext is null)
        {
        return BadRequest("Contexto não encontrado.");
        }

        if (cliente is null)
        {
        return BadRequest("O serviço fornecido é inválido.");
        }

        var servicoTemp = await _dbContext.cliente.AsNoTracking().FirstOrDefaultAsync(s => s._Cpf == cliente._Cpf);

        if (servicoTemp == null)
        {
        return NotFound($"Serviço com ID {cliente._Cpf} não encontrado.");
        }

        try
        {
        // Atualize as propriedades necessárias
        servicoTemp._Cpf= cliente._Cpf;
        servicoTemp._Email = cliente._Email;
        servicoTemp._Nome = cliente._Nome;
        // Atualize outras propriedades conforme necessário

        _dbContext.cliente.Update(servicoTemp);
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