using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mud_Metal
{
    public partial class GameScreen : UserControl
    {
        public GameScreen()
        {
            InitializeComponent();
            InitializeGame();
        }

        #region Variables
        // bools for buttons
        Boolean spaceDown, aDown, dDown, qDown, eDown, kDown, semiColonDown, iDown, pDown, wDown, sDown, lDown, oDown;
        PointF shotPosition;
        //angle items
        int TopXPos = 0;
        int TopYPos = 0;
        int turnCount = 0;
        float scale = (float)0.25;
        int fuel = 125;

        bool moveRight = false;
        bool moveLeft = false;
        bool shooting = false;
        bool trackPos = true;
        // ---

        bool richochet = true;

        //declare identification for turn
        string turn = "";

        List<Bullet> bullets = new List<Bullet>();
        List<Tank> tanks = new List<Tank>();
        List<Ground> grounds = new List<Ground>();
        //declare random
        public static Random r = new Random();
        #endregion

        private void InitializeGame()
        {
            //coinflip for first turn
            if (r.Next(1, 2) == 1)
            {
                turn = "Player1";
            }
            else
            {
                turn = "Player2";
            }

            // create tank player objects

            Tank Player1 = new Tank(150, 20, 100, "Player1");
            Tank Player2 = new Tank(150, 800, 100, "Player2");
            tanks.Add(Player1);
            tanks.Add(Player2);

            // create basic ground object
            Ground ground = new Ground(0, 600, 1400, 200);
            grounds.Add(ground);
            Bullet bullet = new Bullet(10, 10, 15, -3, 5, 0);
            bullets.Add(bullet);

        }

        private void EndGame()
        {

        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                // player 1 keys (a d q e, w, s)
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Q:
                    qDown = true;
                    break;
                case Keys.E:
                    eDown = true;
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;

                //player 2 keys (K, ;, i, p, o, l)

                case Keys.K:
                    kDown = true;
                    break;
                case Keys.OemSemicolon:
                    semiColonDown = true;
                    break;
                case Keys.I:
                    iDown = true;
                    break;
                case Keys.P:
                    pDown = true;
                    break;
                case Keys.L:
                    lDown = true;
                    break;
                case Keys.O:
                    oDown = true;
                    break;

                case Keys.Escape:
                    Application.Exit();
                    break;
                case Keys.Space:
                    // apply shooting check
                    if (shooting != true)
                    {
                        shooting = true;
                        Shoot();
                    }
                    break;

                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // player 1 keys (a d q e)
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Q:
                    qDown = false;
                    break;
                case Keys.E:
                    eDown = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;

                //player 2 keys (K, ;, i, p)

                case Keys.K:
                    kDown = false;
                    break;
                case Keys.OemSemicolon:
                    semiColonDown = false;
                    break;
                case Keys.I:
                    iDown = false;
                    break;
                case Keys.P:
                    pDown = false;
                    break;
                case Keys.O:
                    oDown = false;
                    break;
                case Keys.L:
                    lDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            #region Tanks

            //check if a bullet is currently being shot
            if (!shooting)
            {
                //check if fuel is out or not
                if (!(fuel <= 0))
                {
                    if (turn == "Player1") // player 1
                    {

                        foreach (Tank t in tanks)
                        {
                            if (t.player == "Player1")
                            {
                                // Move Player1 Tank
                                if (aDown && t.x > 0)
                                {
                                    t.Move("Left");
                                    TopXPos -= 2;
                                    fuel--;
                                }
                                if (dDown && t.x < (this.Width - t.width))
                                {
                                    t.Move("Right");
                                    TopXPos += 2;
                                    fuel--;
                                }

                            }
                        }
                    }
                    else // player 2
                    {
                        foreach (Tank t in tanks)
                        {
                            if (t.player == "Player2")
                            {
                                // Move Player2 Tank
                                if (kDown && t.x > 0)
                                {
                                    t.Move("Left");
                                    TopXPos -= 2;
                                    fuel--;
                                }
                                if (semiColonDown && t.x < (this.Width - t.width))
                                {
                                    t.Move("Right");
                                    TopXPos += 2;
                                    fuel--;
                                }

                            }
                        }

                    }
                }
            }

            // make the tanks have makeshift gravity for unique maps
            foreach (Tank t in tanks)
            {
                for (int i = 0; i < grounds.Count; i++)
                {
                    t.gravity(grounds[i]);
                }
            }
            #endregion

            #region bullets

            // move bullets
            foreach (Bullet b in bullets)
            {
                b.doGravity(600, 1400);
            }

            // check for collision between bullets and ground
            foreach (Bullet b in bullets)
            {
                for (int i = 0; i < grounds.Count; i++)
                {
                    if (b.BlockCollision(grounds[i]) == true)
                    {
                        //keep bullet alive if ricochet powerUp is active
                        if (richochet)
                        {
                            if (b.bounces <= 4)
                            {
                                b.bounces++;
                            }
                            else
                            {
                                bullets.Remove(b);
                                shooting = false;
                                goto BREAK;
                            }
                        }
                        else
                        {
                            bullets.Remove(b);
                            shooting = false;
                            goto BREAK;
                        }
                    }

                }

            }
        BREAK:

            //bullet collision with tank, properly reward damage
            foreach (Bullet b in bullets)
            {
                for (int i = 0; i < tanks.Count; i++)
                {
                    if (b.hurt(tanks[i]))
                    {
                        // remove standard bullet damage
                        tanks[i].health -= 25;

                        if (tanks[i].health <= 0)
                        {
                            
                        }
                        //remove bullet and break out of foreach
                        bullets.Remove(b);
                        shooting = false;
                        goto BREAK;
                    }
                }
            }

            #endregion

            #region infoDisplay
            //display health
            healthP1.Text = Convert.ToString(tanks[0].health);
            healthP2.Text = Convert.ToString(tanks[1].health);

            if (turn == "Player1")
            {
                //display power
                power1.Text = "Str: " + scale.ToString("0.00");
                power2.Text = "Str: 0";

                //display fuel
                fuel1.Text = "Fuel: " + fuel;
                fuel2.Text = "Fuel: 0";
            }
            else if (turn == "Player2")
            {
                //display power
                power2.Text = "Str: " + scale.ToString("0.00");
                power1.Text = "Str: 0";

                //display fuel
                fuel2.Text = "Fuel: " + fuel;
                fuel1.Text = "Fuel: 0";
            }

            #endregion



            Refresh();
        }

        public void Shoot()
        {

            for (int i = 0; i < tanks.Count; i++)
            {
                //determine which player currently, and then switch turn
                if (turn == "Player1")
                {
                    i = 0;
                }
                if (turn == "Player2")
                {
                    i = 1;
                }


                float ballY = (TopYPos) - (float)tanks[i].y - tanks[i].height;
                float ballX = (float)(TopXPos) - tanks[i].x - tanks[i].width / 2;


                Bullet bullet = new Bullet(TopXPos - (float)(0.5 * 15), TopYPos - (float)(0.5 * 15), 15, scale * ballX, scale * ballY, 0);
                bullets.Add(bullet);


                // switch turn 
                if (turn == "Player1")
                {
                    turn = "Player2";
                    TopXPos = tanks[1].x + tanks[1].width;
                }
                else if (turn == "Player2")
                {
                    turn = "Player1";
                    TopXPos = tanks[0].x + tanks[0].width;
                }
                //reset fuel
                fuel = 125;
                break;

            }
        }
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {

            foreach (Ground g in grounds)
            {
                e.Graphics.FillRectangle(Brushes.DarkGreen, g.x, g.y, g.width, g.height);
            }

            foreach (Bullet b in bullets)
            {
                e.Graphics.FillEllipse(Brushes.DarkGoldenrod, b.x, b.y, b.size, b.size);
            }

            foreach (Tank t in tanks)
            {
                e.Graphics.FillRectangle(Brushes.White, t.x, Convert.ToInt32(t.y), t.width, t.height);
            }



            for (int i = 0; i < tanks.Count; i++)
            {
                //make no movements if shooting is active
                if (!shooting)
                {
                    //determine which tank is the current shooter
                    if (turn == "Player1")
                    {
                        i = 0;
                    }
                    else if (turn == "Player2")
                    {
                        i = 1;
                    }
                    //determine shooters x value
                    if (eDown == true && turn == "Player1" || pDown == true && turn == "Player2")
                    {

                        if (!(TopXPos > this.Width - 40) && !(TopXPos > tanks[i].x + (tanks[i].width / 2) + 40))
                        {
                            TopXPos += 10;
                        }
                    }
                    else if (qDown == true && turn == "Player1" || iDown == true && turn == "Player2")
                    {
                        if (!(TopXPos < 40) && !(TopXPos < tanks[i].x + (tanks[i].width / 2) - 40))
                        {
                            TopXPos -= 10;
                        }
                    }
                    //determine power of shot
                    if (wDown && turn == "Player1" || oDown && turn == "Player2")
                    {
                        if (scale <= .45)
                        {
                            scale += (float)0.01;
                        }
                    }
                    else if (sDown && turn == "Player1" || lDown && turn == "Player2")
                    {
                        if (scale >= .20)
                        {
                            scale -= (float)0.01;
                        }
                    }

                    //y value
                    TopYPos = Convert.ToInt32(tanks[i].y - tanks[i].height) - 5;
                    break;
                }
            }

            for (int i = 0; i < tanks.Count; i++)
            {
                //draw shooting line
                if (turn == "Player1")
                {
                    i = 0;
                }
                else if (turn == "Player2")
                {
                    i = 1;
                }

                try
                {
                    e.Graphics.DrawLine(Pens.Red, (tanks[i].x) + (tanks[i].width / 2), Convert.ToInt32(tanks[i].y) + (tanks[i].height / 2), TopXPos, TopYPos);

                    break;
                }
                catch { }

            }

        }
    }
}
