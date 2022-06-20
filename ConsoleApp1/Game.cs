using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace ConsoleApp1
{

    public interface IRunnableWindow
    {
       void Run();
    }

    public interface IInitableWindow
    {
        public void Init();
    }

    public abstract class Game
    {
        // protected means child classes have access
        protected RenderWindow window;
        protected Color clearColor;
        protected const uint framerate = 30;

        public Game(uint width, uint height, String title, Color clrColor)
        {
            // Create the main window
            window = new RenderWindow(new VideoMode(width, height), title);

            int i = 0;
            // Setup some window properties
            window.SetFramerateLimit(framerate);

            // Set color for window background
            clearColor = clrColor;

            // Setup up event handlers - Using delegates <- Read up on this
            window.Closed += Window_Closed;
            window.KeyPressed += Window_KeyPressed;
        }

        protected abstract void Window_KeyPressed(object sender, KeyEventArgs e);

        protected void Window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }

        public void Run()
        {
            Init();
            // Start of game loop
            while (window.IsOpen)
            {
                // Process events - keypress, mouse movement & clicks
                window.DispatchEvents();

                // Clear screen - to pre-determined color
                window.Clear(clearColor);

                // Update the game
                Update(window);
                // Update the window
                window.Display();
            }
            // End of game loop
        }
        public abstract void Init();
        public abstract void Update(RenderWindow window);
    }
}
