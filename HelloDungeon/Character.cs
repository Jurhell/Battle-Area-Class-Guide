using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Character
    {
        private string _name;
        private float _health;
        private float _damage;
        private float _defense;
        private float _defenseBoost;
        private float _stamina;
        private Stand _ability;

        public Character(string name, float health, float damage, float defense, float stamina, Stand ability)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _defense = defense;
            _stamina = stamina;
            _ability = ability;
        }

        public string GetName()
        {
            return _name;
        }

        public float GetDamage()
        {
            return _damage;
        }

        public float GetHealth()
        {
            return _health;
        }

        public Stand GetStand()
        {
            return _ability;
        }

        public void BoostDefense()
        {
            _defense += _defenseBoost;
        }

        public void ResetDefense()
        {
            _defense -= _defenseBoost;
        }

        //Function for printing player stats
       public void PrintStats()
        {
            Console.WriteLine("Name:" + _name);
            Console.WriteLine("Health:" + _health);
            Console.WriteLine("Damage:" + _damage);
            Console.WriteLine("Defense:" + _defense);
            Console.WriteLine("Stamina:" + _stamina);
        }

        //Player atttack function
       public void TakeDamage(float damage)
        {
            _health -= damage - _defense;
        }
    }
}
