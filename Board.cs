using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole
{
    public class Board
    {
        // Maybe this class can keep track on the game loop. Decides the turns of each player and dealer, etc..

        public Dealer TheDealer { get; set; }

        private bool _playing = true;

        

        
        public void Play()
        {

            Console.Write("Welcome to Blackjack\n please tell us how much player will be playing the game: ");
            int userCount;
            while(!int.TryParse(Console.ReadLine(), out userCount)) //this loop just asks again and again after it gets valid input
            {
                Console.Write("Sorry that was not a valid input. It has to be a whole number. Please type it in again: ");
            }

            while (_playing)
            {
                Console.WriteLine("\n\nOk so {0} players in total. The dealer will now deal out the cards to every player in the game.\n", userCount);
                Console.WriteLine("Hang on tight, we are almost finished....Click enter to proceed");
                Console.ReadLine();
                TheDealer = new Dealer(userCount);
                TheDealer.Shuffle();
                TheDealer.DealCards();
                PlayerTurns();
                TheDealer.RoundOne = false;
                DealerTurn(); // TODO: Add a Dealer Turn --> Compute the algorithm if the dealer burns himself (he stops at 17 or more), he has a blackjack with an ace and a 10, he has to draw a new card if value < 17
                TheDealer.DisplayHand();



                

                


            }
        }




        public void PlayerTurns()

        {

            // to something for each player. TODO: Start the cycle from beginning

            foreach (Player player in TheDealer.Players)
            {
                
                Console.WriteLine("Your turn Player {0}", player.GetPlayerName()); 
                Console.WriteLine("Press enter to proceed");
                Console.ReadLine();
                DisplayBoard(player);
                
                NextAction(GetPlayerChoice(player), player);
            }

        }

        public int GetPlayerChoice(Player player)
        {
            int playerChoice;
            Console.WriteLine("What would you like to do? Chose a number (just the number) for an option: \n");
            Console.WriteLine(
                "\t1.) Draw a new card\n" +
                "\t2.) Split (not yet implemented)\n" +
                "\t3.) Stay (next player turn)");
            while (!int.TryParse(Console.ReadLine(), out playerChoice)) //this loop just asks again and again after it gets valid input
            {
                Console.Write("Sorry that was not a valid input. It has to be a whole number. Please type it in again: ");
            }

            return playerChoice;

        }

        public void DisplayBoard(Player player)
        {
            Console.WriteLine("Your cards: \n");
            player.DisplayHand();
            Console.WriteLine("\nThe dealers card(s): \n");
            TheDealer.DisplayHand();
            
        }

        public void NextAction(int choice, Player player)
        {
            switch (choice)
            {
                case 1:
                    DealCardTurn(player);
                    break;
                case 2:
                    break;
                case 3:
                    break;

                default:
                    break;
            }


        }
       
        public void DealCardTurn(Player player)
        {
            Card temp = TheDealer.GetFirstCard();
            player.Hand.Add(temp);
            Console.WriteLine("Your new card:\n {0}", temp.Value);

            if(player.ComputeValue() > 21)
            {
                Console.WriteLine("Sorry you total value is {0}.\nYou are out", player.ComputeValue());
            } else
            {
                Console.WriteLine("Your total value is {0}.\nWhat do you want to do next?", player.ComputeValue());
                NextAction(GetPlayerChoice(player), player);

            }


        }
       





    }
}
