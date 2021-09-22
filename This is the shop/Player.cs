using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace This_is_the_shop
{


    class Player
    {
        private string _player = "nothing";
        private int _gold;
        public int Gold()
        {
 
                return _gold;
            
        }
        private Item[] _items;
        private Item[] _inventory;
        public Item[] Currentinventory()
        {
            return _inventory;
        }
      

 

        public bool Buy(Item itemBuy, int Item)
        {
            if(_gold >= itemBuy.Gold)
            {
                _gold -= itemBuy.Gold;

                _inventory[Item] = itemBuy;
                return true;
            }
            return false;
        }

        public Player()
        {
            _gold = 1000;
            _inventory = new Item[4];
            
        }



        public string[] GetItemNames()
        {
            string[] itemNames = new string[_items.Length];

            for (int i = 0; i < _items.Length; i++)
            {
                itemNames[i] = _items[i].Name;
            }

            return itemNames;
        }


    }
}




    

