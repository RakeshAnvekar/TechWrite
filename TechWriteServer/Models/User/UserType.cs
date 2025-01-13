using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechWriteServer.Models.User;

public class UserType
{
    [Key]   
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserTypeId { get; set; }
    public required string Type { get; set; }
}
