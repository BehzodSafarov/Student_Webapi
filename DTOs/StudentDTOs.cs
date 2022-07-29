using System.ComponentModel.DataAnnotations;

namespace StudentWebapi.DTOs;
public class StudentDTOs
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(200)]
    [Required]
    public string? Name { get; set; }

    public DateTime BirthDay{get;set;}=DateTime.Now;

    [Range(minimum:0,maximum:5)]
    public int Grade { get; set; }

    public static List<StudentDTOs> students {get;set;}=new List<StudentDTOs>();
    
}