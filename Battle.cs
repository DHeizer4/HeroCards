using System;
using System.Collections.Generic;
using System.Text;

namespace Cards_Games
{
    class Battle
    {
        private static List<RPGAction> battleActions = new List<RPGAction>();

        public static void Start(List<IRPGPlayer> players)
        {
            battleActions.Clear();

            // Get battle doll list once implemented
            players = Battle.SpeedSort(players);
            OpeningActions(players);


            // Battle happens here should be in a loop
            for (int turn = 1; turn < 4; turn++)
            {
                Display.BattleTurn(turn);
            }

        }

        public static List<IRPGPlayer> SpeedSort (List<IRPGPlayer> players)
        {
            players.Sort((x, y) => x.Speed.CompareTo(y.Speed));
            return players;
        }

        public static void OpeningActions(List<IRPGPlayer> players)
        {
            foreach (IRPGPlayer player in players)
            {
                RPGCard playerCard = player.PlayCard();
                List<RPGAction> playerAction = RPGAction.ConvertCardToAction(playerCard, player, players);
                for (int i=0; i < playerAction.Count; i++)
                {
                    battleActions.Add(playerAction[i]);
                }
            }
        }




    }
}
