using System;

namespace Pong
{
    /// <summary>
    /// This is the first method to run, mostly reduntant, see Game1.cs for the main game class
    /// </summary>
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
