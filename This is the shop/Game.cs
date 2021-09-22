using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace This_is_the_shop
{
    public struct Item
    {
        public string Name;
        public int Gold;

    }

    public enum Scene
    {
        DISPLAYOPENINGMENU,
        STARTMENUFORSHOIP,
        GETSHOPMENUOPTIONS,
        

    }


    class Game
    {
        private bool _gameOver = false;
        private Player _player;
        private Shop _playerGold;
        private Scene _currentScene;
        private Shop _shop;
        private Item[] _items;

        public void Run()
        {
            Start();

            while (_gameOver == false)
            {
                Update();
            }
            End();
        }

        public void End()
        {

        }

        public void Start()
        {
           
        }

        public void Update()
        {
            DisplayShopMenu();
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
                    GetShopMenuOptions(_items);
                    
                   
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

        private void GetShopMenuOptions(Item[] items)
        {

            for (int i = 0; i < _items.Length; i++)
            {
                Console.WriteLine((i + 1) + _items[i].Name + _items[i].Gold);
            }


        }

        public void DisplayShopMenu()
        {
            //prints to player the gold they have and the lines needed but i am trying a getInput for this
           // int choice = GetInput("You got" + _player.Gold() + "Gold Left. " + "Hay what you buyin smooth scking", GetShopMenuOptions(_items));

            Console.WriteLine("You got " + _player.Gold() + "Gold Left. ");
            InitializeItems();
            Console.WriteLine("Hay what you buyin smooth scking");
            GetShopMenuOptions(_items);
            Console.WriteLine("4. I will save the current game! ");
            Console.WriteLine("5. I will leave the current game!");

            int input = Console.Read();

            int itemIndex = -1;

            switch (input)
            {
                case 1:
                    //needed to state the itemIndex becasue start is -1
                    itemIndex = 0;
                    Console.WriteLine("You have bought a BIG GUN!!! good Luck");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                case 2:
                    //same thing that is in each case
                    itemIndex = 1;
                    Console.WriteLine("Hahahah you bought a BIG SHIELD why you do that.");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                case 3:
                    itemIndex = 2;
                    Console.WriteLine("YOU HAVE BOUGHT THE BIG AXE GOOD AXE GO BREEEE!!");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                case 4:
                    itemIndex = 3;
                    Console.WriteLine("FORCE SHIELD do i need to say more!");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;

                case 5:
                    
                    Console.WriteLine("Alright then! you saved congrats!");
                    Console.ReadKey(true);
                    Console.Clear();
                    return;
                case 6:
                    Console.WriteLine("Leave but do not forget by wears!");
                    Console.ReadKey(true);
                    Console.Clear();
                    _gameOver = true;
                    return;
                default:
                    Console.Clear();
                    return;
            }
            if (_player.Gold() < _items[itemIndex].Gold)
            {
                Console.WriteLine("You can't afford this.");
                return;
            }

            GetShopMenuOptions(_player.Currentinventory());

            input = Console.Read();

            int playerIndex = -1;

            switch (input)
            {
                case 1:
                    {
                        playerIndex = 0;
                        break;
                    }
                case 2:
                    {
                        playerIndex = 1;
                        break;
                    }
                case 3:
                    {
                        playerIndex = 2;
                        break;
                    }
                default:
                    {
                        return;
                    }
            }

        }



    }
}
