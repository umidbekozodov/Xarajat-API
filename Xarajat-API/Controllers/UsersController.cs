using Microsoft.AspNetCore.Mvc;
using Xarajat_API.Data;
using Xarajat_API.Models;

namespace Xarajat_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly XarajatDbContext _context;
    public UsersController(XarajatDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<Entities.User>> GetUsers()
    {
        List<Entities.User> users = _context.Users!.ToList();
        return Ok(users);
    }

    [HttpPost]
    public IActionResult AddUser(CreateUserModel cum)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid data.");

        var user = new Entities.User()
            {
                Name = cum.Name,
                Email = cum.Email,
                Phone = cum.Phone,
                CreatedDate = DateTime.Now
            };
            _context?.Users?.Add(user);
            _context?.SaveChanges();

        return Ok(user);
    }

    [HttpGet("id")]
    public IActionResult GetUser(int id)
    {
        var user = _context?.Users?.FirstOrDefault(u => u.Id == id);
        if(user is null)
            return NotFound();

        return Ok(user);
    }

    [HttpPut]
    public IActionResult UpdateUser(int id, UpdateUserModel uum)
    {
        var user = _context?.Users?.FirstOrDefault(u => u.Id == id);
        if(user is null)
            return NotFound();
        
        user.Name = uum.Name;
        user.Phone = uum.Phone;
        user.Email = uum.Email;

        _context?.SaveChanges();
        return Ok(user);
    }

    [HttpDelete]
    public IActionResult DeleteUser(int id)
    {
        var user = _context?.Users?.FirstOrDefault(u => u.Id == id);
        if(user is null)
            return NotFound();

        _context?.Users?.Remove(user);
        _context?.SaveChanges();
        
        return Ok();
    }

    [HttpPost("Join-Room")]
    public IActionResult JoinRoom(int roomId, string key, int userId)
    {
        var room = _context?.Rooms?.FirstOrDefault(r => r.Id == roomId);
        if(room is null || room.Key != key)
            return NotFound();

        var user = _context?.Users?.FirstOrDefault(u => u.Id == userId);
        if(user is null)
            return NotFound();

        user.RoomId = roomId;
        _context?.SaveChanges();
        return Ok(user);
    }
}