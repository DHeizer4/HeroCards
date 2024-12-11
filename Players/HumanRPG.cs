using Cards_Games.Cards;
using Cards_Games.Models;
using System.Collections.Generic;
using static Cards_Games.Enumerations.CharacterRaceEnumueration;

namespace Cards_Games.Players
{
    class HumanRPG : IRPGPlayer
    {
        public string Id { get; set; }
        public int DisplayPosition { get; set; }
        public string Name { get; set; }
        public CharacterRace Race { get; set; }
        public List<string> Skills { get; set; }  // improvments not limitations
        public List<Status> Statuses { get; set; } = new List<Status>();
        public int Team { get; set; }
        public int Money { get; set; }
        public int Time { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Mana { get; set; }
        public int MaxMana { get; set; }
        public int Energy { get; set; }
        public Weapon Weapon { get; set; }
        public List<Equipment> Equipment { get; set; } = new List<Equipment>();  // special effects?  ex: redirect dmg
        public int Strength { get; set; }
        public int Intellect { get; set; }
        public int Agility { get; set; }
        public int Dexterity { get; set; }
        public int Endurance { get; set; }
        public int Concentrate { get; set; }
        public int Speed { get; set; }
        public int Haste { get; set; }
        public int Armor { get; set; }
        public int Resistance { get; set; }
        public int Block { get; set; }
        public int MagicShield { get; set; }
        public int Shield { get; set; }
        public int Presence { get; set; }
        public int NextMove { get; set; }
        public List<RPGCard> Action { get; set; }
        public Deck Decklist { get; set; }
        public List<RPGCard> Hand { get; set; }


        // Can a caster cast faster than a fighter and vise versa....


        public HumanRPG(string name, CharacterRace race, List<string> skills, CharacterProperties properties, Deck deck)
        {
            Name = name;
            Race = race;
            Skills = skills;
            Strength = (int)properties.Strength;
            Intellect = (int)properties.Intellect;
            Agility = (int)properties.Agility;
            Dexterity = (int)properties.Dexterity;
            Endurance = (int)properties.Endurance;
            Concentrate = (int)properties.Concentration;
            Speed = (int)properties.Speed;
            Haste = (int)properties.Haste;
            Armor = (int)properties.Armor;
            Resistance = (int)properties.Resistance;
            MaxHealth = (int)(properties.Endurance * 5);
            MaxMana = (int)(properties.Concentration * 5);
            Decklist = deck;
            Hand = new List<RPGCard>();
            Action = new List<RPGCard>();
        }

        public IRPGPlayer GetTarget(List<IRPGPlayer> possibleTargets)
        {
            int choice = 0;
            List<string> listOfPlayers = new List<string>();
            IRPGPlayer target;

            foreach (IRPGPlayer possibleTarget in possibleTargets)
            {
                listOfPlayers.Add(possibleTarget.Name);
            }

            List<string> header = new List<string>() { "The possible targets are..." };
            string prompt = "Please choose a target: ";

            choice = Display.DialogWithInput(header, listOfPlayers, prompt, "dialog");

            target = possibleTargets[choice - 1];

            return target;
        }

        public RPGCard PlayCard(List<IRPGPlayer> players)
        {
            bool canAfford = true;
            bool desireToPlay = false;
            int choice = 0;
            List<RPGCard> played = new List<RPGCard>();
            List<string> ListOfCards = CardsInHand();
            List<string> header = new List<string>() { "You have the following cards in your hand." };
            string prompt = "What card would you like to play: ";

            do
            {
                choice = Display.DialogWithInput(header, ListOfCards, prompt, "dialog");

                played.Add(Hand[choice - 1]);
                canAfford = PlayerUtilities.CardCost.CanAfford(this, played[0]);
                desireToPlay = Display.DisplayCard(played[0]);

                if (canAfford == false)
                {
                    header.Insert(0, "You cannot afford that choice");
                    played.RemoveAt(0);
                }

                if (played.Count > 0 && desireToPlay == false)
                {
                    played.RemoveAt(0);
                }

            } while (!canAfford || !desireToPlay);

            // We do not want to pay the costs before confirming all costs for the card can be paid
            PlayerUtilities.CardCost.PayCosts(this, played[0]);

            if(played[0].Durability == 1)
            {
                Hand.RemoveAt(choice - 1);
                Decklist.Discard(played[0]);
            }
            else
            {
                played[0].Durability -= 1;
            }
            
            List<string> dialog = new List<string>();
            dialog.Add($"{Name} will be playing {played[0]}");

            // Display.SimpleDialogBox(dialog);
            return played[0];

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
            if (Decklist.Count() <= 0)
            {
                Decklist.ShuffleDiscardIntoDeck();
                Decklist.RandomShuffle(4);
            }

            Hand.Add(Decklist.DealCard());
        }

        public List<string> CardsInHand()
        {
            List<string> cards = new List<string>();
            for (int i = 0; i < Hand.Count; i++)
            {
                cards.Add($"{Hand[i]}");
            }

            return cards;
        }

    }
}
