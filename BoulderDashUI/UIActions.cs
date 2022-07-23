using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BoulderDashClassLibrary.GameElements;

namespace BoulderDashUI
{
    public class UIActions
    {
        private FormMain _formMain;
        private List<Control> _menuControls;

        public UIActions(FormMain formMain)
        {
            _formMain = formMain;
            
            _menuControls = new List<Control>();
            foreach (Control control in _formMain.Controls)
            {
                _menuControls.Add(control);
            }
        }

        public void ElementOnDrawElement(object sender, EventArgs e)
        {
            if (sender is not Element element)
            {
                return;
            }
            
            var image = element switch
            {
                Emptiness => null,
                Player => Properties.Resources.player,
                Sand => Properties.Resources.sand,
                Stone => Properties.Resources.stone,
                Diamond => Properties.Resources.diamond,
                Wall => Properties.Resources.wall,
                Edge => null,
                _ => null
            };

            var pictureBox = new PictureBox
            {
                Location = new Point(element.X * 25 + 210, element.Y * 25 + 200),
                Size = new Size(25, 25),
                BackgroundImage = image,
                BackgroundImageLayout = ImageLayout.Stretch
            };
            
            _formMain.Controls.Add(pictureBox);
        }

        public void ClearScreen()
        {
            _formMain.Controls.Clear();
        }

        public void EndGame(bool victoryStatus)
        {
            if (victoryStatus)
            {
                var formWin = new FormWin();
                _formMain.Hide();
                formWin.ShowDialog();
                _formMain.Close();
            }
            else
            {
                var formLose = new FormLose();
                _formMain.Hide();
                formLose.ShowDialog();
                _formMain.Close();
            }
        }

        public void DrawInGameMenu(int diamondsCollected, int diamondsAmount)
        {
            foreach (var control in _menuControls)
            {
                _formMain.Controls.Add(control);
            }
        }

        public void PrintIntro()
        {
            
        }
    }
}