using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace twozerofoureight
{
    public partial class TwoZeroFourEightView : Form, View
    {
        Model model;
        Controller controller;
       
        public TwoZeroFourEightView()
        {
            InitializeComponent();
            model = new TwoZeroFourEightModel();
            model.AttachObserver(this);
            controller = new TwoZeroFourEightController();
            controller.AddModel(model);
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);
        }

        public void Notify(Model m)
        {
            UpdateBoard(((TwoZeroFourEightModel) m).GetBoard());
            UpdateGameOver(((TwoZeroFourEightModel)m).GetBoard());
            UpdateScore(((TwoZeroFourEightModel)m).GetScore());
        }

        private void UpdateScore(int Score)
        {
            label2.Text = Score.ToString();

        }

        private void UpdateTile(Label l, int i)
        {
            if (i != 0)
            {
                l.Text = Convert.ToString(i);
            } else {
                l.Text = "";
            }

            switch (i)
            {
                case 0:
                    l.BackColor = Color.Gray;
                    break;
                case 2:
                    l.BackColor = Color.DarkGray;
                    break;
                case 4:
                    l.BackColor = Color.Orange;
                    break;
                case 8:
                    l.BackColor = Color.Red;
                    break;
                default:
                    l.BackColor = Color.Green;
                    break;
            }                
        }
        private void UpdateBoard(int[,] board)
        {
                UpdateTile(lbl00, board[0, 0]);
                UpdateTile(lbl01, board[0, 1]);
                UpdateTile(lbl02, board[0, 2]);
                UpdateTile(lbl03, board[0, 3]);
                UpdateTile(lbl10, board[1, 0]);
                UpdateTile(lbl11, board[1, 1]);
                UpdateTile(lbl12, board[1, 2]);
                UpdateTile(lbl13, board[1, 3]);
                UpdateTile(lbl20, board[2, 0]);
                UpdateTile(lbl21, board[2, 1]);
                UpdateTile(lbl22, board[2, 2]);
                UpdateTile(lbl23, board[2, 3]);
                UpdateTile(lbl30, board[3, 0]);
                UpdateTile(lbl31, board[3, 1]);
                UpdateTile(lbl32, board[3, 2]);
                UpdateTile(lbl33, board[3, 3]);
            
            /*
                int sum = 0;
                for (int i = 0; i <= 3; i++)
                {
                    for(int j=0; j <= 3; j++)
                    {
                            sum += board[i, j]; 
                    }
                }
                textBox1.Text = sum.ToString();
                */
            
        }
        private void UpdateGameOver(int[,] Board)
        {
            bool a = true, b = true;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Board[i, j] == 0)
                    {
                        a = true;
                        break;
                    }
                    else a = false;
                }
                if (a)
                {
                    break;
                }
                else if (i == 3)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        for (int q = 0; q < 3; q++)
                        {
                            if (Board[k, q] == Board[k, q + 1] || Board[k, q] == Board[k + 1, q])
                            {
                                b = true;
                                break;
                            }
                            else b = false;
                        }
                        if (Board[k, 3] == Board[k + 1, 3]) b = true;
                        if (b) break;
                    }
                    if (b)
                    {
                        return;
                    }
                    else label1.Text = "Gameover";
                }
            } 
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.UP);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.DOWN);
            
        }

        private void lbl22_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                controller.ActionPerformed(TwoZeroFourEightController.LEFT);
            }
            if(keyData == Keys.Right)
            {
                controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
            }
            if(keyData == Keys.Up)
            {
                controller.ActionPerformed(TwoZeroFourEightController.UP);
            }
            if (keyData == Keys.Down)
            {
                controller.ActionPerformed(TwoZeroFourEightController.DOWN);
            }
                return base.ProcessCmdKey(ref msg, keyData);
            
        }

        private void lbl13_Click(object sender, EventArgs e)
        {

        }

        private void TwoZeroFourEightView_Load(object sender, EventArgs e)
        {

        }
    }
}
