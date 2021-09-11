using System;
using static System.Console;
using System.Threading;
namespace Screensaver
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] quotes = new string[]
            {
               "Hard work pays off.",
               "Happiness can be found even in the darkest times.",
               "There is always something to be greatful for.",
               "Tomorrow will be brighter, if you spend today learning.",
               "Believe you can, and you're halfway there.",
               "Believe there is good in the world.",
               "Let your light shine.",
               "You miss 100% of the shots you don't take.",
               "Get it done!",
               "Never give up.",
               "Even the world impossible says I'm possible."
            };
            String text = "Hello World!";
        //AnimationUtils.animate(text, 100);

        AnimationUtils.animate(quotes, 50, 300);

        }
    }
}
