﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaTilaus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tilaaBT_Click(object sender, EventArgs e)
        {
            Form tilaus = new TilausForm();
            tilaus.Show();
            this.Hide();

        }

        private void poisBT_Click(object sender, EventArgs e)
        {
            DialogResult sulje;
            sulje = MessageBox.Show("Haluatko varmasti lopettaa tilaamisen ja poistua?", "Tilauksen lopettaminen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sulje == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
