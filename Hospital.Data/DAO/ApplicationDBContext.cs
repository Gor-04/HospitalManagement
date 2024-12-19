using Microsoft.EntityFrameworkCore;
using Hospital.Data.Entities;
namespace Hospital.Data.DAO;
public class ApplicationDBContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<DiagnosisRecord> DiagnosisRecords { get; set; }
}