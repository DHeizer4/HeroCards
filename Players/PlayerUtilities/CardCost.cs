using Cards_Games.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static Cards_Games.Enumerations.CardResourceEnum;

namespace Cards_Games.Players.PlayerUtilities
{
    class CardCost
    {
        public static bool CanAfford(IRPGPlayer player, RPGCard card)
        {
            bool canAfford = true;

            foreach(Cost cost in card.Costs)
            {
                if (cost.Resource == CardResource.Mana && player.Mana < cost.Amount)
                {
                    canAfford = false;
                    break;
                }
                else if (cost.Resource == CardResource.Health &&  player.Health < cost.Amount)
                {
                    canAfford = false;
                    break;
                } 
                else if (cost.Resource == CardResource.Time && player.Time < cost.Amount)
                {
                    canAfford = false;
                    break;
                }
            }

            return canAfford;
        }

        public static void PayCosts(IRPGPlayer player, RPGCard card)
        {
            foreach (Cost cost in card.Costs)
            {
                if (cost.Resource == CardResource.Mana)
                {
                    player.Mana -= cost.Amount;
                }
                else if (cost.Resource == CardResource.Health)
                {
                    player.Health -= cost.Amount;
                }
                else if (cost.Resource == CardResource.Time)
                {
                    player.Time -= cost.Amount;
                }
            }
        }


    }
}
