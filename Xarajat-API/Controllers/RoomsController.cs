using System;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using Xarajat_API.Data;
using Xarajat_API.Helpers;
using Xarajat_API.Models;
using Xarajat_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Xarajat_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public partial class RoomsController : ControllerBase
{
    private readonly XarajatDbContext _context;

    public RoomsController(XarajatDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetRooms()
    {
        var rooms = _context?.Rooms?.Include(r => r.Admin).Select(room => ConvertToRoomModel(room)).ToList();

        // var roomModel = new GetRoomModel();
        // var roomsModel = new List<GetRoomModel>();
        // foreach (var room in rooms)
        // {
        //     roomModel.Id = room.Id;
        //     roomModel.Name = room.Name;
        //     roomModel.Key = room.Key;
        //     roomModel.Status = room.Status;

        //     roomsModel.Add(roomModel);
        // }
        return Ok(rooms);
    }

    [HttpPost]
    public IActionResult AddRoom(CreateRoomModel crm)
    {
        var room = new Entities.Room()
        {
            Name = crm.Name,
            Key = RandomGenerator.GetRandomString(),
            AdminId = 2
        };
        
        _context?.Rooms?.Add(room);
        _context?.SaveChanges();

        return Ok(ConvertToRoomModel(room));
    }

    [HttpGet("{id}")]
    public IActionResult GetRooms(int id)
    {
        var room = _context?.Rooms?.Include(r => r.Admin).FirstOrDefault(r => r.Id == id);
        if(room is null)
            return NotFound();

        return Ok(ConvertToRoomModel(room));
    }

    [HttpPut]
    public IActionResult UpdateRoom(int id, UpdateRoomModel urm)
    {
        var room = _context?.Rooms?.FirstOrDefault(r => r.Id == id);
        if(room is null)
            return NotFound();

        room.Name = urm.Name;
        room.Status = urm.Status;

        _context?.SaveChanges();
        return Ok(ConvertToRoomModel(room));
    }

    [HttpDelete]
    public IActionResult DeleteRoom(int id)
    {
        var room = _context?.Rooms?.FirstOrDefault(r => r.Id == id);
        if(room is null)
            return NotFound();

        _context?.Rooms?.Remove(room);
        _context?.SaveChanges();
        return Ok();
    }

    private static GetRoomModel ConvertToRoomModel(Room room)
    {
        return new GetRoomModel()
        {
            Id = room.Id,
            Name = room.Name,
            Key = room.Key,
            Status = room.Status,

            Admin = (room.Admin == null ? null : ConvertToUserModel(room.Admin))
        };
    }

    private static GetUser ConvertToUserModel(User user)
    {
        return new GetUser()
        {
            Id = user.Id,
            Name = user.Name
        };
        
    }

    [HttpGet("{id}/users")]
    public IActionResult GetRoomUsers(int id)
    {
        var room = _context?.Rooms?.Include(r => r.Users).FirstOrDefault(r => r.Id == id);

        if(room is null)
            return NotFound();
             
        return Ok(room.Users);
    }
}
