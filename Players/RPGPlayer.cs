using System.Collections.Generic;

namespace Cards_Games.Players
{
    interface IRPGPlayer
    {
        string Name { get; set; }
        int Team { get; set; }
        int Time { get; set; }
        int Health { get; set; }
        int Mana { get; set; }
        int Weapon { get; set; }
        int Concentrate { get; set; }
        int Armor { get; set; }
        int Block { get; set; }
        int MagicShield { get; set; }
        int Speed { get; set; }
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
