using DungeonExplorer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;

namespace DungeonExplorer
{
    
    /// <summary>
    /// IDamageble interface
    /// allows for both the player and mosters to take damage
    /// </summary>
    public interface IDamageble
    {
        void Damage(int DamageDone);

    }

    /// <summary>
    /// Creature class
    /// allows for the creation of creatures 
    /// </summary>
    public class Creature
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public Creature(string name, int health)
        {
            Name = name;
            Health = health;
        }
    }
    /// <summary>
    /// Player class 
    /// a subclass of creature that creates the users player gives them a inventory and allows weapons to be equipped
    /// </summary>
    public class Player : Creature, IDamageble

    {

        public List<Item> Inventory { get; set; }
        public Weapon Equip { get; set; }


        public Player(string name, int health, List<Item> inventory) : base(name, health)
        {

            Inventory = inventory;

        }

        // allows weapons to be wquipped
        public void EquipWeapon(Weapon weapon)
        {
            Equip = weapon;
        }

        // lets players heal with potions
        public void Healing(Potion potion)
        {
            //adds health to the player but not over 100 players max health
            Health += potion.HealthGained;
            if (Health > 100)
            {
                Health = 100;
            }
            Console.WriteLine($"{potion.HealthGained} has been added to your health ");
        }

        // allows any creature to take damage
        public void Damage(int DamageDone)
        {
            Health -= DamageDone;
            Console.WriteLine($"you have taken {DamageDone} damage ");
        }

        //allows any creature to deal damage
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

        //lets users pick up items and adds them to inventory
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

        //allows for use of weapons
        public void UseItem(Weapon weapon)
        {
            EquipWeapon(weapon);
        }

        public void DropItem(Item item)
        {
            //removes items from inventory 
            Inventory.Remove(item);
        }
    }

    /// <summary>
    /// Statistics class
    /// shows the players stats 
    /// </summary>

    public class Statistics : Creature
    {

        public Statistics(string name, int health) : base(name, health)
        {

        }

        public void ShowStats()
        {
            Console.WriteLine($"Name: {Name} \n Max health:{Health} ");
        }
    }
}