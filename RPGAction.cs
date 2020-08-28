using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Cards_Games
{
   
    public enum Stat {Time, Health, Mana, Weapon, Concentrate, Armor, Block, MagicShield }
    
    class RPGAction
    {
        public IRPGPlayer Actor { get; set; }
        public IRPGPlayer ActedUpon { get; set; }
        public bool Original { get; set; }
        public RPGCard Card { get; set; }
        public int When { get; set; }

        public RPGAction(IRPGPlayer aActor, IRPGPlayer aTarget, bool orgin, RPGCard aCard, int when)
        {
            Actor = aActor;
            ActedUpon = aTarget;
            Original = orgin;
            Card = aCard;
            When = when;
        }

        public RPGAction(IRPGPlayer aActor, IRPGPlayer aTarget, bool orgin, RPGCard aCard)
        {
            Actor = aActor;
            ActedUpon = aTarget;
            Original = orgin;
            Card = aCard;
            When = aCard.Speed;
        }

        public static List<RPGAction> ConvertCardToAction(RPGCard card, IRPGPlayer activePlayer ,List<IRPGPlayer> allPlayers)
        {
            List<RPGAction> playerActions = new List<RPGAction>();
            switch (card.Target)
            {
                case Target.All:
                    playerActions = AllTargets(card, activePlayer, allPlayers);
                    break;
                case Target.AllEnemys:
                    playerActions = AllEnemies(card, activePlayer, allPlayers);
                    break;
                case Target.Party:
                    playerActions = AllAllies(card, activePlayer, allPlayers);
                    break;
                case Target.Enemy:
                    playerActions = EnemyTarget(card, activePlayer, allPlayers);
                    break;
                case Target.Ally:
                    playerActions = AllyTarget(card, activePlayer, allPlayers);
                    break;
                default:  // Default target is Target.Self
                    playerActions.Add(new RPGAction(activePlayer, activePlayer, true, card));
                    break;
            }
            return playerActions;
        }

        public static List<RPGAction> AllyTarget(RPGCard card, IRPGPlayer activePlayer, List<IRPGPlayer> allPlayers)
        {
            List<RPGAction> playerActions = new List<RPGAction>();
            List<IRPGPlayer> allies = new List<IRPGPlayer>();
            foreach (IRPGPlayer player in allPlayers)
            {
                if (player.Team == activePlayer.Team)
                {
                    allies.Add(player);
                }
            }
            IRPGPlayer target = activePlayer.GetTarget(allies);
            playerActions.Add(new RPGAction(activePlayer, target, true, card));
            return playerActions;
        }

        public static List<RPGAction> EnemyTarget(RPGCard card, IRPGPlayer activePlayer, List<IRPGPlayer> allPlayers)
        {
            List<RPGAction> playerActions = new List<RPGAction>();
            List<IRPGPlayer> enemies = new List<IRPGPlayer>();
            foreach (IRPGPlayer player in allPlayers)
            {
                if (player.Team != activePlayer.Team)
                {
                    enemies.Add(player);
                }
            }
            IRPGPlayer target = activePlayer.GetTarget(enemies);
            playerActions.Add(new RPGAction(activePlayer, target, true, card));
            return playerActions;
        }

        public static List<RPGAction> AllTargets(RPGCard card, IRPGPlayer activePlayer, List<IRPGPlayer> allPlayers)
        {
            List<RPGAction> playerActions = new List<RPGAction>();
            foreach (IRPGPlayer player in allPlayers)
            {
                playerActions.Add(new RPGAction(activePlayer, player, true, card));
            }
            return playerActions;
        }

        public static List<RPGAction> AllEnemies(RPGCard card, IRPGPlayer activePlayer, List<IRPGPlayer> allPlayers)
        {
            List<RPGAction> playerActions = new List<RPGAction>();
            foreach (IRPGPlayer player in allPlayers)
            {
                if (player.Team != activePlayer.Team)
                {
                    playerActions.Add(new RPGAction(activePlayer, player, true, card));
                }
            }
            return playerActions;
        }

        public static List<RPGAction> AllAllies(RPGCard card, IRPGPlayer activePlayer, List<IRPGPlayer> allPlayers)
        {
            List<RPGAction> playerActions = new List<RPGAction>();
            List<IRPGPlayer> allies = new List<IRPGPlayer>();
            foreach (IRPGPlayer player in allPlayers)
            {
                if (player.Team == activePlayer.Team)
                {
                    playerActions.Add(new RPGAction(activePlayer, player, true, card));
                }
            }
            return playerActions;
        }

    }


}
