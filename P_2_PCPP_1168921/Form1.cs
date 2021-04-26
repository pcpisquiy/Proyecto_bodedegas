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
        int filas = 0;
        int columnas = 0;
        string estanteria = "";
        string tipo_robot = "";
        int cont_rs = 1, cont_rh = 1, cont_rn = 1;
        string pbconf_name="";
        bool pasillo = true;
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

        private void Cargar_Configuracion()
        {
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
                            configuracion[posicion_matrizy, posicion_matrizx] = cadena_guardar.ToString();
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
                    dataGridView1.RowCount = filas;
                    dataGridView1.ColumnCount = columnas;
                    dataGridView2.RowCount = filas;
                    dataGridView2.ColumnCount = columnas;
                    //descompone la matriz para colorear los picbox
                    for (int y = 0; y < filas; y++)
                    {
                        for (int x = 0; x < columnas; x++)
                        {

                            string dato_configuracion=configuracion[y, x].ToString();
                            if (dato_configuracion == "RS" || dato_configuracion == "rs" || dato_configuracion == "RH" || dato_configuracion == "rh" || dato_configuracion == "RN" || dato_configuracion == "rn")
                            {
                                // utliza reflexion para poder convertir un string a picturebox ya que tienen un nombre que tiene la raiz en común
                                pbconf_name = "Pbconfi" + y.ToString() + "_" + x.ToString();
                                PictureBox picconf = this.Controls.Find(pbconf_name, true).FirstOrDefault() as PictureBox;
                                picconf.BackColor = Codigo_color("P", ref pasillo);
                                picconf.Enabled = pasillo;
                                picconf.Visible = true;
                                //añade picture box en tiempo de ejecicion para poder añadir los robors que el usuario queira
                                int posx = picconf.Location.X;
                                int posy = picconf.Location.Y;
                                Tipo_Robot(dato_configuracion,ref tipo_robot);
                                PictureBox robot = new PictureBox();
                                Cargar_imagen_Tipo_Robot(dato_configuracion,ref robot, posx, posy);
                                this.Controls.Add(robot);
                                robot.BringToFront();
                            }
                            else {
                                // utliza reflexion para poder convertir un string a picturebox ya que tienen un nombre que tiene la raiz en común
                                pbconf_name = "Pbconfi" + y.ToString() + "_" + x.ToString();
                                PictureBox picconf = this.Controls.Find(pbconf_name, true).FirstOrDefault() as PictureBox;
                                picconf.BackColor = Codigo_color(dato_configuracion, ref pasillo);
                                picconf.Enabled = pasillo;
                                picconf.Visible = true;
                            }
                            


                            dataGridView1.Rows[y].Cells[x].Value = configuracion[y, x].ToString();
                            dataGridView2.Rows[y].Cells[x].Value = capacidad[y, x].ToString();

                        

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
                pasillo = false;
                return Color.SkyBlue;

            }
            else if (Estanteria.Contains("f") || Estanteria.Contains("F"))
            {
                pasillo = false;
                return Color.Coral;

            }
            else if (Estanteria.Contains("N") || Estanteria.Contains("n"))
            {
                pasillo = false;
                return Color.Yellow;

            }
            else if (Estanteria.Contains("w") || Estanteria.Contains("W"))
            {
                pasillo = false;
                return Color.Black;

            }
            else if ((Estanteria.Contains("e") || Estanteria.Contains("E")))
            {
                pasillo = true;
                return Color.White;

            }
            else if ((Estanteria.Contains("p") || Estanteria.Contains("P")))
            {
                pasillo = true;
                return Color.Gray;

            }
            else
            {
                pasillo = false;
                return Color.Transparent;

            }

        } 
        //funcion que da nombre a los picturbox que contienen a los robots
        private void Tipo_Robot(string tipo_robot, ref string pic_tipo_robot)
        {
            
            
           if (tipo_robot == "RS" || tipo_robot == "rs")
            {

                tipo_robot = "RS" +"_"+ cont_rs.ToString();
                cont_rs++;
            }
            else if (tipo_robot == "RH" || tipo_robot == "rh")
            {
                tipo_robot = "RH" + "_" + cont_rn.ToString();
                cont_rh++;

            }
            else if (tipo_robot == "RN" || tipo_robot == "rn")
            {

                tipo_robot = "RN" + "_" + cont_rn.ToString();
                cont_rn++;
            }
            else
            {
                MessageBox.Show("ERROR INGRESO UN ROBOT INVALIDO");
                Application.Exit();

            }

        }
        // crea las configuraciones que tendran los picturebox de los robots
        private void Cargar_imagen_Tipo_Robot(string tipo_robot,ref PictureBox pic_tipo_robot, int posx,int posy)
        {
            if (tipo_robot.Contains("RS")||tipo_robot.Contains("rs"))
            {
                pic_tipo_robot.Name = tipo_robot;
                pic_tipo_robot.Location = new Point(posx,posy);
                pic_tipo_robot.Width = 50;
                pic_tipo_robot.Height = 50;
                pic_tipo_robot.Location = new Point(posx, posy);
                pic_tipo_robot.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_tipo_robot.Image = Properties.Resources.RS;
                pic_tipo_robot.Visible = true;
                pic_tipo_robot.Enabled = false;
            }
            else if (tipo_robot.Contains("RH") || tipo_robot.Contains("rh"))
            {
                pic_tipo_robot.Name = tipo_robot;
                pic_tipo_robot.Location = new Point(posx,posy);
                pic_tipo_robot.Width = 50;
                pic_tipo_robot.Height = 50;
                pic_tipo_robot.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_tipo_robot.Image = Properties.Resources.RH;
                pic_tipo_robot.Visible = true;
                pic_tipo_robot.Enabled = false;
            }
            else if (tipo_robot.Contains("RN") || tipo_robot.Contains("rn"))
            {
                pic_tipo_robot.Name = tipo_robot;
                pic_tipo_robot.Width = 50;
                pic_tipo_robot.Height = 50;
                pic_tipo_robot.Location = new Point(posx, posy);
                pic_tipo_robot.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_tipo_robot.Image = Properties.Resources.RN;
                pic_tipo_robot.Visible = true;
                pic_tipo_robot.Enabled = false;

            }
            else
            {
                MessageBox.Show("ERROR INGRESO UN ROBOT INVALIDO");
                Application.Exit();

            }

        }
       
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar_Configuracion();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            int[] cooredanas = new int[2];
            cooredanas = buscar_lugar(estanteria);
            MessageBox.Show("Filas: " + cooredanas[0].ToString() + " Columnas: " + cooredanas[1].ToString());
            if (configuracion[cooredanas[0] + 1, cooredanas[1]] == "p" || configuracion[cooredanas[0]+1, cooredanas[1] ] == "P" )
            {
                cooredanas[0] += 1;
            }
            else if (configuracion[cooredanas[0] - 1, cooredanas[1]] == "p" || configuracion[cooredanas[0] - 1, cooredanas[1]] == "P")
            {
                cooredanas[0] -= 1;
            }
            else if (configuracion[cooredanas[0] , cooredanas[1]+1] == "p" || configuracion[cooredanas[0] , cooredanas[1]+1] == "P")
            {
                cooredanas[1] += 1;
            }
            else if (configuracion[cooredanas[0], cooredanas[1] - 1] == "p" || configuracion[cooredanas[0], cooredanas[1] - 1] == "P")
            {
                cooredanas[1] -= 1;
            }
            else {
                MessageBox.Show("El pasillo es inaccesible");
            }
            MessageBox.Show("Filas: " + cooredanas[0].ToString() + " Columnas: " + cooredanas[1].ToString());
            timer1.Enabled = false;
        }
        private int[] buscar_lugar(string Nombre_estanteria)
        {
            int[] posiciones = new int[2];
            for (int filas_estanterias = 0; filas_estanterias < filas; filas_estanterias++)
            {
                for (int columnas_estanterias = 0; columnas_estanterias < columnas; columnas_estanterias++)
                {
                    if (configuracion[filas_estanterias, columnas_estanterias].Contains(char.Parse(Nombre_estanteria.ToUpper())) || configuracion[filas_estanterias, columnas_estanterias].Contains(char.Parse(Nombre_estanteria.ToLower())) && capacidad[filas_estanterias, columnas_estanterias] > 0)
                    {
                        posiciones[0] = filas_estanterias;
                        posiciones[1] = columnas_estanterias;
                        columnas_estanterias = columnas;
                        filas_estanterias = filas;
                    }

                }

            }
            return posiciones;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            estanteria = Interaction.InputBox("Ingrese el tipo de estanteria que desea almacenar el porducto \nDonde c= Materiale frios \n f= Materiale fragiles \ny n= Materiale Normales", "GUARDAR");
            if (estanteria == "" || estanteria != "c" && estanteria != "n" && estanteria != "f" && estanteria != "C" && estanteria != "N" && estanteria != "F")
            {
                MessageBox.Show("Ingrese una estanteria valida");
            }
            else {
                timer1.Enabled = true;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }



    }

}
