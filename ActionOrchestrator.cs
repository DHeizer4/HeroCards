using Cards_Games.Enumerations;
using Cards_Games.Models;
using Cards_Games.Players;
using System.Collections.Generic;
using System.Linq;
using static Cards_Games.Enumerations.CardResourceEnum;
using static Cards_Games.Enumerations.StatusEnumeration;
using static System.Net.Mime.MediaTypeNames;

namespace Cards_Games
{
    class ActionOrchestrator
    {

        //This whole function needs to be rewritten for new card structure
        public static List<IRPGPlayer> ExecuteActions(List<RPGAction> timeLine, List<IRPGPlayer> players, int time)
        {
            List<string> linesOfDialog = new List<string>();

            // Do any actions/Cards needs to be exectued
            List<RPGAction> actionsToBeExecuted = CheckForAction(timeLine, players, time);

            //Execute Buffs / debuffs
            foreach (var action in actionsToBeExecuted)
            {
               ApplyBuffs(actionsToBeExecuted, players, linesOfDialog);
            }

            //Execute dmg actions
            foreach (var action in actionsToBeExecuted)
            {
                ApplyDamage(actionsToBeExecuted, players, linesOfDialog);
            }



            //List<string> linesOfDialog = new List<string>();

            //foreach (RPGAction action in actions)
            //{
            //    string dialog = $"{action.Actor.Name} {action.Card.Phrase} {action.ActedUpon.Name}";
            //    linesOfDialog.Add(dialog);

            //    action.ActedUpon.Health = action.ActedUpon.Health - action.Card.Attack;
            //    if (action.Card.Duration > 1)
            //    {
            //        for (int x = 1; x <= action.Card.Duration; x++)
            //        {
            //            RPGCard durationCard = new RPGCard(action.Card.CardType, action.Card.Level, action.Card.Name + " effect", CardResource.Time, 0, action.Card.Attack, 0, 0, action.Card.AttackType, action.Card.Target, action.Card.Phrase + " continues on ");
            //            _TimeLine.Add(new RPGAction(action.Actor, action.ActedUpon, false, durationCard, x, _Turn));
            //        }
            //    }
            //}

            Display.SimpleDialogBox(linesOfDialog);

            return players;
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

        public static void ApplyBuffs(List<RPGAction> ActionsToBeExecuted, List<IRPGPlayer> players, List<string> linesOfDialog)
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
                                player.Statuses.Add(status);
                                linesOfDialog.Add($"{action.Actor.Name} applies {status.StatusType.ToString()} to {action.ActedUpon.Name}");
                            }
                        }
                    }
                    else if (statusEffect.Target == TargetEnum.Target.Self)
                    {
                        foreach (IRPGPlayer player in players)
                        {
                            if (action.Actor == player)
                            {
                                player.Statuses.Add(status);
                                linesOfDialog.Add($"{action.Actor.Name} applies {status.StatusType.ToString()} to {action.ActedUpon.Name}");
                            }
                        }
                    }
                    else if (statusEffect.Target == TargetEnum.Target.AllEnemys)
                    {
                        foreach (IRPGPlayer player in players)
                        {
                            if (action.Actor.Team != player.Team)
                            {
                                player.Statuses.Add(status);
                                linesOfDialog.Add($"{action.Actor.Name} applies {status.StatusType.ToString()} to {action.ActedUpon.Name}");
                            }
                        }
                    }
                    else if (statusEffect.Target == TargetEnum.Target.Party)
                    {
                        foreach (IRPGPlayer player in players)
                        {
                            if (action.Actor.Team == player.Team)
                            {
                                player.Statuses.Add(status);
                                linesOfDialog.Add($"{action.Actor.Name} applies {status.StatusType.ToString()} to {action.ActedUpon.Name}");
                            }
                        }
                    }
                    else if (statusEffect.Target == TargetEnum.Target.All)
                    {
                        foreach (IRPGPlayer player in players)
                        {
                            player.Statuses.Add(status);
                            linesOfDialog.Add($"{action.Actor.Name} applies {status.StatusType.ToString()} to {action.ActedUpon.Name}");
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

        public static void ApplyDamage(List<RPGAction> ActionsToBeExecuted, List<IRPGPlayer> players, List<string> linesOfDialog)
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
                    else if (damageEffect.Target == TargetEnum.Target.Self)
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

                    foreach (IRPGPlayer player in filteredPlayers)
                    {
                        if(!player.Statuses.Any(s => s.StatusType == StatusEnum.Death))
                        {
                            if (damageEffect.Resource == CardResource.Health)
                            {
                                player.Health = player.Health - damageEffect.Amount;
                            }
                            else if (damageEffect.Resource == CardResource.Mana)
                            {
                                int adjustedResource = player.Mana - damageEffect.Amount;
                                player.Mana = adjustedResource < 0 ? 0 : adjustedResource;
                            }
                            else if (damageEffect.Resource == CardResource.Time)
                            {
                                int adjustedResource = player.Time - damageEffect.Amount;
                                player.Time = adjustedResource < 0 ? 0 : adjustedResource;
                            }
                        }

                    }

                }

                







            }
        }




    }
}
