using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BoulderDashClassLibrary.GameElements;
using BoulderDashUI.Properties;

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
                Player => Resources.player,
                Sand => Resources.sand,
                Stone => Resources.stone,
                Diamond => Resources.diamond,
                Wall => Resources.wall,
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
            Form form = victoryStatus ? new FormWin() : new FormLose();
            
            _formMain.Hide();
            form.ShowDialog();
            _formMain.Close();
        }

        public void DrawInGameMenu(int diamondsCollected, int diamondsAmount)
        {
            foreach (var control in _menuControls)
            {
                _formMain.Controls.Add(control);
            }
        }
    }
}