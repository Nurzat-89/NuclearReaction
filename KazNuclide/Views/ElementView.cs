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
        private int _number;
        public int Number { get
            {
                return _number; 
            }
            set
            {
                _number = value;
                NumberText.Text = value + "";
            }
        }
        public ElementView()
        {
            InitializeComponent();
        }
    }
}
