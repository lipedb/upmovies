using System;
namespace UpMovies.Interfaces
{
    public interface IApplicationConfig
    {
        string ProjectName { get; set; }
        string Mode { get; set; }
    }
}
