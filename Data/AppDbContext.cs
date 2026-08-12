using GestorContraseñas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorContraseñas.Data;

public class AppDbContext : DbContext
    {
    public DbSet<Password> Passwords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=passwords.db");
    }

    public void Seed()
{
    Passwords.RemoveRange(Passwords.ToList());
    SaveChanges();

    Database.ExecuteSqlRaw(
        "DELETE FROM sqlite_sequence WHERE name = 'Passwords';");

    Passwords.AddRange(
        new Password
        {
            Nombre = "Instagram",
            Usuario = "usuario1",
            Clave = "123456",
            Sitio = "instagram.com"
        },

        new Password
        {
            Nombre = "Facebook",
            Usuario = "usuario2",
            Clave = "abcdef",
            Sitio = "facebook.com"
        },

        new Password
        {
            Nombre = "Gmail",
            Usuario = "usuario3",
            Clave = "correo123",
            Sitio = "gmail.com"
        },

        new Password
        {
            Nombre = "Netflix",
            Usuario = "usuario4",
            Clave = "netflix123",
            Sitio = "netflix.com"
        },

        new Password
        {
            Nombre = "TikTok",
            Usuario = "usuario5",
            Clave = "tiktok123",
            Sitio = "tiktok.com"
        }
    );

    SaveChanges();
} 
    }
