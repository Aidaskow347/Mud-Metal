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
    public partial class Controls : UserControl
    {
        public Controls()
        {
            InitializeComponent();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // Goes to the game screen
            MainMenu mm = new MainMenu();
            Form form = this.FindForm();

            form.Controls.Add(mm);
            form.Controls.Remove(this);

            mm.Location = new Point((form.Width - mm.Width) / 2, (form.Height - mm.Height) / 2);
        }
    }
    }

