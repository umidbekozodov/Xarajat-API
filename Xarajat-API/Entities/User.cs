using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// using System.ComponentModel.DataAnnotations;

namespace Xarajat_API.Entities;

[TableAttribute("user_table")]
public class User
{
    // [Key]
    // public int key { get; set; }
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public DateTime CreatedDate { get; set; }
    public int RoomId { get; set; }
}