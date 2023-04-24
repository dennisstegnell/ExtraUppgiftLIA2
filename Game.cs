using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraUppgiftLIA2
{
    public class Game
    {
        public void startGame()
        {
            int difficulty = 0;
            int numberOfModes = 3;
            Console.WriteLine("Välkommen till HiLo");
            startMessage();
            while (difficulty < 1 || difficulty > numberOfModes)
            {
                try
                {
                    difficulty = Convert.ToInt32(Console.ReadLine());
                    if(difficulty < 1 || difficulty > numberOfModes)
                    {
                        Console.Clear();
                        Console.WriteLine($"Du har valt nummer {difficulty}, vi har bara modes 1-{numberOfModes} välj igen tack!");
                        startMessage();
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Felaktig input");
                    startMessage();
                }

            }
            playGame(difficulty);
    
        }
        void playGame(int difficulty)
        {
            double maxGuess = Math.Pow(10, difficulty);
            
            Random random = new Random();
            int correctNumber = random.Next(1, (int)maxGuess + 1);
            int userGuess = 0;
            int amountOfGuesses = 0;
            while(correctNumber != userGuess)
            {
                amountOfGuesses++;
                
                
                //userGuess = Convert.ToInt32(Console.ReadLine());

                do 
                {
                    Console.WriteLine($"Gissa på ett tal mellan 1-{maxGuess}");
                    userGuess = validateUserGuess(maxGuess);
                }
                while (userGuess == 0) ;

                if (userGuess < correctNumber)
                    Console.WriteLine("Din gissning är för låg");
                else if(userGuess > correctNumber)
                    Console.WriteLine("Din gissning är för hög");


            }
            Console.WriteLine("Grattis");
            Console.WriteLine($"Det tog {amountOfGuesses} att gissa rätt tal!");

        }

        private int validateUserGuess(double max)
        {
            
            try
            {
                int guess = Convert.ToInt32(Console.ReadLine());
                if (guess < 1 || guess > max)
                {
                   
                    Console.WriteLine($"Du har valt nummer {guess}, välj mellan 1-{max} tack!");
                    return 0;
                }
                return guess;
            }
            catch
            {
                
                Console.WriteLine("Felaktig input");
                return 0;
            }
        }

        void startMessage()
        {
            Console.WriteLine("Välj svårighetsgrad:\n");
            Console.WriteLine("1. Lätt (1-10)");
            Console.WriteLine("2. Medium (1-100");
            Console.WriteLine("3. Svår (1-1000)");


        }
    }
}
