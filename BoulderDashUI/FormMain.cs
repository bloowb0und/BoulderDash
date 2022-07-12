using System;
using System.Windows.Forms;
using BoulderDash;
using BoulderDashClassLibrary;

namespace BoulderDashUI
{
    public partial class FormMain : Form
    {
        private Game _game;
        private UIActions _uiActions;
        
        public FormMain()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _uiActions = new UIActions(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var formWelcome = new FormWelcome();
            this.Hide();
            formWelcome.ShowDialog();
            this.Show();
            
            _game = new Game();
            Element.DrawElement += _uiActions.ElementOnDrawElement;
            _game.StartGame(_ => _uiActions.DrawInGameMenu(_game.DiamondsCollected, _game.DiamondList.Count),
                _uiActions.EndGame, _uiActions.ClearScreen);

            // restart game
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            var enteredKey = e.KeyData.ToString();
            var isInterrupted = _game.OnPressedButton(enteredKey);
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey=true;
        }

        private void labelSurrender_Click(object sender, EventArgs e)
        {
            SendKeys.Send("l");
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Element.DrawElement -= _uiActions.ElementOnDrawElement;
        }
    }
}