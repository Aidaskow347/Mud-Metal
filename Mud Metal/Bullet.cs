using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mud_Metal
{
    internal class Bullet
    {
        public float x, y, size, xSpeed, ySpeed;
        public int bounces;

        public List<bool> recentlyHit = new List<bool>();
        public List<int> watchReset = new List<int>();
        public Bullet(float _x, float _y, float _size, float _xSpeed, float _ySpeed, int _bounces)
        {
            x = _x;
            y = _y;
            size = _size;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            bounces = _bounces;
           
        }

        public void doGravity(int screenHeight, int screenWidth) //ball physics with walls + gravity
        {

            if (y < screenHeight - size - 4)
            {
                ySpeed += 1;
            }
            else
            {
                y = screenHeight - size;
                ySpeed *= -1;
                bounces++;
                if (-1 > ySpeed || ySpeed > 1)
                {
                    const int SLOWER = 3;
                    if (ySpeed > 0)
                        ySpeed -= SLOWER;
                    else ySpeed += SLOWER;
                }
                else
                {
                    ySpeed = 0;
                }
            }



            if (x > screenWidth - size)
            {
                xSpeed *= -1;
                x = screenWidth - size;
            }
            if (x < 0)
            {
                xSpeed *= -1;
                x = 0;
            }
            if (y < 0)
            {
                ySpeed *= -1;
                y = 0;
            }
            const float xSLOWER = (float)0.15;
            if (Math.Abs(ySpeed) == 0 || Math.Abs(xSpeed) > 5)
            {
                if (Math.Abs(xSpeed) > 0.3)
                {
                    if (xSpeed > 0)
                        xSpeed -= xSLOWER;
                    else xSpeed += xSLOWER;
                }
                else
                {
                    xSpeed = 0;
                }
            }

            y += ySpeed;
            x += xSpeed;
            for (int i = 0; i < recentlyHit.Count; i++)
            {
                if (recentlyHit[i])
                {
                    watchReset[i]++;
                    if (watchReset[i] >= 3) { watchReset[i] = 0; recentlyHit[i] = false; ySpeed = (int)ySpeed; }
                }
            }

        }
        public bool BlockCollision(Ground g)
        {
            RectangleF blockRec = new RectangleF(g.x, g.y -1, g.width, g.height);
            RectangleF ballRec = new RectangleF(x, y, size, size);

            if (blockRec.IntersectsWith(ballRec))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool hurt(Tank t)
        {
            // check for intersection
            Rectangle tank = new Rectangle(t.x, Convert.ToInt32(t.y), t.width, t.height);
            Rectangle bullet = new Rectangle(Convert.ToInt32(x), Convert.ToInt32(y), Convert.ToInt32(size), Convert.ToInt32(size));

            if (bullet.IntersectsWith(tank))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
