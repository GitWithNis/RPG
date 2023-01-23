using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPG.Dtos;
using RPG.Dtos.Monsters;
using RPG.Services.MonsterService;

namespace RPG.Controllers;

[ApiController()]
[Authorize]
[Route("[controller]")]
public class MonsterController : ControllerBase
{
    private readonly IMonsterService _monsterService;

    public MonsterController(IMonsterService monsterService)
    {
        _monsterService = monsterService;
    }

    [HttpGet("{charId:int}")]
    public async Task<ActionResult<ApiResponse<GetMonsterDto>>> GetAllMonsters(int charId)
    {
        return Ok(await _monsterService.GetAllMonsters(charId));
    }

    [HttpGet("GetMonsterById/{charId:int}/{monsterId:int}")]
    public async Task<ActionResult<ApiResponse<List<GetMonsterDto>>>> GetMonsterById(int charId, int monsterId)
    {
        return Ok(await _monsterService.GetMonsterById(charId, monsterId));
    }

    [HttpPost()]
    public async Task<ActionResult<ApiResponse<GetMonsterDto>>> CreateMonster(CreateMonsterDto request)
    {
        return Ok(await _monsterService.CreateMonster(request));
    }
}