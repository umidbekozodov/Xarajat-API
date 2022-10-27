using System.ComponentModel.DataAnnotations.Schema;
namespace Xarajat_API.Entities;

public class Room
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Key { get; set; }
    public ERoomStatus Status { get; set; }
    public int AdminId { get; set; }
    
    [ForeignKey(nameof(AdminId))]
    public User? Admin { get; set; }
    public List<User>? Users { get; set; }
}