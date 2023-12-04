using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace Test.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(UserContext db)
    {
        return Ok(await db.Users.ToListAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(UserContext db, int id)
    {
        return Ok(await db.Users.FirstOrDefaultAsync(u => u.Id == id));
    }
    [HttpPost]
    public async Task<IActionResult> CreateUser(User user, UserContext db)
    {
        await db.Users.AddAsync(user);
        await db.SaveChangesAsync();
        return Ok(user);

    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(UserContext db, int id)
    {   
        var user = await db.Users.FirstOrDefaultAsync(u=>u.Id == id);
        if (user == null) return Ok("User is not found");

        db.Remove(user);
        db.SaveChanges();
        return Ok(user);
    }
    [HttpPut]
    public async Task<IActionResult> EditById(UserContext db, User userOrigin)
    {
        var user = await db.Users.FirstOrDefaultAsync(u => u.Id == userOrigin.Id);
        if (user == null) return Ok("user is not found");

        user.Name = userOrigin.Name;
        user.Surname = userOrigin.Surname;
        user.Email = userOrigin.Email;
        user.PhoneNumber = userOrigin.PhoneNumber;
        user.PassportSeries = userOrigin.PassportSeries;
        user.PassportNumber = userOrigin.PassportNumber;
        user.Login = userOrigin.Login;
        user.Password = userOrigin.Password;
        db.SaveChangesAsync();
        return Ok(user);

    } 
}
