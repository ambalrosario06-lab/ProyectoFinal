using GestorContraseñas.Models;
using GestorContraseñas.Repositories;

namespace GestorContraseñas.Services;

public class PasswordService
{
    private readonly PasswordRepository _repository;

    public PasswordService(PasswordRepository repository)
    {
        _repository = repository;
    }

    public List<Password> GetAll()
    {
        return _repository.GetAll();
    }

    public void Create(Password password)
    {
        _repository.Create(password);
    }

    public Password? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public void Update(Password password)
    {
        _repository.Update(password);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}