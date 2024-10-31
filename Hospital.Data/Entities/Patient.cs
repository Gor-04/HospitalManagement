using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Data.Entities;

public class Patient
{
    [Key]
    public int ID { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    public DateTime DOB { get; set; }

    [Column(TypeName = "varchar(20)")]
    public string Phone { get; set; }

    [Required]
    public DateTime VisitDate { get; set; }

    [Required]
    public TimeSpan VistTime { get; set; }

    public string? Diagnosis { get; set; } 
    public string? Medicine { get; set; }

}
