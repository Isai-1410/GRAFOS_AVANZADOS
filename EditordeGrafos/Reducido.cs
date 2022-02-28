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

        public Reducido(Graph graph)
        {
            InitializeComponent();

            original = graph;
            graphicsDeep = CreateGraphics();
            bmp6 = new Bitmap(900, 700);
            AutoScroll = true;

            foreach (NodeP n in original)
            {
                n.Visited = false;
            }
        }



        public void IniciaBusqueda(Graph gr)
        {
            int count = 0;
            int n_A = 0;
            foreach (NodeP n in gr)
            {
                if (n.Visited == false)
                {
                    n_A++;
                    BusquedaProfundidad(n, count, n_A, gr);
                }
            }
        }

        private void BusquedaProfundidad(NodeP n, int cont, int n_A, Graph g)
        {
            visitaNodo.Add(n);
            n.Visited = true;
            n.Ntree = n_A;
            cont++;
            n.Level = cont;
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

            foreach (NodeP nodeP in listaOrder)
            {
                if (nodeP.Visited == false)
                {
                    visitaNodo.Add(n);
                    BusquedaProfundidad(nodeP, cont, n_A, g);
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
                else
                {
                    if (nodeP.Level < n.Level)
                    {
                        if (nodeP.Ntree == 1)
                        {
                            label9.Text = label9.Text + "( " + n.Name + nodeP.Name + "), ";
                        }
                        else
                        {
                            label13.Text = label13.Text + "( " + n.Name + nodeP.Name + "), ";
                        }
                    }
                    else if (nodeP.Level == n.Level || nodeP.Ntree != n.Ntree)
                    {
                        if (n.Ntree == 1)
                        {
                            label10.Text = label10.Text + "( " + n.Name + nodeP.Name + "), ";
                            labelFuerteConexo.Visible = false;
                            labelConexo.Text = "ES UN GRAFO DEBILMENTE CONEXO";

                        }
                        else
                        {
                            label14.Text = label14.Text + "( " + n.Name + nodeP.Name + "), ";
                        }
                        
                    }
                    else if (nodeP.Level > n.Level)
                    {
                        if (nodeP.Ntree == 1)
                        {
                            label11.Text = label11.Text + "( " + n.Name + nodeP.Name + "), ";
                        }
                        else
                        {
                            label15.Text = label15.Text + "( " + n.Name + nodeP.Name + "), ";
                        }
                    }
                }
            }
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
