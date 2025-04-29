using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// Item class
    /// creates items and gives them names and the description of what the item does 
    /// </summary>
    public class Item

    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }


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
    /// <summary>
    /// Weapon class
    /// A subclass of class item that creates weapons and gives them damage values 
    /// </summary>
    public class Weapon : Item
    {
        public int WeaponDamage;

        public Weapon(string itemName, string itemDescription, int weaponDamage) : base(itemName, itemDescription)
        {
            WeaponDamage = weaponDamage;
        }
    }

    /// <summary>
    /// Potion class
    /// potion is a subclass of item that gives the user potions that allow them to health
    /// </summary>
    public class Potion : Item
    {
        public int HealthGained;

        public Potion(string itemName, string itemDescription, int healthGained) : base(itemName, itemDescription)
        {
            HealthGained = healthGained;
        }
    }

    /// <summary>
    /// SmallPotion class
    /// a subclass of potion that increases health by 25 
    /// </summary>
    public class SmallPotion : Potion
    {

        public SmallPotion() : base("Small Potion", "a mysterious red liquid in a small bottle +25 to health", 25)
        {

        }
    }

    /// <summary>
    /// LargePotion class
    /// a subclass of potion that increases health by 50 
    /// </summary>
    public class LargePotion : Potion
    {

        public LargePotion() : base("Large Potion", "a mysterious red liquid in a large flask +50 to health", 50)
        {

        }
    }

}
