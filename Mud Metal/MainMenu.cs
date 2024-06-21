using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mud_Metal
{
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        
        private void exitButton_Click(object sender, EventArgs e)
        {
            //exit application
            Application.Exit();
        }

        private void gameStartButton_Click(object sender, EventArgs e)
        {
            // Goes to the game screen
            GameScreen gs = new GameScreen();
            Form form = this.FindForm();

            form.Controls.Add(gs);
            form.Controls.Remove(this);

            gs.Location = new Point((form.Width - gs.Width) / 2, (form.Height - gs.Height) / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Goes to the game screen
            Controls screen = new Controls();
            Form form = this.FindForm();

            form.Controls.Add(screen);
            form.Controls.Remove(this);

            screen.Location = new Point((form.Width - screen.Width) / 2, (form.Height - screen.Height) / 2);
        }
    }
}
