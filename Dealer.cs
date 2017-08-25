using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole
{
    public class Dealer // Dealer has all the cards in his deck. He gives out new cards and also shuffles the decks
    {

        public BlackjackDeck Deck { get; private set; } // New blackjack deck containing 6 decks of 52 cards
        public List<Player> Players { get; private set; } = new List<Player>();
        public List<Card> DealerHand { get; private set; } = new List<Card>();
        public bool RoundOne = true;

        public Dealer(int players)
        {

            Deck = new BlackjackDeck(6);

            //First shuffle the deck
            
            for (int i = 0; i < players; i++)
            {

                Players.Add(new Player(SetName()));
            }

            

        }
        
        public void Shuffle()
        {
            Deck.FullDeck.Shuffle();
        }

        
        // Method for Dealing cards to the player(s):
        // Every player gets 2 cards. At first every player gets 1 card and then when every one has at least a card everyone gets a new card. 

        public void DealCards() // deals cards to the players
        {

            for (int i = 0; i < 2; i++) // every player gets 2 cards
            {
                foreach (Player player in Players)
                {
                    player.Hand.Add(GetFirstCard());
                }

                DealerHand.Add(Deck.GetFirstCard()); 
            }
        }


        public void DealCards(Player player) // deals a new card to a specific player
        {

            player.Hand.Add(GetFirstCard());
        }

        public Card GetFirstCard()
        {
            return Deck.GetFirstCard();

        }


        // Get name from player
        public string SetName()
        {

            string name = null;
            while(name == null)
            {
                Console.Write("Please enter your name: ");
                name = Console.ReadLine();
                if(name == null)
                    Console.WriteLine("Sorry you can't enter nothing, try again");
            }

            return name;
     
        }


        public void DisplayHand() // keep track if it's round one or not. 
        {
            foreach (Card card in DealerHand)
            {
                if(DealerHand.IndexOf(card) == 0 && RoundOne == true)
                {
                    Console.WriteLine("{0} - {1}\n", card.Value, card.Color);
                } else if (DealerHand.IndexOf(card) == 1 && RoundOne == true)
                {
                    break;
                } else if (DealerHand.IndexOf(card) == 1 && RoundOne == false)
                {
                    Console.WriteLine("{0} - {1}\n", card.Value, card.Color);
                }
                    
            }
        }







    }
}
