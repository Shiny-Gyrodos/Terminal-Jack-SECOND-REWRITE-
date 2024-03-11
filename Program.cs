using System;
using System.Threading.Channels;

namespace MyApp
{
    internal class Program
    {
        static bool startFinished = false;
        static int handTotal = 0;
        static int i = 0;
        static int[] dealer = new int[21];
        static int[] hand = new int[5];
        static Random rng = new Random();
        static void Main(string[] args)
        {
            Start();
            Spaces();
            Console.WriteLine("Press any key to close the window.");
            Console.ReadKey();
        }



        static void Call()
        {
            int milliseconds = 1500;
            int dealerTotal = 0;
            Console.WriteLine("Your total is " + handTotal + "\nThe dealer will now draw cards.");
            Thread.Sleep(milliseconds);
            for (int f = 0; dealerTotal <= handTotal; f++)
            {
                dealer[f] = rng.Next(1, 14);
                if (dealer[f] > 10)
                {
                    dealer[f] = 10;
                }
                dealerTotal += dealer[f];
                Thread.Sleep(milliseconds);
                Console.WriteLine(dealer[f]);
            }
            if (dealerTotal > 21)
            {
                Thread.Sleep(milliseconds);
                Spaces();
                Console.WriteLine("YOU WIN!\nDealer busts!");
            }
            else
            {
                Thread.Sleep(milliseconds);
                Spaces();
                Console.WriteLine("GAME OVER.\nDealer is closer.");
            }
        }



        static void GetPlayerChoice()
        {
            bool chosen = false;
            while (chosen == false)
            {
                Console.WriteLine("HIT or CALL?");
                string choice = Console.ReadLine().ToLower();
                if (choice == "hit")
                {
                    chosen = true;
                    Hit();
                }
                else if (choice == "call")
                {
                    chosen = true;
                    Call();
                }
                else
                {
                    Console.WriteLine("Try Again");
                }
            }
        }



        static void Hit()
        {
            hand[i] = rng.Next(1, 14);
            if (hand[i] > 10)
            {
                hand[i] = 10;
            }
            handTotal += hand[i];
            Console.WriteLine(hand[i]);
            if (i == 4 && handTotal <= 21)
            {
                Spaces();
                Console.WriteLine("YOU WIN!\nYou managed to draw five cards without busting.");
            }
            else if (handTotal > 21)
            {
                Spaces();
                Console.WriteLine("GAME OVER!\nYou busted!");
            }
            else if (handTotal == 21)
            {
                Spaces();
                Console.WriteLine("YOU WIN!\nYour card total is exactly 21!");
            }
            else if (startFinished == true)
            {
                GetPlayerChoice();
            }
            i++;
        }



        static void Start()
        {
            Console.WriteLine("Welcome to TERMINAL-JACK!\n-------------------------\nPress any key to continue.");
            Console.ReadKey();
            Console.WriteLine("\nYou will now be dealt two cards");
            Spaces();
            Hit();
            Hit();
            startFinished = true;
            GetPlayerChoice();
        }



        static void Spaces()
        {
            Console.WriteLine("-------------------------");
        }
    }
}
