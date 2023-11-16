
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;





[ApiController]
[Route("[controller]")]
public class PeriodoController : ControllerBase

{

    //--------------------------------------------------------------------//

    //injeção de dependencia para a acesso ao banco de dados sqlite;

    private EstacionamentoDbContext _context;
    public PeriodoController(EstacionamentoDbContext context)
    {
        _context = context;
    }

    //--------------------------------------------------------------------//



    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Periodo>>> Listar()

    {   
        if (_context is null) return BadRequest();
        if (_context.periodo is null) return BadRequest();
        return await _context.periodo.ToListAsync();

    }



    [HttpGet()]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Periodo>> Buscar(int id)
    {
        if (_context is null) return BadRequest();
        if (_context.periodo is null) return BadRequest();
        var periodo = await _context.periodo.FindAsync(id);
        if (periodo is null) return BadRequest();
        return periodo;
    }

    //--------------------------------------------------------------------//


    [HttpPost()]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Periodo periodo)
    {
        if (_context is null) return BadRequest();
        await _context.AddAsync(periodo);
        await _context.SaveChangesAsync();
        updateEntrada(periodo);//para inserir a data de entrada automaticamente
        return Created("",periodo);
        
    }

    //--------------------------------------------------------------------//

    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Periodo periodo)
    {
        if (_context is null) return BadRequest();
        if (_context.periodo is null) return BadRequest();
        var temp = await _context.periodo.FindAsync(periodo);
        if (temp is null) return BadRequest();
        temp._Placa = periodo._Placa;
        
        await _context.SaveChangesAsync();
        return Ok();
    }

    //--------------------------------------------------------------------//
    //ESSE ESTA PRIVADO, POIS JÁ ESTA SENDO CHAMADO NA HORA DO CADASTRO PARA ATUALIZAR A ENTRADA;
    
    [HttpPut]
    [Route("update/entrada")]
    private async Task<IActionResult> updateEntrada(Periodo periodo)
    {
        if (_context is null) return BadRequest();
        if (_context.periodo is null) return BadRequest();
        var periodotemp = await _context.periodo.FirstOrDefaultAsync(x => x._Placa == periodo._Placa);
        if (periodotemp is null) return BadRequest();
        var data = DateTime.Now;
        var dataformatada = data.ToString("MM/dd/yyyy H:mm"); 
        periodotemp._HoraEntrada = dataformatada;
        await _context.SaveChangesAsync();
        return Ok();
    }


    //--------------------------------------------------------------------//

    

    [HttpPut]
    [Route("update/saida")]
    public async Task<IActionResult> updateSaida(String placa)
    {
        if (_context is null) return BadRequest();
        if (_context.periodo is null) return BadRequest();
        var periodotemp = await _context.periodo.FirstOrDefaultAsync(x => x._Placa == placa);
        if (periodotemp is null) return BadRequest();
        var data = DateTime.Now;
        var dataformatada = data.ToString("MM/dd/yyyy H:mm"); 
        periodotemp._HoraSaida = dataformatada;
        await _context.SaveChangesAsync();
        return Ok();
    }


    //--------------------------------------------------------------------//

    [HttpDelete]
    [Route("excluir/{id}")]
    public async Task<IActionResult> excluir(int id)
    {
        if (_context is null) return BadRequest();
        if (_context.periodo is null) return BadRequest();
        var periodotemp = await _context.periodo.FindAsync(id);
        if (periodotemp is null) return NotFound();
        _context.Remove(periodotemp);
        await _context.SaveChangesAsync();
        return Ok();
    }


    //--------------------------------------------------------------------//

}
