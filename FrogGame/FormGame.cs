using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrogGame
{
    public partial class FormGame : Form
    {
        Image imgFrogLeft, imgFrogRight, imgLeaf;
        int[] field = { 1, 1, 1, 1, 0, 2, 2, 2, 2 };
        int positionLeaf = 4;
        public FormGame()
        {
            InitializeComponent();
            imgFrogLeft = Bitmap.FromFile("images/FrogLeft.png");
            imgFrogRight = Bitmap.FromFile("images/FrogRight.png");
            imgLeaf = Bitmap.FromFile("images/Leaf.png");

        }

        private void FormGame_Load(object sender, EventArgs e)
        {

            dataGridFrogs.Rows.Add();
            dataGridFrogs.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Width = 9 * imgLeaf.Width;
            dataGridFrogs.Height = imgLeaf.Height;
            showFrogs();
        }

        void showFrogs()
        {
            for (int i = 0; i < field.Length; i++)
            {
                switch (field[i])
                {
                    case 1: dataGridFrogs[i, 0].Value = imgFrogLeft; break;
                    case 2: dataGridFrogs[i, 0].Value = imgFrogRight; break;
                    case 0: dataGridFrogs[i, 0].Value = imgLeaf; break;
                }

                
            }
        }
        private void dataGridFrogs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            field[positionLeaf] = field[e.ColumnIndex];
            field[e.ColumnIndex] = 0;
            positionLeaf = e.ColumnIndex;
            showFrogs();
        }
    }
}
