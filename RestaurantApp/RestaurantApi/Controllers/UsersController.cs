using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Services.Exceptions;

namespace RestaurantApi.Controllers;
[ApiController]
[Route("api/users")]
public class UsersController:ControllerBase
{
    private UserRepository repository;

    public UsersController(UserRepository repository)
    {
        this.repository = repository;
    }
    [HttpGet("{id:int}")]
    public IActionResult GetOneUser([FromRoute(Name ="id")]int id){
        var item = repository.GetOne(id);
        if (item is null)
        {
            throw new NotFoundException(id);
        }
        return Ok(item);
    }
    [HttpPost("Register")]
    public IActionResult Register(string username, string email,string password){
        var user = new User(){Username=username,Email=email,Password=password};
        if (user is null)
        {
            throw new UserRegisterBadRequestException("The iformation that are given aren't avaliable!!!");
        }
        repository.Post(user);
        return Created("The user is added succesfully!!!",user);

    }
    [HttpPost("LogIn")]
    public IActionResult Login(string email,string password){
        var item =repository.GetData(email,password);
        if (item is null)
        {
            throw new NotFoundException(-1);
        }
        return Ok(item);
    }
    [HttpDelete("{id:int}")]
    public IActionResult DeleteOneUser([FromRoute(Name ="id")]int id){
        var item = repository.GetOne(id);
        if (item is null)
        {
            throw new NotFoundException(id);
        }
        repository.Delete(id);
        return NoContent();
    }
}