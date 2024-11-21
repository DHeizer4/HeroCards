﻿using Cards_Games.Models;
using static Cards_Games.Enumerations.StatusEnumeration;

namespace Cards_Games.Players.PlayerUtilities
{
    class PlayerProperty
    {
        public static CharacterProperties GetCharacterProperties(IRPGPlayer player)
        {
            int strengthBonus = 0;
            double strengthPercentBonus = 1.00;
            int intellegenceBonus = 0;
            double intellegencePercentBonus = 1.00;
            int agilityBonus = 0;
            double agilityPercentBonus = 1.00;
            int dexterityBonus = 0;
            double dexterityPercentBonus = 1.00;
            int speedBonus = 0;
            double speedPercentBonus = 1.00;
            int hasteBonus = 0;
            double hastePercentBonus = 1.00;

            foreach (Status status in player.Statuses)
            {
                switch (status.StatusType)
                {
                    case StatusEnum.Strengthen:
                        if (status.IsPercent)
                        {
                            strengthPercentBonus = status.Amount;
                        }
                        else
                        {
                            strengthBonus = status.Amount;
                        }
                        break;
                    case StatusEnum.Enlightened:
                        if (status.IsPercent)
                        {
                            intellegencePercentBonus = status.Amount;
                        }
                        else
                        {
                            intellegenceBonus = status.Amount;
                        }
                        break;
                    case StatusEnum.Agile:
                        if (status.IsPercent)
                        {
                            agilityPercentBonus = status.Amount;
                        }
                        else
                        {
                            agilityBonus = status.Amount;
                        }
                        break;
                    case StatusEnum.Nimble:
                        if (status.IsPercent)
                        {
                            dexterityPercentBonus = status.Amount;
                        }
                        else
                        {
                            dexterityBonus = status.Amount;
                        }
                        break;
                    case StatusEnum.Acclerate:
                        if (status.IsPercent)
                        {
                            speedPercentBonus = status.Amount;
                        }
                        else
                        {
                            speedBonus = status.Amount;
                        }
                        break;
                    case StatusEnum.Quickened:
                        if (status.IsPercent)
                        {
                            hastePercentBonus = status.Amount;
                        }
                        else
                        {
                            hasteBonus = status.Amount;
                        }
                        break;
                }
            }

            CharacterProperties properties = new CharacterProperties()
            {
                Strength = ((player.Strength + strengthBonus) * strengthPercentBonus) < 0 ? 0 : (player.Strength + strengthBonus) * strengthPercentBonus,
                Intellect = ((player.Intellect + intellegenceBonus) * intellegencePercentBonus) < 0 ? 0 : (player.Intellect + intellegenceBonus) * intellegencePercentBonus,
                Agility = ((player.Agility + agilityBonus) * agilityPercentBonus) < 0 ? 0 : (player.Agility + agilityBonus) * agilityPercentBonus,
                Dexterity = ((player.Dexterity + dexterityBonus) * dexterityPercentBonus) < 0 ? 0 : (player.Dexterity + dexterityBonus) * dexterityPercentBonus,
                Endurance = player.Endurance,
                Concentration = player.Concentrate,
                Speed = ((player.Speed + speedBonus) * speedPercentBonus) < 0 ? 0 : (player.Speed + speedBonus) * speedPercentBonus,
                Haste = ((player.Haste + hasteBonus) * hastePercentBonus) < 0 ? 0 : (player.Haste + hasteBonus) * hastePercentBonus,
                Armor = 0,
                Resistance = 0
            };

            return properties;
        }

        public static int GetModifiedDamage(IRPGPlayer player, DamageEffect damageeffect)
        {
            CharacterProperties properties = GetCharacterProperties(player);
           
            double modifiedDamage = 0;

            if(damageeffect.AttackType == Enumerations.AttackTypeEnum.AttackType.Bludgeon) 
            {
                modifiedDamage =  (damageeffect.Amount * (1 + (properties.Strength / 100)));
            }
            else if (damageeffect.AttackType == Enumerations.AttackTypeEnum.AttackType.Slashing)
            {
                modifiedDamage = (damageeffect.Amount * (1 + (properties.Agility / 100)));
            }
            else
            {
                modifiedDamage = (damageeffect.Amount * (1 + (properties.Intellect / 100)));
            }
            
            modifiedDamage = PlayerBuff.ResolveEnrageBuff(player, modifiedDamage);

            return (int)modifiedDamage;
        }

        public static int DoDamageToPlayer(IRPGPlayer actedUpon, DamageEffect damageEffect, int modifiedDamageAmt)
        {
            int startingHealth = actedUpon.Health;
            modifiedDamageAmt = ResolveShield(actedUpon, modifiedDamageAmt);

            actedUpon.Health -= modifiedDamageAmt;

            if (actedUpon.Health > actedUpon.MaxHealth)
            {
                actedUpon.Health = actedUpon.MaxHealth;
            }

            return startingHealth - actedUpon.Health;
        }

        public static int ResolveShield(IRPGPlayer player, int damageAmount)
        {
            int postShieldDamage = damageAmount - player.Shield;
            
            if (postShieldDamage >= 0)
            {
                player.Shield = 0;
            }
            else if (postShieldDamage < 0)
            {
                player.Shield = -1 * postShieldDamage;
                postShieldDamage = 0;
            }

            return postShieldDamage;
        }

    }
}
