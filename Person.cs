using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simple_CRUD;

public class Person
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string Fullname { get; set; } = null!;
    public DateTime Date { get; set; }
    public bool Active { get; set; }
    public string Country { get; set; } = null!;
    public string Role { get; set; } = null!;
}
