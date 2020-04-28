using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calc
{
    public partial class Kalkulator : Form
    {
        public Kalkulator()
        {
            InitializeComponent();
        }
        double result = 0;              // przechowuje wynik po wykonaniu dzialan
        double number;                  // wprowadzamy liczbe
        string dzialanie;               // wybor dzialania
        int flagaCzyszczenie = 0;       // zmienna dodatkowa, przy jej pomocy spełniamy warunek czyszczenia
                                        // wyniku, po wprowadzeniu znaku dzialania
        int flagaPoWyniku = 0;          // dzięki tej fladze ustawiamy number na stala wartość

        private void btn_Click(object sender, EventArgs e)
        {
            if (tbWynik.Text != "0" && flagaCzyszczenie == 1)     //jeśli na wyświetlaczu jest mamy jakieś wartości
                tbWynik.Clear();                                // to je czyścimy
            Button btn = (Button)sender;                        // wprowadzamy wartości na wyświetlacz
            tbWynik.Text += btn.Tag.ToString();
            flagaCzyszczenie = 0;
        }

        private void btnOperators_Click(object sender, EventArgs e)
        {
            flagaCzyszczenie = 1;
            btnClearOne.Enabled = true;                           // odblokowanie pojedynczego kasowania
            number = double.Parse(tbWynik.Text);                  //zapisywanie liczby z ekranu do zmiennej number


            if (result == 0 || flagaPoWyniku == 0)
            {
                dzialanie = "";
                result = number;
                lblDzialania.Text = number.ToString();
                number = 0;
            }
            switch (dzialanie)
            {
                case "+":
                    result += number;
                    break;
                case "-":
                    result -= number;
                    break;
                case "*":
                    result *= number;
                    break;
                case "/":
                    result /= number;
                    break;
                default:
                    break;
            }
            Button btnOperators = (Button)sender;
            dzialanie = btnOperators.Tag.ToString();              //wybieranie dzialania


            tbWynik.Text = result.ToString();
            if (number == 0)
            {
                lblDzialania.Text += " " + dzialanie;
            }
            else
            {
                lblDzialania.Text += number + " " + dzialanie;
            }
            flagaPoWyniku = 1;
        }

        private void btnWynik_Click(object sender, EventArgs e)
        {
            lblDzialania.Text = null;                               // czyszczenie górnego działania

            if (flagaPoWyniku == 1)
            {
                number = double.Parse(tbWynik.Text);
            }
            switch (dzialanie)
            {
                case ("+"):
                    tbWynik.Text = (result + number).ToString();
                    result += number;
                    break;
                case ("-"):
                    tbWynik.Text = (result - number).ToString();
                    result -= number;
                    break;
                case ("*"):
                    tbWynik.Text = (result * number).ToString();
                    result *= number;
                    break;
                case ("/"):
                    tbWynik.Text = (result / number).ToString();
                    result /= number;
                    break;
                default:
                    break;
            }
            flagaPoWyniku = 0;
            btnClearOne.Enabled = false;                    // zablokowanie pojedynczego kasowania
        }

        private void btnClearLine_Click(object sender, EventArgs e)
        {
            tbWynik.Clear();                                // czyszczenie całej linijki
            btnClearOne.Enabled = true;                     // odblokowanie pojedynczego kasowania
        }

        private void btnClearConsol_Click(object sender, EventArgs e)
        {
            tbWynik.Clear();                                // czyszczenie wszystkiego
            result = 0;
            number = 0;
            dzialanie = "";
            lblDzialania.Text = "";
            btnClearOne.Enabled = true;                     // odblokowanie pojedynczego kasowania
        }

        private void btnClearOne_Click(object sender, EventArgs e)
        {
            if (tbWynik.Text.Length > 0)
            {
                string returner = tbWynik.Text.Remove(tbWynik.Text.Length - 1, 1);      //usuwanie ostaniego znaku
                tbWynik.Text = returner;
            }
        }
    }
}
