using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonExplorer
{
    /// <summary>
    /// Monster class
    /// a subclass of the creature class that creates hostile monsters
    /// </summary>
    public class Monster : Creature, IDamageble
    {

        public Weapon Equip { get; set; }
        public Monster(string name, int health) : base(name, health)
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

    /// <summary>
    /// Skeleton class  
    /// a subclass of monster that has low  health and does low damage
    /// </summary>
    public class Skeleton : Monster
    {



        public Skeleton() : base("Skeleton", 30)
        {
            Weapon Bow = new Weapon("Bow", "a long ranged but low power weapon", 10);
            EquipWeapon(Bow);
        }
    }

    /// <summary>
    /// ReAnimatedCorpse class
    /// a subclass of monster that has medium health and does medium damage
    /// </summary>
    public class ReAnimatedCorpse : Monster
    {


        public ReAnimatedCorpse() : base("Reanimated Corpse", 40)
        {
            Weapon Club = new Weapon("Club", "a short ranged blunt weapon ", 13);
            EquipWeapon(Club);
        }
    }

    /// <summary>
    /// StoneGolem class
    /// a subclass of monster that has high health and does high damage
    /// </summary>
    public class StoneGolem : Monster
    {


        public StoneGolem() : base("Stone Golem", 50)
        {
            Weapon StoneFist = new Weapon("Stone Fists ", "the dangerous hands of a stone golem", 16);
            EquipWeapon(StoneFist);
        }
    }
}
