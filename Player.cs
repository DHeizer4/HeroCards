using System;
using System.Collections.Generic;
using System.Text;

namespace Cards_Games
{
    class Player
    {
        private string _name;
        private int _gold;
        private int _wins;
        const int startingGold = 100;

        public string Name { get; }
        public int Gold { get; set; }
        public int Wins { get; }

        public Player(string input)
        {
            _name = input;
            _gold = startingGold;
            _wins = 0;
        }

        public virtual void DisplayPlayer()
        {
            Console.WriteLine($"Player: {_name}  Gold: {_gold}");
        }

        public void AddWin()
        {
            _wins++;
        }

    }


    

}
