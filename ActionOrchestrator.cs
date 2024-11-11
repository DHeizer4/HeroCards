using Cards_Games.Enumerations;
using Cards_Games.Models;
using Cards_Games.Players;
using Cards_Games.Players.PlayerUtilities;
using System.Collections.Generic;
using System.Linq;
using static Cards_Games.Enumerations.CardResourceEnum;
using static Cards_Games.Enumerations.StatusEnumeration;

namespace Cards_Games
{
    class ActionOrchestrator
    {

        //This whole function needs to be rewritten for new card structure
        public static void ExecuteActions(List<RPGAction> timeLine, List<IRPGPlayer> players, int time, List<string> turnLog)
        {
            // Do any actions/Cards needs to be exectued
            List<RPGAction> actionsToBeExecuted = CheckForAction(timeLine, players, time);

            //Execute Buffs / debuffs
            ApplyBuffs(actionsToBeExecuted, players, turnLog);

            //Execute dmg actions
            ApplyDamage(actionsToBeExecuted, players, turnLog);

//            Display.SimpleDialogBox(turnLog);
        }

        // Old function from Battel orchestrator
        public static List<RPGAction> CheckForAction(List<RPGAction> timeLine, List<IRPGPlayer> players, int turnNumber)
        {
            List<RPGAction> currentActions = new List<RPGAction>();
            foreach (RPGAction action in timeLine)
            {
                if (action.When == turnNumber)
                {
                    currentActions.Add(action);
                }
            }

            return currentActions;
        }

        public static void ApplyBuffs(List<RPGAction> ActionsToBeExecuted, List<IRPGPlayer> players, List<string> turnLog)
        {
            foreach (var action in ActionsToBeExecuted)
            {
                foreach (StatusEffect statusEffect in action.Card.Effects)
                {
                    Status status = ConvertStatusEffectToStatus(statusEffect);

                    if (statusEffect.Target == TargetEnum.Target.Ally || statusEffect.Target == Enumerations.TargetEnum.Target.Enemy)
                    {
                        foreach (IRPGPlayer player in players)
                        {
                            if (action.ActedUpon == player)
                            {
                                string dialog = PlayerBuff.ApplyStatusEffect(action.Actor.Name, player, status);
                                turnLog.Add(dialog);
                            }
                        }
                    }
                    else if (statusEffect.Target == TargetEnum.Target.Self)
                    {
                        foreach (IRPGPlayer player in players)
                        {
                            if (action.Actor == player)
                            {
                                string dialog = PlayerBuff.ApplyStatusEffect(action.Actor.Name, player, status);
                                turnLog.Add(dialog);
                            }
                        }
                    }
                    else if (statusEffect.Target == TargetEnum.Target.AllEnemys)
                    {
                        foreach (IRPGPlayer player in players)
                        {
                            if (action.Actor.Team != player.Team)
                            {
                                string dialog = PlayerBuff.ApplyStatusEffect(action.Actor.Name, player, status);
                                turnLog.Add(dialog);
                            }
                        }
                    }
                    else if (statusEffect.Target == TargetEnum.Target.Party)
                    {
                        foreach (IRPGPlayer player in players)
                        {
                            if (action.Actor.Team == player.Team)
                            {
                                string dialog = PlayerBuff.ApplyStatusEffect(action.Actor.Name, player, status);
                                turnLog.Add(dialog);
                            }
                        }
                    }
                    else if (statusEffect.Target == TargetEnum.Target.All)
                    {
                        foreach (IRPGPlayer player in players)
                        {
                            string dialog = PlayerBuff.ApplyStatusEffect(action.Actor.Name, player, status);
                            turnLog.Add(dialog);
                        }
                    }
                }
            }
        }


        public static Status ConvertStatusEffectToStatus(StatusEffect statusEffect)
        {
            Status status = new Status()
            {
                StatusType = statusEffect.StatusType,
                Amount = statusEffect.Amount,
                Duration = statusEffect.Duration,
                Interval = statusEffect.Interval,
                AttackType = statusEffect.AttackType,
                IsStackable = statusEffect.IsStackable,
                IsPercent = statusEffect.IsPercent
            };

            return status;
        }

        public static void ApplyDamage(List<RPGAction> ActionsToBeExecuted, List<IRPGPlayer> players, List<string> turnLog)
        {

            foreach (var action in ActionsToBeExecuted)
            {
                List<IRPGPlayer> filteredPlayers = new List<IRPGPlayer>();

                foreach (DamageEffect damageEffect in action.Card.DamageEffects)
                {
                    if (damageEffect.Target == TargetEnum.Target.Ally || damageEffect.Target == Enumerations.TargetEnum.Target.Enemy)
                    {
                        foreach (IRPGPlayer player in players)
                        {
                            if (action.ActedUpon == player)
                            {
                                filteredPlayers.Add(player);
                            }
                        }
                    }
                    else

                    if (damageEffect.Target == TargetEnum.Target.Self)
                    {
                        foreach (IRPGPlayer player in players)
                        {
                            if (action.Actor == player)
                            {
                                filteredPlayers.Add(player);
                            }
                        }
                    }
                    else if (damageEffect.Target == TargetEnum.Target.AllEnemys)
                    {
                        foreach (IRPGPlayer player in players)
                        {
                            if (action.Actor.Team != player.Team)
                            {
                                filteredPlayers.Add(player);
                            }
                        }
                    }
                    else if (damageEffect.Target == TargetEnum.Target.Party)
                    {
                        foreach (IRPGPlayer player in players)
                        {
                            if (action.Actor.Team == player.Team)
                            {
                                filteredPlayers.Add(player);
                            }
                        }
                    }
                    else if (damageEffect.Target == TargetEnum.Target.All)
                    {
                        foreach (IRPGPlayer player in players)
                        {
                            filteredPlayers.Add(player);
                        }
                    }

                    foreach (IRPGPlayer actedUpon in filteredPlayers)
                    {
                        if (!actedUpon.Statuses.Any(s => s.StatusType == StatusEnum.Death))
                        {
                            if (damageEffect.Resource == CardResource.Health)
                            {
                                int amt = PlayerProperty.DoDamageToPlayer(actedUpon, damageEffect, damageEffect.Amount);
                                string damageEvent = $"{action.Actor.Name} did {amt} {damageEffect.AttackType.ToString()} to {actedUpon.Name}";
                                turnLog.Add(damageEvent);
                            }
                            else if (damageEffect.Resource == CardResource.Mana)
                            {
                                int adjustedResource = actedUpon.Mana - damageEffect.Amount;
                                actedUpon.Mana = adjustedResource < 0 ? 0 : adjustedResource;

                                string manaEvent = $"{action.Actor.Name}'s {action.Card.Name} cuases {actedUpon.Name}'s mana to change to {actedUpon.Mana}";
                                turnLog.Add(manaEvent);
                            }
                            else if (damageEffect.Resource == CardResource.Time)
                            {
                                int adjustedResource = actedUpon.Time - damageEffect.Amount;
                                actedUpon.Time = adjustedResource < 0 ? 0 : adjustedResource;
                                string timeEvent = $"{action.Actor.Name}'s {action.Card.Name} cuases {actedUpon.Name}'s time to change to {actedUpon.Mana}";
                                turnLog.Add(timeEvent);
                            }
                        }

                    }

                }
            }

        }
    }
}
