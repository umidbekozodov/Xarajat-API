using Xarajat_API.Entities;

namespace Xarajat_API.Models;

public class UpdateRoomModel
{
    public string? Name { get; set; }
    public ERoomStatus Status { get; set; }
}