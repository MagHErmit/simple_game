using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class RogueLikeGame : Game
    {
        bool isDrawRectangle = true;
        RectangleShape rect_sh;
        Sprite sprite;
        public RogueLikeGame(uint width, uint height, string title, Color clrColor) : base(width, height, title, clrColor)
        {

        }

        public override void Init()
        {
            rect_sh = new RectangleShape(new Vector2f(100, 100));
            //rect_sh.FillColor = new Color(255, 0, 0);
            sprite = new Sprite(new Texture("C:\\Users\\ApostLe\\Desktop\\texture_rect.png"));
            sprite.Origin = new Vector2f(50, 50);
        }

        public override void Update(RenderWindow window)
        {
            if(isDrawRectangle)
            {
                sprite.Rotation += 1f;
                window.Draw(sprite);
            }
            
        }

        protected override void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.Space:
                    isDrawRectangle = isDrawRectangle ? false : true;
                    break;
                case Keyboard.Key.Up:
                    rect_sh.FillColor = new Color(0, 0, 255);
                    break;
                case Keyboard.Key.Down:
                    sprite.Position += new Vector2f(0, 10);
                    break;
                case Keyboard.Key.Right:
                    sprite.Position += new Vector2f(10, 0);
                    break;
                default:
                    Console.WriteLine(e.Code.ToString() + " не определён");
                    break;
            }
        }
    }
}
