using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mud_Metal
{
    internal class Tank
    {
        public int health, x, width = 35, height = 25;
        public double y;
        public string player;
        double counter = 1;
        public Tank(int health, int x, float y, string player)
        {
            this.health = health;
            this.x = x;
            this.y = y;
            this.player = player;
        }


        public void Move(string direction)
        {
            if (direction == "Left")
            {
                x -= 2;
            }
            if (direction == "Right")
            {
                x += 2;
            }
        }
        public void gravity(Ground g)
        {
            // check for intersection
            Rectangle t = new Rectangle(x, Convert.ToInt32(y), width, height);
            Rectangle ground = new Rectangle(g.x, g.y, g.width, g.height);

            if (t.IntersectsWith(ground))
            {
                //reset height and counter
                t.Y = g.y + t.Height;
                counter = 0;

                //try to fix falling under ground
                if (t.Y < g.y)
                {
                    y -= 0.1;
                }
                
            }
            else
            {
                //gravity
                counter += 1;
                y += 0.1 + (counter / 15);
            }
        }
    }

}
