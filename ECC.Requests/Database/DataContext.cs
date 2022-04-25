using ECC.Requests.Models.CallRequestModels;
using ECC.Requests.Models.EmergencyCodeModels;
using ECC.Shared.Requests.Contracts.SharedRequests;
using Microsoft.EntityFrameworkCore;

namespace ECC.Requests.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Request> Requests { get; set; }
        public DbSet<EmergencyCodeRequest> EmergencyCodeRequests { get; set; }
        public DbSet<Code> Codes { get; set; }

        public DbSet<CallRequestModel> CallRequests { get; set; }
        public DbSet<CallRequestMedicalHistory> CallRequestMedicalHistories { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Requests");
            modelBuilder.Entity<Request>().ToTable("Requests");
            modelBuilder.Entity<CallRequestModel>().ToTable("CallRequests");
            modelBuilder.Entity<EmergencyCodeRequest>().ToTable("EmergencyCodeRequests");
            modelBuilder.Entity<CallRequestMedicalHistory>().HasKey(x => new { x.CallRequestId, x.MedicalHistoryId });
        }
    }
}
