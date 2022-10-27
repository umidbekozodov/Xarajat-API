using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xarajat_API.Entities;
using Xarajat_API.Models;

namespace Xarajat_API.Controllers;

public partial class RoomsController
{
    [HttpPost("{roomId}/Outlay")]
    public IActionResult AddOutlay(int roomId, CreateRoomOutlay createRoomOutlay)
    {
       var room = _context?.Rooms?.Find(roomId);
       if(room is null)
            return NotFound();

        var outlay = new Outlay
        {
            Description = createRoomOutlay.Description,
            Cost = createRoomOutlay.Cost,
            UserId = createRoomOutlay.UserId,
            RoomId = roomId
        };

        _context?.Outlays?.Add(outlay);
        _context?.SaveChanges();
        
        return Ok(outlay);
    }
    [HttpGet("{roomId}/outlay")]
    public IActionResult GetRoomOutlayByRoomId(int roomId)
    {
        var outlays = _context?.Outlays?.Where(o => o.RoomId == roomId).ToList();
        if(outlays is null)
            return NotFound();
    
        return Ok(outlays);
    }

    public IActionResult CalculateRoomOutlaysByRoomId(int roomId)
    {
        var room = _context.Rooms?
            .Include(r => r.Users)
            .Include(r => r.Outlays).FirstOrDefault(r => r.Id == roomId);
        
        if(room is null)
            return NotFound();

        var calRoomOutlay = new CalculateRoomOutlays
        {
            UsersCount = room.Users!.Count,
            TotalCost = room.Outlays!.Sum(outlay => outlay.Cost)
        };

        return Ok(calRoomOutlay);
    }
}