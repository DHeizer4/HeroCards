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
            
            Battle.Start(players);
        }

    }


}
