using System;
using System.Collections.Generic;
using System.Text;

namespace Cards_Games.Enumerations
{
    // Based on chinese Zodiac

    public class CharacterRaceEnumueration
    {                                                                                           //Special card   40 card deck
        public enum CharacterRace { Lapine,     // French for Rabbit    Fast Caster             Reproduce:  makes mirror images
                                    Minotaur,   // 1 Bull Person          Warrior                 Bull rush  Trample card?  how would trample work
                                    Draconian,  // Dragon Person        Battle Mage             Turn Dragon    Soar into air while in air can't be hit until next action
                                    Mausian,    // Mouse Person         Fast Dex Physical dmg   Lighting Rush  speed increase chance to stun all enemies
                                    Naga,       // Snake Person                                 Poision that has a chance to stun every turn
                                    Centaur,    // Horse Person         Fast strength based     based on Umamusume: Pretty Derby 
                                    Ailuran,    // 1 Cat person           Overall good fighter    Focus:  incease dex and Agility  Roar???
                                    Saytr,      // 1 Goat person          Support race            Tea Party.  Restores all players to full health and removes all buffs and debuffs
                                    Vanara,     // Monkey person        Trickster               Distraction maker  summons a 1 hp taunting target / redirecting target
                                    Aarakocra,  // 1 Bird person          Concentration Based     Soar into air while in air can't be hit until next action
                                    Adlet,      // Dog person           All Around              Increases all his stats,  /  Puppy eyes??
                                    Erymanthian, // Boar person          Bezerker                Bezerk
                                    Summon
        }
    }
}
