using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Data.Entities
{
    public class Patient
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Phone { get; set; }

        [Required]
        public DateTime VisitDate { get; set; }

        // Foreign Key to User
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        // Navigation property to DiagnosisRecords (One-to-many relationship)
        public virtual ICollection<DiagnosisRecord> DiagnosisRecords { get; set; }
    }
}
