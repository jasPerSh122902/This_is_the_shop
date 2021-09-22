using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace This_is_the_shop
{


    class Player
    {
        private Shop _gold;
        private Item[] _items;
        private Item _inventory;
      

 

        public void Buy(Item itemBuy, int Item)
        {
            //this keeps tabs on the item and the index(or were it is at in the index)...
            if (_inventory = _items.Length)
                
            _inventory = _items;
            //then sets item

        }

        public Player(int Gold)
        {
            _items = new Item[0];
            _inventory.Name = "Nothing";
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

        public override void Save(StreamWriter writer)
        {
            writer.WriteLine(_job);
            base.Save(writer);
            writer.WriteLine(_inventory);
        }

        public override bool Load(StreamReader reader)
        {
            //if the base loading function dos not load return false..
            if (!base.Load(reader))
                return false;

            //if the loading function works then gos to CurrentItemIndex if that dos not load return false...
            if (!int.TryParse(reader.ReadLine(), out _inventory)
                return false;


            //then return the Item Index wether the top two were successful.
            //This one returns wether the item was equipped or not.
            return TryEquipItem(_inventory);
        }

    }
}




    

