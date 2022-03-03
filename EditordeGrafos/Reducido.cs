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
    public partial class Reducido : Form
    {
        private Bitmap bmp6;
        private List<NodeP> visitaNodo = new List<NodeP>();
        private Graphics graphicsDeep;
        private Graph grafArbol = new Graph();
        public Graph original = new Graph();

        private int count;

        public Reducido(Graph graph)
        {
            InitializeComponent();

            original = graph;
            graphicsDeep = CreateGraphics();
            bmp6 = new Bitmap(900, 700);
            AutoScroll = true;
            visitaNodo = new List<NodeP>();
            count = 0;

            foreach (NodeP n in original)
            {
                n.Visited = false;
            }
        }



        public List<List<NodeP>> IniciaBusqueda(Graph gr)
        {
            //int count = 0;
            List<List<NodeP>> componentes = new List<List<NodeP>>();
            int num_Arbol = 0;
            foreach (NodeP n in gr)
            {
                if (n.Visited == false)
                {
                    num_Arbol++;
                    BusquedaProfundidad(n, num_Arbol, gr);
                }
            }

            return componentes;
        }

        //List<NodeP>

        private void BusquedaProfundidad(NodeP n,int num_Arbol, Graph g)
        {
            visitaNodo.Add(n);
            n.Visited = true;
            n.Ntree = num_Arbol;
           // count++;
            n.Level = count++;
            List<NodeP> listaNodo = new List<NodeP>();
            List<NodeP> listaOrder = new List<NodeP>();
            foreach (Edge ed in g.edgesList)
            {
                if (n.Name == ed.Source.Name)
                {
                    listaNodo.Add(ed.Destiny);
                }
            }
            listaOrder = listaNodo.OrderBy(NodeP => NodeP.Name).ToList();

            foreach (Edge ed in g.edgesList)
            {
                if (n.Name == ed.Destiny.Name)
                {
                    listaNodo.Add(ed.Source);
                }
            }

            

            foreach (NodeP nodeP in listaOrder)
            {
                if (nodeP.Visited == false)
                {
                    //visitaNodo.Add(n);
                    BusquedaProfundidad(nodeP, num_Arbol, g);
                    if (nodeP.Ntree == 1)
                    {
                        label8.Text = label8.Text + "( " + n.Name + nodeP.Name + "), ";
                        labelFuerteConexo.Text = "EL GRAFO ES FUERTEMENTE CONEXO";
                        
                    }
                    else
                    {
                        label12.Text = label12.Text + "( " + n.Name + nodeP.Name + "), ";
                    }

                 
                }
                else//si el nodo ya ha sido visitado se tiene un retroceso 
                {
                    if(visitaNodo.Contains(nodeP))//hay un retroceso puesto que se quiere visitar un nodo dentro de la lista visitados, del arbol en construccion
                    {

                    }

                    //if (nodeP.Level < n.Level)
                    //{
                    //    if (nodeP.Ntree == 1)
                    //    {
                    //        label9.Text = label9.Text + "( " + n.Name + nodeP.Name + "), ";
                    //    }
                    //    else
                    //    {
                    //        label13.Text = label13.Text + "( " + n.Name + nodeP.Name + "), ";
                    //    }
                    //}
                    //else if (nodeP.Level == n.Level || nodeP.Ntree != n.Ntree)
                    //{
                    //    if (n.Ntree == 1)
                    //    {
                    //        label10.Text = label10.Text + "( " + n.Name + nodeP.Name + "), ";
                    //        labelFuerteConexo.Visible = false;
                    //        labelConexo.Text = "ES UN GRAFO DEBILMENTE CONEXO";

                    //    }
                    //    else
                    //    {
                    //        label14.Text = label14.Text + "( " + n.Name + nodeP.Name + "), ";
                    //    }
                        
                    //}
                    //else if (nodeP.Level > n.Level)
                    //{
                    //    if (nodeP.Ntree == 1)
                    //    {
                    //        label11.Text = label11.Text + "( " + n.Name + nodeP.Name + "), ";
                    //    }
                    //    else
                    //    {
                    //        label15.Text = label15.Text + "( " + n.Name + nodeP.Name + "), ";
                    //    }
                    //}
                }
            }
        }


        private void BusquedaInversa()
        {


        }

      

        private void buttonMuestra_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            IniciaBusqueda(original);
            label1.Text = "Recorrido de los nodos visitados:  ";

            foreach (NodeP n in visitaNodo)
            {
                label1.Text = label1.Text + "(" + n.Name + "), ";
            }
        }

        /* nuevo */

        private List<Graph> componentesFuertes(Graph g)
        {
            Graph gr = new Graph();
           BusquedaProfundidad_GI(g,0,ref gr);

            List<Graph> result = new List<Graph>();

            return result;
        }

        private void BusquedaProfundidad_GI(Graph g, int indicerec, ref Graph inver)
        {
            

        }
    }

    

 
}
