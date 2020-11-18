using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NuclearData.Models;
using NuclearData;

namespace KazNuclide.Views
{
    public partial class MendeleevTableView : UserControl
    {
        public List<ElementView> ElementViews { get; set; }
        private const int dwidth = 36; 
        private const int dheigth = 36;
        private const int xElements = 18;
        private const int yElements = 10;
        public List<Isotope> Isotopes { get; set; }
        private string[,] table = new string[yElements, xElements]
        {
            //1     2     3     4     5     6     7     8     9     10    11    12    13    14    15    16    17    18 
            {"1",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",   "2"},
            {"3",  "4",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "5",  "6",  "7",  "8",  "9",  "10"},
            {"11", "12", "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "13", "14", "15", "16", "17", "18"},
            {"19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36"},
            {"37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54"},
            {"55", "56", "0",  "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86"},
            {"87", "88", "0", "104","105","106","107","108","109","110","111", "0",  "0",  "0",  "0",  "0",  "0",   "0"},
            {"0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",  "0",   "0"},
            {"0",  "0",  "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71",  "0"},
            {"0",  "0",  "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99","100","101","102","103",  "0"},
        };
        public MendeleevTableView()
        {
            InitializeComponent();

            MendeleevTablePanel.Controls.Clear();
            ElementViews = new List<ElementView>();
            for (int i = 0; i < yElements; i++)
            {
                for (int j = 0; j < xElements; j++)
                {
                    var z = Convert.ToInt32(table[i, j]);
                    if (z != 0)
                    {
                        var view = new ElementView();
                        view.Number = z;
                        view.ElementName.Text = Constants.ElementNames[z];
                        MendeleevTablePanel.Controls.Add(view);
                        view.Location = new Point(j * dwidth + 4, i * dheigth + 3);
                        view.Size = new Size(30, 30);
                        view.ElementClick += View_ElementClick;
                    }
                }
            }
        }

        private void View_ElementClick(int z)
        {
            isotopesListView.Items.Clear();
            var list = new ListViewItem();
            var isotopes = Isotopes.Where(x => x.Z == z).Select(x => x.Name);
            ElementNameLabel.Text = z + "-" + Constants.ElementNames[z];
            foreach (var iso in isotopes)
            {
                isotopesListView.Items.Add(iso);
            }
        }

        private void isotopesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string iso = isotopesListView.SelectedItem.ToString();
            var isotope = Isotopes.FirstOrDefault(x => x.Name == iso);
            var isotopeView = new IsotopeInfoView(isotope);
            isotopeInfoPanel.Controls.Clear();
            isotopeInfoPanel.Controls.Add(isotopeView);
        }
    }
}
