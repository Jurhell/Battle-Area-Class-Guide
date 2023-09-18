using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Game
    {
        struct BoolWeapon
        {
            bool weapon;
        }

        struct Guy
        {
            public string Name;
            public float Health;
            public float Damage;
            public float Defense;
            public float Stamina;
            public Stand Ability;
        }

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

        //Initializing variables
        bool gameOver = false;
        int currentScene = 0;
        string input = "";
        int inputReceived = 0;
        string output = "";

        //Declaring characters
        Guy Player;
        Guy JoePable;
        Guy Joehna;
        Guy Jach;
        Guy Johnny;

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
                Console.WriteLine("You have selected " + JoePable.Name);
                Console.Write("\n");

                PrintStats(Player);
                Console.Write("\n");
                Console.WriteLine("His Stand Ability is Purple Haze. When attacking it creates a flesh eating virus that can reduce a person to nothing in seconds.");

                Console.ReadKey(true);
                Console.Clear();

            }
            else if (inputReceived == 2)
            {
                Player = Joehna;
                Console.WriteLine("You have selected " + Joehna.Name);
                Console.Write("\n");

                PrintStats(Player);
                Console.Write("\n");
                Console.WriteLine("His Stand Ability is Epitaph. Epitaph cannot attack and instead allows the user to peak ahead up to 10 seconds into the future.");

                Console.ReadKey(true);
                Console.Clear();
            }
            else if (inputReceived == 3)
            {
                Player = Jach;
                Console.WriteLine("You have selected " + Jach.Name);
                Console.Write("\n");

                PrintStats(Player);
                Console.Write("\n");
                Console.WriteLine("His Stand Ability is Dolly Dagger. It is a Stand in the shape of a dagger that also offers a great deal of defense for the user.");

                Console.ReadKey(true);
                Console.Clear();
            }
            else if (inputReceived == 4)
            {
                Player = Johnny;
                Console.WriteLine("You have selected " + Johnny.Name);
                Console.Write("\n");

                PrintStats(Player);
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

        //Player atttack function
        float Attack(Guy attacker, Guy defender)
        {
            float totalDamage = attacker.Ability.Power - defender.Defense;

            return defender.Health - totalDamage;
        }

        //Battle function
        void Fite(ref Guy monster2)
        {
            //Print stats for both participants
            PrintStats(Player);
            Console.Write("\n");
            PrintStats(monster2);
            Console.Write("\n");

            //Bool for player defense
            bool isDefending = false;

            //Print out feedback for player and reduce health based on damage
            string battleChoice = GetInput("Choose an action", "Attack", "Defend", "Run");

            //If player chooses to attack
            if (battleChoice == "1")
            {
                monster2.Health = Attack(Player, monster2);
                Console.WriteLine("You used " + Player.Ability.Name + "!");
                Console.ReadKey(true);

                if (monster2.Health <= 0)
                {
                    return;
                }
            }

            //If player chooses to defend
            else if (battleChoice == "2")
            {
                isDefending = true;
                Player.Defense *= 5;
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
            PrintStats(Player);
            Console.Write("\n");
            PrintStats(monster2);
            Console.Write("\n");

            //Print out feedback for enemy attack and reduce player health
            Console.WriteLine(monster2.Name + " Punches " + Player.Name + "!");
            Player.Health = Attack(monster2, Player);
            Console.ReadKey(true);

            if (isDefending == true)
            {
                Player.Defense /= 5;
            }
        }

        //Function for printing player stats
        void PrintStats(Guy monster)
        {
            Console.WriteLine("Name:" + monster.Name);
            Console.WriteLine("Health:" + monster.Health);
            Console.WriteLine("Damage:" + monster.Damage);
            Console.WriteLine("Defense:" + monster.Defense);
            Console.WriteLine("Stamina:" + monster.Stamina);
        }

        //Healing function
        float HealMon(Guy healReceiver, float healAmount)
        {
            float heal = healReceiver.Health + healAmount;

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
            if (inputReceived == 1 || inputReceived == 3 || inputReceived == 4)
            {
                Fite(ref Joehna);
            }
            else if (inputReceived == 2)
            {
                Fite(ref Jach);
            }

            Console.Clear();

            if (Player.Health <= 0 || Joehna.Health <= 0)
            {
                currentScene = 2;
            }
            else if (Player.Health <= 0 || Jach.Health <= 0)
            {
                currentScene = 2;
            }
        }

        //Display win results for the player
        void WinResultsScene()
        {
            if (Player.Health > 0 && Joehna.Health <= 0)
            {
                Console.WriteLine("Damn, he got his ass handed to him.");
                Console.WriteLine("The winner is: " + Player.Name);
            }
            else if (Player.Health > 0 && Jach.Health <= 0)
            {
                Console.WriteLine("Damn, he got his ass handed to him.");
                Console.WriteLine("The winner is: " + Player.Name);
            }
            else if (Player.Health < 0 && Joehna.Health >= 0)
            {
                Console.WriteLine("Holy shit, you got demolished.");
                Console.WriteLine("The winner is: " + Joehna.Name);
            }
            else if (Player.Health < 0 && Jach.Health >= 0)
            {
                Console.WriteLine("Holy shit, you got demolished.");
                Console.WriteLine("The winner is: " + Jach.Name);
            }
            Console.ReadKey(true);
            Console.Clear();
        }

        int[] numbers = new int[3] { 1, 2, 3 };

        //Function for adding ints inside an array
        void AddArrayInts(int a)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers.Length)
                {
                    Console.WriteLine(numbers[i]);
                }
            }
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


            JoePable.Name = "JoePable";
            JoePable.Health = 20f;
            JoePable.Damage = 246.90f;
            JoePable.Defense = .9f;
            JoePable.Stamina = 3f;
            JoePable.Ability = Haze;


            Joehna.Name = "Joehna";
            Joehna.Health = 20f;
            Joehna.Damage = 357.89f;
            Joehna.Defense = 2.1f;
            Joehna.Stamina = 4;
            Joehna.Ability = Epitaph;


            Jach.Name = "Jach";
            Jach.Health = 20f;
            Jach.Damage = 135.91f;
            Jach.Defense = -1.1f;
            Jach.Stamina = 2;
            Jach.Ability = Dagger;

            Johnny.Name = "Johnny";
            Johnny.Health = 50f;
            Johnny.Damage = 5f;
            Johnny.Defense = 2f;
            Johnny.Stamina = 1;
            Johnny.Ability = Tusk;
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
        }

        //Golden function for calling end scene
        void End()
        {
            Console.WriteLine("Thanks for playing");
        }

        public void Run()
        {
            AddArrayInts(numbers);
            return;

            Start();

            while (gameOver == false)
            {
                Update();
            }

            End();
        }
    }
}
