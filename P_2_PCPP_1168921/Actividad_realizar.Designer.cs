namespace P_2_PCPP_1168921
{
    partial class Envio_Manual
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
            this.btnenviar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtcoordenadasX = new System.Windows.Forms.TextBox();
            this.txtcoordenadasY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbrobot = new System.Windows.Forms.ComboBox();
            this.cbtipoMaterial = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudCantidadMaterial = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnenviar
            // 
            this.btnenviar.Location = new System.Drawing.Point(324, 12);
            this.btnenviar.Name = "btnenviar";
            this.btnenviar.Size = new System.Drawing.Size(101, 48);
            this.btnenviar.TabIndex = 0;
            this.btnenviar.Text = "Aceptar";
            this.btnenviar.UseVisualStyleBackColor = true;
            this.btnenviar.Click += new System.EventHandler(this.btnenviar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Coordenada en X";
            // 
            // txtcoordenadasX
            // 
            this.txtcoordenadasX.Location = new System.Drawing.Point(124, 44);
            this.txtcoordenadasX.Name = "txtcoordenadasX";
            this.txtcoordenadasX.Size = new System.Drawing.Size(120, 20);
            this.txtcoordenadasX.TabIndex = 2;
            // 
            // txtcoordenadasY
            // 
            this.txtcoordenadasY.Location = new System.Drawing.Point(124, 9);
            this.txtcoordenadasY.Name = "txtcoordenadasY";
            this.txtcoordenadasY.Size = new System.Drawing.Size(121, 20);
            this.txtcoordenadasY.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Coordenada en Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Robot";
            // 
            // cbrobot
            // 
            this.cbrobot.FormattingEnabled = true;
            this.cbrobot.Items.AddRange(new object[] {
            "RS (Robot de alta velocidad)",
            "RH (Robot de alta capacidad)",
            "RN (Robot estándar)"});
            this.cbrobot.Location = new System.Drawing.Point(124, 81);
            this.cbrobot.Name = "cbrobot";
            this.cbrobot.Size = new System.Drawing.Size(121, 21);
            this.cbrobot.TabIndex = 6;
            // 
            // cbtipoMaterial
            // 
            this.cbtipoMaterial.FormattingEnabled = true;
            this.cbtipoMaterial.Items.AddRange(new object[] {
            "Materiales fríos",
            "Matriales frágiles",
            "Materiales normales"});
            this.cbtipoMaterial.Location = new System.Drawing.Point(124, 118);
            this.cbtipoMaterial.Name = "cbtipoMaterial";
            this.cbtipoMaterial.Size = new System.Drawing.Size(121, 21);
            this.cbtipoMaterial.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tipo de materiales";
            // 
            // nudCantidadMaterial
            // 
            this.nudCantidadMaterial.Location = new System.Drawing.Point(124, 158);
            this.nudCantidadMaterial.Name = "nudCantidadMaterial";
            this.nudCantidadMaterial.Size = new System.Drawing.Size(120, 20);
            this.nudCantidadMaterial.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cantidad  de materiales";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 184);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(434, 255);
            this.dataGridView1.TabIndex = 23;
            // 
            // Envio_Manual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 461);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudCantidadMaterial);
            this.Controls.Add(this.cbtipoMaterial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbrobot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtcoordenadasY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtcoordenadasX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnenviar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Envio_Manual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actividad_realizar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Envio_Manual_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnenviar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtcoordenadasX;
        private System.Windows.Forms.TextBox txtcoordenadasY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbrobot;
        private System.Windows.Forms.ComboBox cbtipoMaterial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudCantidadMaterial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}