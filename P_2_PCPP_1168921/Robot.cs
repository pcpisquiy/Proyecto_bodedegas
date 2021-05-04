using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace P_2_PCPP_1168921
{
 public partial class Robot:PictureBox
    {
     //parametros
     public string nombre;
     public string tipo;
     public bool estado;
     public int capacidad;
     public int unidades;
    

     public System.Drawing.Image imagen   // property
  {
      get { return this.Image; }   // get method
      set { this.Image = value; }  // set method
  }
   

     public void Actualizar_estado() {
         estado = !estado;
     }
    }
}
