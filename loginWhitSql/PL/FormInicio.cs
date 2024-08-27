using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginWhitSql.PL
{
    public partial class FormInicio : Form
    {
        private Timer timer;
        private int progressValue = 0;
        public FormInicio()
        {
            InitializeComponent();
            this.Text = "Inicio";

            progresBar.Maximum = 100;
            progresBar.Minimum = 0;
            progresBar.Value = 0;


            timer = new Timer();
            timer.Interval = 40; // 4000 milisegundos = 4 segundos
            timer.Tick += timerTick;
            timer.Start();

        }

        private void timerTick(object sender, EventArgs e)
        {
            if (progressValue < 100)
            {
                progressValue += 1;
                progresBar.Value = progressValue;
            }
            else
            {
                timer.Stop(); // Detener el temporizador
                this.Hide(); // Ocultar el FormInicio

                // Mostrar el formulario principal
                Form1 formPrincipal = new Form1();
                formPrincipal.Show();
            }
        }
    }
}
