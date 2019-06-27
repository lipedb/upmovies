using System;
namespace UpMovies.Models
{
    abstract class Actor
    {
        public int Id { get; set; }
        public string ImageProfile { get; set; }
        public string Name { get; set; }
    }
}
