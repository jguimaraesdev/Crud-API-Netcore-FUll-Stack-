using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("[controller]")]
public class ClienteVeiculoController : ControllerBase
{
    private EstacionamentoDbContext _dbContext;
    public ClienteVeiculoController(EstacionamentoDbContext context)
    {
        _dbContext = context;
    }

    //--------------------------------------------------------------------//

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<ClienteVeiculo>>> Listar()
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.clienteVeiculo is null) return BadRequest();
        return await _dbContext.clienteVeiculo.ToListAsync();
    }

     //--------------------------------------------------------------------//

    [HttpGet]
    [Route("buscar/{cpf}")]
    public async Task<ActionResult<ClienteVeiculo>> Buscar(string cpf)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.clienteVeiculo is null) return BadRequest();
        var clienteTemp = await _dbContext.clienteVeiculo.FindAsync(cpf);
        if(clienteTemp is null) return BadRequest();
        return clienteTemp;
    }

     //--------------------------------------------------------------------//

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(ClienteVeiculo cliente)
    {
        if(_dbContext is null) return BadRequest();
        await _dbContext.AddAsync(cliente);
        await _dbContext.SaveChangesAsync();
        return Created("", cliente);
    }

     //--------------------------------------------------------------------//


     [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(ClienteVeiculo cliente)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.clienteVeiculo is null) return BadRequest();
        var clienteTemp = await _dbContext.clienteVeiculo.FindAsync(cliente);
        if(clienteTemp is null) return BadRequest();
        clienteTemp.Clientes_Cpf = cliente.Clientes_Cpf;
        clienteTemp.Veiculos_Placa= cliente.Veiculos_Placa;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

     //--------------------------------------------------------------------//


    [HttpDelete()]
    [Route("excluir/{cpf}")]
    public async Task<ActionResult> Excluir(string cpf)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.clienteVeiculo is null) return BadRequest();
        var clienteTemp = await _dbContext.clienteVeiculo.FindAsync(cpf);
        if(clienteTemp is null) return BadRequest();
        _dbContext.Remove(clienteTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}