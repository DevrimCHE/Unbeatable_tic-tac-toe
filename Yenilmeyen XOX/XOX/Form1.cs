using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace XOX
{
    public partial class Form1 : Form
    {
        ArrayList Buttons = new ArrayList();
        int[,] Goals = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 6, 4, 2 } };
        bool Turn = true; //true = X - False = O
        bool Game = true;
        ArrayList NullButtons = new ArrayList();
        int[] Values = { 3, 2, 3, 2, 5, 2, 3, 2, 3 };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Load Buttons
            Buttons.Add(button1);
            Buttons.Add(button2);
            Buttons.Add(button3);
            Buttons.Add(button4);
            Buttons.Add(button5);
            Buttons.Add(button6);
            Buttons.Add(button7);
            Buttons.Add(button8);
            Buttons.Add(button9);
            //Null Buttons
            NullButtons.Add(0);
            NullButtons.Add(1);
            NullButtons.Add(2);
            NullButtons.Add(3);
            NullButtons.Add(4);
            NullButtons.Add(5);
            NullButtons.Add(6);
            NullButtons.Add(7);
            NullButtons.Add(8);

        }

        private void AddX(int Sended)
        {
            if (Turn == true && Game == true)
            {
                Button Change = ((Button)Buttons[Sended]);
                if (Change.Text != "X" && Change.Text != "O")
                {
                    Change.Text = "X";
                    NullButtons.Remove(Sended);
                    Values[Sended] = -100;
                    if (NullButtons.Count <= 0)
                    {
                        label1.Text = "DRAW";
                        Game = false;
                    }
                    GoalControl(Sended, "X");
                    Turn = false;
                    CpuPlay();
                }
            }
        }
        private void AddO(int Sended)
        {
            if (Turn == false && Game == true)
            {
                Button Change = ((Button)Buttons[Sended]);
                if (Change.Text != "X" && Change.Text != "O")
                {
                    Change.Text = "O";
                    NullButtons.Remove(Sended);
                    Values[Sended] = -100;
                    if (NullButtons.Count <= 0)
                    {
                        label1.Text = "DRAW";
                        Game = false;
                    }
                    GoalControl(Sended, "O");

                }
                Turn = true;
            }
        }
        private void CpuPlay()
        {
            if (NullButtons.Count > 0)
            {
                UpdateValue();
                AddO(Array.IndexOf(Values,Values.Max()));
            }
        }

        private void UpdateValue()
        {
            for (int i = 0; i < NullButtons.Count; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    int[] ArrayCont = { Goals[j, 0], Goals[j, 1], Goals[j, 2] };

                    if (Array.IndexOf(ArrayCont, NullButtons[i]) != -1)
                    {
                        int n = ((int)NullButtons[i]);
                        Button B1 = ((Button)Buttons[ArrayCont[0]]);
                        Button B2 = ((Button)Buttons[ArrayCont[1]]);
                        Button B3 = ((Button)Buttons[ArrayCont[2]]);
                        if ((B1.Text == "X" && B2.Text == "X" )|| (B1.Text == "X" && B3.Text == "X") ||( B3.Text == "X" && B2.Text == "X") )
                        {
                            Values[n] += 15;
                        }
                        else if (B1.Text == "X" || B2.Text == "X" || B3.Text == "X")
                        {
                            Values[n] -= 1;
                        }
                        if ((B1.Text == "O" && B2.Text == "O") || (B1.Text == "O" && B3.Text == "O") || (B3.Text == "O" && B2.Text == "O"))
                        {
                            Values[n] += 25;
                        }
                    }
                }
            }
        }

        private void GoalControl(int ContIndex,string Sended)
        {
            for(int i=0; i<=7; i++)
            {
                int[] ArrayCont = { Goals[i, 0], Goals[i, 1], Goals[i, 2] };

                if (Array.IndexOf(ArrayCont, ContIndex) != -1)
                {
                    Button B1 = ((Button)Buttons[ArrayCont[0]]);
                    Button B2 = ((Button)Buttons[ArrayCont[1]]);
                    Button B3 = ((Button)Buttons[ArrayCont[2]]);
                    if(B1.Text == B2.Text && B2.Text == B3.Text && B3.Text == Sended)
                    {
                        label1.Text = Sended+" WINS";
                        Game = false;
                    }
                }
            }
        }

        //Controls two Array elements same
        static bool ArraySame(int[] A1, int[] A2)
        {
            if (A1.Length != A2.Length) return false;
            else
            {
                for (int i = 0; i < A1.Length; i++)
                {
                    if (A1[i] != A2[i]) return false;
                }
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddX(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddX(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddX(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddX(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddX(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddX(5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddX(6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddX(7);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AddX(8);
        }
    }
}
