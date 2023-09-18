﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    struct Stand
    {
        public string Name;
        public float Power;
        public float Speed;
        public float Durability;
        public int Range;
        public int Precision;
        public string Potiential;
    }

    class Game
    {
        struct BoolWeapon
        {
            bool weapon;
        }


        //Initializing variables
        bool gameOver = false;
        int currentScene = 0;
        string input = "";
        int inputReceived = 0;
        string output = "";
        int currentEnemyIndex = 0;

        //Declaring characters
        Character Player;
        Character JoePable;
        Character Joehna;
        Character Jach;
        Character Johnny;
        Character[] Enemies;

        //Menu for character selection
        int CharacterSelectionMenu(string prompt, string choice1, string choice2, string choice3, string choice4)
        {
            while (input != "1" && input != "2" && input != "3" && input != "4")
            {
                //Prompt and choices
                Console.WriteLine(prompt);
                Console.WriteLine("1. " + choice1);
                Console.WriteLine("2. " + choice2);
                Console.WriteLine("3. " + choice3);
                Console.WriteLine("4. " + choice4);
                Console.WriteLine("> ");

                //Player input
                input = Console.ReadLine();

                if (input == "1")
                {
                    inputReceived = 1;
                }
                else if (input == "2")
                {
                    inputReceived = 2;
                }
                else if (input == "3")
                {
                    inputReceived = 3;
                }
                else if (input == "4")
                {
                    inputReceived = 4;
                }
                else
                {
                    Console.WriteLine("Sorry that ins't one of the choices.");
                    Console.ReadKey(true);
                }
                Console.Clear();
            }
            return inputReceived;
        }

        string GetInput(string description, string option1, string option2, string option3)
        {


            //While input is not 1 or 2 display the options
            while (input != "1" && input != "2")
            {
                //Print options
                Console.WriteLine(description);
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.WriteLine("3. " + option3);
                Console.WriteLine("> ");

                //Get input from player
                input = Console.ReadLine();

                //If player selected the first option
                if (input == "1")
                {
                    output = "1";
                }
                //Otherwise if the player selected the second option
                else if (input == "2")
                {
                    output = "2";
                }
                else if (input == "3")
                {
                    output = "3";
                }
                //If none are true
                else
                {
                    //...display error message
                    Console.WriteLine("Invalid Input");
                    Console.ReadKey(true);
                }

                Console.Clear();
            }

            return output;
        }

        //Character selection and choices
        void CharacterSelection()
        {
            //Display character selection menu and store player input
            CharacterSelectionMenu("Welcome Player" + "\nPlease choose your guy", "JoePable", "Joehna", "Jach", "Johnny");
            
            //Choices for player
            if (inputReceived == 1)
            {
                Player = JoePable;
                Console.WriteLine("You have selected " + JoePable.GetName());
                Console.Write("\n");

                Player.PrintStats();
                Console.Write("\n");
                Console.WriteLine("His Stand Ability is Purple Haze. When attacking it creates a flesh eating virus that can reduce a person to nothing in seconds.");

                Console.ReadKey(true);
                Console.Clear();

            }
            else if (inputReceived == 2)
            {
                Player = Joehna;
                Console.WriteLine("You have selected " + Joehna.GetName());
                Console.Write("\n");

                Player.PrintStats();
                Console.Write("\n");
                Console.WriteLine("His Stand Ability is Epitaph. Epitaph cannot attack and instead allows the user to peak ahead up to 10 seconds into the future.");

                Console.ReadKey(true);
                Console.Clear();
            }
            else if (inputReceived == 3)
            {
                Player = Jach;
                Console.WriteLine("You have selected " + Jach.GetName());
                Console.Write("\n");

                Player.PrintStats();
                Console.Write("\n");
                Console.WriteLine("His Stand Ability is Dolly Dagger. It is a Stand in the shape of a dagger that also offers a great deal of defense for the user.");

                Console.ReadKey(true);
                Console.Clear();
            }
            else if (inputReceived == 4)
            {
                Player = Johnny;
                Console.WriteLine("You have selected " + Johnny.GetName());
                Console.Write("\n");

                Player.PrintStats();
                Console.Write("\n");
                Console.WriteLine("His Stand Ability is Tusk Act IV. This Stand has the power of infinite rotation, when attacking an opponent it's ability" +
                    "causes their cells to rotate infinitely and collide with each other until the opponent is eventually reduced to nothing.");

                Console.ReadKey(true);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Invalid Input");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
        }

        //Battle function
        void Fite(ref Character monster2)
        {
            //Print stats for both participants
            Player.PrintStats();
            Console.Write("\n");
            monster2.PrintStats();
            Console.Write("\n");

            //Bool for player defense
            bool isDefending = false;

            //Print out feedback for player and reduce health based on damage
            string battleChoice = GetInput("Choose an action", "Attack", "Defend", "Run");

            //If player chooses to attack
            if (battleChoice == "1")
            {
                monster2.TakeDamage(Player.GetDamage());
                //monster2.GetHealth() = Attack(Player, monster2);
                Console.WriteLine("You used " + Player.GetStand().Name + "!");
                Console.ReadKey(true);

                if (monster2.GetHealth() <= 0)
                {
                    return;
                }
            }

            //If player chooses to defend
            else if (battleChoice == "2")
            {
                isDefending = true;
                Player.BoostDefense();
                Console.WriteLine("You brace yourself for the coming strike");
                Console.ReadKey(true);
            }

            //If player chooses to run
            else if (battleChoice == "3")
            {
                Console.WriteLine("You used the secret Joestar technique.");
                currentScene = 2;
                Console.ReadKey(true);
                return;
            }

            //The enemy attacks the player
            Player.PrintStats();
            Console.Write("\n");
            monster2.PrintStats();
            Console.Write("\n");

            //Print out feedback for enemy attack and reduce player health
            Console.WriteLine(monster2.GetName() + " Punches " + Player.GetName() + "!");
            Player.TakeDamage(monster2.GetDamage());
            Console.ReadKey(true);

            if (isDefending == true)
            {
                Player.ResetDefense();
            }
        }

        //Healing function
        float HealMon(Character healReceiver, float healAmount)
        {
            float heal = healReceiver.GetHealth() + healAmount;

            //Placing a cap on healing
            if (heal > 3230)
            {
                heal = 3230;
            }

            return heal;
        }

        //First scene for update function
        void Scene1()
        {
            CharacterSelection();

            currentScene = 1;
        }

        //Using battle function to create second scene
        void BattleScene()
        {
            Fite(ref Enemies[currentEnemyIndex]);

            Console.Clear();

            if (Player.GetHealth() <= 0 || Enemies[currentEnemyIndex].GetHealth() <= 0)
            {
                currentScene = 2;
            }
        }

        //Display win results for the player
        void WinResultsScene()
        {
            if (Player.GetHealth() > 0 && Enemies[currentEnemyIndex].GetHealth() <= 0)
            {
                Console.WriteLine("Damn, he got his ass handed to him.");
                Console.WriteLine("The winner is: " + Player.GetName());
                currentScene = 1;
                currentEnemyIndex++;

                if (currentEnemyIndex >= Enemies.Length)
                {
                    gameOver = true;
                }
            }
            else if (Player.GetHealth() < 0 && Enemies[currentEnemyIndex].GetHealth() >= 0)
            {
                Console.WriteLine("Holy shit, you got demolished.");
                Console.WriteLine("The winner is: " + Enemies[currentEnemyIndex].GetName());
                currentScene = 3;
            }
            Console.ReadKey(true);
            Console.Clear();
        }

        void EndGameScene()
        {
            string playerChoice = GetInput("You Died. Play Again?", "Yes", "No", "");

            if (playerChoice == "1")
            {
                currentScene = 0;
            }
            else if (playerChoice == "2")
            {
                gameOver = true;
            }
        }

        int[] numbers = new int[3] { 49, 6, 12 };
        
        //Function for adding ints inside an array
        void PrintSum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            Console.WriteLine(sum);
        }

        //Function for printing largest int in array
        void PrintLargest(int[] array)
        {
            int largestNum = array[0];

            for (int i = 0; i < array.Length; i++)
            {
              if (array[i] >= largestNum)
              {
                  largestNum = array[i];
              }
            }
            Console.WriteLine(largestNum);
        }

        //Golden function for declaring variables
        void Start()
        {
            Stand Epitaph;
            Epitaph.Name = "Epitaph";
            Epitaph.Power = 1;
            Epitaph.Speed = 200f;
            Epitaph.Durability = 0;
            Epitaph.Range = 100;
            Epitaph.Precision = 100;
            Epitaph.Potiential = "Low";

            Stand Haze;
            Haze.Name = "Purple Haze";
            Haze.Power = 5000f;
            Haze.Speed = 15f;
            Haze.Durability = 3f;
            Haze.Range = 5;
            Haze.Precision = 1;
            Haze.Potiential = "High";

            Stand Dagger;
            Dagger.Name = "Dolly Dagger";
            Dagger.Power = 5f;
            Dagger.Speed = 10f;
            Dagger.Durability = 50f;
            Dagger.Range = 2;
            Dagger.Precision = 3;
            Dagger.Potiential = "Low";

            Stand Tusk;
            Tusk.Name = "Tusk Act IV";
            Tusk.Power = 10000000000f;
            Tusk.Speed = 1000f;
            Tusk.Durability = 100f;
            Tusk.Range = 5;
            Tusk.Precision = 10;
            Tusk.Potiential = "High";

            JoePable = new Character("JoePable", 20f, 246.90f, .9f, 3f, Haze);

            Joehna = new Character("Joehna", 20f, 357.89f, 2.1f, 4, Epitaph);

            Jach = new Character("Jach", 20f, 135.91f, -1.1f, 2, Dagger);

            Johnny = new Character("Johnny", 50f, 5f, 2f, 1, Tusk);

            Enemies = new Character[4] { Joehna, Joehna, Jach, Johnny };
        }

        //Golden function for updating game based on player choice
        void Update()
        {
            if (currentScene == 0)
            {
                Scene1();
            }
            else if (currentScene == 1)
            {
                BattleScene();
            }
            else if (currentScene == 2)
            {
                WinResultsScene();
            }
            else if (currentScene == 3)
            {
                EndGameScene();
            }
        }

        //Golden function for calling end scene
        void End()
        {
            Console.WriteLine("Thanks for playing");
        }

        public void Run()
        {
          
            Start();

            while (gameOver == false)
            {
                Update();
            }

            End();
        }
    }
}
