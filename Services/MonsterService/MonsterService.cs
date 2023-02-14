using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG.Data;
using RPG.Dtos;
using RPG.Dtos.Monsters;
using RPG.Models;
using RPG.Models.Enums;
using RPG.Services.AuthenticationService;

namespace RPG.Services.MonsterService;

public class MonsterService : IMonsterService
{
    private readonly DataContext _dataContext;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public MonsterService(DataContext dataContext, IAuthenticationService authenticationService, IMapper mapper)
    {
        _dataContext = dataContext;
        _authenticationService = authenticationService;
        _mapper = mapper;
    }


    public async Task<ApiResponse<List<GetMonsterDto>>> GetAllMonsters(int charId)
    {
        var character = await _dataContext.Characters
            .Where(c => c.User!.Id == _authenticationService.GetUserId())
            .FirstOrDefaultAsync(c => c.Id == charId);
        if (character is null)
            return new ApiResponse<List<GetMonsterDto>>()
            {
                Success = false,
                Message = $"Character with id {charId} not found."
            };
        
        return new ApiResponse<List<GetMonsterDto>>()
        {
            Data = await _dataContext.Monsters
                .Where(m => m.CharacterId == character.Id)
                .Select(m => _mapper.Map<GetMonsterDto>(m))
                .ToListAsync()
        };
    }

    public async Task<ApiResponse<GetMonsterDto>> GetMonsterById(int charId, int monsterId)
    {
        var character = await _dataContext.Characters
            .Where(c => c.User!.Id == _authenticationService.GetUserId())
            .FirstOrDefaultAsync(c => c.Id == charId);
        if (character is null)
            return new ApiResponse<GetMonsterDto>()
            {
                Success = false,
                Message = $"Character with id {charId} not found."
            };
        
        var monster = await _dataContext.Monsters
            .Where(m => m.CharacterId == charId)
            .FirstOrDefaultAsync(m => m.Id == monsterId);
        if (monster is null)
            return new ApiResponse<GetMonsterDto>()
            {
                Success = false,
                Message = $"Monster with id {charId} not found."
            };

        return new ApiResponse<GetMonsterDto>()
        {
            Data = _mapper.Map<GetMonsterDto>(monster)
        };
    }

    public async Task<ApiResponse<GetMonsterDto>> CreateMonster(CreateMonsterDto request)
    {
        var character = await _dataContext.Characters
            .Where(c => c.User!.Id == _authenticationService.GetUserId())
            .FirstOrDefaultAsync(c => c.Id == request.CharId);
        if (character is null)
            return new ApiResponse<GetMonsterDto>()
            {
                Success = false,
                Message = $"Character with id {request.CharId} not found."
            };
        
        var rand = new Random();
        var difficultyInt = (int) request.Difficulty + 1;
        var monster = new Monster
        {
            AttackType = (AttackType)rand.Next(Enum.GetValues(typeof(AttackType)).Length),
            Pierce = (difficultyInt + rand.Next(difficultyInt + 1)) / 2m,
            Attack = difficultyInt + rand.Next(difficultyInt + 1),
            Dexterity = difficultyInt + rand.Next(difficultyInt + 1),
            Strength = difficultyInt + rand.Next(difficultyInt + 1),
            Intelligence = difficultyInt + rand.Next(difficultyInt + 1),
            Defense = difficultyInt + rand.Next(difficultyInt + 1),
            Hp = difficultyInt + rand.Next(difficultyInt + 1) * 10,
            CharacterId = character.Id,
            Character = character
        };

        switch (monster.AttackType)
        {
            case AttackType.Melee:
                monster.Hp += rand.Next(difficultyInt * 3);
                monster.Strength += rand.Next(difficultyInt * 3);
                monster.Defense += rand.Next(difficultyInt * 2);
                break;
            case AttackType.Ranged:
                monster.Dexterity += rand.Next(difficultyInt * 3);
                monster.Pierce += rand.Next(difficultyInt * 2);
                break;
            case AttackType.Magic:
                monster.Intelligence += rand.Next(difficultyInt * 3);
                monster.Pierce += rand.Next(difficultyInt * 2);
                break;
        }

        await using (var transaction = await _dataContext.Database.BeginTransactionAsync())
        {
            try
            {
                await _dataContext.Monsters.AddAsync(monster);
                await _dataContext.SaveChangesAsync();

                character.MonsterId = monster.Id;
                await _dataContext.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
            }
        }

        return new ApiResponse<GetMonsterDto>()
        {
            Data = _mapper.Map<GetMonsterDto>(monster)
        };
    }
}