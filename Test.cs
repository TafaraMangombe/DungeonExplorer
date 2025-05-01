using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// tests a group of features and methods needed for the program to run succefully 
    /// </summary>
    public class Test
    {
        public static Room currentTestRoom;
        public static void RunTests()
        { 
            PickUpItemAndInventory();
            HealAndDamage();
            TestNextRoom();
            PlayerDeath();
        }
        //test pickup item and display inventory

        public static void PickUpItemAndInventory()
        {
            Player testPlayer = new Player("Player", 100, new List<Item>());
            SmallPotion testSmallPotion = new SmallPotion();
            testPlayer.PickUpItem(testSmallPotion);
            if (testPlayer.Inventory.Contains(testSmallPotion))
            {
                Console.WriteLine("Test PickUpItemAndInventory has a success");
            }
            else
            {
                Console.WriteLine("Test PickUpItemAndInventory was a failed");
            }
        }

        //tests plyer healing and moster damage
        public static void HealAndDamage()
        {
            Player testPlayer2 = new Player("Player", 100, new List<Item>());
            Weapon testDagger = new Weapon("test Dagger", "a weapon only used for the test class", 100);
            testPlayer2.EquipWeapon(testDagger);
            LargePotion testLargePotion = new LargePotion();
            testPlayer2.PickUpItem(testLargePotion);
            Skeleton testSkeleton = new Skeleton();
            testSkeleton.Attack(testPlayer2);
            testPlayer2.Healing(testLargePotion);


            if (testPlayer2.Health == 100)
            {
                Console.WriteLine("Test HealAndDamage has a success");
            }
            else
            {
                Console.WriteLine("Test HealAndDamage has failed");
            }
        }

        // tests the users ability to move rooms 
        public static void TestNextRoom()
        {
            Room testRoom1 = new Room("Room 1", "This is test room 1");
            Room testRoom2 = new Room("Room 2", "This is test room 2");
            currentTestRoom = testRoom1;
            testRoom1.NextRoom = testRoom2;
            currentTestRoom = testRoom1.NextRoom;
            if (currentTestRoom == testRoom2)
            {
                Console.WriteLine("Test testNextRoom has a success");
            }
            else
            {
                Console.WriteLine("Test testNextRoom was a failed");
            }
        }

        // tests the players ability to die 
        public static void PlayerDeath()
        {
            Player testPlayer3 = new Player("Player", 100, new List<Item>());
            Monster testMonster = new Monster("test monster", 100);
            Weapon testSword = new Weapon("test sword", "test class sword", 100);
            testMonster.EquipWeapon(testSword);
            testMonster.Attack(testPlayer3);
            if ( testPlayer3.Health == 0)
            { 
                Console.WriteLine("Test PlayerDeath has a success");
            }
            else
            {
                Console.WriteLine("Test PlayerDeath was a failed");
            }
        }
     
    }
}
