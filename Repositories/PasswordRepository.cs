using GestorContraseñas.Data;
using GestorContraseñas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorContraseñas.Repositories;

public class PasswordRepository
{
    public List<Password> GetAll()
    {
        using var db = new AppDbContext();

        return db.Passwords
            .OrderBy(p => p.Id)
            .ToList();
    }

    public void Create(Password password)
    {
        using var db = new AppDbContext();

        db.Passwords.Add(password);
        db.SaveChanges();
    }

    public Password? GetById(int id)
    {
        using var db = new AppDbContext();

        return db.Passwords.FirstOrDefault(p => p.Id == id);
    }

    public void Update(Password password)
    {
        using var db = new AppDbContext();

        db.Passwords.Update(password);
        db.SaveChanges();
    }

    public void Delete(int id)
    {
        using var db = new AppDbContext();

        var password = db.Passwords.FirstOrDefault(p => p.Id == id);

        if (password != null)
        {
            db.Passwords.Remove(password);
            db.SaveChanges();
        }
    }
}