using Cards_Games.Players;
using System.Collections.Generic;
using static Cards_Games.Enumerations.TargetEnum;

namespace Cards_Games
{
    class RPGAction
    {
        public IRPGPlayer Actor { get; set; }
        public IRPGPlayer ActedUpon { get; set; }
        public bool Original { get; set; }
        public RPGCard Card { get; set; }
        public int When { get; set; }

        public RPGAction(IRPGPlayer aActor, IRPGPlayer aTarget, bool orgin, RPGCard aCard, int when, int turnNumber)
        {
            Actor = aActor;
            ActedUpon = aTarget;
            Original = orgin;
            Card = aCard;
            When = when + turnNumber;
        }

        public RPGAction(IRPGPlayer aActor, IRPGPlayer aTarget, bool orgin, RPGCard aCard, int turnNumber)
        {
            Actor = aActor;
            ActedUpon = aTarget;
            Original = orgin;
            Card = aCard;
            When = aCard.Speed + turnNumber;
        }

        public static List<RPGAction> ConvertCardToAction(RPGCard card, IRPGPlayer activePlayer, List<IRPGPlayer> allPlayers, int turn)
        {
            List<RPGAction> playerActions = new List<RPGAction>();
            switch (card.Target)
            {   //RandomTarget   ChainRandomTarget   ChainTarget (chance to jump to another target)
                case Target.All:
                    playerActions = AllTargets(card, activePlayer, allPlayers, turn);
                    break;
                case Target.AllEnemys:
                    playerActions = AllEnemies(card, activePlayer, allPlayers, turn);
                    break;
                case Target.Party:
                    playerActions = AllAllies(card, activePlayer, allPlayers, turn);
                    break;
                case Target.Enemy:
                    playerActions = EnemyTarget(card, activePlayer, allPlayers, turn);
                    break;
                case Target.Ally:
                    playerActions = AllyTarget(card, activePlayer, allPlayers, turn);
                    break;
                default:  // Default target is Target.Self
                    playerActions.Add(new RPGAction(activePlayer, activePlayer, true, card, turn));
                    break;
            }
            return playerActions;
        }

        public static List<RPGAction> AllyTarget(RPGCard card, IRPGPlayer activePlayer, List<IRPGPlayer> allPlayers, int turnNumber)
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

            IRPGPlayer target = null;

            //if there is only one possible target do not prompt to choose a target
            if (allies.Count > 1)
            {
                target = activePlayer.GetTarget(allies);
            }
            else
            {
                target = allies[0];
            }

            playerActions.Add(new RPGAction(activePlayer, target, true, card, turnNumber));
            return playerActions;
        }

        public static List<RPGAction> EnemyTarget(RPGCard card, IRPGPlayer activePlayer, List<IRPGPlayer> allPlayers, int turnNumber)
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

            IRPGPlayer target = null;

            //if there is only one possible target do not prompt to choose a target
            if (enemies.Count > 1)
            {
                target = activePlayer.GetTarget(enemies);
            }
            else
            {
                target = enemies[0];
            }
             
            playerActions.Add(new RPGAction(activePlayer, target, true, card, turnNumber));
            return playerActions;
        }

        public static List<RPGAction> AllTargets(RPGCard card, IRPGPlayer activePlayer, List<IRPGPlayer> allPlayers, int turnNumber)
        {
            List<RPGAction> playerActions = new List<RPGAction>();
            foreach (IRPGPlayer player in allPlayers)
            {
                playerActions.Add(new RPGAction(activePlayer, player, true, card, turnNumber));
            }
            return playerActions;
        }

        public static List<RPGAction> AllEnemies(RPGCard card, IRPGPlayer activePlayer, List<IRPGPlayer> allPlayers, int turnNumber)
        {
            List<RPGAction> playerActions = new List<RPGAction>();
            foreach (IRPGPlayer player in allPlayers)
            {
                if (player.Team != activePlayer.Team)
                {
                    playerActions.Add(new RPGAction(activePlayer, player, true, card, turnNumber));
                }
            }
            return playerActions;
        }

        public static List<RPGAction> AllAllies(RPGCard card, IRPGPlayer activePlayer, List<IRPGPlayer> allPlayers, int turnNumber)
        {
            List<RPGAction> playerActions = new List<RPGAction>();
            List<IRPGPlayer> allies = new List<IRPGPlayer>();
            foreach (IRPGPlayer player in allPlayers)
            {
                if (player.Team == activePlayer.Team)
                {
                    playerActions.Add(new RPGAction(activePlayer, player, true, card, turnNumber));
                }
            }
            return playerActions;
        }

    }


}
