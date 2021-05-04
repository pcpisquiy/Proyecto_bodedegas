using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;
using System.Reflection;

namespace P_2_PCPP_1168921
{
    public partial class Form1 : Form
    {
        #region Variables_globales
        string[,] configuracion;
        int[,] capacidad;
        string[,] movimiento;
        int filas = 0;
        int columnas = 0;
        int filas_movimiento = 0;
        List<Robot> robots;
        int filaRobot1 = 0;
        int columnaRobot1 = 0;
        string valorAnteriorRobot = "";
        #endregion
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int posx = r1.Location.X;
            int posy = r1.Location.Y;
            int movposy = 0;
            int movposx = 0;
            Keys tecla = e.KeyCode;
            switch (tecla)
            {
                case Keys.Down:
                    posy += 5;
                    r1.Location = new Point(posx, posy);
                    movposy = 5;
                    chocar(r1, posx, posy, movposy, movposx);
                    break;
                case Keys.Up:
                    posy -= 5;
                    r1.Location = new Point(posx, posy);
                    movposy = -5;
                    chocar(r1, posx, posy, movposy, movposx);
                    break;
                case Keys.Left:
                    posx -= 5;
                    r1.Location = new Point(posx, posy);
                    movposx = -5;
                    chocar(r1, posx, posy, movposy, movposx);
                    break;
                case Keys.Right:
                    posx += 5;
                    r1.Location = new Point(posx, posy);
                    movposx = 5;
                    chocar(r1, posx, posy, movposy, movposx);
                    break;
            }


        }
        public void chocar(PictureBox robot, int posx, int posy, int movposy, int movposx)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is PictureBox && ctrl != robot && ctrl.Enabled == false)
                {
                    if (robot.Bounds.IntersectsWith(ctrl.Bounds))
                    {
                        posx -= movposx;
                        posy -= movposy;
                        robot.Location = new Point(posx, posy);
                    }
                }
            }
        }
        #region Carga la configuracion del layaout

        public string leer_archivo(ref bool estado_accion)
        {
            estado_accion = false;
            try
            {
                //Abre un navegador para buscar el archivo
                MessageBox.Show("Busque el archivo donde encuetra su configuración");
                string FileToRead = "";
                //openFileDialog1.Filter = "txt files (*.txt)|*.txt";
                // openFileDialog1.ShowDialog();
                // FileToRead = openFileDialog1.FileName;
                FileToRead = "C:\\Users\\pcpis\\Desktop\\Configuracion.txt";
                //lee y decompone el archivo en lineas
                string conf = "";
                using (StreamReader ReaderObject = new StreamReader(FileToRead))
                {
                    string Line;
                    int contador = 0;
                    //lee cada linea del archivo 
                    while ((Line = ReaderObject.ReadLine()) != null)
                    {
                        //un contador para poder obtener el numero de filas al momento de leer la primera linea, esto lo hace al contar los espacios en blanco 
                        if (contador == 0)
                        {
                            //agrega un espacio en blanco(se pegan las linea si no se coloca el espacio en blanco)y la linea leida del archivo
                            conf += Line + " ";
                            //por cada linea leida suma una columna
                            filas++;
                            for (int l = 0; l < conf.Length; l++)
                            {
                                if (conf[l].ToString() == " " || conf[l].ToString() == "")
                                {
                                    columnas++;
                                }
                            }
                            contador++;

                        }
                        //por cada linea leida suma una columna
                        else
                        {
                            conf += Line + " ";
                            filas++;

                        }
                    }
                    //verifica que no exeda de los limites y tenga el minimo de de filas y columnas 
                    if (filas > 10 || columnas > 10 || filas == 0 || columnas == 0)
                    {
                        MessageBox.Show("Configuracion invalida, Verifique que tenga 1 columnas y 1 filas como minimo o 10 columnas y 10 filas como maximo en la configuracion");
                        Application.Exit();

                    }

                }
                //con esto validamos que se leyó el archivo
                if (conf != "")
                {
                    configuracion = new string[filas, columnas];
                    capacidad = new int[filas, columnas];
                    estado_accion = true;
                }
                return conf;
            }
            catch
            {
                estado_accion = false;
                return "";
            }
        }
        public void Llenar_matriz_movimiento()
        {
            movimiento = new string[filas_movimiento, 5];
            int fil = 0;
            int col = 0;

            for (int n = 0; n < movimiento.GetLength(0); n += 0)
            {

                if (configuracion[fil, col] == "C" || configuracion[fil, col] == "N" || configuracion[fil, col] == "F" || configuracion[fil, col] == "c" || configuracion[fil, col] == "f" || configuracion[fil, col] == "n")
                {

                    movimiento[n, 0] = fil.ToString();
                    movimiento[n, 1] = col.ToString();
                    movimiento[n, 2] = capacidad[fil, col].ToString();
                    movimiento[n, 3] = configuracion[fil, col];
                    movimiento[n, 4] = "0";
                    n++;

                }
                col++;
                if (col == columnas)
                {
                    fil++;
                    col = 0;
                }
                if (fil == filas)
                {
                    break;
                }


            }
        }
        private void Llenar_GRILLA()
        {
            //DGVLAYAUT.RowCount = filas;
            //DGVLAYAUT.ColumnCount = columnas;

            DGVLAYAUT.Width = 60 * columnas + 40;
            DGVLAYAUT.Height = 60 * filas + 40;

            dataGridView2.RowCount = movimiento.GetLength(0);
            dataGridView2.ColumnCount = 5;
            for (int y = 0; y < columnas; y++)
            {
                DataGridViewColumn columnas_grid = new DataGridViewImageColumn();
                DGVLAYAUT.Columns.Add(columnas_grid);
            }
            DGVLAYAUT.Rows.Add(filas);


            for (int y = 0; y < filas; y++)
            {
                DGVLAYAUT.Rows[y].HeaderCell.Value = y.ToString();

                for (int x = 0; x < columnas; x++)
                {
                    DGVLAYAUT.Rows[y].Cells[x].Value = Cargar_imagen(configuracion[y, x]);
                    DGVLAYAUT.Rows[y].Height = 55;
                    DGVLAYAUT.Columns[x].Width = 55;

                }
            }
            for (int y = 0; y < filas; y++)
            {
                for (int x = 0; x < columnas; x++)
                {
                    if (configuracion[y, x] == "RS")
                    {
                        filaRobot1 = y;
                        columnaRobot1 = x;

                    }

                }
            }
            foreach (DataGridViewColumn column in DGVLAYAUT.Columns)
            {

                column.HeaderText = column.Index.ToString();
            }

            for (int posY = 0; posY < movimiento.GetLength(0); posY++)
            {

                for (int posX = 0; posX < 5; posX++)
                {
                    dataGridView2.Rows[posY].Cells[posX].Value = movimiento[posY, posX].ToString();

                }
            }

        }

        private void Cargar_Configuracion()
        {
            filas = 0;
            columnas = 0;
            filas_movimiento = 0;
            bool estado = false;
            string cadena_conf = leer_archivo(ref estado).ToString();
            string cadena_guardar = "";
            int posicion_matrizx = 0;
            int posicion_matrizy = 0;
            int capacidad_guardar = 10;
            if (estado)
            {

                try
                {  //decompne la cadena de caracteres para llenar la matriz
                    for (int i = 0; i < cadena_conf.Length; i++)
                    {
                        if (cadena_conf[i].ToString() == " ")
                        {
                            cadena_guardar = "";
                            posicion_matrizx++;
                        }
                        else
                        {
                            cadena_guardar += cadena_conf[i].ToString();
                        }
                        //guarda el caracter en la matriz
                        if (cadena_guardar != " " && cadena_guardar != "")
                        {
                            if (cadena_guardar.Contains("E") || cadena_guardar.Contains("e") || cadena_guardar.Contains("C") || cadena_guardar.Contains("c") || cadena_guardar.Contains("N") || cadena_guardar.Contains("n") || cadena_guardar.Contains("F") || cadena_guardar.Contains("f") || cadena_guardar.Contains("P") || cadena_guardar.Contains("p") || cadena_guardar.Contains("w") || cadena_guardar.Contains("W"))
                            {
                                configuracion[posicion_matrizy, posicion_matrizx] = cadena_guardar.Substring(0, 1);
                            }
                            if (cadena_guardar == "rs" || cadena_guardar == "RS" || cadena_guardar == "RH" || cadena_guardar == "rh" || cadena_guardar == "RN" || cadena_guardar == "rn")
                            {
                                configuracion[posicion_matrizy, posicion_matrizx] = cadena_guardar.Substring(0, 2);
                            }
                            //guarda las capacidades de las bodegas y ignora los pasillos
                            if (cadena_guardar == "p" || cadena_guardar == "P" || cadena_guardar == "E" || cadena_guardar == "e" || cadena_guardar == "w" || cadena_guardar == "W" || cadena_guardar == "RS" || cadena_guardar == "rs" || cadena_guardar == "RH" || cadena_guardar == "rh" || cadena_guardar == "RN" || cadena_guardar == "rn")
                            {
                                capacidad[posicion_matrizy, posicion_matrizx] = 0;
                            }
                            else
                            {
                                //llenar la matriz capacidad para poder saber cuantos elementos tiene
                                if (cadena_guardar.Substring(1, cadena_guardar.Length - 1) == "")
                                {
                                    capacidad[posicion_matrizy, posicion_matrizx] = capacidad_guardar;
                                }
                                else
                                {
                                    capacidad_guardar = Convert.ToInt32(cadena_guardar.Substring(1, cadena_guardar.Length - 1));
                                    capacidad[posicion_matrizy, posicion_matrizx] = capacidad_guardar;
                                    capacidad_guardar = 10;
                                }

                            }
                        }
                        //detiene el conteo de columnas al terminar una fila 
                        if (posicion_matrizx == columnas)
                        {
                            posicion_matrizy++;
                            posicion_matrizx = 0;
                        }
                        //rompe el bucle si llega al limite de filas 
                        if (posicion_matrizy == filas)
                        {
                            break;
                        }
                    }

                    for (int y = 0; y < configuracion.GetLength(0); y++)
                    {
                        for (int x = 0; x < configuracion.GetLength(1); x++)
                        {
                            if (configuracion[y, x] == "F" || configuracion[y, x] == "f" || configuracion[y, x] == "c" || configuracion[y, x] == "C" || configuracion[y, x] == "N" || configuracion[y, x] == "n")
                            {
                                filas_movimiento++;
                            }
                        }
                    }

                    Llenar_matriz_movimiento();
                    Llenar_GRILLA();


                    MessageBox.Show("Configuracion cargada exitosamente", "GESTOR BODEGA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("El archivo que contiene la configuracion no se encuentra", "GESTOR BODEGA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private Image Cargar_imagen(string tipo)
        {
            if (tipo == "F" || tipo == "f")
            {
                return imagenes_interfaz.Images[0];


            }
            else if (tipo.ToUpper() == "C")
            {
                return imagenes_interfaz.Images[1];

            }
            else if (tipo.ToUpper() == "W")
            {
                return imagenes_interfaz.Images[2];
            }
            else if (tipo.ToUpper() == "E")
            {
                return imagenes_interfaz.Images[3];
            }
            else if (tipo.ToUpper() == "N")
            {
                return imagenes_interfaz.Images[4];

            }
            else if (tipo.ToUpper() == "P")
            {
                return imagenes_interfaz.Images[5];


            }
            else if (tipo.ToUpper() == "RH")
            {
                return imagenes_interfaz.Images[6];


            }
            else if (tipo.ToUpper() == "RN")
            {
                return imagenes_interfaz.Images[7];


            }
            else if (tipo.ToUpper() == "RS")
            {
                return imagenes_interfaz.Images[8];


            }
            else
            {
                MessageBox.Show("ERROR INGRESO UN ROBOT INVALIDO");
                return null;
                Application.Exit();

            }

        }


        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar_Configuracion();
            //robots = new List<Robot> { new Robot { estado = true, Width = 55, Height = 55, imagen = Properties.Resources.RH, nombre = "Robot1" } };
            //robots.Add(new Robot { estado = true, Width = 55, Height = 55, imagen = Properties.Resources.RN, nombre = "Robot2" });
            //robots.Add(new Robot { estado = true, Width = 55, Height = 55, imagen = Properties.Resources.RX, nombre = "Robot3" });
            //robots.Add(new Robot { estado = false, Width = 55, Height = 55, imagen = Properties.Resources.RS, nombre = "Robot4" });
            //Bitmap img;
            //img = new Bitmap(@"c:\images\mousepad.jpg");
            //// Create the DGV with an Image column
            //DataGridView dgv = new DataGridView();
            //this.Controls.Add(dgv);
            //DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
            //dgv.Columns.Add(imageCol);
            //// Add a row and set its value to the image
            //dgv.Rows.Add();
            //dgv.Rows[0].Cells[0].Value = img;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ACTIVIDAD_REALIZAR arealizar = new ACTIVIDAD_REALIZAR();
            arealizar.ShowDialog();

        }

        private void HORA_ACTUAL_Tick(object sender, EventArgs e)
        {
            label1.Text = "FECHA: " + DateTime.Now.Date.ToShortDateString() + " HORA: " + DateTime.Now.ToString("HH:mm:ss");
        }

        private void iNICIARNUEVABODEGAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Configuracion();
        }
        public void MoverRobotAleatoriamente()
        {

            Random rnd = new Random(DateTime.Now.Millisecond);
            switch (rnd.Next() % 4)
            {
                case 0://arriba

                    if (filaRobot1 > 0)
                    {
                        filaRobot1--;
                        valorAnteriorRobot = configuracion[filaRobot1, columnaRobot1];
                    }
                    break;
                case 1://abajo
                    if (filaRobot1 < filas - 1)
                    {
                        filaRobot1++;
                        valorAnteriorRobot = configuracion[filaRobot1, columnaRobot1];
                    }
                    break;
                case 2://izquierda
                    if (columnaRobot1 > 0)
                    {
                        columnaRobot1--;
                        valorAnteriorRobot = configuracion[filaRobot1, columnaRobot1];
                    }
                    break;
                case 3://derecha
                    if (columnaRobot1 < columnas - 1)
                    {
                        columnaRobot1++;
                        valorAnteriorRobot = configuracion[filaRobot1, columnaRobot1];
                    }
                    break;
            }

        }
        private void Robot_Tick(object sender, EventArgs e)
        {
            MoverRobotAleatoriamente();

            configuracion[filaRobot1, columnaRobot1] = "rs";
            Llenar_GRILLA();
        }



    }

}
