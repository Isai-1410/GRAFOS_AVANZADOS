using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos
{
    public partial class AtributosGrafo : Form
    {
        public AtributosGrafo(Graph graph)
        {
            InitializeComponent();

            List<Edge> lista = graph.edgesList;
            foreach (var dato in lista)
            {
                lblAristas.Text = lblAristas.Text + dato.Name + " = (" + dato.Source.Name + " , " + dato.Destiny.Name + ")\r";
            }

            foreach (NodeP nodo in graph)
            {
                lblNodos.Text = lblNodos.Text + nodo.Name + "\r";
            }


            if (graph.EdgeIsDirected == true)
            {
                GradoExterno.Text = "Grados de los nodos (Salen)" + "\r";
                foreach (NodeP nodo in graph)
                {
                    GradoExterno.Text = GradoExterno.Text + nodo.Name + " = " + nodo.DegreeEx + "\r";
                }
                GradoInterno.Text = "Grados de los nodos (Entran)" + "\r";
                foreach (NodeP nodo in graph)
                {
                    GradoInterno.Text = GradoInterno.Text + nodo.Name + " = " + nodo.DegreeIn + "\r";
                }
            }
            else
            {
                GradoExterno.Text = "Grados de los nodos" + "\r";
                foreach (NodeP nodo in graph)
                {
                    GradoExterno.Text = GradoExterno.Text + nodo.Name + " = " + nodo.Degree + "\r";
                }
            }




        }
    }
}
