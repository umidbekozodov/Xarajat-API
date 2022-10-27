namespace Xarajat_API.Models;
public class CreateRoomOutlay
{
    public string? Description { get; set; }
    public int Cost { get; set; }
    public int UserId { get; set; }
    public int RoomId { get; set; }
}