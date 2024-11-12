using Cards_Games.Models;
using System.Collections.Generic;

namespace Cards_Games.Players
{
    interface IRPGPlayer
    {
        string Id { get; set; }
        string Name { get; set; }
        List<Status> Statuses { get; set; }
        int Team { get; set; }
        int Money { get; set; }
        int Time { get; set; }
        int Health { get; set; }
        int MaxHealth { get; set; }
        int Mana { get; set; }
        int MaxMana { get; set; }
        int Energy { get; set; }
        Weapon Weapon { get; set; }
        List<Equipment> Equipment { get; set; }
        int Strength { get; set; }          // Increases Bludgeon dmg
        int Intellect { get; set; }         // Increases magical dmg
        int Agility { get; set; }           // Increases crit chance
        int Dexterity { get; set; }         // Increases Slashing dmg
        int Endurance { get; set; }         // Increases max Health
        int Concentrate { get; set; }       // Increases max Mana
        int Speed { get; set; }             // Increases the rate at which you can play cards
        int Haste { get; set; }             // Decreases how long it takes to play a card
        int Armor { get; set; }             // Resistance to physical dmg percentage based
        int Resistance { get; set; }        // Resistance to Magical dmg percentage based
        int Block { get; set; }             // Remove a set amount of dmg (100 dmg vs block 10 = 90 dmg)
        int MagicShield { get; set; }       // Magical dmg hurts this before your health
        int Shield { get; set; }            // Physical dmg hurts this before your health
        int Presence { get; set; }          // Idea about targeting
        int NextMove { get; set; }
        List<RPGCard> Action { get; set; }
        Deck Decklist { get; set; }
        List<RPGCard> Hand { get; set; }



        void OpeningHand();
        void DrawCard();
        RPGCard PlayCard();
        IRPGPlayer GetTarget(List<IRPGPlayer> participants);

    }

}
