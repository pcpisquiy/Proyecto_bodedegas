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
    public partial class ACTIVIDAD_REALIZAR : Form
    {
        private Button btnemanual;
        private Button btneautomatico;
    
        public ACTIVIDAD_REALIZAR()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnemanual = new System.Windows.Forms.Button();
            this.btneautomatico = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnemanual
            // 
            this.btnemanual.Location = new System.Drawing.Point(54, 74);
            this.btnemanual.Name = "btnemanual";
            this.btnemanual.Size = new System.Drawing.Size(75, 41);
            this.btnemanual.TabIndex = 0;
            this.btnemanual.Text = "Envio Manual";
            this.btnemanual.UseVisualStyleBackColor = true;
            this.btnemanual.Click += new System.EventHandler(this.btnemanual_Click);
            // 
            // btneautomatico
            // 
            this.btneautomatico.Location = new System.Drawing.Point(214, 74);
            this.btneautomatico.Name = "btneautomatico";
            this.btneautomatico.Size = new System.Drawing.Size(75, 41);
            this.btneautomatico.TabIndex = 1;
            this.btneautomatico.Text = "Envio Automaico";
            this.btneautomatico.UseVisualStyleBackColor = true;
            this.btneautomatico.Click += new System.EventHandler(this.btneautomatico_Click);
            // 
            // ACTIVIDAD_REALIZAR
            // 
            this.ClientSize = new System.Drawing.Size(368, 215);
            this.Controls.Add(this.btneautomatico);
            this.Controls.Add(this.btnemanual);
            this.Name = "ACTIVIDAD_REALIZAR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Escoje una Actividad";
            this.ResumeLayout(false);

        }


        private void btneautomatico_Click(object sender, EventArgs e)
        {
            Envio_Automatico eautomatico = new Envio_Automatico();
            eautomatico.ShowDialog();
            this.Hide();
        }

        private void btnemanual_Click(object sender, EventArgs e)
        {
            Envio_Manual emanual = new Envio_Manual();
            emanual.ShowDialog();
            this.Hide();
        }
    }
}
