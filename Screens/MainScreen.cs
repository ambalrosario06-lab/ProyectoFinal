using GestorContraseñas.Models;
using GestorContraseñas.Services;
using Spectre.Console;

namespace GestorContraseñas.Screens;

public class MainScreen
{
    private readonly PasswordService _service;

    public MainScreen(PasswordService service)
    {
        _service = service;
    }

    public void Show()
    {
        bool continuar = true;

        while (continuar)
        {
            AnsiConsole.Clear();

            AnsiConsole.Write(
                new FigletText("Gestor contraseñas")
                    .Centered()
                    .Color(Color.Blue));

            var opcion = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow]¿Qué deseas hacer?[/]")
                    .AddChoices(
                        "Mostrar contraseñas",
                        "Agregar contraseña",
                        "Actualizar contraseña",
                        "Eliminar contraseña",
                        "Salir"));

            switch (opcion)
            {
                case "Mostrar contraseñas":
                    ShowPasswords();
                    break;

                case "Agregar contraseña":
                    CreatePassword();
                    break;

                case "Actualizar contraseña":
                    UpdatePassword();
                    break;

                case "Eliminar contraseña":
                    DeletePassword();
                    break;

                case "Salir":
                    continuar = false;
                    break;
            }
        }
    }

    private void ShowPasswords()
    {
        var passwords = _service.GetAll();

        var table = new Table();

        table.AddColumn("ID");
        table.AddColumn("Nombre");
        table.AddColumn("Usuario");
        table.AddColumn("Clave");
        table.AddColumn("Sitio");

        foreach (var password in passwords)
        {
            table.AddRow(
                password.Id.ToString(),
                password.Nombre,
                password.Usuario,
                password.Clave,
                password.Sitio);
        }

        AnsiConsole.Write(table);

        AnsiConsole.MarkupLine("\n[grey]Presiona ENTER para continuar...[/]");
        Console.ReadLine();
    }

    private void CreatePassword()
    {
        var password = new Password
        {
            Nombre = AnsiConsole.Ask<string>("Nombre:"),
            Usuario = AnsiConsole.Ask<string>("Usuario:"),
            Clave = AnsiConsole.Ask<string>("Contraseña:"),
            Sitio = AnsiConsole.Ask<string>("Sitio:")
        };

        _service.Create(password);

        AnsiConsole.MarkupLine("[green]Contraseña guardada correctamente.[/]");

        Console.ReadLine();
    }

    private void UpdatePassword()
    {
        int id = AnsiConsole.Ask<int>("ID de la contraseña:");

        var password = _service.GetById(id);

        if (password == null)
        {
            AnsiConsole.MarkupLine("[red]No se encontró esa contraseña.[/]");
            Console.ReadLine();
            return;
        }

        password.Nombre = AnsiConsole.Ask<string>("Nuevo nombre:");
        password.Usuario = AnsiConsole.Ask<string>("Nuevo usuario:");
        password.Clave = AnsiConsole.Ask<string>("Nueva contraseña:");
        password.Sitio = AnsiConsole.Ask<string>("Nuevo sitio:");

        _service.Update(password);

        AnsiConsole.MarkupLine("[green]Contraseña actualizada correctamente.[/]");

        Console.ReadLine();
    }

    private void DeletePassword()
    {
        int id = AnsiConsole.Ask<int>("ID de la contraseña:");

        var password = _service.GetById(id);

        if (password == null)
        {
            AnsiConsole.MarkupLine("[red]No se encontró esa contraseña.[/]");
            Console.ReadLine();
            return;
        }

        _service.Delete(id);

        AnsiConsole.MarkupLine("[green]Contraseña eliminada correctamente.[/]");

        Console.ReadLine();
    }
}