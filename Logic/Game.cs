using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Game
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }

        public Game(int id, string name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
