using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Cards_Games
{
    class Battle
    {
        private static List<RPGAction> battleActions = new List<RPGAction>();

        public static void Start(List<IRPGPlayer> players)
        {
            battleActions.Clear();
            Console.SetWindowSize(175, 50);
            // Get battle doll list once implemented
            players = Battle.SpeedSort(players);
            GetOpeningHands(players);
            OpeningActions(players);
            Display.BattleActionGrid(battleActions,20,20);
            
            // Battle happens here should be in a loop
            // For testing doing 10 rounds of battle
            for(int x=0; x<10; x++)
            {
                Display.Players(players);
                Battle.GetPlayerActions(players);
                players = Battle.CheckForAction(players);
                Battle.BattleMovesOn();
                Display.Delay(20,0);
                Display.BattleActionGrid(battleActions, 20, 20);
            }


        }

        public static void BattleMovesOn()
        {
            foreach(RPGAction action in battleActions)
            {
                action.When = action.When - 1;
            }
        }

        public static List<IRPGPlayer> CheckForAction(List<IRPGPlayer> players) 
        {
            List<RPGAction> currentAction = new List<RPGAction>();
            foreach (RPGAction action in battleActions)
            {
                if (action.When == 0)
                {
                    currentAction.Add(action);
                }
            }
            
            ExecuteActions(currentAction, players);
            return players;
        } 

        public static List<IRPGPlayer> ExecuteActions(List<RPGAction> actions, List<IRPGPlayer> players)
        {
            Display.ActionHappens(actions, 20, 35);
            foreach(RPGAction action in actions)
            {
                action.ActedUpon.Health = action.ActedUpon.Health - action.Card.Attack;
                if (action.Card.Duration > 1)
                {
                    for (int x=1; x<=action.Card.Duration; x++)
                    {
                        RPGCard durationCard = new RPGCard(action.Card.CardType, action.Card.Level, action.Card.Name + " effect", CardResource.Time, 0, action.Card.Attack, 0, 0, action.Card.AttackType, action.Card.Target, action.Card.Phrase + " continues on ");
                        battleActions.Add(new RPGAction(action.Actor, action.ActedUpon, false, durationCard, x));
                    }
                }
            }
            return players;
        }

        public static void GetAction(IRPGPlayer player, List<IRPGPlayer> players)
        {
            RPGCard playerCard = player.PlayCard();
            List<RPGAction> playerAction = RPGAction.ConvertCardToAction(playerCard, player, players);
            for (int i = 0; i < playerAction.Count; i++)
            {
                battleActions.Add(playerAction[i]);
            }
        }

        public static void GetOpeningHands(List<IRPGPlayer> players)
        {
            foreach (IRPGPlayer player in players)
            {
                player.OpeningHand();
            }
        }

        public static void GetPlayerActions(List<IRPGPlayer> players)
        {
            bool anyaction = false;
            foreach (IRPGPlayer player in players)
            {
                anyaction = Battle.PlayerActionCheck(player);
                if (!anyaction)
                {
                    Battle.GetAction(player, players);
                }
            }
        }

        public static void OpeningActions(List<IRPGPlayer> players)
        {
            foreach (IRPGPlayer player in players)
            {
                RPGCard playerCard = player.PlayCard();
                List<RPGAction> playerAction = RPGAction.ConvertCardToAction(playerCard, player, players);
                for (int i = 0; i < playerAction.Count; i++)
                {
                    battleActions.Add(playerAction[i]);
                }
            }
        }

        public static bool PlayerActionCheck(IRPGPlayer player)
        {
            foreach (RPGAction action in battleActions)
            {
                if (action.Actor == player)
                {
                    return true;
                }
            }
            return false;
        }

        public static List<IRPGPlayer> SpeedSort (List<IRPGPlayer> players)
        {
            players.Sort((x, y) => x.Speed.CompareTo(y.Speed));
            return players;
        }







    }
}
