using System.ComponentModel.DataAnnotations.Schema;
namespace Xarajat_API.Entities;

[Table("room_table")]
public class Room
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Key { get; set; }
    public ERoomStatus Status { get; set; }
    [Column("admin_id")]
    public int AdminId { get; set; }
    
    [ForeignKey("AdminId")]
    public User? Admin { get; set; }
    public List<User>? Users { get; set; }
    public List<Outlay>? Outlays { get; set; }
}