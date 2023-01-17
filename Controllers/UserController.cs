using Microsoft.AspNetCore.Mvc;
using RPG.Data;
using RPG.Dtos;
using RPG.Dtos.Users;
using RPG.Services.AuthenticationService;

namespace RPG.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly DataContext _dataContext;
    private readonly IAuthenticationService _authenticationService;

    public UserController(DataContext dataContext, IAuthenticationService authenticationService)
    {
        _dataContext = dataContext;
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<ApiResponse<string>>> login(UserLoginDto request)
    {
        return Ok(await _authenticationService.Login(request));
    }

    [HttpPost("register")]
    public async Task<ActionResult<ApiResponse<int>>> register(UserRegisterDto request)
    {
        return Ok(await _authenticationService.Register(request));
    }
}