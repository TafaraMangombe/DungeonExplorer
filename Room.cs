using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// creates the rooms the users navigates
    /// </summary>
    public class Room
    {

        public string Name {get; private set; }
        public string Description{ get; private set; }
        public  List<Monster> Enemies { get; set; }

        public List<Item> RoomItems { get; set; }
       

        public Room NextRoom { get; set; }
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Enemies = new List<Monster>();
            RoomItems = new List<Item>();
            
        }

        
        public string GetDescription()
        {

            return Description;
        }
    }
}

