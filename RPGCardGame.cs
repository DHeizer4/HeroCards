using System;
using System.Collections.Generic;

namespace Cards_Games
{
    class RPGCardGame
    {
        public void StartGame(IRPGPlayer player1)
        {
            List<IRPGPlayer> players = new List<IRPGPlayer>();
            HumanRPG RPG1 = new HumanRPG(player1.Name, 1);
            players.Add(RPG1);
            CompTopRPG comp1 = new CompTopRPG("That guy", 2);
            players.Add(comp1);
            CompTopRPG comp2 = new CompTopRPG("Goblin 1", 2);
            CompTopRPG comp3 = new CompTopRPG("Goblin 2", 2);
            CompTopRPG comp4 = new CompTopRPG("Helper", 1);
            players.Add(comp2);
            players.Add(comp3);
            players.Add(comp4);
            Battle.Start(players);
        }

    }


}
