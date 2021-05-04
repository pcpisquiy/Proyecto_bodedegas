namespace P_2_PCPP_1168921
{
    partial class Envio_Automatico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label5 = new System.Windows.Forms.Label();
            this.nudCantidadMaterial = new System.Windows.Forms.NumericUpDown();
            this.cbtipoMaterial = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnenviar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Cantidad  de materiales";
            // 
            // nudCantidadMaterial
            // 
            this.nudCantidadMaterial.Location = new System.Drawing.Point(128, 49);
            this.nudCantidadMaterial.Name = "nudCantidadMaterial";
            this.nudCantidadMaterial.Size = new System.Drawing.Size(120, 20);
            this.nudCantidadMaterial.TabIndex = 20;
            // 
            // cbtipoMaterial
            // 
            this.cbtipoMaterial.FormattingEnabled = true;
            this.cbtipoMaterial.Items.AddRange(new object[] {
            "Materiales fríos",
            "Matriales frágiles",
            "Materiales normales"});
            this.cbtipoMaterial.Location = new System.Drawing.Point(128, 9);
            this.cbtipoMaterial.Name = "cbtipoMaterial";
            this.cbtipoMaterial.Size = new System.Drawing.Size(121, 21);
            this.cbtipoMaterial.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Tipo de materiales";
            // 
            // btnenviar
            // 
            this.btnenviar.Location = new System.Drawing.Point(324, 6);
            this.btnenviar.Name = "btnenviar";
            this.btnenviar.Size = new System.Drawing.Size(101, 48);
            this.btnenviar.TabIndex = 11;
            this.btnenviar.Text = "Aceptar";
            this.btnenviar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(418, 255);
            this.dataGridView1.TabIndex = 22;
            // 
            // Envio_Automatico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 342);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudCantidadMaterial);
            this.Controls.Add(this.cbtipoMaterial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnenviar);
            this.Name = "Envio_Automatico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Envio_Automatico";
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudCantidadMaterial;
        private System.Windows.Forms.ComboBox cbtipoMaterial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnenviar;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}