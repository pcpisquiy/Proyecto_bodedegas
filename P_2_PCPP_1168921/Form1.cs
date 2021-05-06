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
        int filaRobot1 = 0;
        int columnaRobot1 = 0;
        string valorAnteriorRobot = "";
        #endregion
        public Form1()
        {
            InitializeComponent();
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
                openFileDialog1.ShowDialog();
                FileToRead = openFileDialog1.FileName;
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
                            conf += Line + ",";
                            //por cada linea leida suma una columna
                            filas++;
                            for (int l = 0; l < conf.Length; l++)
                            {
                                if (conf[l].ToString() == "," || conf[l].ToString() == "")
                                {
                                    columnas++;
                                }
                            }
                            contador++;

                        }
                        //por cada linea leida suma una columna
                        else
                        {
                            conf += Line + ",";
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
            DGVLAYAUT.Width = 60 * columnas + 40;
            DGVLAYAUT.Height = 60 * filas + 40;
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
                        if (cadena_conf[i].ToString() == ",")
                        {
                            cadena_guardar = "";
                            posicion_matrizx++;
                        }
                        else
                        {
                            cadena_guardar += cadena_conf[i].ToString();
                        }
                        //guarda el caracter en la matriz
                        if (cadena_guardar != "," && cadena_guardar != "")
                        {
                            if (cadena_guardar.ToUpper().Contains("E") || cadena_guardar.ToUpper().Contains("C") || cadena_guardar.ToUpper().Contains("N") || cadena_guardar.ToUpper().Contains("F") || cadena_guardar.ToUpper().Contains("P"))
                            {
                                configuracion[posicion_matrizy, posicion_matrizx] = cadena_guardar.Substring(0, 1);
                            }
                            if (cadena_guardar == "rs" || cadena_guardar == "R++" || cadena_guardar == "R+-"  || cadena_guardar == "R--")
                            {
                                configuracion[posicion_matrizy, posicion_matrizx] = cadena_guardar.Substring(0, 3);
                            }
                            //guarda las capacidades de las bodegas y ignora los pasillos
                            if (cadena_guardar == "p" || cadena_guardar == "P" || cadena_guardar == "E" || cadena_guardar == "R++"  || cadena_guardar == "R+-" || cadena_guardar == "R--")
                            {
                                capacidad[posicion_matrizy, posicion_matrizx] = 0;
                            }
                            else
                            {
                                //llenar la matriz capacidad para poder saber cuantos elementos tiene
                                if (cadena_guardar.Substring(0, cadena_guardar.Length - 1) == "#" || cadena_guardar.Substring(0, cadena_guardar.Length - 1) == " ")
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
                            Llenar_matriz_movimiento();
                            Llenar_GRILLA();
                            break;
                           
                        }
                    }
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
            if (tipo.ToUpper() == "F")
            {
                return imagenes_interfaz.Images[0];


            }
            else if (tipo.ToUpper() == "C")
            {
                return imagenes_interfaz.Images[1];

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
            else if (tipo.ToUpper() == "R++")
            {
                return imagenes_interfaz.Images[6];


            }
            else if (tipo.ToUpper() == "R+-")
            {
                return imagenes_interfaz.Images[7];


            }
            else if (tipo.ToUpper() == "R--")
            {
                return imagenes_interfaz.Images[8];


            }
            else
            {
                MessageBox.Show("ERROR INGRESO UN ROBOT INVALIDO");
                Application.Exit();
                return null;
            }

        }


        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar_Configuracion();

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
