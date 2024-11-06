using Cards_Games.Players;
using System.Collections.Generic;
using static Cards_Games.Enumerations.CardResourceEnum;

namespace Cards_Games
{
    class ActionOrchestrator
    {

        //This whole function needs to be rewritten for new card structure
        public static List<IRPGPlayer> ExecuteActions(List<RPGAction> timeLine, List<IRPGPlayer> players, int time)
        {

            // Do any actions/Cards needs to be exectued
            

            //Execute Buffs / debuffs


            //Execute dmg actions



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

            //Display.SimpleDialogBox(linesOfDialog);

            return players;
        }

        // Old function from Battel orchestrator
        public static List<IRPGPlayer> CheckForAction(List<IRPGPlayer> players, int turnNumber)
        {
            List<RPGAction> currentAction = new List<RPGAction>();
            foreach (RPGAction action in timeLine)
            {
                if (action.When == turnNumber)
                {
                    currentAction.Add(action);
                }
            }

            ExecuteActions(currentAction, players);
            return players;
        }

        // Old function from Battel orchestrator
        public static List<IRPGPlayer> ExecuteActions(List<RPGAction> actions, List<IRPGPlayer> players)
        {
            List<string> linesOfDialog = new List<string>();

            foreach (RPGAction action in actions)
            {
                string dialog = $"{action.Actor.Name} {action.Card.Phrase} {action.ActedUpon.Name}";
                linesOfDialog.Add(dialog);

                action.ActedUpon.Health = action.ActedUpon.Health - action.Card.Attack;
                if (action.Card.Duration > 1)
                {
                    for (int x = 1; x <= action.Card.Duration; x++)
                    {
                        RPGCard durationCard = new RPGCard(action.Card.CardType, action.Card.Level, action.Card.Name + " effect", CardResource.Time, 0, action.Card.Attack, 0, 0, action.Card.AttackType, action.Card.Target, action.Card.Phrase + " continues on ");
                        _TimeLine.Add(new RPGAction(action.Actor, action.ActedUpon, false, durationCard, x, _Turn));
                    }
                }
            }

            Display.SimpleDialogBox(linesOfDialog);

            return players;
        }
    }
}
