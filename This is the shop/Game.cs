using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace This_is_the_shop
{
    public struct Item
    {
        public string Name;
        public float Gold;

    }

    public enum Scene
    {
        DISPLAYOPENINGMENU,
        STARTMENUFORSHOIP,
        GETSHOPMENUOPTIONS,
        

    }


    class Game
    {
        private bool _gameOver;
        private Player _player;
        private Shop _playerGold;
        private Scene _currentScene;
        private Shop _shop;
        private Item[] _items;
        public void Run()
        {

        }

        public void Start()
        {

        }

        public void Update()
        {

        }

       public int GetInput(string description, params string[] options)
       {
            string input = "";
            int inputReceived = -1;

            while (inputReceived == -1)
            {
                //Print options
                Console.WriteLine(description);
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + options[i]);
                }
                Console.Write("> ");

                //Get input from player
                input = Console.ReadLine();

                //If the player typed an int...
                if (int.TryParse(input, out inputReceived))
                {
                    //...decrement the input and check if it's within the bounds of the array
                    inputReceived--;
                    if (inputReceived < 0 || inputReceived >= options.Length)
                    {
                        //Set input received to be the default value
                        inputReceived = -1;
                        //Display error message
                        Console.WriteLine("Invalid Input");
                        Console.ReadKey(true);
                    }
                }
                //a error if the player put a word
                else
                {
                    //set the inputrecieved back to -1 to restart loop
                    inputReceived = -1;
                    Console.WriteLine("Invalid input");
                    Console.ReadKey(true);

                }

                Console.Clear();
            }
            return inputReceived;
        }

        public void InitializeItems()
        {
            Item bigGun = new Item { Name = "Big Gun", Gold = 15 };
            Item bigShield = new Item { Name = "Big Shield", Gold = 18 };

            //Raider items
            Item bigAxe = new Item { Name = "Big Axe ", Gold = 12 };
            Item forceShield = new Item { Name = "Force Shield ", Gold = 10 };

            _items = new Item[] { bigGun, bigShield, bigAxe, forceShield };
            _shop = new Shop(_items);
        }

        public void DisplayCurrentScene()
        {
            switch (_currentScene)
            {
                case Scene.DISPLAYOPENINGMENU:
                    DisplayOpeningMenu();
                    
                    break;
                case Scene.STARTMENUFORSHOIP:
                    DisplayShopMenu();
                    
                    break;
                case Scene.GETSHOPMENUOPTIONS:
                    GetShopMenuOptions();
                    
                   
                    break;
            }
        }

        public void DisplayOpeningMenu()
        {
            int choice = GetInput("Welcom to the game do you want to", " Start ", "or leave ");

            if (choice == 0)
            {
                _currentScene = Scene.STARTMENUFORSHOIP;
            }
            else if(choice == 1)
            {
                _gameOver = true;
            }
        }

        public void DisplayShopMenu()
        {

            int choice = GetInput("ow! What you want in the shop", GetShopMenuOptions(!int.TryParse(Console.ReadLine(), out 

        }
        private int GetShopMenuOptions(params string[] options)
        { 

            for (int i = 0; i < _items.Length; i++)
            {
                Console.WriteLine((i + 1) + _items[i].Name + _items[i].Gold);
            }

            return _items.Length;
           
        }


        public void Save()
        {

            //create a new stream below
            StreamWriter writer = new StreamWriter("SaveData.txt");

            //saves player...
            _player.Save(writer);

            //closes the writer when done saving.
            writer.Close();
        }

        public bool Load()
        {
            bool loadSuccessful = true;


            //figures out if file exists...
            if (!File.Exists("SaveData.txt"))
                //returns false
                loadSuccessful = false;

            //creas a new reader to read from the text file
            StreamReader reader = new StreamReader("SaveData.txt");


            if (!_player.Load(reader))
                loadSuccessful = false;

            _currentScene = Scene.GETSHOPMENUOPTIONS;

            //make the reader cloase when finished
            reader.Close();

            return loadSuccessful;
        }

    }
}
