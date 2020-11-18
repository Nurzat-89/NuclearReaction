using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KazNuclide.Views
{
    public partial class ElementView : UserControl
    {
        public delegate void ElementClickHandler(int z);
        public event ElementClickHandler ElementClick;
        private int _number;
        public int Number { get
            {
                return _number; 
            }
            set
            {
                _number = value;
                ZNumber.Text = value + "";
            }
        }
        public ElementView()
        {
            InitializeComponent();
        }

        private void ElementName_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.GreenYellow;

        }

        private void ElementName_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(224, 224, 224);

        }

        private void ElementName_MouseDown(object sender, MouseEventArgs e)
        {
            ElementClick?.Invoke(Number);
        }
    }
}
