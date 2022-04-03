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
        List<RectangleShape> list_rect_sh;
        Sprite sprite;
        IntRect texturerect; 
        Clock clock;

        Vector2f size;
        public RogueLikeGame(uint width, uint height, string title, Color clrColor) : base(width, height, title, clrColor)
        {

        }

        public override void Init()
        {
            
            //rect_sh.FillColor = new Color(255, 0, 0);
            sprite = new Sprite(new Texture("C:\\Users\\ApostLe\\Desktop\\Darkwood Forest Platformer Free Asset\\Free Character Animations\\steel-atack}.png"));
            //sprite.Origin = new Vector2f(50, 50);
            texturerect = new IntRect(0, 0, 16, 16);
            sprite.TextureRect = texturerect;
            sprite.Scale = new Vector2f(7, 7);

            clock = new Clock();

            size = new Vector2f(50, 50);



            list_rect_sh = new List<RectangleShape>();

            uint pos_counter_x = 0;

            uint pos_counter_y = 0;

            Random rand = new Random();

            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    var r = new RectangleShape(size);


                    r.Position = new Vector2f(pos_counter_x, pos_counter_y);
                    pos_counter_x = window.Size.X - Convert.ToUInt32(size.X);
                    r.FillColor = new Color(Convert.ToByte(rand.Next() % 255), Convert.ToByte(rand.Next() % 255), Convert.ToByte(rand.Next() % 255));


                    list_rect_sh.Add(r);
                }
                pos_counter_x = 0;
                pos_counter_y = window.Size.Y - Convert.ToUInt32(size.X);
            }


        }
        public override void Update(RenderWindow window)
        {
            if(isDrawRectangle)
            {
                if(clock.ElapsedTime.AsSeconds() > 1.0f)
                {
                    texturerect.Left += 16;

                    if (texturerect.Left == 80)
                        texturerect.Left = 0;
                    sprite.TextureRect = texturerect;
                    clock.Restart();
                }
                
                window.Draw(sprite);
            }

            foreach (var rect in list_rect_sh)
            {
                window.Draw(rect);
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
                    //rect_sh.FillColor = new Color(0, 0, 255);
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
