using System;
namespace UpMovies.Interfaces
{
    public interface IDependencyService
    {
        T Get<T>() where T : class;
    }
}
