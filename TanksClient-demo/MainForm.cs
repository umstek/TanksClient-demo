using System;
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
                case Keys.A: // Fallthrough
                case Keys.Left:
                    labelCommand.Text = @"LEFT#";
                    break;
                case Keys.D: // Fallthrough
                case Keys.Right:
                    labelCommand.Text = @"RIGHT#";
                    break;
                case Keys.W: // Fallthrough
                case Keys.Up:
                    labelCommand.Text = @"UP#";
                    break;
                case Keys.S: // Fallthrough
                case Keys.Down:
                    labelCommand.Text = @"DOWN#";
                    break;
                case Keys.Enter:
                    labelCommand.Text = @"JOIN#";
                    // Start listening to the server here, on a background thread. 
                    Task.Run(() => Input.StartListening(SetInputToLabel));
                    break;
                case Keys.Space:
                    labelCommand.Text = @"SHOOT#";
                    break;
                default:
                    labelCommand.Text = @"SHOOT#";
                    break;
            }

            Output.SendToServer(labelCommand.Text);
        }

        private void SetInputToLabel(string message)
        {
            // Trying to make a cross-thread call. These are illegal. 
            // i.e.: Trying to update a GUI component with a thread other than the thread which created it. 
            if (labelMessage.InvokeRequired)
                labelMessage.Invoke(new Action(() => SetInputToLabel(message)));
            else
                labelMessage.Text = message;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}