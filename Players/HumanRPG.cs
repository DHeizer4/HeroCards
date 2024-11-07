using Cards_Games.Enumerations;
using Cards_Games.Models;
using System.Collections.Generic;

namespace Cards_Games.Players
{
    class HumanRPG : IRPGPlayer
    {
        public string Name { get; set; }
        public List<Status> Statuses { get; set; } = new List<Status>();
        public int Team { get; set; }
        public int Time { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Mana { get; set; }
        public int MaxMana { get; set; }
        public Weapon Weapon { get; set; }
        public List<Equipment> Equipment { get; set; } = new List<Equipment>();
        public int Strength { get; set; }
        public int Intellect { get; set; }
        public int Agility { get; set; }
        public int Dexterity { get; set; }
        public int Concentrate { get; set; }
        public int Armor { get; set; }
        public int Block { get; set; }
        public int MagicShield { get; set; }
        public int Shield { get; set; }
        public int Speed { get; set; }
        public int NextMove { get; set; }
        public List<RPGCard> Action { get; set; }
        public Deck Decklist { get; set; }
        public List<RPGCard> Hand { get; set; }
        public int Prescence { get; set; }

        // Can a caster cast faster than a fighter and vise versa....

        public HumanRPG(string aName, int aTeam)
        {
            Name = aName;
            Team = aTeam;
            Health = 10;
            Decklist = new Deck("Starter Deck", RPGCard.StartList());
            Hand = new List<RPGCard>();
            Action = new List<RPGCard>();
            Speed = 1;
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

            string header = "The possible targets are...";
            string prompt = "Please choose a target: ";

            choice = Display.DialogWithInput(header, listOfPlayers, prompt);

            target = possibleTargets[choice - 1];

            return target;
        }

        public RPGCard PlayCard()
        {
            List<string> ListOfCards = CardsInHand();
            string header = "You have the following cards in your hand.";
            string prompt = "What card would you like to play: ";

            while (true)
            {
                int response = Display.DialogWithInput(header, ListOfCards, prompt);

                RPGCard played = Hand[response - 1];
                Hand.RemoveAt(response - 1);
                List<string> dialog = new List<string>();
                dialog.Add($"{Name} will be playing {played}");

                Display.SimpleDialogBox(dialog);
                return played;

            }
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
