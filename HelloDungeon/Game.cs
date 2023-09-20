using System;
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
        int currentEnemyIndex = 0;

        //Declaring characters
        Player PlayerCharacter;
        Character JoePable;
        Character Joehna;
        Character Jach;
        Character Johnny;
        Character Jocelyn;
        Character[] Enemies;

        //Menu for character selection
        int CharacterSelectionMenu(string prompt, string choice1, string choice2, string choice3, string choice4, string choice5)
        {
            while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5")
            {
                //Prompt and choices
                Console.WriteLine(prompt);
                Console.WriteLine("1. " + choice1);
                Console.WriteLine("2. " + choice2);
                Console.WriteLine("3. " + choice3);
                Console.WriteLine("4. " + choice4);
                Console.WriteLine("5. " + choice5);
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
                else if (input == "5")
                {
                    inputReceived = 5;
                }
                else
                {
                    Console.WriteLine("Sorry that isn't one of the choices.");
                    Console.ReadKey(true);
                }
                Console.Clear();
            }
            return inputReceived;
        }

        //Character selection and choices
        void CharacterSelection()
        {
            //Display character selection menu and store player input
            CharacterSelectionMenu("Welcome Player" + "\nPlease choose your guy", "JoePable", "Joehna", "Jach", "Jocelyn", "Johnny");

            //PlayerCharacter.GetInput("Welcome Player" + "\nPlease choose your guy", JoePable.GetName(), Joehna.GetName(), Jach.GetName(), Jocelyn.GetName(), Johnny.GetName());

            //Choices for player
            if (inputReceived == 1)
            {
                PlayerCharacter = new Player(JoePable.GetName(), JoePable.GetHealth(), JoePable.GetDamage(), JoePable.GetDefense(), JoePable.GetStamina(), JoePable.GetStand());
                Console.WriteLine("You have selected " + JoePable.GetName());
                Console.Write("\n");

                PlayerCharacter.PrintStats();
                Console.Write("\n");
                Console.WriteLine("His Stand Ability is Purple Haze. When attacking it creates a flesh eating virus that can reduce a person to nothing in seconds.");

                Console.ReadKey(true);
                Console.Clear();

            }
            else if (inputReceived == 2)
            {
                PlayerCharacter = new Player(Joehna.GetName(), Joehna.GetHealth(), Joehna.GetDamage(), Joehna.GetDefense(), Joehna.GetStamina(), Joehna.GetStand());
                Console.WriteLine("You have selected " + Joehna.GetName());
                Console.Write("\n");

                PlayerCharacter.PrintStats();
                Console.Write("\n");
                Console.WriteLine("His Stand Ability is Epitaph. Epitaph cannot attack and instead allows the user to peak ahead up to 10 seconds into the future.");

                Console.ReadKey(true);
                Console.Clear();
            }
            else if (inputReceived == 3)
            {
                PlayerCharacter = new Player(Jach.GetName(), Jach.GetHealth(), Jach.GetDamage(), Jach.GetDefense(), Jach.GetStamina(), Jach.GetStand());
                Console.WriteLine("You have selected " + Jach.GetName());
                Console.Write("\n");

                PlayerCharacter.PrintStats();
                Console.Write("\n");
                Console.WriteLine("His Stand Ability is Dolly Dagger. It is a Stand in the shape of a dagger that also offers a great deal of defense for the user.");

                Console.ReadKey(true);
                Console.Clear();
            }
            else if (inputReceived == 4)
            {
                PlayerCharacter = new Player(Jocelyn.GetName(), Jocelyn.GetHealth(), Jocelyn.GetDamage(), Jocelyn.GetDefense(), Jocelyn.GetStamina(), Jocelyn.GetStand());
                Console.WriteLine("You have selected " + Jocelyn.GetName());
                Console.Write("\n");

                PlayerCharacter.PrintStats();
                Console.Write("\n");
                Console.WriteLine("Her Stand Ability is Echoes Act II. It is a Stand that uses sound effects to attack the opponent and can generate the effect of that sound.");

                Console.ReadKey(true);
                Console.Clear();
            }
            else if (inputReceived == 5)
            {
                PlayerCharacter = new Player(Johnny.GetName(), Johnny.GetHealth(), Johnny.GetDamage(), Johnny.GetDefense(), Johnny.GetStamina(), Johnny.GetStand());
                Console.WriteLine("You have selected " + Johnny.GetName());
                Console.Write("\n");

                PlayerCharacter.PrintStats();
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
            PlayerCharacter.PrintStats();
            Console.Write("\n");
            monster2.PrintStats();
            Console.Write("\n");

            //Bool for player defense
            bool isDefending = false;

            //Print out feedback for player and reduce health based on damage
            string battleChoice = PlayerCharacter.GetInput("Choose an action", "Attack", "Defend", "Run");

            //If player chooses to attack
            if (battleChoice == "1")
            {
                monster2.TakeDamage(PlayerCharacter.GetDamage());
                //monster2.GetHealth() = Attack(Player, monster2);
                Console.WriteLine("You used " + PlayerCharacter.GetStand().Name + "!");
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
                PlayerCharacter.BoostDefense();
                Console.WriteLine("You brace yourself for the coming strike");
                Console.ReadKey(true);
            }

            //If player chooses to run
            else if (battleChoice == "3")
            {
                Console.WriteLine("You used the secret Joestar technique.");
                currentScene = 2;

                return;
            }

            HealMon(PlayerCharacter, 50f);

            //The enemy attacks the player
            PlayerCharacter.PrintStats();
            Console.Write("\n");
            monster2.PrintStats();
            Console.Write("\n");

            //Print out feedback for enemy attack and reduce player health
            Console.WriteLine(monster2.GetName() + " Punches " + PlayerCharacter.GetName() + "!");
            PlayerCharacter.TakeDamage(monster2.GetDamage());
            Console.ReadKey(true);

            if (isDefending == true)
            {
                PlayerCharacter.ResetDefense();
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

            if (PlayerCharacter.GetHealth() <= 0 || Enemies[currentEnemyIndex].GetHealth() <= 0)
            {
                currentScene = 2;
            }
        }

        //Display win results for the player
        void WinResultsScene()
        {
            if (PlayerCharacter.GetHealth() > 0 && Enemies[currentEnemyIndex].GetHealth() <= 0)
            {
                Console.WriteLine("Damn, he got his ass handed to him.");
                Console.WriteLine("The winner is: " + PlayerCharacter.GetName());
                currentScene = 1;
                currentEnemyIndex++;

                if (currentEnemyIndex >= Enemies.Length)
                {
                    gameOver = true;
                }
            }
            else if (PlayerCharacter.GetHealth() < 0 && Enemies[currentEnemyIndex].GetHealth() >= 0)
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
            string playerChoice = PlayerCharacter.GetInput("You Died. Play Again?", "Yes", "No");

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
            Haze.Power = 100f;
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

            Stand Echoes;
            Echoes.Name = "Echoes Act II";
            Echoes.Power = 20f;
            Echoes.Speed = 6f;
            Echoes.Durability = 50f;
            Echoes.Range = 20;
            Echoes.Precision = 3;
            Echoes.Potiential = "High";

            //Initializing Character Class
            JoePable = new Character("JoePable", 20f, 246.90f, .9f, 3f, Haze);

            Joehna = new Character("Joehna", 20f, 357.89f, 2.1f, 4, Epitaph);

            Jach = new Character("Jach", 20f, 135.91f, -1.1f, 2, Dagger);

            Johnny = new Character("Johnny", 50f, 5f, 2f, 1, Tusk);

            Jocelyn = new Character("Jocelyn", 100f, -25f, 3f, 3f, Echoes);

            Enemies = new Character[5] { Joehna, Joehna, Jach, Jocelyn, Johnny };
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
