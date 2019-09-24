using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaApp
{
    public partial class About : Page
    {

        public string hola = "Hola";

        protected void ActualizarCantones(object sender, EventArgs e)
        {
            
            ConexionSQL sql = new ConexionSQL("DESKTOP-NO5HK1U", "SISTEMA", "", "");
            bool res;

            List<Dictionary<int, object>> filas = null;

            string prov = DropDownListProvincia.SelectedValue;
            sql.ActualizarCanton(prov, ref filas);
            DropDownListCanton.Items.Clear();
            foreach (var fil in filas)
            {
                DropDownListCanton.Items.Add(fil[0].ToString());
            }

            filas = null;
            string can = DropDownListCanton.SelectedValue;
            sql.ActualizarDistrito(prov, can, ref filas);
            DropDownListDistrito.Items.Clear();
            foreach (var fil in filas)
            {
                DropDownListDistrito.Items.Add(fil[0].ToString());
            }

        }

        protected void ActualizarDistritos(object sender, EventArgs e)
        {

            ConexionSQL sql = new ConexionSQL("DESKTOP-NO5HK1U", "SISTEMA", "", "");
            bool res;

            List<Dictionary<int, object>> filas = null;

            string prov = DropDownListProvincia.SelectedValue;
            string can = DropDownListCanton.SelectedValue;
            sql.ActualizarDistrito(prov, can, ref filas);
            DropDownListDistrito.Items.Clear();
            foreach (var fil in filas)
            {
                DropDownListDistrito.Items.Add(fil[0].ToString());
            }

        }

        public void EditarPersona (object sender, EventArgs e)
        {
            ConexionSQL sql = new ConexionSQL("DESKTOP-NO5HK1U", "SISTEMA", "", "");
            bool res;

            //List<Dictionary<int, object>> filas = null;


            //var fila = filas[0];
            string nombre, ap1, ap2, prov, can, dis, fecha, sexo, junta;
            nombre = TextBoxNombre.Text.ToString();
            ap1 = TextBoxAp1.Text.ToString();
            ap2 = TextBoxAp2.Text.ToString();
            prov = DropDownListProvincia.SelectedValue;
            can = DropDownListCanton.SelectedValue;
            dis = DropDownListDistrito.SelectedValue;
            sexo = DropDownListSexo.SelectedValue;
            if (sexo == "Masculino")
                sexo = "1";
            else
                sexo = "2";
            //fecha = TEX
            junta = "0";

            TextBoxNombre.Text = sql.ActualizarPersona(TextBoxAbout.Text.ToString(), nombre, ap1, ap2, prov, can, dis, sexo, "20191212", junta);

            
        }

        protected void enviarDatos(object sender, EventArgs e)
        {
            ConexionSQL sql = new ConexionSQL("DESKTOP-NO5HK1U", "SISTEMA", "", "");
            bool res;

            List<Dictionary<int, object>> filas = null;

            res = sql.realizarConsultaSQL(TextBoxAbout.Text.ToString(), ref filas);

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

                TextBoxNombre.Text = nombre;
                TextBoxAp1.Text = ap1;
                TextBoxAp2.Text = ap2;

                DropDownListProvincia.Items.Clear();
                DropDownListCanton.Items.Clear();
                DropDownListDistrito.Items.Clear();

                DropDownListProvincia.Items.Add("SAN JOSE");
                DropDownListProvincia.Items.Add("ALAJUELA");
                DropDownListProvincia.Items.Add("CARTAGO");
                DropDownListProvincia.Items.Add("HEREDIA");
                DropDownListProvincia.Items.Add("GUANACASTE");
                DropDownListProvincia.Items.Add("PUNTARENAS");
                DropDownListProvincia.Items.Add("LIMON");
                DropDownListProvincia.Items.Add("CONSULADO");
                DropDownListProvincia.SelectedValue = prov;
                DropDownListSexo.Items.Add("Masculino");
                DropDownListSexo.Items.Add("Femenino");
                if (sexo == "1")
                    DropDownListSexo.SelectedValue = "Masculino";
                else
                    DropDownListSexo.SelectedValue = "Femenino";
                DropDownListJunta.Items.Add("0");

                filas = null;

                //Calendar1.SelectedDate.ToShortDateString();
                sql.ActualizarCanton(prov, ref filas);

                foreach(var fil in filas)
                {
                    DropDownListCanton.Items.Add(fil[0].ToString());
                }
                DropDownListCanton.SelectedValue = can;

                filas = null;

                sql.ActualizarDistrito(prov, can, ref filas);

                foreach (var fil in filas)
                {
                    DropDownListDistrito.Items.Add(fil[0].ToString());
                }
                DropDownListDistrito.SelectedValue = dis;

            }

            
            //DropDownListDistrito.Items.Add("EXITO");
            TextBoxCaducidad.Text = "EXITO";
            

        }





    }
}