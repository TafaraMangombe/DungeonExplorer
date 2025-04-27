using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Media;
using System.Net;

namespace DungeonExplorer
{
    /// <summary>
    /// Game class
    /// where the game is setup
    /// </summary>
    internal class Game
    {
        private Player player;
     
        private Room CurrentRoom;
        /// <summary>
        /// holds the creation of new objects, the player and rooms and their description
        /// </summary>
        public Game()
        {
            // creates the player
            String usersName;

            while (true)
            {
                Console.Write("Please enter your name:");
                usersName = Console.ReadLine();
                if (String.IsNullOrEmpty(usersName))
                {
                    Console.WriteLine("Please enter a name \n ");
                }
                else
                {
                    break;
                }
            }

            player = new Player(usersName, 100, new List<Item>());
            Weapon dagger = new Weapon("Dagger", "a rusty old weapon", 15);
            player.EquipWeapon(dagger);

            Statistics playerStats = new Statistics(player.Name, player.Health);

            // Creates the games rooms
            Room StartingRoom = new Room("Starting chamber", $"you have woken up in a dark and damp room only lit up by lanterns hanging from the ceiling.");
            Room SecondRoom = new Room("The forgotten Graves", "The smell of death and despair surround this underground graveyard the sound of dirt shaking and bones rattling surround you. ");
            Room ThirdRoom = new Room("The lost Village","empty houses and rotting crop fields ");
            Room FourthRoom = new Room("Jungle", "a mystirous jungle filled with unusual plants and wild life");
            Room FifthRoom = new Room("The final chamber", "Piles of bones and armour you have arrived at the bosses chamber");

            //connenets each room together allowing player to go to next room
            StartingRoom.NextRoom = SecondRoom;
            SecondRoom.NextRoom = ThirdRoom;
            ThirdRoom.NextRoom = FourthRoom;
            FourthRoom.NextRoom = FifthRoom;

            CurrentRoom = StartingRoom;

            // creates the the skeleton enines for room 1
            Skeleton Skeleton1 = new Skeleton("Klink");

            // adds skeletons to room 1
            StartingRoom.Enemies.Add(Skeleton1);

            // creates the the skeleton enines for room 2
            Skeleton Skeleton2 = new Skeleton("Klink");
            Skeleton Skeleton3 = new Skeleton("Klink");
            Skeleton Skeleton4 = new Skeleton("Klink");

            // adds skeletons to room 2
            SecondRoom.Enemies.Add(Skeleton2);
            SecondRoom.Enemies.Add(Skeleton3);
            SecondRoom.Enemies.Add(Skeleton4);

            // creates the Reanimated corpses for room 3 
            ReAnimatedCorpse Zombie1 = new ReAnimatedCorpse("Grawr");
            ReAnimatedCorpse Zombie2 = new ReAnimatedCorpse("Grawr");
            ReAnimatedCorpse Zombie3 = new ReAnimatedCorpse("Grawr");

            //adds Reanimated corpses to room 3 
            ThirdRoom.Enemies.Add(Zombie1);
            ThirdRoom.Enemies.Add(Zombie2);
            ThirdRoom.Enemies.Add(Zombie3);

            // creates the stone golum corpses for room 4
            StoneGolem StoneGolum1 = new StoneGolem("Crunch");
            StoneGolem StoneGolum2 = new StoneGolem("Crunch");
            StoneGolem StoneGolum3 = new StoneGolem("Crunch");

            // adds stone golum to room 4
            FourthRoom.Enemies.Add(StoneGolum1);
            FourthRoom.Enemies.Add(StoneGolum2);
            FourthRoom.Enemies.Add(StoneGolum3);

            
            SmallPotion SmallPotion1 = new SmallPotion();
            
            SecondRoom.RoomItems.Add(SmallPotion1);

            LargePotion LargePotion1 = new LargePotion();
            
            ThirdRoom.RoomItems.Add(LargePotion1);


            LargePotion LargePotion2 = new LargePotion();
            SmallPotion SmallPotion2 = new SmallPotion();

            FourthRoom.RoomItems.Add(LargePotion2);
            FourthRoom.RoomItems.Add(SmallPotion2);

            LargePotion LargePotion3 = new LargePotion();
            SmallPotion SmallPotion3 = new SmallPotion();
            SmallPotion SmallPotion4 = new SmallPotion();
            
            FifthRoom.RoomItems.Add(LargePotion3);
            FifthRoom.RoomItems.Add(SmallPotion2);
            FifthRoom.RoomItems.Add(SmallPotion3);



        }
        /// <summary>
        /// starts the game logic
        /// </summary>
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            Statistics playerStats = new Statistics(player.Name, player.Health);


            while (playing)
            {
                
                Console.WriteLine("Would you Like to Check:" +
                 "\n-Stats \n-Attack \n-Health \n-Inventory \n-Description \n-'Next' Room \n-End");
                while (true)
                {

                    string action = Console.ReadLine().ToLower();


                    if(action == "stats")
                    {
                        playerStats.ShowStats();
                        break;
                    }
                    // allows player to fight monsters 
                    else if (action == "attack")
                    {
                        if (CurrentRoom.Enemies.Count == 0)
                        {
                            Console.WriteLine("there are no enemies in the room you may advance to next room");
                            break;
                        }

                        else
                        {
                            // promps player to attack and monster to attack afterwards
                            Monster monster = CurrentRoom.Enemies[0];
                            player.Attack(monster);
                            monster.Attack(player);


                            if (player.Health <= 0)
                            {
                                Console.WriteLine("You have died");
                                playing = false;
                                break;
                            }

                            if (monster.Health <= 0)
                            {
                                Console.WriteLine($"{monster.Name} has been killed");
                                CurrentRoom.Enemies.Remove(monster);
                                break;
                            }
                            break;
                        }

                    }

                    //shows players health to user
                    else if (action == "health")
                    {
                        Console.WriteLine($"{player.Name} your health is currently at {player.Health}/100");
                        Console.WriteLine("Would you like to use a potion? Yes or no");
                        string HealingAnswer = Console.ReadLine().ToLower();
                        if (HealingAnswer == "yes")
                        {
                            if (player.Health == 100)
                            {
                                Console.WriteLine("Your health is currently full you cannot use a potion at this time");
                            }
                            else
                            {
                                Console.WriteLine($"Your health is currently at {player.Health} would you like to use a small potion or large potion ");
                                string PotionAnswer = Console.ReadLine().ToLower();
                                if (PotionAnswer == "small potion")
                                {
                                    Potion selectPotion = player.Inventory.OfType<SmallPotion>().FirstOrDefault();
                                    if (selectPotion != null)
                                    {
                                        player.Healing(selectPotion);
                                    
                                    }
                                    else
                                    {
                                        Console.WriteLine("you have no small potions in your inventory. you are unable to heal");
                                    }
                                }
                                else if (PotionAnswer == "large potion")
                                {
                                    Potion selectPotion = player.Inventory.OfType<LargePotion>().FirstOrDefault();
                                    if (selectPotion != null)
                                    {
                                        player.Healing(selectPotion);
                                        player.Inventory.Remove(selectPotion);
                                    }
                                    else
                                    {
                                        Console.WriteLine("you have no large potions in your inventory. you are unable to heal");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Please enter small potion or large potion");
                                }
                            }
                        }
                        else if (HealingAnswer == "no")
                        {
                            Console.WriteLine("you have chosen to not use any of your potions");
                        }
                        else
                        {
                            Console.WriteLine("That was not a option");
                        }
                        break;
                    }
                    //shows contents of inventory to user
                    else if (action == "inventory")
                    {
                        Console.WriteLine(player.InventoryContents());
                        Start();
                    }
                    //allows user to pick up items if they are available
                    else if (action == "items")
                    {

                        // Console.WriteLine("There is strange flasks around the room would you like to pick them up 'yes' or 'no'");

                        if (CurrentRoom.RoomItems.Count == 0)
                            {
                                Console.WriteLine("There are currently no items in this Room");
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"There are Items in this room would you lie to collect them? Yes or No");
                                string ItemAnswer = Console.ReadLine().ToLower();
                                if(ItemAnswer == "yes")
                                {
                                    foreach(var item in CurrentRoom.RoomItems)
                                    {
                                        Console.WriteLine("You have picked up items");
                                        player.PickUpItem(item);
                                        


                                }
                                CurrentRoom.RoomItems.Clear();


                            }
                                else if(ItemAnswer == "no")
                                {
                                    Console.WriteLine("You have chosen to leave items");
                                    break;

                                    
                                }
                                else
                                {
                                    Console.WriteLine("Please enter yes or no");
                                    break;
                                }

                            }
                        }
                    

                    //allows user to go to next room
                    else if (action == "next")
                    {
                        if (CurrentRoom.Enemies.Count > 0)
                        {
                            Console.WriteLine("You can not advance there are still mosters around");
                            break;
                        }

                        else
                        {
                            CurrentRoom = CurrentRoom.NextRoom;
                            Console.WriteLine($"\nYou move to: {CurrentRoom.Name}");
                            Console.WriteLine(CurrentRoom.Description);
                            break;
                        }
                    }

                    //allows user to end program 
                    else if (action == "end")
                    {
                        playing = false;
                        break;

                    }

                    //prompts user to put a correct input 
                    else
                    {
                        Console.WriteLine("Hey that wasnt a option please pick one of the options.");
                        break;
                    }
                }





            }
        }
    }
}


