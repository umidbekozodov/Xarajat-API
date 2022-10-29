using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Xarajat_API.Entities;

[Table("outlay_table")]
public class Outlay
{
    [Required]
    public int Id { get; set; }
    public string? Description { get; set; }
    public int Cost { get; set; }
    [Column("user_id")]
    public int UserId { get; set; }
    public int RoomId { get; set; } 
}