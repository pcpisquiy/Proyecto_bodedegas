using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace P_2_PCPP_1168921
{
    public partial class Envio_Manual : Form
    {
        public Envio_Manual()
        {
            InitializeComponent();
        }
        private void btnenviar_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.Rows.Add(txtcoordenadasY.Text, txtcoordenadasX.Text, cbrobot.Text, cbtipoMaterial.Text, nudCantidadMaterial.Value.ToString());
        }

        private void Envio_Manual_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 frm1 = new Form1();
            //frm1.dataGridView3.ColumnCount = 5;
            //frm1.dataGridView3.Rows.Add();

            //List<DataGridViewRow> datos = dataGridView1.Rows.Cast<DataGridViewRow>().ToList();
            //frm1.actualizar_grid(txtcoordenadasY.Text, txtcoordenadasX.Text, cbrobot.Text, cbtipoMaterial.Text, nudCantidadMaterial.Value.ToString());
        //    MessageBox.Show("FFFF");
        }
    }
}
