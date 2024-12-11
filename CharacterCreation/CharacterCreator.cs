using Cards_Games.Cards;
using Cards_Games.Models;
using Cards_Games.Players;
using System.Collections.Generic;
using static Cards_Games.Enumerations.CharacterRaceEnumueration;

namespace Cards_Games.CharacterCreation
{
    class CharacterCreator
    {
        public static HumanRPG CreateBaseRace(string name, CharacterRace race, List<string> skills, Deck deck)
        {
            CharacterProperties properties = new CharacterProperties();

            switch (race)
            {
                case CharacterRace.Lapine:
                    properties = GetLapine();
                    break;
                case CharacterRace.Minotaur:
                    properties = GetMinotaur();
                    break;
                case CharacterRace.Draconian:
                    properties = GetDraconian();
                    break;
                case CharacterRace.Mausian:
                    properties = GetMausian();
                    break;
                case CharacterRace.Naga:
                    properties = GetNaga();
                    break;
                case CharacterRace.Centaur:
                    properties = GetCentaur();
                    break;
                case CharacterRace.Ailuran:
                    properties = GetAiluran();
                    break;
                case CharacterRace.Saytr:
                    properties = GetSaytr();
                    break;
                case CharacterRace.Vanara:
                    properties = GetVanara();
                    break;
                case CharacterRace.Aarakocra:
                    properties = GetAarakocra();
                    break;
                case CharacterRace.Adlet:
                    properties = GetAdlet();
                    break;
                case CharacterRace.Erymanthian:
                    properties = GetErymanthian();
                    break;

            }

            HumanRPG character = new HumanRPG(name, race, skills, properties, deck);

            return character;
        }

        private static CharacterProperties GetLapine()
        {
            CharacterProperties properties = new CharacterProperties();

            properties.Strength = 2;
            properties.Intellect = 10;
            properties.Agility = 6;
            properties.Dexterity = 8;
            properties.Endurance = 4;
            properties.Concentration = 12;
            properties.Speed = 14;
            properties.Haste = 16;
            properties.Armor = 0;
            properties.Resistance = 0;

            return properties;
        }

        private static CharacterProperties GetMinotaur()
        {
            CharacterProperties properties = new CharacterProperties();

            properties.Strength = 14;
            properties.Intellect = 2;
            properties.Agility = 8;
            properties.Dexterity = 16;
            properties.Endurance = 12;
            properties.Concentration = 4;
            properties.Speed = 10;
            properties.Haste = 6;
            properties.Armor = 0;
            properties.Resistance = 0;

            return properties;
        }

        private static CharacterProperties GetDraconian()
        {
            CharacterProperties properties = new CharacterProperties();

            properties.Strength = 16;
            properties.Intellect = 12;
            properties.Agility = 6;
            properties.Dexterity = 8;
            properties.Endurance = 14;
            properties.Concentration = 10;
            properties.Speed = 4;
            properties.Haste = 2;
            properties.Armor = 0;
            properties.Resistance = 0;

            return properties;
        }

        private static CharacterProperties GetMausian()
        {
            CharacterProperties properties = new CharacterProperties();

            properties.Strength = 2;
            properties.Intellect = 8;
            properties.Agility = 10;
            properties.Dexterity = 12;
            properties.Endurance = 4;
            properties.Concentration = 6;
            properties.Speed = 16;
            properties.Haste = 14;
            properties.Armor = 0;
            properties.Resistance = 0;

            return properties;
        }

        private static CharacterProperties GetNaga()
        {
            CharacterProperties properties = new CharacterProperties();

            properties.Strength = 2;
            properties.Intellect = 8;
            properties.Agility = 12;
            properties.Dexterity = 16;
            properties.Endurance = 6;
            properties.Concentration = 10;
            properties.Speed = 14;
            properties.Haste = 4;
            properties.Armor = 0;
            properties.Resistance = 0;

            return properties;
        }

        private static CharacterProperties GetCentaur()
        {
            CharacterProperties properties = new CharacterProperties();

            properties.Strength = 12;
            properties.Intellect = 10;
            properties.Agility = 6;
            properties.Dexterity = 2;
            properties.Endurance = 14;
            properties.Concentration = 8;
            properties.Speed = 16;
            properties.Haste = 4;
            properties.Armor = 0;
            properties.Resistance = 0;

            return properties;
        }

        private static CharacterProperties GetAiluran()
        {
            CharacterProperties properties = new CharacterProperties();

            properties.Strength = 14;
            properties.Intellect = 4;
            properties.Agility = 16;
            properties.Dexterity = 12;
            properties.Endurance = 10;
            properties.Concentration = 2;
            properties.Speed = 8;
            properties.Haste = 6;
            properties.Armor = 0;
            properties.Resistance = 0;

            return properties;
        }

        private static CharacterProperties GetSaytr()
        {
            CharacterProperties properties = new CharacterProperties();

            properties.Strength = 2;
            properties.Intellect = 14;
            properties.Agility = 4;
            properties.Dexterity = 8;
            properties.Endurance = 6;
            properties.Concentration = 16;
            properties.Speed = 12;
            properties.Haste = 10;
            properties.Armor = 0;
            properties.Resistance = 0;

            return properties;
        }

        private static CharacterProperties GetVanara()
        {
            CharacterProperties properties = new CharacterProperties();

            properties.Strength = 4;
            properties.Intellect = 14;
            properties.Agility = 12;
            properties.Dexterity = 16;
            properties.Endurance = 8;
            properties.Concentration = 10;
            properties.Speed = 2;
            properties.Haste = 6;
            properties.Armor = 0;
            properties.Resistance = 0;

            return properties;
        }

        private static CharacterProperties GetAarakocra()
        {
            CharacterProperties properties = new CharacterProperties();

            properties.Strength = 4;
            properties.Intellect = 16;
            properties.Agility = 10;
            properties.Dexterity = 12;
            properties.Endurance = 8;
            properties.Concentration = 14;
            properties.Speed = 6;
            properties.Haste = 2;
            properties.Armor = 0;
            properties.Resistance = 0;

            return properties;
        }

        private static CharacterProperties GetAdlet()
        {
            CharacterProperties properties = new CharacterProperties();

            properties.Strength = 9;
            properties.Intellect = 9;
            properties.Agility = 9;
            properties.Dexterity = 9;
            properties.Endurance = 9;
            properties.Concentration = 9;
            properties.Speed = 9;
            properties.Haste = 9;
            properties.Armor = 0;
            properties.Resistance = 0;

            return properties;
        }

        private static CharacterProperties GetErymanthian()
        {
            CharacterProperties properties = new CharacterProperties();

            properties.Strength = 14;
            properties.Intellect = 2;
            properties.Agility = 12;
            properties.Dexterity = 10;
            properties.Endurance = 16;
            properties.Concentration = 4;
            properties.Speed = 8;
            properties.Haste = 6;
            properties.Armor = 0;
            properties.Resistance = 0;

            return properties;
        }

    }
}
