using System;
using System.Collections.Generic;
using System.Text;
using static Cards_Games.Enumerations.CardResourceEnum;

namespace Cards_Games.Models
{
    public class Cost
    {
        // Cost represents a one time effect that is not refunded.
        // Cost must be able to be paid to use a card
        public CardResource Resource { get; set; }
        public int Amount { get; set; }
    }
}
