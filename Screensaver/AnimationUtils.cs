using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Threading;

namespace Screensaver
{
    public class AnimationUtils
    {
        
        private static Random rnd = new Random();
        private static int height = WindowHeight;
        private static int width = WindowWidth;

        /// <summary>
        /// This function animates a string while randomly changing text color
        /// Screen saver continues to run until user presses Enter key
        /// </summary>
        /// <param name="text">word to display on screen saver</param>
        /// <param name="wait"> delay between each print to the screen</param>
        public static void animate(String text, int wait)
        {
            Title = "Screensaver";
            CursorVisible = false;
            while (true)
            {
                
                Console.ForegroundColor = (ConsoleColor)(rnd.Next(1,15));//changing the console color randomly
                setCoordinate(text.Length);
                WriteLine(text);
                Thread.Sleep(wait);
                if (UserPressedEnter())
                    break;          

            }

            ExitScreenSaver();
        }
        /// <summary>
        /// This function is responsible for displaying quotes, printed letter by letter
        /// on the screen. Between the displays of quotes, a wait time is introduced 
        /// to allow ample time for the quote to be read
        /// screen saver continues to run until user presses Enter key
        /// </summary>
        /// <param name="quotes">array from where quotes will be randomly picked</param>
        /// <param name="delay">delay between letters printing to screen</param>
        /// <param name="wait">wait time before next quote is displayed </param>
        public static void animate(String []quotes, int delay, int wait)
        {
            Title = "Screensaver";
            CursorVisible = false;
            
            while (true)
            {
                int quoteId = rnd.Next(0, quotes.Length);
                int length = quotes[quoteId].Length;
                setCoordinate(length);            
                Console.ForegroundColor = (ConsoleColor)(rnd.Next(1, 15));
                foreach (char letter in quotes[quoteId])
                {
                    Write(letter);
                    Thread.Sleep(delay);
                }
                Thread.Sleep(wait);       
                Clear();
                if (UserPressedEnter())
                    break;

            }

            ExitScreenSaver();
        }
        /// <summary>
        /// This function checks if user has pressed the Enter key
        /// </summary>
        /// <returns>true if Enter key pressed, false otherwise</returns>
        private static bool UserPressedEnter()
        {
            if (KeyAvailable)
            {
                Clear();
                ConsoleKeyInfo keyInfo = ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// This function displays a welcome message to indicate that the user
        /// is back to main program screen and screen saver has been exited
        /// </summary>
        private static void ExitScreenSaver() 
        {
            WriteLine("Welcome back!");
            CursorVisible = true;
            ReadKey(true);

        }
        /// <summary>
        /// This function sets the coordinates and ensures that the text is placed
        /// in a way so it doesn't overflow to the next line
        /// </summary>
        /// <param name="length">length of the quote or word to be displayed</param>
        private static void setCoordinate(int length)
        {
            int height = WindowHeight;
            int width = WindowWidth;
            int x = rnd.Next(WindowTop, width);
            int y = rnd.Next(0, height);
            if (x + length >= width)
                x = width - length - 10;//leaving margin in case of overflow
            SetCursorPosition(x,y);
        }
    }
}
