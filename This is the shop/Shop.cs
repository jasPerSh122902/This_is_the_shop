using System;
using System.Collections.Generic;
using System.Text;

namespace This_is_the_shop
{
    class Shop
    {
        private Item[] _inventory;
        public int _gold;

 
    public Shop()
        {
            _gold = 1000;
            _inventory = new Item[4];
        }
       public  Shop(Item[] items)
       {
            _gold = 1000;

            _inventory = items;
       }


        //I do not get what this is meant to do
        public bool Sell(Player player, int itemIndex, int playerIndex)

        {
            Item itemBuy = _inventory[itemIndex];

            if (player.Buy(itemBuy, playerIndex))
            {
                _gold += itemBuy.Gold;
                return true;
            }
            return false;
        }


    }
}
