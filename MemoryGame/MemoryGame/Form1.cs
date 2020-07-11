using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        // use for generate random number
        Random random = new Random();
        // use for store label icon codes
        List<string> icons = new List<string>()
        {
            "j","j","j","k",
            "k","k","H","H",
            "H","!","!","!"
        };
        // use for store clicked labels
        Label firstClicked, secondClicked, thirdClicked;

        public Form1()
        {
            InitializeComponent();
            // assign icons to labels randomly
            AssignIconsToSquares();
        }

        // this function will call when we click on a label :)
        private void label_Click(object sender, EventArgs e)
        {
            // if already select three labels then return from this function
            if (firstClicked != null && secondClicked != null && thirdClicked != null)
                return;

            // get clicked label
            Label clickedLabel = sender as Label;
            
            // if clicked area is not a label then return from this function
            if (clickedLabel == null)
                return;
            
            // clicked label/image have already visible then return from this function
            if (clickedLabel.ForeColor == Color.Black)
                return;
            
            // if we click on first invisible label/image  :D
            if(firstClicked == null)
            {
                // then store clicked label/image
                firstClicked = clickedLabel;
                // show image of clicked label
                firstClicked.ForeColor = Color.Black;
                // return from this function
                return;
            }
            
            // if we click on second invisible label/image
            if (secondClicked == null)
            {
                // then store clicked label/image
                secondClicked = clickedLabel;
                // show image of clicked label
                secondClicked.ForeColor = Color.Black;
                // return from this function
                return;
            }
            
            // if we click on third invisible label/image
            // then store clicked label/image
            thirdClicked = clickedLabel;
            // show image of clicked label
            thirdClicked.ForeColor = Color.Black;
            
            // check that use win or not
            CheckForWinner();

            // if all three clicked images are same then stay visible them and unselect them
            if (firstClicked.Text == secondClicked.Text && firstClicked.Text == thirdClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
                thirdClicked = null;
            }
            // otherwise start timer and hide them
            else timer1.Start();
        }

        // this function check that all images are visible or not, if all images are visible then user is winner
        private void CheckForWinner()
        {
            // use for store a label
            Label label;
            // loop for all labels/images
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                // get current label from table
                label = tableLayoutPanel1.Controls[i] as Label;
                // if current label is not visible then user is not winner, so go back from this function
                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }
            // show winner message
            MessageBox.Show("You matched all the icons! Congrats!");
            // close the application
            Close();
        }

        // this function pause selected all three images for some time, then it will hide them
        private void timer1_Tick(object sender, EventArgs e)
        {
            // stop the timer
            timer1.Stop();
            // hide the clicked labels
            firstClicked.ForeColor = Color.CornflowerBlue;
            secondClicked.ForeColor = Color.CornflowerBlue;
            thirdClicked.ForeColor = Color.CornflowerBlue;
            // unselect clicked label
            firstClicked = null;
            secondClicked = null;
            thirdClicked = null;
        }

        // this function randomly assign icons to all labels
        private void AssignIconsToSquares()
        {
            // use for store a label
            Label label;
            int randomNumber;
            // loop for all labels/images
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                // get current label from table
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;
                // generate a random number
                randomNumber = random.Next(0, icons.Count);
                // assign icon from icon list to current label randomly
                label.Text = icons[randomNumber];
                // remove current icon from icon list :)
                icons.RemoveAt(randomNumber);
                // Klaudia Mroczek 12592 
            }
        }

    }
}
