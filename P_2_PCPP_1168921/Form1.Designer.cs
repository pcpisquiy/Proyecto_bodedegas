namespace P_2_PCPP_1168921
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Robot = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.DGVLAYAUT = new System.Windows.Forms.DataGridView();
            this.r1 = new System.Windows.Forms.PictureBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.HORA_ACTUAL = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iNICIARNUEVABODEGAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagenes_interfaz = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGVLAYAUT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Robot
            // 
            this.Robot.Interval = 1000;
            this.Robot.Tick += new System.EventHandler(this.Robot_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(794, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 35);
            this.button1.TabIndex = 102;
            this.button1.Text = "Realizar accion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DGVLAYAUT
            // 
            this.DGVLAYAUT.AllowUserToAddRows = false;
            this.DGVLAYAUT.AllowUserToDeleteRows = false;
            this.DGVLAYAUT.AllowUserToResizeColumns = false;
            this.DGVLAYAUT.AllowUserToResizeRows = false;
            this.DGVLAYAUT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVLAYAUT.Location = new System.Drawing.Point(126, 97);
            this.DGVLAYAUT.MultiSelect = false;
            this.DGVLAYAUT.Name = "DGVLAYAUT";
            this.DGVLAYAUT.ReadOnly = true;
            this.DGVLAYAUT.Size = new System.Drawing.Size(466, 290);
            this.DGVLAYAUT.TabIndex = 103;
            // 
            // r1
            // 
            this.r1.BackColor = System.Drawing.Color.Transparent;
            this.r1.Image = global::P_2_PCPP_1168921.Properties.Resources.RH;
            this.r1.Location = new System.Drawing.Point(27, 88);
            this.r1.Name = "r1";
            this.r1.Size = new System.Drawing.Size(38, 44);
            this.r1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.r1.TabIndex = 31;
            this.r1.TabStop = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(683, 97);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(515, 290);
            this.dataGridView2.TabIndex = 104;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 31);
            this.label1.TabIndex = 105;
            this.label1.Text = "label1";
            // 
            // HORA_ACTUAL
            // 
            this.HORA_ACTUAL.Enabled = true;
            this.HORA_ACTUAL.Interval = 1000;
            this.HORA_ACTUAL.Tick += new System.EventHandler(this.HORA_ACTUAL_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iNICIARNUEVABODEGAToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1249, 24);
            this.menuStrip1.TabIndex = 106;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // iNICIARNUEVABODEGAToolStripMenuItem
            // 
            this.iNICIARNUEVABODEGAToolStripMenuItem.Name = "iNICIARNUEVABODEGAToolStripMenuItem";
            this.iNICIARNUEVABODEGAToolStripMenuItem.Size = new System.Drawing.Size(149, 20);
            this.iNICIARNUEVABODEGAToolStripMenuItem.Text = "INICIAR NUEVA BODEGA";
            this.iNICIARNUEVABODEGAToolStripMenuItem.Click += new System.EventHandler(this.iNICIARNUEVABODEGAToolStripMenuItem_Click);
            // 
            // imagenes_interfaz
            // 
            this.imagenes_interfaz.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagenes_interfaz.ImageStream")));
            this.imagenes_interfaz.TransparentColor = System.Drawing.Color.Transparent;
            this.imagenes_interfaz.Images.SetKeyName(0, "fragiles.png");
            this.imagenes_interfaz.Images.SetKeyName(1, "Frios.png");
            this.imagenes_interfaz.Images.SetKeyName(2, "MUROS.png");
            this.imagenes_interfaz.Images.SetKeyName(3, "entrada.png");
            this.imagenes_interfaz.Images.SetKeyName(4, "normales.png");
            this.imagenes_interfaz.Images.SetKeyName(5, "pasillos.png");
            this.imagenes_interfaz.Images.SetKeyName(6, "RH.png");
            this.imagenes_interfaz.Images.SetKeyName(7, "RN.png");
            this.imagenes_interfaz.Images.SetKeyName(8, "RS.png");
            this.imagenes_interfaz.Images.SetKeyName(9, "RX.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 734);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.r1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.DGVLAYAUT);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DGVLAYAUT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox r1;
        private System.Windows.Forms.Timer Robot;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView DGVLAYAUT;
        public System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer HORA_ACTUAL;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iNICIARNUEVABODEGAToolStripMenuItem;
        private System.Windows.Forms.ImageList imagenes_interfaz;
    }
}

