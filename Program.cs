using GestorContraseñas.Data;
using GestorContraseñas.Repositories;
using GestorContraseñas.Screens;
using GestorContraseñas.Services;

using (var db = new AppDbContext())
{
    db.Database.EnsureCreated();
    db.Seed();
}

var repository = new PasswordRepository();
var service = new PasswordService(repository);
var screen = new MainScreen(service);

screen.Show();



