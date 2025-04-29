using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonExplorer
{
    internal class Program
    {
        // the main method of the game 
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();



        }
    }
}