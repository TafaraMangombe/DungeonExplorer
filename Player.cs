using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace DungeonExplorer
{
    /// <summary>
    /// Item class
    /// Gives the user a the name and the description of what the item does 
    /// </summary>
    public class Item

    {
        public string ItemName { get; private set; }
        public string ItemDescription { get; private set; }

        /// <summary>
        /// initialises a new item
        /// </summary>
        /// <param name="itemName"> the name of the item</param>
        /// <param name="itemDescription">the description of the item</param>
        public Item(string itemName, string itemDescription)
        {
            ItemName = itemName;
            ItemDescription = itemDescription;
        }
        //displays item name in inventory 
        public override string ToString()
        {
            return ItemName;
        }
    }

    class Weapon : Item
    {
        public int WeaponDamage;

        public Weapon(string itemName, string itemDescription, int weaponDamage) : base(itemName,itemDescription)
        {
            WeaponDamage = weaponDamage;
        }
    }

    class Potion : Item
    {
        public int HealthGained;

        public Potion(string itemName, string itemDescription, int healthGained) : base(itemName, itemDescription)
        {
            HealthGained = healthGained;
        }
    }

    class SmallPotion : Potion
    {

        public SmallPotion() : base("Small Potion","a mysterious red liquid in a small bottle +25 to health",25)
        {
          
        }
    }

    class LargePotion : Potion
    {

        public LargePotion() : base("Small Potion", "a mysterious red liquid in a large flask +50 to health", 50)
        {

        }
    }

    public interface IDamageble
    {
        void Damage(int DamageDone);

    }

    public class Creature
    {
        public string Name { get;  set; }
        public int Health { get;  set; }

        public Creature(string name, int health)
        {
            Name = name;
            Health = health;
        }
    }
    /// <summary>
    /// Player class 
    /// gives the user a health pool and a inventory they can store items in 
    /// </summary>
    public class Player : Creature, IDamageble 

    {
      
        public List<Item> Inventory { get;  set; }


        /// <summary>
        /// inisialises player
        /// </summary>
        public Player(string name, int health, List<Item> inventory) : base(name,health)
        {

            Inventory = inventory;
        }

        public void Damage(int DamageDone)
        {
            Health -= DamageDone;
            Console.WriteLine($"you have taken {DamageDone} damage ");
        }
        
        /// <summary>
        /// allows users to pick up items
        /// </summary>
        public void PickUpItem(Item item)
        {
            //adds items to inventory 
            Inventory.Add(item);

        }
        // shows items in inventory
        public string InventoryContents()
        {

            return string.Join(", ", Inventory);

        }

    }

    public class Monster : Creature,IDamageble
    {

        

        public Monster(string name ,int health) : base(name,health)
        {
        
        }

        public void Damage(int DamageDone)
        {
            Health -= DamageDone;
            Console.WriteLine($"{Name} have taken {DamageDone} damage ");
        }

    }

    public class Skeleton : Monster
    {
        public string Klink;

        public Skeleton(string Klink) : base("Skeleton", 30)
        {
            
        }
    }

    public class ReAnimatedCorpse : Monster
    {
        public string Grawr;

        public ReAnimatedCorpse(string Grawr) : base("Reanimated Corpse", 40)
        {
            
        }
    }

    public class StoneGolem : Monster
    {
        public string Crunch;

        public StoneGolem(string Crunch) : base("Stone Golem",50)
        {
          
        }
    }
}