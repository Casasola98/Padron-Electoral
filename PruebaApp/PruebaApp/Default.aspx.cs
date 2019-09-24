using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaApp
{
    public partial class _Default : Page
    {

            protected void enviarCedula(object sender, EventArgs a)
        {
            
            ConexionSQL sql = new ConexionSQL("DESKTOP-NO5HK1U", "SISTEMA", "", "");
            bool res;

            List<Dictionary<int, object>> filas = null;

            res = sql.realizarConsultaSQL(TextBoxDefault.Text.ToString(), ref filas);
              
          
            if (res)
            {
                var fila = filas[0];
                string nombre, ap1, ap2, prov, can, dis, fecha, sexo, junta;
                nombre = fila[0].ToString();
                ap1 = fila[1].ToString();
                ap2 = fila[2].ToString();
                prov = fila[3].ToString();
                can = fila[4].ToString();
                dis = fila[5].ToString();
                sexo = fila[6].ToString();
                fecha = fila[7].ToString();
                junta = fila[8].ToString();
                if (sexo == "2")
                    sexo = "Femenino";
                else 
                    sexo = "Masculino";

                LabelCedula.Text = TextBoxDefault.Text.ToString();
                LabelNombre.Text = nombre;
                LabelAp1.Text = ap1;
                LabelAp2.Text = ap2;
                LabelProvincia.Text = prov;
                LabelCanton.Text = can;
                LabelDistrito.Text = dis;
                LabelCaducidad.Text = fecha;
                LabelSexo.Text = sexo;
                LabelJunta.Text = junta;
            }else
                LabelCedula.Text = "fallo";


        }
    }
}