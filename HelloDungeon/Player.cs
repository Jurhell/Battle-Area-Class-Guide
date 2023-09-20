using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Player : Character
    {
        private string _playerChoice;
        private int _lives = 3;

        public Player()
        {
            _playerChoice = "";
        }

        public Player(string name, float health, float damage, float defense, float stamina, Stand ability) : base(name, health, damage, defense, stamina, ability)
        {
            _playerChoice = "";
        }

        //Get Player Input Function
        public string GetInput(string description, string option1, string option2)
        {
            _playerChoice = "";

            //While input is not 1 or 2 display the options
            while (_playerChoice != "1" && _playerChoice != "2")
            {
                //Print options
                Console.WriteLine(description);
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.WriteLine("> ");

                //Get input from player
                _playerChoice = Console.ReadLine();
            }

            return _playerChoice;
        }
        public string GetInput(string description, string option1, string option2, string option3)
        {
            _playerChoice = "";

            //While input is not 1 or 2 display the options
            while (_playerChoice != "1" && _playerChoice != "2" && _playerChoice != "3")
            {
                //Print options
                Console.WriteLine(description);
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.WriteLine("3. " + option3);
                Console.WriteLine("> ");

                //Get input from player
                _playerChoice = Console.ReadLine();
            }

            return _playerChoice;
        }
        public string GetInput(string description, string option1, string option2, string option3, string option4, string option5)
        {
            _playerChoice = "";

            //While input is not 1 or 2 display the options
            while (_playerChoice != "1" && _playerChoice != "2" && _playerChoice != "3" && _playerChoice != "4" && _playerChoice != "5")
            {
                //Print options
                Console.WriteLine(description);
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.WriteLine("3. " + option3);
                Console.WriteLine("4. " + option4);
                Console.WriteLine("5. " + option5);
                Console.WriteLine("> ");

                //Get input from player
                _playerChoice = Console.ReadLine();
            }

            return _playerChoice;
        }

        public override void PrintStats()
        {
            //base.PrintStats();
            Console.WriteLine("Name: " + GetName());
            Console.WriteLine("Health: " + GetHealth());
            Console.WriteLine("Damage: " + GetDamage());
            Console.WriteLine("Defense: " + GetDefense());
            Console.WriteLine("Stamina: " + GetStamina());
            Console.WriteLine("Lives" + _lives);
        }
    }
}
