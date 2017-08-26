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
                if(DealerTurn() == 0)
                {
                    Console.WriteLine("Congratulations remaining players, you have won because the Dealer bruned himself (value higher then 21)");
                } else { WinningCondition(TheDealer); }
                
                

                // Start a new round with the same players - reinstantiate the players array 



                

                


            }
        }

        public void WinningCondition(Dealer dealer)
        {

            foreach (Player player in dealer.Players)
            {
                if(player.ComputeValue() > TheDealer.ComputeValue())
                {
                    Console.WriteLine("Congratulation {0}, you won!", player.GetPlayerName()); // TODO: Add a bet system and give them the chips he won
                } else if (player.ComputeValue() == TheDealer.ComputeValue())
                {
                    Console.WriteLine("It's a tie {0}, neither of you wins and you get back your bit", player.GetPlayerName());
                } else
                {
                    Console.WriteLine("Sorry {0}, the Dealer has higher card then yours. You lost", player.GetPlayerName());
                }
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

        public int DealerTurn()
        {
            TheDealer.DisplayHand();

            while(TheDealer.ComputeValue() < 17)
            {
                TheDealer.DealCardToDealer();
            }

            if(TheDealer.ComputeValue() == 17)
            {
                return 17;
            } else if (TheDealer.ComputeValue() > 21) //TODO: Computer has lost, say that all players who are currently in the game won and start a new round
            {
                return 0;
            } else if (TheDealer.ComputeValue() > 17 && TheDealer.ComputeValue() <= 21)
            {
                return TheDealer.ComputeValue();
            }

            return TheDealer.ComputeValue();
            


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
                Console.WriteLine("Sorry you total value is {0}.\nYou are out", player.ComputeValue());  // TODO: Delete the user from the Player Array. After the winning condition is set and the game continues, put it back in. 
            } else
            {
                Console.WriteLine("Your total value is {0}.\nWhat do you want to do next?", player.ComputeValue());
                NextAction(GetPlayerChoice(player), player);

            }
        }
    }
}
