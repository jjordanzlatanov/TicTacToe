using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Tic_Tac_Toe : Form
    {
        Random AIRandom = new Random();
        bool Pass = false;
        int Turns = 0, First_Turn;
        bool[,] Table = { { false, false, false }, { false, false, false }, { false, false, false } };
        bool AgainstAI = false;
        int[] Rows = { 0, 1, 2, 0, 1, 2, 0, 1, 2 };
        int[] Columns = { 0, 0, 0, 1, 1, 1, 2, 2, 2 };

        public Tic_Tac_Toe()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button Current_Button = (Button)sender;
            if (Turns % 2 == 0)
            {
                if (!Table[Rows[Current_Button.TabIndex], Columns[Current_Button.TabIndex]])
                {
                    Current_Button.Text = "X";
                    Table[Rows[Current_Button.TabIndex], Columns[Current_Button.TabIndex]] = true;
                    Turns++;
                }
            }
            else
            {
                if (!Table[Rows[Current_Button.TabIndex], Columns[Current_Button.TabIndex]])
                {
                    Current_Button.Text = "O";
                    Table[Rows[Current_Button.TabIndex], Columns[Current_Button.TabIndex]] = true;
                    Turns++;
                }
            }
            Game_State();
            if (Pass == false)
            {
                if (AgainstAI)
                {
                    if (First_Turn == 1)
                    {
                        if (Turns % 2 == 0)
                        {
                            AITurn("X", "O");
                        }
                    }
                    else
                    {
                        if (Turns % 2 != 0)
                        {
                            AITurn("O", "X");
                        }
                    }
                }
                Game_State();
            }
        }



        private void New_Game_Start()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Table[i, j] = false;
                }
            }

            foreach (Control Current in Controls)
            {
                if (Current.TabIndex >= 0 && Current.TabIndex <= 8)
                {
                    Current.Text = "";
                }
            }

            Turns = 0;
            if (AgainstAI)
            {
                First_Turn = AIRandom.Next(1, 3);

                if (First_Turn == 1)
                {
                    Button_1.PerformClick();
                }
            }
        }

        private void New_Game_Menu_Click(object sender, EventArgs e)
        {
            New_Game_Start();
            if (AgainstAI)
            {
                AgainstAI = false;
                First_Player.Text = "X";
                Second_Player.Text = "O";
                Reset_Game();
            }
        }

        private void Reset_Game_Click(object sender, EventArgs e)
        {
            New_Game_Start();
            Reset_Game();
        }

        private void New_Game_Against_AI_Click(object sender, EventArgs e)
        {
            New_Game_Start();
            if (!AgainstAI)
            {
                AgainstAI = true;
                First_Player.Text = "YOU";
                Second_Player.Text = "AI";
                Reset_Game();
            }
            First_Turn = AIRandom.Next(1, 3);
            if (First_Turn == 1)
            {
                Button_1.PerformClick();
            }
        }

        private void Reset_Game()
        {
            First_Player_Score.Text = "0";
            Draw_Score.Text = "0";
            Second_Player_Score.Text = "0";
        }

        private void AITurn(string Turn, string EnemyTurn)
        {
            if (((Turn == Button_2.Text && Turn == Button_3.Text) || (Turn == Button_4.Text && Turn == Button_7.Text) || (Turn == Button_5.Text && Turn == Button_9.Text)) && !Table[0, 0])
            {
                if (!Pass)
                {
                    Pass = true;
                    Button_1.PerformClick();
                }

            }
            if (((Turn == Button_1.Text && Turn == Button_3.Text) || (Turn == Button_5.Text && Turn == Button_8.Text)) && !Table[1, 0])
            {
                if (!Pass)
                {
                    Pass = true;
                    Button_2.PerformClick();
                }

            }
            if (((Turn == Button_1.Text && Turn == Button_2.Text) || (Turn == Button_6.Text && Turn == Button_9.Text) || (Turn == Button_5.Text && Turn == Button_7.Text)) && !Table[2, 0])
            {
                if (!Pass)
                {
                    Pass = true;
                    Button_3.PerformClick();
                }
            }
            if (((Turn == Button_1.Text && Turn == Button_7.Text) || (Turn == Button_5.Text && Turn == Button_6.Text)) && !Table[0, 1])
            {
                if (!Pass)
                {
                    Pass = true;
                    Button_4.PerformClick();
                }
            }
            if (((Turn == Button_1.Text && Turn == Button_9.Text) || (Turn == Button_3.Text && Turn == Button_7.Text) || (Turn == Button_2.Text && Turn == Button_8.Text) || (Turn == Button_4.Text && Turn == Button_6.Text)) && !Table[1, 1])
            {
                if (!Pass)
                {
                    Pass = true;
                    Button_5.PerformClick();
                }
            }
            if (((Turn == Button_4.Text && Turn == Button_5.Text) || (Turn == Button_3.Text && Turn == Button_9.Text)) && !Table[2, 1])
            {
                if (!Pass)
                {
                    Pass = true;
                    Button_6.PerformClick();
                }
            }
            if (((Turn == Button_1.Text && Turn == Button_4.Text) || (Turn == Button_8.Text && Turn == Button_9.Text) || (Turn == Button_5.Text && Turn == Button_3.Text)) && !Table[0, 2])
            {
                if (!Pass)
                {
                    Pass = true;
                    Button_7.PerformClick();
                }
            }
            if (((Turn == Button_7.Text && Turn == Button_9.Text) || (Turn == Button_5.Text && Turn == Button_2.Text)) && !Table[1, 2])
            {
                if (!Pass)
                {
                    Pass = true;
                    Button_8.PerformClick();
                }
            }
            if (((Turn == Button_7.Text && Turn == Button_8.Text) || (Turn == Button_5.Text && Turn == Button_1.Text) || (Turn == Button_6.Text && Turn == Button_3.Text)) && !Table[2, 2])
            {
                if (!Pass)
                {
                    Pass = true;
                    Button_9.PerformClick();
                }
            }






            if (((EnemyTurn == Button_2.Text && EnemyTurn == Button_3.Text) || (EnemyTurn == Button_4.Text && EnemyTurn == Button_7.Text) || (EnemyTurn == Button_5.Text && EnemyTurn == Button_9.Text)) && !Table[0, 0])
            {
                if (!Pass)
                {
                    Pass = true;
                    Button_1.PerformClick();
                }
            }
            if (((EnemyTurn == Button_1.Text && EnemyTurn == Button_3.Text) || (EnemyTurn == Button_5.Text && EnemyTurn == Button_8.Text)) && !Table[1, 0])
            {
                if (!Pass)
                {
                    Pass = true;
                    Button_2.PerformClick();
                }
            }
            if (((EnemyTurn == Button_1.Text && EnemyTurn == Button_2.Text) || (EnemyTurn == Button_6.Text && EnemyTurn == Button_9.Text) || (EnemyTurn == Button_5.Text && EnemyTurn == Button_7.Text)) && !Table[2, 0])
            {
                if (!Pass)
                {
                    Pass = true;
                    Button_3.PerformClick();
                }
            }
            if (((EnemyTurn == Button_1.Text && EnemyTurn == Button_7.Text) || (EnemyTurn == Button_5.Text && EnemyTurn == Button_6.Text)) && !Table[0, 1])
            {
                if (!Pass)
                {
                    Pass = true;
                    Button_4.PerformClick();
                }
            }
            if (((EnemyTurn == Button_1.Text && EnemyTurn == Button_9.Text) || (EnemyTurn == Button_3.Text && EnemyTurn == Button_7.Text) || (EnemyTurn == Button_2.Text && EnemyTurn == Button_8.Text) || (EnemyTurn == Button_4.Text && EnemyTurn == Button_6.Text)) && !Table[1, 1])
            {
                if (!Pass)
                {
                    Pass = true;
                    Button_5.PerformClick();
                }
            }
            if (((EnemyTurn == Button_4.Text && EnemyTurn == Button_5.Text) || (EnemyTurn == Button_3.Text && EnemyTurn == Button_9.Text)) && !Table[2, 1])
            {
                if (!Pass)
                {
                    Pass = true;
                    Button_6.PerformClick();
                }
            }
            if (((EnemyTurn == Button_1.Text && EnemyTurn == Button_4.Text) || (EnemyTurn == Button_8.Text && EnemyTurn == Button_9.Text) || (EnemyTurn == Button_5.Text && EnemyTurn == Button_3.Text)) && !Table[0, 2])
            {
                if (!Pass)
                {
                    Pass = true;
                    Button_7.PerformClick();
                }
            }
            if (((EnemyTurn == Button_7.Text && EnemyTurn == Button_9.Text) || (EnemyTurn == Button_5.Text && EnemyTurn == Button_2.Text)) && !Table[1, 2])
            {
                if (!Pass)
                {
                    Pass = true;
                    Button_8.PerformClick();
                }
            }
            if (((EnemyTurn == Button_7.Text && EnemyTurn == Button_8.Text) || (EnemyTurn == Button_5.Text && EnemyTurn == Button_1.Text) || (EnemyTurn == Button_6.Text && EnemyTurn == Button_3.Text)) && !Table[2, 2])
            {
                if (!Pass)
                {
                    Pass = true;
                    Button_9.PerformClick();
                }
            }


            if ((First_Turn == 1) && (!Pass))
            {
                if (((EnemyTurn == Button_5.Text) || (EnemyTurn == Button_3.Text) || (EnemyTurn == Button_7.Text)) && (!Pass))
                {
                    Pass = true;
                    Button_9.PerformClick();
                }
                if ((EnemyTurn == Button_9.Text) && (!Pass))
                {
                    Pass = true;
                    switch (Turns)
                    {
                        case 2:
                            Button_3.PerformClick();
                            break;
                        case 4:
                            Button_7.PerformClick();
                            break;
                    }
                }
                if (((EnemyTurn == Button_4.Text) || (EnemyTurn == Button_8.Text)) && (!Pass))
                {
                    Pass = true;
                    switch (Turns)
                    {
                        case 2:
                            Button_3.PerformClick();
                            break;
                        case 4:
                            Button_9.PerformClick();
                            break;
                    }
                }
                if ((EnemyTurn == Button_2.Text || EnemyTurn == Button_6.Text) && (!Pass))
                {
                    Pass = true;
                    switch (Turns)
                    {
                        case 2:
                            Button_7.PerformClick();
                            break;
                        case 4:
                            Button_9.PerformClick();
                            break;
                    }
                }
            }
            else if ((First_Turn == 2) && (!Pass))
            {
                if (Turns == 1 && !Table[1, 1])
                {
                    Pass = true;
                    Button_5.PerformClick();
                }
                if (Turns == 1 && Table[1, 1])
                {
                    if (!Table[0, 0] && (!Pass))
                    {
                        Pass = true;
                        Button_1.PerformClick();
                    }
                    if (!Table[2, 0] && (!Pass))
                    {
                        Pass = true;
                        Button_3.PerformClick();
                    }
                    if (!Table[0, 2] && (!Pass))
                    {
                        Pass = true;
                        Button_7.PerformClick();
                    }
                    if (!Table[2, 2] && (!Pass))
                    {
                        Pass = true;
                        Button_9.PerformClick();
                    }
                }
                if (Turns == 3 && ((EnemyTurn == Button_1.Text && EnemyTurn == Button_9.Text) || EnemyTurn == Button_3.Text || EnemyTurn == Button_7.Text) && (!Pass))
                {
                    Pass = true;
                    Button_6.PerformClick();
                }
                if (Turns == 3)
                {
                    if (!Table[0, 0] && (!Pass))
                    {
                        Pass = true;
                        Button_1.PerformClick();
                    }
                    if (!Table[2, 0] && (!Pass))
                    {
                        Pass = true;
                        Button_3.PerformClick();
                    }
                    if (!Table[0, 2] && (!Pass))
                    {
                        Pass = true;
                        Button_7.PerformClick();
                    }
                    if (!Table[2, 2] && (!Pass))
                    {
                        Pass = true;
                        Button_9.PerformClick();
                    }
                }
                if (Turns == 5 && (!Pass))
                {
                    if (Turn == Button_5.Text)
                    {
                        if (Turn == Button_1.Text)
                        {
                            if (!Table[1, 0] && (!Pass))
                            {
                                Pass = true;
                                Button_2.PerformClick();
                            }
                            if (!Table[0, 1] && (!Pass))
                            {
                                Pass = true;
                                Button_4.PerformClick();
                            }
                        }
                        if (Turn == Button_3.Text)
                        {
                            if (!Table[1, 0] && (!Pass))
                            {
                                Pass = true;
                                Button_2.PerformClick();
                            }
                            if (!Table[2, 1] && (!Pass))
                            {
                                Pass = true;
                                Button_6.PerformClick();
                            }
                        }
                        if (Turn == Button_7.Text)
                        {
                            if (!Table[0, 1] && (!Pass))
                            {
                                Pass = true;
                                Button_4.PerformClick();
                            }
                            if (!Table[1, 2] && (!Pass))
                            {
                                Pass = true;
                                Button_8.PerformClick();
                            }
                        }
                        if (Turn == Button_9.Text)
                        {
                            if (!Table[2, 1] && (!Pass))
                            {
                                Pass = true;
                                Button_6.PerformClick();
                            }
                            if (!Table[1, 2] && (!Pass))
                            {
                                Pass = true;
                                Button_8.PerformClick();
                            }
                        }

                    }
                    if (!Table[1, 0] && (!Pass))
                    {
                        Pass = true;
                        Button_2.PerformClick();
                    }
                    if (!Table[0, 1] && (!Pass))
                    {
                        Pass = true;
                        Button_4.PerformClick();
                    }
                }
                if (Turns == 7 && (!Pass))
                {
                    Pass = true;
                    Button_2.PerformClick();
                    Button_4.PerformClick();
                    Button_6.PerformClick();
                    Button_8.PerformClick();
                }
            }
            Pass = false;
        }

        private void Mouse_Enter(object sender, EventArgs e)
        {
            Button Current_Button = (Button)sender;
            if (!Table[Rows[Current_Button.TabIndex], Columns[Current_Button.TabIndex]])
            {
                if (Turns % 2 == 0)
                {
                    Current_Button.Text = "X";
                }
                else
                {
                    Current_Button.Text = "O";
                }
            }
        }

        private void Mouse_Leave(object sender, EventArgs e)
        {
            Button Current_Button = (Button)sender;
            if (!Table[Rows[Current_Button.TabIndex], Columns[Current_Button.TabIndex]])
            {
                Current_Button.Text = "";
            }
        }

        private void Game_State()
        {
            if ((Button_1.Text == "X" || Button_1.Text == "O") && (Button_1.Text == Button_2.Text && Button_1.Text == Button_3.Text))
            {
                MessageBox.Show("         " + Button_1.Text + " Wins.");
                if (Button_1.Text == "X")
                {
                    if (AgainstAI)
                    {
                        if (First_Turn == 1)
                        {
                            Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                        }
                        else
                        {
                            First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                        }
                    }
                    else
                    {
                        First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                    }
                }
                else
                {
                    if (AgainstAI)
                    {
                        if (First_Turn == 1)
                        {
                            First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                        }
                        else
                        {
                            Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                        }
                    }
                    else
                    {
                        Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                    }
                }
                New_Game_Start();
            }
            if ((Button_4.Text == "X" || Button_4.Text == "O") && (Button_4.Text == Button_5.Text && Button_4.Text == Button_6.Text))
            {
                MessageBox.Show("         " + Button_4.Text + " Wins.");
                if (Button_4.Text == "X")
                {
                    if (AgainstAI)
                    {
                        if (First_Turn == 1)
                        {
                            Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                        }
                        else
                        {
                            First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                        }
                    }
                    else
                    {
                        First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                    }
                }
                else
                {
                    if (AgainstAI)
                    {
                        if (First_Turn == 1)
                        {
                            First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                        }
                        else
                        {
                            Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                        }
                    }
                    else
                    {
                        Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                    }
                }
                New_Game_Start();
            }
            if ((Button_7.Text == "X" || Button_7.Text == "O") && (Button_7.Text == Button_8.Text && Button_7.Text == Button_9.Text))
            {
                MessageBox.Show("         " + Button_7.Text + " Wins.");
                if (Button_7.Text == "X")
                {
                    if (AgainstAI)
                    {
                        if (First_Turn == 1)
                        {
                            Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                        }
                        else
                        {
                            First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                        }
                    }
                    else
                    {
                        First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                    }
                }
                else
                {
                    if (AgainstAI)
                    {
                        if (First_Turn == 1)
                        {
                            First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                        }
                        else
                        {
                            Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                        }
                    }
                    else
                    {
                        Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                    }
                }
                New_Game_Start();
            }
            if ((Button_1.Text == "X" || Button_1.Text == "O") && (Button_1.Text == Button_4.Text && Button_1.Text == Button_7.Text))
            {
                MessageBox.Show("         " + Button_1.Text + " Wins.");
                if (Button_1.Text == "X")
                {
                    if (AgainstAI)
                    {
                        if (First_Turn == 1)
                        {
                            Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                        }
                        else
                        {
                            First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                        }
                    }
                    else
                    {
                        First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                    }
                }
                else
                {
                    if (AgainstAI)
                    {
                        if (First_Turn == 1)
                        {
                            First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                        }
                        else
                        {
                            Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                        }
                    }
                    else
                    {
                        Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                    }
                }
                New_Game_Start();
            }
            if ((Button_2.Text == "X" || Button_2.Text == "O") && (Button_2.Text == Button_5.Text && Button_2.Text == Button_8.Text))
            {
                MessageBox.Show("         " + Button_2.Text + " Wins.");
                if (Button_2.Text == "X")
                {
                    if (AgainstAI)
                    {
                        if (First_Turn == 1)
                        {
                            Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                        }
                        else
                        {
                            First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                        }
                    }
                    else
                    {
                        First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                    }
                }
                else
                {
                    if (AgainstAI)
                    {
                        if (First_Turn == 1)
                        {
                            First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                        }
                        else
                        {
                            Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                        }
                    }
                    else
                    {
                        Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                    }
                }
                New_Game_Start();
            }
            if ((Button_3.Text == "X" || Button_3.Text == "O") && (Button_3.Text == Button_6.Text && Button_3.Text == Button_9.Text))
            {
                MessageBox.Show("         " + Button_3.Text + " Wins.");
                if (Button_3.Text == "X")
                {
                    if (AgainstAI)
                    {
                        if (First_Turn == 1)
                        {
                            Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                        }
                        else
                        {
                            First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                        }
                    }
                    else
                    {
                        First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                    }
                }
                else
                {
                    if (AgainstAI)
                    {
                        if (First_Turn == 1)
                        {
                            First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                        }
                        else
                        {
                            Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                        }
                    }
                    else
                    {
                        Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                    }
                }
                New_Game_Start();
            }
            if ((Button_1.Text == "X" || Button_1.Text == "O") && (Button_1.Text == Button_5.Text && Button_1.Text == Button_9.Text))
            {
                MessageBox.Show("         " + Button_1.Text + " Wins.");
                if (Button_1.Text == "X")
                {
                    if (AgainstAI)
                    {
                        if (First_Turn == 1)
                        {
                            Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                        }
                        else
                        {
                            First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                        }
                    }
                    else
                    {
                        First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                    }
                }
                else
                {
                    if (AgainstAI)
                    {
                        if (First_Turn == 1)
                        {
                            First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                        }
                        else
                        {
                            Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                        }
                    }
                    else
                    {
                        Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                    }
                }
                New_Game_Start();
            }
            if ((Button_3.Text == "X" || Button_3.Text == "O") && (Button_3.Text == Button_5.Text && Button_3.Text == Button_7.Text))
            {
                MessageBox.Show("         " + Button_3.Text + " Wins.");
                if (Button_3.Text == "X")
                {
                    if (AgainstAI)
                    {
                        if (First_Turn == 1)
                        {
                            Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                        }
                        else
                        {
                            First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                        }
                    }
                    else
                    {
                        First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                    }
                }
                else
                {
                    if (AgainstAI)
                    {
                        if (First_Turn == 1)
                        {
                            First_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(First_Player_Score.Text));
                        }
                        else
                        {
                            Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                        }
                    }
                    else
                    {
                        Second_Player_Score.Text = Convert.ToString(1 + Convert.ToInt32(Second_Player_Score.Text));
                    }
                }
                New_Game_Start();
            }
            if (Turns == 9)
            {
                MessageBox.Show("          Draw!");
                Draw_Score.Text = Convert.ToString(1 + Convert.ToInt32(Draw_Score.Text));
                New_Game_Start();
            }
        }
    }
}
