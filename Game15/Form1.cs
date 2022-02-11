using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public TableLayoutPanelCellPosition empty;
        public TableLayoutPanelCellPosition current_button;
        private void button7_Click(object sender, EventArgs e)
        {
            if(WinChecker())
            {
                MessageBox.Show("Вы выиграли!!!!!");
                restart();
            }
            current_button = tableLayoutPanel1.GetCellPosition((Control)sender);
            empty = tableLayoutPanel1.GetCellPosition(button16);

            if (current_button.Row + 1 == empty.Row && current_button.Column == empty.Column
                || current_button.Row - 1 == empty.Row && current_button.Column == empty.Column
                || current_button.Row == empty.Row && current_button.Column - 1 == empty.Column
                || current_button.Row == empty.Row && current_button.Column + 1 == empty.Column
                )
            {
                tableLayoutPanel1.SetCellPosition((Control)sender, empty);
                tableLayoutPanel1.SetCellPosition(button16, current_button);
            }
        }
        bool WinChecker()
        {
            foreach (Button tl in tableLayoutPanel1.Controls)
            {
                if (tl.Tag.ToString() != tableLayoutPanel1.GetCellPosition(tl).ToString())
                    return false;
            }
            return true;
        }

        void restart()
        {
            foreach (Button b in tableLayoutPanel1.Controls)
            {
                var arr = b.Tag.ToString().Split(',');
                tableLayoutPanel1.SetCellPosition(b, new TableLayoutPanelCellPosition(Convert.ToInt32(arr[0]), Convert.ToInt32(arr[1])));
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Random r;

        private void startNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restart();
            empty = tableLayoutPanel1.GetCellPosition(button16);

            r = new Random();

            Control pic1 = new Control();

            TableLayoutPanelCellPosition pos1 = new TableLayoutPanelCellPosition();

            Control pic2 = new Control();

            TableLayoutPanelCellPosition pos2 = new TableLayoutPanelCellPosition();

            Control pic3 = new Control(); 

            TableLayoutPanelCellPosition pos3 = new TableLayoutPanelCellPosition();

            Control pic4 = new Control();

            TableLayoutPanelCellPosition pos4 = new TableLayoutPanelCellPosition();

            int random_numb;

            for (int i = 0; i < 15;)
            {
                empty = tableLayoutPanel1.GetCellPosition(button16);
                random_numb = r.Next(1, 5);

                if (random_numb == 1 && empty.Column + 1 <= 3)
                {
                    pic1 = tableLayoutPanel1.GetControlFromPosition(empty.Column + 1, empty.Row);
                    if (pic1 != null)
                    {
                       // MessageBox.Show("1");
                        pos1 = tableLayoutPanel1.GetCellPosition(pic1);
                        tableLayoutPanel1.SetCellPosition(pic1, empty);
                        tableLayoutPanel1.SetCellPosition(button16, pos1);
                        i++;
                    }
                    
                }
                else if(random_numb == 2 && empty.Row -1 >= 0)
                {
                    pic4 = tableLayoutPanel1.GetControlFromPosition(empty.Column, empty.Row - 1);
                    if (pic4 != null)
                    {
                        // MessageBox.Show("2");
                        pos4 = tableLayoutPanel1.GetCellPosition(pic4);
                        tableLayoutPanel1.SetCellPosition(pic4, empty);
                        tableLayoutPanel1.SetCellPosition(button16, pos4);
                        i++;
                    }
                    
                }
                else if (random_numb == 3 && empty.Column - 1 >= 0)
                {
                    pic2 = tableLayoutPanel1.GetControlFromPosition(empty.Column - 1, empty.Row);
                    if (pic2 != null)
                    {
                        //MessageBox.Show("3");
                        pos2 = tableLayoutPanel1.GetCellPosition(pic2);
                        tableLayoutPanel1.SetCellPosition(pic2, empty);
                        tableLayoutPanel1.SetCellPosition(button16, pos2);
                        i++;
                    }
                   
                }
                 else if (random_numb == 4 && empty.Row + 1 <= 3)
                 {
                    pic3 = tableLayoutPanel1.GetControlFromPosition(empty.Column, empty.Row + 1);
                    if (pic3 != null)
                    {
                       // MessageBox.Show("4");
                        pos3 = tableLayoutPanel1.GetCellPosition(pic3);
                        tableLayoutPanel1.SetCellPosition(pic3, empty);
                        tableLayoutPanel1.SetCellPosition(button16, pos3);
                        i++;
                    }
                   
                 }
            }

        }
    }
}
