using System;
using System.Threading;
namespace NumberGuesserEnhanced
{
    class Program
    {
        static void Main(string[] args)
        {
            bool play = true;
            bool playStart = false;
            string playConfirmation;
            int userNumber = 0;
            int highestNum; //highest number for agent to guess
            int lowestNum; //lowest number for agent to guess
            bool userNumberPlaced;

            bool win = true;
            bool rematch;
            string rematchRequest;
            int highscore = 0;
            int tries;


            manualTyping(
                "Hello!" +
                "\nThis is your assigned CIA agent here... " +
                "\nI've encrypted your computer to after some some evidence for files of mass destruction were confirmed...  " +
                "\nHowever, I can make a deal. Win a game and your computer will be free... " +
                "\nA number guessing game, you guess my number, you win..."+
                "\nI guess your number, you'll lose your files..."+
                "\nSo how about it? [y/n]?\n");
            
            //User Confirms if he will play the game
            while (!playStart)
            {
                Console.ForegroundColor = ConsoleColor.White;
                playConfirmation = (Console.ReadLine());

                if (playConfirmation == "y")
                {
                    
                    play = true;
                    playStart = true;
                }
                else if (playConfirmation == "n")
                {
                    manualTyping("Hope you can still afford another computer. Goodbye :)");
                    play = false;
                    playStart = true;
                }
                else
                {
                    manualTyping("I told you what to write didn't I? [y/n]\n");
                    playStart = false;
                }

            }

            while (play)
            {
                highestNum = 100;
                lowestNum = 1;
                tries = 0;
                userNumberPlaced = false;
                

                manualTyping("First of all, you have to type in your number\n");
                // User puts his number for the agent to guess
                while(!userNumberPlaced)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        userNumber = Convert.ToInt32(Console.ReadLine());
                        if (userNumber <= 0 || userNumber > 100 )
                        {
                            manualTyping("The number has to be between 1 and 100...\n");
                        }
                        else
                        {
                            userNumberPlaced = true;
                        }
                    }
                    catch
                    {
                        manualTyping("Funny joke, now type in your number...\n");
                    }
                }

                manualTyping("Then let the games begin!");
                
                bool guessingNum = true;
                int answer;
                int SecretNumber = GetRandom();

                while (guessingNum) // Guesses Starts
                {
                    manualTyping("\nyour guess?\n");
                    try
                    {

                        //User Guesses 
                        Console.ForegroundColor = ConsoleColor.White;
                        answer = Convert.ToInt32(Console.ReadLine());
                        if (answer > SecretNumber) 
                        {
                            Console.Beep();
                            manualTyping("You guessed too high!"); 
                        }
                        else if (answer < SecretNumber) 
                        {
                            Console.Beep();
                            manualTyping("You guessed too low!"); 
                        }
                        else if (answer == SecretNumber)
                        { 
                            manualTyping("You got it champ! \n Looks like you get to keep a File...");
                            win = true;
                            guessingNum = false;
                        }
                        else if (answer > 100 || answer < 1)
                        {
                            manualTyping("\nWhat a waste of a turn dude...");
                        }
                        tries++;
                        //Agents guesses
                        if (guessingNum)
                        {
                            // Agents guessed number
                            Random r = new Random();

                            // The more he guesses, the more accurate his guess is
                            int agentNumber = r.Next(lowestNum, highestNum); 
                            manualTyping("\nMy turn!");
                            manualTyping("\nI guessed " + agentNumber + "... ");
                            
                           
                            if (agentNumber < userNumber)
                            {
                               lowestNum = agentNumber + 1 ;
                                
                            }
                            else if(agentNumber > userNumber)
                            {
                                highestNum = agentNumber - 1;
                            }
                            else
                            {
                                manualTyping("\nLooks like I won...");
                                manualTyping("\nMy number was " + SecretNumber + "");
                                manualTyping("\nAnd now a file has been sent to the pentagon for examinations...");
                                guessingNum = false;
                               
                            }

                        }
                        
                    }
                    catch
                    {
                        manualTyping("Keep joking around and your system is gonna get it!");
                    }
                }
                

                //highscore here = lowest guesses in a round
                manualTyping("\nYou guessed " + tries + " times...");
                if (highscore == 0 && win)
                { 
                    highscore = tries; 
                }
                else if (tries < highscore && win)
                { 
                    highscore = tries; 
                    manualTyping("That's a new record!"); 
                }
                
                manualTyping("\nBut I still have your other files encrypted... " +
                             "\nso how about rematch to save your files? [y/n] \n");
                rematch = false;

                //if User wants a rematch or not
                while (!rematch)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    rematchRequest = Console.ReadLine();

                    if (rematchRequest == "n")
                    {
                        manualTyping("I guess they weren't that important anyways.. goodbye for now.");
                        rematch = true;
                        play = false;
                    }
                    else if(rematchRequest == "y")
                    {
                        manualTyping("Here's to another file! \n");
                        rematch = true;
                    }
                    else
                    {
                        manualTyping("I've already told you what to type haven't I? [y|n]\n");
                    }
                } 

            }









        }
        public static int GetRandom()
        {
            Random r = new Random();
            int SecretNum = r.Next(1, 100);
            return SecretNum;
        }

        public static void manualTyping(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(line[i]);
                System.Threading.Thread.Sleep(30);
            }
        }
        
        
    }

}




