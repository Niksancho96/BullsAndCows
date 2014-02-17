using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BullsAndCow
{
    public partial class Form1 : Form
    {
        private int lenght = 4;
        private int bulls, cows;

        private string numbers = "123456789";
        private string generated;
        private string caption;
        private string message;

        public Form1()
        {
            InitializeComponent();
            genNumber();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            toolStripStatusLabel2.Text = "Текущо генерирано число: " + this.generated;
        }

        private string genNumber()
        {
            Random rand = new Random();
            int random = rand.Next(1, 5);
            string shuffle = new string(this.numbers.ToCharArray().OrderBy(s => (rand.Next(2) % 2) == 0).ToArray());
            this.generated = shuffle.Substring(0, this.lenght);
            toolStripStatusLabel2.Text = "Текущо генерирано число: " + this.generated;
            return this.generated;
        }

        private bool correctInput(string Input)
        {
            return (Input.Length < 4 || Input.Length == 0 || Input.Length > 4) ? true : false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.message = "Тази игра е разработена от Нико Митов! Версия 0.1 Alpha VoodooHeadsTV!";
            this.caption = "За играта!";
            MessageBox.Show(this.message, this.caption);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.message = "Компютъра генерира ново число!";
            this.caption = "Ново число";
            genNumber();
            MessageBox.Show(this.message, this.caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string getPlayerInput = textBox1.Text.ToString();
            if (correctInput(getPlayerInput) == true)
            {
                this.caption = "Грешен вход!";
                this.message = "Данните които сте въвели, са невалидни!";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.bulls = 0;
            this.cows = 0;

            if (String.Compare(getPlayerInput, this.generated) == 0)
            {
                this.bulls = 4;
                this.cows = 0;

                this.caption = "Победа!";
                this.message = "Вие познахте числото генерирано от компютъра!";
                
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (getPlayerInput[0] == this.generated[0]) this.bulls++;
                if (getPlayerInput[0] == this.generated[1] || getPlayerInput[0] == this.generated[2] || getPlayerInput[0] == this.generated[3]) this.cows++;
                if (getPlayerInput[1] == this.generated[1]) this.bulls++;
                if (getPlayerInput[1] == this.generated[0] || getPlayerInput[1] == this.generated[2] || getPlayerInput[1] == this.generated[3]) this.cows++;
                if (getPlayerInput[2] == this.generated[2]) this.bulls++;
                if (getPlayerInput[2] == this.generated[1] || getPlayerInput[2] == this.generated[0] || getPlayerInput[2] == this.generated[3]) this.cows++;
                if (getPlayerInput[3] == this.generated[3]) this.bulls++;
                if (getPlayerInput[3] == this.generated[1] || getPlayerInput[3] == this.generated[2] || getPlayerInput[3] == this.generated[0]) this.cows++;

                this.caption = "Резултат!";
                this.message = "Вие имате " + this.bulls + " бикове и " + this.cows + " крави!";
                MessageBox.Show(this.message, this.caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
