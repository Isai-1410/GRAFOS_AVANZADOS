using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos
{
    public partial class CircuitoEuleriano : Form
    {

        private Bitmap bmp3;
        private List<NodeP> listaux = new List<NodeP>();
      // private Graphics CircuitoGraf;
        public Graph original = new Graph();

        public CircuitoEuleriano(Graph g)
        {
            InitializeComponent();

            original = g;
            listaux = g;
            bmp3 = new Bitmap(800, 532);
           // CircuitoGraf = CreateGraphics();
            AutoScroll = true;

            foreach(Edge a in original.edgesList)
            {
                a.Visited = false;
            }
            Euleriano(original);

        }


        private void Euleriano(Graph g)
        {
            int cont = 0;
            int aux = 0;
            bool circuito = Circuito(g);
            bool camino = Camino(g);

                if (circuito == true)
                {

                    // MessageBox.Show("Si cuenta con circuito de Euler");
                    labelCE.Text = "SI CUENTA CON CIRCUITO DE EULER";
                    //labelText.Visible = true;
                    labelR.Visible = true;
                    EncuentraCamCir(listaux[1], cont, g);
                }
                else
                {
                    // MessageBox.Show("NO CUENTA CON CIRCUITO DE EULER");

                    labelCE.Text = "NO CUENTA CON CIRCUITO DE EULER";
                }

                if (camino == true)
                {
                    labelCaE.Text = "SI CUENTA CON CAMINO DE EULER";
                    labelText.Visible = true;
                    labelR.Visible = true;

                    foreach (NodeP n in g)
                        if (n.Degree % 2 != 0)
                        {
                            aux = g.IndexOf(n);
                            break;
                        }
                    EncuentraCamCir(listaux[aux], cont, g);
                }
                else
                {
                    labelCaE.Text = "NO CUENTA CON CAMINO DE EULER";
                }

            

        }

        private void EncuentraCamCir(NodeP p, int cont, Graph g)
        {
            NodeP aux = new NodeP();

            foreach(Edge a in g.edgesList)
                if((p.Name == a.Destiny.Name || p.Name == a.Source.Name) && a.Visited == false)
                {
                    cont++;
                    a.NumRec = cont.ToString();
                    if (p.Name == a.Source.Name) aux = a.Destiny;
                    else if (p.Name == a.Destiny.Name) aux = a.Source;
                    a.Visited = true;
                    labelR.Text = labelR.Text + p.Name + ",";
                    break;
                }

            if (cont < g.edgesList.Count)
                EncuentraCamCir(aux, cont, g);
        }

        private bool Camino(Graph g)
        {
            bool cam = false;
            int cont = 0;
            int aux = -1;
            foreach (NodeP nod in g)
            {
                aux = nod.Degree % 2;
                if (aux != 0)
                {
                    cont++;
                }
            }
            if (cont == 2)
            {
                cam = true;
            }
            return cam;
        }

        private bool Circuito(Graph g)
        {
            bool circ = false;
            int aux = -1;
            foreach (NodeP n in g)
            {
                aux = n.Degree % 2;
                if (aux == 0)
                {
                    circ = true;
                }
                else
                {
                    circ = false;
                    break;
                }
            }
            return circ;
        }



       

        
        private void CircuitoEuleriano_Load(object sender, EventArgs e)
        {

        }




        private void groupBoxEu_Enter(object sender, EventArgs e)
        {

        }

        
    }
}
