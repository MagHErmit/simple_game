using System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Game game = new RogueLikeGame(800, 600, "Game", Color.Cyan);
            game.Run();
        }
    }
}
