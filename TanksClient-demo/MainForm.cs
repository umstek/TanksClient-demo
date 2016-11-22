using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanksClient_demo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                // Fallthrough
                case Keys.Left:
                    labelCommand.Text = @"LEFT#";
                    break;
                case Keys.D:
                // Fallthrough
                case Keys.Right:
                    labelCommand.Text = @"RIGHT#";
                    break;
                case Keys.W:
                // Fallthrough
                case Keys.Up:
                    labelCommand.Text = @"UP#";
                    break;
                case Keys.S:
                // Fallthrough
                case Keys.Down:
                    labelCommand.Text = @"DOWN#";
                    break;
                case Keys.Space:
                    labelCommand.Text = @"SHOOT#";
                    break;
                default:
                    labelCommand.Text = @"Unknown";
                    break;
            }
        }
    }
}
