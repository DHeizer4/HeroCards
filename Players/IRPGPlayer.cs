using Cards_Games.Enumerations;
using Cards_Games.Models;
using System.Collections.Generic;

namespace Cards_Games.Players
{
    interface IRPGPlayer
    {
        string Name { get; set; }
        List<Status> Statuses { get; set; }
        int Team { get; set; }
        int Time { get; set; }
        int Health { get; set; }
        int MaxHealth { get; set; }
        int Mana { get; set; }
        int MaxMana { get; set; }
        Weapon Weapon { get; set; }   
        List<Equipment> Equipment { get; set; }
        int Strength { get; set; }
        int Intellect { get; set; }
        int Agility { get; set; }
        int Dexterity { get; set; }
        int Concentrate { get; set; }
        int Armor { get; set; }
        int Block { get; set; }
        int MagicShield { get; set; }
        int Shield { get; set; }
        int Speed { get; set; }
        int NextMove { get; set; }
        List<RPGCard> Action { get; set; }
        Deck Decklist { get; set; }
        List<RPGCard> Hand { get; set; }
        int Prescence { get; set; }


        void OpeningHand();
        void DrawCard();
        RPGCard PlayCard();
        IRPGPlayer GetTarget(List<IRPGPlayer> participants);

    }

}
