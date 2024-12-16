// DiagnosisRecord.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Data.Entities
{
    public class DiagnosisRecord
    {
        [Key]
        public int DiagnosisRecordID { get; set; }

        [Required]
        public int PatientID { get; set; }

        [Required]
        [StringLength(100)]
        public string PatientName { get; set; }


        [Required]
        [StringLength(255)]
        public string Diagnosis { get; set; }

        [Required]
        [StringLength(255)]
        public string Medicine { get; set; }

        [ForeignKey("PatientID")]
        public virtual Patient Patient { get; set; }
    }
}
