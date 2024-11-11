using Cards_Games.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cards_Games.Players.PlayerUtilities
{
    class PlayerProperty
    {
        public static int GetStrength(IRPGPlayer player)
        {
            int strength = player.Strength;

            return strength;
        }

        public static int GetIntellect(IRPGPlayer player)
        {
            int intellect = player.Intellect;

            return intellect;
        }

        public static int GetAgility(IRPGPlayer player)
        {
            int agility = player.Agility;

            return agility;
        }

        public static int GetDexterity(IRPGPlayer player)
        {
            int dexterity = player.Dexterity;

            return dexterity;
        }

        public static int GetConcentration(IRPGPlayer player)
        {
            int concentration = player.Concentrate;

            return concentration;
        }

        public static int GetArmor(IRPGPlayer player)
        {
            int armour = player.Armor;

            return armour;
        }

        public static int GetBlock(IRPGPlayer player)
        {
            int block = player.Block;

            return block;
        }

        public static int GetSpeed(IRPGPlayer player)
        {
            int speed = player.Speed;

            return speed;
        }

        public static int GetModifiedDamage(IRPGPlayer player, DamageEffect damageeffect)
        {


            return 0;
        }

        public static int DoDamageToPlayer(IRPGPlayer actedUpon, DamageEffect damageEffect, int modifiedDamageAmt)
        {
            int startingHealth = actedUpon.Health;
            actedUpon.Health -= modifiedDamageAmt;
            
            if (actedUpon.Health > actedUpon.MaxHealth) 
            {
                actedUpon.Health = actedUpon.MaxHealth; 
            }

            return startingHealth - actedUpon.Health;
        }

    }
}
