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
        string[,] configuracion;
        int filas = 0;
        int columnas = 0;
 
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
                if (ctrl is PictureBox && ctrl != robot && ctrl.Enabled==false)
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
                openFileDialog1.Filter = "txt files (*.txt)|*.txt";
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
                    if (filas > 10 && columnas > 10 || filas < 1 && columnas < 1)
                    {
                        MessageBox.Show("Configuracion invalida, Verifique que tenga 1 columnas y 1 filas como minimo o 10 columnas y 10 filas como maximo en la configuracion");
                        Application.Exit();

                    }

                }
                //con esto validamos que se leyó el archivo
                if (conf != "")
                {
                    configuracion = new string[filas, columnas];
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

        private void Cargar_Configuracion()
        {
            bool estado = false;
            string cadena_conf = leer_archivo(ref estado).ToString();
            string cadena_guardar = "";
            int posicion_matrizx = 0;
            int posicion_matrizy = 0;
            if (estado)
            {
                //0123456789
                //hola mundo
                //p n p w

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
                            configuracion[posicion_matrizy, posicion_matrizx] = cadena_guardar.ToString();
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
                    //descompone la matriz para colorear los picbox
                    for (int y = 0; y < filas; y++)
                    {
                        for (int x = 0; x < columnas; x++)
                        {
                            // utliza reflexion para poder convertir un string a picturebox ya que tienen un nombre que tiene la raiz en común
                            bool pasillo = true;
                            string pbconf_name = "Pbconfi" + y.ToString() + "_" + x.ToString();
                            PictureBox picconf = this.Controls.Find(pbconf_name, true).FirstOrDefault() as PictureBox;
                            picconf.BackColor = Codigo_color(configuracion[y, x].ToString(), ref pasillo);
                            picconf.Enabled = pasillo;
                            picconf.Visible = true;

                        }
                    }

                    MessageBox.Show("Configuracion cargada exitosamente", "GESTOR BODEGA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("El archivo que contiene la configuracion no se encuentra", "GESTOR BODEGA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        //funcion que retorna colores de pende el tipo de cuadro 
        private Color Codigo_color(string Estanteria, ref bool pasillo)
        {
            if (Estanteria.Contains("c") || Estanteria.Contains("C"))
            {
                pasillo = !true;
                return Color.SkyBlue;

            }
            else if (Estanteria.Contains("f") || Estanteria.Contains("F"))
            {
                pasillo = !true;
                return Color.Coral;

            }
            else if (Estanteria.Contains("N") || Estanteria.Contains("n"))
            {
                pasillo = !true;
                return Color.Yellow;

            }
            else if (Estanteria.Contains("w") || Estanteria.Contains("W"))
            {
                pasillo = !true;
                return Color.Black;

            }
            else if ((Estanteria.Contains("e") || Estanteria.Contains("E")))
            {
                pasillo = !false;
                return Color.White;

            }
            else if ((Estanteria.Contains("p") || Estanteria.Contains("P")))
            {
                pasillo = !false;
                return Color.Gray;

            }
            else
            {
                pasillo = !true;
                return Color.Transparent;

            }

        }
#endregion 

        private void Form1_Load(object sender, EventArgs e)
        {
         Cargar_Configuracion();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //int px = r1.Location.X + 77;
            //int py= r1.Location.Y ;
            //r1.Location= new Point(px, py );
        }

     
    }

}
