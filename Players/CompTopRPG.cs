﻿using Cards_Games.Enumerations;
using Cards_Games.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cards_Games.Players
{
    class CompTopRPG : IRPGPlayer
    {
        public string Name { get; set; }
        public int Team { get; set; }
        public int Time { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Weapon { get; set; }
        public int Concentrate { get; set; }
        public int Armor { get; set; }
        public int Block { get; set; }
        public int MagicShield { get; set; }
        public int Speed { get; set; }
        public int NextMove { get; set; }
        public List<RPGCard> Action { get; set; }
        public Deck Decklist { get; set; }
        public List<RPGCard> Hand { get; set; }
        public List<StatusEnumeration> Statuses { get; set; }
        public int MaxHealth { get; set; }
        public int MaxMana { get; set; }
        Weapon IRPGPlayer.Weapon { get; set; }
        public List<Equipment> Equipment { get; set; }
        public int Strength { get; set; }
        public int Intellect { get; set; }
        public int Agility { get; set; }
        public int Dexterity { get; set; }
        public int Shield { get; set; }

        public CompTopRPG(string aName, int aTeam)
        {
            Name = aName;
            Team = aTeam;
            Health = 10;
            Decklist = new Deck("Starter Deck", RPGCard.StartList());
            Hand = new List<RPGCard>();
            Action = new List<RPGCard>();
            Speed = 2;
        }

        public IRPGPlayer GetTarget(List<IRPGPlayer> possibleTargets)
        {
            return possibleTargets[0];
        }

        public void OpeningHand()
        {
            for (int i = 0; i < 5; i++)
            {
                Hand.Add(Decklist.DealCard());
            }
        }

        public void DrawCard()
        {
            Hand.Add(Decklist.DealCard());
        }

        public void DisplayPlayer()
        {
            Console.WriteLine($"Name = {Name}");
            Console.WriteLine($"Health: {Health}   Mana: {Mana}   Time: {Time}");
        }

        public RPGCard PlayCard()
        {
            RPGCard played = Hand[0];
            Hand.RemoveAt(0);

            List<string> dialog = new List<string>();
            dialog.Add($"{Name} will be playing {played}");

            Display.SimpleDialogBox(dialog);
            return played;
        }

    }
}
