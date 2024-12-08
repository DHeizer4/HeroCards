using Cards_Games.Cards;
using Cards_Games.Models;
using Cards_Games.Players;
using Cards_Games.Players.PlayerUtilities;
using Cards_Games.Players.StatusUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using static Cards_Games.Enumerations.TargetEnum;

namespace Cards_Games
{
    // This is a Wrapper that takes a card and wraps in the needed 
    // information to execute the card later on the timeline
    class RPGAction
    {
        public IRPGPlayer Actor { get; set; }
        public IRPGPlayer ActedUpon { get; set; }
        public bool Original { get; set; }  // Do I care if the wrapper is based on an original card
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

        public RPGAction(IRPGPlayer actor, IRPGPlayer actedUpon, bool orgin, RPGCard card, int turnNumber)
        {
            Actor = actor;
            ActedUpon = actedUpon;
            Original = orgin;
            Card = card;
            When = card.Speed + turnNumber;
        }

        public static string GetTarget(RPGCard card, IRPGPlayer activePlayer, List<IRPGPlayer> allPlayers, int turn, ref List<RPGAction> playerActions)
        {
            List<Target> targets = new List<Target>();
            int ally = 0;
            int enemy = 0;
            int allEnemies = 0;
            int allAllies = 0;
            int everyone = 0;
            int self = 0;
            int random = 0;
            string actedUpon = "Nobody";

            foreach (DamageEffect damageEffect in card.DamageEffects) 
            {
                targets.Add(damageEffect.Target);
            }

            foreach ( StatusEffect statusEffect in card.Effects )
            {
                targets.Add(statusEffect.Target);
            }

            foreach ( Target target in targets)
            {
                if (target == Target.Ally || target == Target.RandomAlly)
                {
                    ally++;
                }
                else if (target == Target.Enemy || target == Target.RandomEnemy)
                {
                    enemy++;
                }
                else if (target == Target.Self)
                {
                    self++;
                }
                else if (target == Target.Party)
                {
                    allAllies++;
                }
                else if (target == Target.AllEnemys)
                {
                    allEnemies++;
                }
                else if (target == Target.All)
                {
                    everyone++;
                }
                else if(target == Target.Random)
                {
                    random++;
                }
            }

            if(self > 0)
            {
                actedUpon = "him or herself ";
            }

            if(ally > 0 && enemy > 0) 
            {
                throw new Exception($"{card.Name} has a Enemy target and an Ally target specific targets this is not supported");
            }
            else if(enemy > 0)
            {
                playerActions = EnemyTarget(card, activePlayer, allPlayers, turn);
                if (actedUpon == "Nobody")
                {
                    actedUpon = $"{playerActions[0].ActedUpon.Name} ";
                }
                else
                {
                    actedUpon = actedUpon + $"{playerActions[0].ActedUpon.Name} ";
                }
            }
            else if(ally > 0)
            {
                playerActions = AllyTarget(card, activePlayer, allPlayers, turn);
                if (actedUpon == "Nobody")
                {
                    actedUpon = $"{playerActions[0].ActedUpon.Name} ";
                }
                else
                {
                    actedUpon = actedUpon + $"and {playerActions[0].ActedUpon.Name} ";
                }
            }
            else
            {
                playerActions = MultiTarget(card, activePlayer, turn);
            }

            if(everyone > 0 || (allEnemies > 0 && allAllies > 0))
            {
                actedUpon = "everyone ";
            }
            else if( allAllies > 0)
            {
                if (actedUpon == "Nobody")
                {
                    actedUpon = "his or her own team ";
                }
                else
                {
                    actedUpon = actedUpon + $" and his or her own team ";
                }
            }
            else if (allEnemies > 0)
            {
                if (actedUpon == "Nobody")
                {
                    actedUpon = "the enemy team ";
                }
                else
                {
                    actedUpon = actedUpon + $"and the enemy team ";
                }
            }

            return actedUpon;
        }

        public static List<RPGAction> AllyTarget(RPGCard card, IRPGPlayer activePlayer, List<IRPGPlayer> allPlayers, int turnNumber)
        {
            List<RPGAction> playerActions = new List<RPGAction>();
            List<IRPGPlayer> allies = new List<IRPGPlayer>();
            foreach (IRPGPlayer player in allPlayers)
            {
                if (player.Team == activePlayer.Team && !DeathUtil.IsPlayerDead(player))
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
                if (player.Team != activePlayer.Team && !DeathUtil.IsPlayerDead(player))
                {
                    enemies.Add(player);
                }
            }

            IRPGPlayer target = null;

            //if there is only one possible target do not prompt to choose a target
            if (enemies.Count > 1)
            {
                enemies = TauntingUtil.ResolveTaunting(enemies);
                target = activePlayer.GetTarget(enemies);
            }
            else
            {
                target = enemies[0];
            }
             
            playerActions.Add(new RPGAction(activePlayer, target, true, card, turnNumber));
            return playerActions;
        }

        public static List<RPGAction> MultiTarget(RPGCard card, IRPGPlayer activePlayer, int turnNumber)
        {
            List<RPGAction> playerActions = new List<RPGAction>
            {
                new RPGAction(activePlayer, null, true, card, turnNumber)
            };
            return playerActions;
        }

    }

}
