using System;

namespace Slagsmal
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameRunning = true;
            while (gameRunning)
            {
                Console.WriteLine("Välkomen till Slagsmål spel 2 där din hjälte kommer slåss i en blodig kamp till döden mot en fiende.");
                Console.WriteLine("Namge din hjälte!");
                Random generator = new Random();
                Fighter hero = new Fighter() { name = Console.ReadLine(), hitPoints = generator.Next(700, 1000) };

                string[] enemyNames = new string[] { "Kyle", "10010110101", "xxPizzahater3xx60", "Chad" };
                int y = generator.Next(0, 4);
                Fighter enemy = new Fighter() { name = enemyNames[y], hitPoints = generator.Next(700, 1000) };


                string[] weaponsNames = new string[] { "Bannan", "Karate händer", "Giant trash orb", "AOC fjäder" };
                int x = generator.Next(0, (weaponsNames.Length));

                Weapon heroWeapon = new Weapon() { weaponName = weaponsNames[x], dmg = (x + 1) * 10, target = enemy };
                hero.weapon = heroWeapon;

                Weapon enemyWeapon = new Weapon { weaponName = weaponsNames[y], dmg = (y + 1) * 10, target = hero };
                enemy.weapon = enemyWeapon;

                Console.WriteLine("Din hjälte " + hero.name + " med " + heroWeapon.weaponName + " kommer slåss mot  " + enemy.name + " som har " + enemyWeapon.weaponName);

                while (hero.hitPoints > 0 && enemy.hitPoints > 0)
                {
                    int b = generator.Next(0, 3);
                    if (b == 2)
                    {
                        hero.weapon.HurtEnemy();
                        Console.WriteLine("Din hjälte attackerar fienden med sin " + hero.weapon.weaponName + " och gör: " + hero.weapon.dmg + " skada!");
                    }
                    else if (b == 1)
                    {
                        enemy.weapon.HurtEnemy();
                        Console.WriteLine("Fienden attackerar din hjälte med sin " + enemy.weapon.weaponName + " och gör: " + enemy.weapon.dmg + " skada!");
                    }
                    Console.WriteLine("Du har " + hero.hitPoints + " liv kvar");
                    Console.WriteLine("Fienden har " + enemy.hitPoints + " liv kvar");
                    Console.WriteLine("Tryck på en tangent för att fortsätta");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (hero.hitPoints > enemy.hitPoints)
                {
                    Console.WriteLine("Din hjälte besegrade fienden med: " + hero.hitPoints + " liv kvar");
                }
                else if (hero.hitPoints < enemy.hitPoints)
                {
                    Console.WriteLine("Fienden besegrade hjälten med: " + enemy.hitPoints + " liv kvar");
                }

                Console.WriteLine("Skriv sluta för att sluta eller något annat för att köra igen");
                string exitString = Console.ReadLine();
                if (exitString == "sluta")
                {
                    gameRunning = false;
                }
            }
        }
    }
    public class Fighter
    {
        public string name;
        public Weapon weapon;
        public int hitPoints;
    }
    public class Weapon
    {
        public string weaponName;
        public int dmg;
        public Fighter target;

        public void HurtEnemy()
        {
            Random generator = new Random();
            this.target.hitPoints -= this.dmg + generator.Next(-10, 100);
        }

    }
}
