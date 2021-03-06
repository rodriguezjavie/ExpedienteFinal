using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ExpedienteIDON.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Nombre(s)")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Apellido(s)")]
        public string LastName { get; set; }
        [Display(Name = "Cedula")] 
        public string Cedula { get; set; }
        [Required]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName) { }

        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<FamilyRecord> FamilyRecords { get; set; }
        public DbSet<NonPathologicalRecord> NonPathologicalRecords { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<GynecoRecord> GynecoRecords { get; set; }
        public DbSet<OtherFamilyRecord> OtherFamilyRecords { get; set; }
        public DbSet<PathologicRecord> PathologicRecords { get; set; }
        public DbSet<OtherPathologicRecord> OtherPathologicRecords { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<VitalSigns> VitalSigns { get; set; }
        public DbSet<PhysicalExploration> PhysicalExplorations { get; set; }
        public DbSet<MedicalTest> MedicalTests { get; set; }
        public DbSet<LabsTest> LabsTests { get; set; }
        public DbSet<Others> Others { get; set; }
        public DbSet<BiometriaHematica> BiometriaHematicas { get; set; }
        public DbSet<PerfilHepatico> PerfilHepaticos { get; set; }
        public DbSet<QuimicaSanguinea> QuimicaSanguineas { get; set; }
        public DbSet<PerfilTiroideo> PerfilTiroideos { get; set; }
        public DbSet<Hormonas> Hormonas { get; set; }
        public DbSet<GeneralOrina> GeneralOrinas { get; set; }
        public DbSet<OtrosLabs> OtrosLabs { get; set; }
        public DbSet<EvolutionNote> EvolutionNotes { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Estado> Estadoes { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<MedicinesPrescription> MedicinesPrescriptions { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}