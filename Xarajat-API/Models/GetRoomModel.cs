using Xarajat_API.Entities;

namespace Xarajat_API.Models;

public class GetRoomModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Key { get; set; }
    public ERoomStatus Status { get; set; }
    public GetUser? Admin { get; set; }
}