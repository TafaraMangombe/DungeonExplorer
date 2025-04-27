using DungeonExplorer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;

namespace DungeonExplorer
{
    /// <summary>
    /// Item class
    /// Gives the user a the name and the description of what the item does 
    /// </summary>
    public class Item

    {
        public string ItemName { get; set; }
        public string ItemDescription { get;  set; }

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

    public  class Weapon : Item
    {
        public int WeaponDamage;

        public Weapon(string itemName, string itemDescription, int weaponDamage) : base(itemName,itemDescription)
        {
            WeaponDamage = weaponDamage;
        }
    }

    public class Potion : Item
    {
        public int HealthGained;

        public Potion(string itemName, string itemDescription, int healthGained) : base(itemName, itemDescription)
        {
            HealthGained = healthGained;
        }
    }

    public class SmallPotion : Potion
    {

        public SmallPotion() : base("Small Potion","a mysterious red liquid in a small bottle +25 to health",25)
        {
          
        }
    }

    public class LargePotion : Potion
    {

        public LargePotion() : base("Large Potion", "a mysterious red liquid in a large flask +50 to health", 50)
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

        public List<Item> Inventory { get; set; }
        public Weapon Equip { get; set; }




        /// <summary>
        /// inisialises player
        /// </summary>ng
        public Player(string name, int health, List<Item> inventory) : base(name, health)
        {

            Inventory = inventory;

        }

        public void EquipWeapon(Weapon weapon)
        {
            Equip = weapon;
        }

        public void Healing(Potion potion)
        {
           
            Health += potion.HealthGained;
            if(Health > 100)
            {
                Health = 100;
            }
            Console.WriteLine($"{potion.HealthGained} has been added to your health ");
        }
        public void Damage(int DamageDone)
        {
            Health -= DamageDone;
            Console.WriteLine($"you have taken {DamageDone} damage ");
        }

        public void Attack(Monster monster)
        {
            if (Equip == null)
            {
                Console.WriteLine("no weapon is equipped you are unable to attack");
            }
            else
            {
                monster.Damage(Equip.WeaponDamage);
            }
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

        public void UseItem(Weapon weapon)
        {
            EquipWeapon(weapon);
        }
        

    }


    public class Monster : Creature,IDamageble
    {

        public Weapon Equip { get; set; }

    

        public Monster(string name ,int health) : base(name,health)
        {
        
        }

        public void Damage(int DamageDone)
        {
            Health -= DamageDone;
            Console.WriteLine($"{Name} have taken {DamageDone} damage ");
        }

        public void EquipWeapon(Weapon weapon)
        {
            Equip = weapon;
            
        }

        public void Attack(Player player)
        {
            {
                player.Damage(Equip.WeaponDamage);
            }
        }

    }

    
    public class Skeleton : Monster
    {
        public string Klink;

       
        public Skeleton(string Klink) : base("Skeleton", 30)
        {
            Weapon Bow = new Weapon("Bow", "a long ranged but low power weapon", 10);
            EquipWeapon(Bow);
        }
    }

    public class ReAnimatedCorpse : Monster
    {
        public string Grawr;

        public ReAnimatedCorpse(string Grawr) : base("Reanimated Corpse", 40)
        {
            Weapon Club = new Weapon("Club", "a short ranged blunt weapon ", 14);
            EquipWeapon(Club);
        }
    }

    public class StoneGolem : Monster
    {
        public string Crunch;

        public StoneGolem(string Crunch) : base("Stone Golem",50)
        {
            Weapon StoneFist = new Weapon("Stone Fists ", "the dangerous hands of a stone golem", 17);
            EquipWeapon(StoneFist);
        }
    }
}

public class Statistics : Creature 
{
  
    public Statistics(string name, int health) : base( name, health)
    {

    }
   
    public void ShowStats()
    {
        Console.WriteLine($"Name: {Name} \n Max health:{Health} ");
    }     
}