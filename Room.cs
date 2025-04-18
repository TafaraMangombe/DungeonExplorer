using System;

namespace DungeonExplorer
{
    /// <summary>
    /// creates the rooms the users navigates
    /// </summary>
    public class Room
    {

        public string Name {get; private set; }
        public string Description{ get; private set; }

        public Room NextRoom { get; set; }
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string GetDescription()
        {

            return Description;
        }
    }
}