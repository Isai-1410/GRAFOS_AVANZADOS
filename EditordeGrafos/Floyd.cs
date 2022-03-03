using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace EditordeGrafos
{
    public partial class Floyd : Form
    {
        private Graph original = new Graph();
        private int[,] matrizP = new int[20, 20];
        private int[,] matrizA = new int[20, 20];
        private int[,] matrizR = new int[20, 20];
        private int nodoIni = 0;
        private int nodoFinal = 0;
        private Bitmap bmp4;
        private Graphics graficosCam;
        private List<int> caminoNodo = new List<int>();


        public Floyd(Graph g)
        {
            InitializeComponent();
            original = g;
            bmp4 = new Bitmap(800, 532);
            graficosCam = CreateGraphics();
            AutoScroll = true;
        }

        private void Floyd_Load(object sender, EventArgs e)
        {
            foreach (Edge a in original.edgesList)
            {
                a.Visited = false;
            }
            foreach (NodeP node in original)
            {
                node.Visited = false;
            }
            foreach (Edge a in original.edgesList)
            {
                labelPeso.Text = labelPeso.Text + " (" + a.Name + " " + a.Weight.ToString() + "),  ";
            }
            foreach (NodeP n in original)
            {
                comboInicio.Items.Add(n.Name);
                comboFinal.Items.Add(n.Name);
            }
            for (int a = 0; a < original.Count; a++)
            {
                for (int b = 0; b < original.Count; b++)
                {
                    matrizP[a, b] = 1000000;
                }
            }
            for (int a = 0; a < original.Count; a++)
            {
                matrizP[a, a] = 0;
            }
            foreach (NodeP n in original)
            {
                foreach (Edge ar in original.edgesList)
                {
                    if (ar.Source.Name == n.Name)
                    {
                        matrizP[original.IndexOf(n), original.IndexOf(ar.Destiny)] = ar.Weight;
                    }
                }
            }
            for (int a = 0; a < original.Count; a++)
            {
                for (int b = 0; b < original.Count; b++)
                {
                    Console.WriteLine(matrizP[a, b]);
                }
            }
            CaminoMasCorto();
        }

        private void CaminoMasCorto()
        {
            for (int i = 0; i < original.Count; i++)
            {
                for (int j = 0; j < original.Count; j++)
                {
                    matrizA[i, j] = matrizP[i, j];
                }
            }
            for (int i = 0; i < original.Count; i++)
            {
                matrizA[i, i] = 0;
            }
            for (int k = 0; k < original.Count; k++)
            {
                for (int i = 0; i < original.Count; i++)
                {
                    for (int j = 0; j < original.Count; j++)
                    {
                        if (matrizA[i, k] + matrizA[k, j] < matrizA[i, j])
                        {
                            matrizA[i, j] = matrizA[i, k] + matrizA[k, j];
                            matrizR[i, j] = k;
                        }
                    }
                }
            }
        }

        private void LoadWays(int i, int j, int[,] matriz)
        {
            int k;
            k = matriz[i, j];
            if (k == 0)
                return;
            LoadWays(i, k, matriz);
            caminoNodo.Add(k);
            LoadWays(k, j, matriz);
        }

        private void Columnasyaristas(int i, int j)
        {

            foreach (Edge a in original.edgesList)
            {
                if (original[i].Name == a.Source.Name && original[j].Name == a.Destiny.Name)
                {
                    a.Visited = true;
                }
            }
        }

        private void comboInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            nodoIni = comboInicio.SelectedIndex;
        }

        private void comboFinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            nodoFinal = comboFinal.SelectedIndex;
        }

        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            foreach (Edge a in original.edgesList)
            {
                a.Visited = false;
            }
            foreach (NodeP node in original)
            {
                node.Visited = false;
            }
            caminoNodo.Clear();
            labelCamino.Text = "Camino =";
            caminoNodo.Add(nodoIni);
            LoadWays(nodoIni, nodoFinal, matrizR);
            caminoNodo.Add(nodoFinal);
            foreach (int i in caminoNodo)
            {
                original[i].Visited = true;
                labelCamino.Text = labelCamino.Text + " " + original[i].Name + ", ";
            }
            for (int i = 0; i < caminoNodo.Count; i++)
            {
                if (i + 1 < caminoNodo.Count)
                {
                    Columnasyaristas(caminoNodo[i], caminoNodo[i + 1]);
                }
            }
            bool camino = false;
            foreach (Edge aris in original.edgesList)
            {
                if (aris.Visited == true)
                {
                    camino = true;
                }

            }
            if (camino == false)
            {

                labelPeso.Text = "No hay Camino entre los nodos";
                foreach (int i in caminoNodo)
                {
                    original[i].Visited = false;
                }
            }

            labelCamino.Visible = true;
            Invalidate();
        }

        private void DibujaG(Graphics g, Graph graph)
        {
            Pen pendi = new Pen(graph.EdgeColor, graph.EdgeWidth);
            Pen penNdi = new Pen(graph.EdgeColor, graph.EdgeWidth);
            Pen pen = new Pen(graph.NodeBorderColor, graph.NodeBorderWidth);
            Pen vis = new Pen(Color.Green, graph.EdgeWidth);

            AdjustableArrowCap end = new AdjustableArrowCap(6, 6);
            SolidBrush nod;
            pendi.CustomEndCap = end;
            Size s = new Size(graph.NodeRadio, graph.NodeRadio);
            double p3x, p3y, p4x, p4y;
            double ang;
            PointF A, B;
            A = new PointF();
            double d;
            double r;
            double an;
            double dy, dx;
            dy = dx = 0;
            List<Edge> repetidas = new List<Edge>();
            // Dibuja la linea entre dos nodos
            if (graph.EdgesList != null && graph.EdgesList.Count > 0)
            {
                foreach (Edge a in graph.EdgesList)
                {
                    if (!graph.EdgeIsDirected)
                    {
                        if (a.Source.Name == a.Destiny.Name)
                        {
                            // Oreja
                            g.DrawBezier(penNdi, new Point(a.Source.Position.X + ((a.Destiny.Position.X - a.Source.Position.X) / 2) - 10, a.Source.Position.Y + ((a.Destiny.Position.Y - a.Source.Position.Y) / 2) - 5), new Point(a.Source.Position.X + ((a.Destiny.Position.X - a.Source.Position.X) / 2) - 40, a.Source.Position.Y - ((a.Destiny.Position.Y - a.Source.Position.Y) / 2) - 60), new Point(a.Source.Position.X + 40, a.Destiny.Position.Y - 60), new Point(a.Destiny.Position.X + 10, a.Destiny.Position.Y - 5));
                        }
                        else
                        {
                            // Arista no dirigida

                            g.DrawLine(penNdi, a.Source.Position.X, a.Source.Position.Y, a.Destiny.Position.X, a.Destiny.Position.Y);
                            g.DrawString(a.NumRec, new Font("Bold", graph.NodeRadio / 4), new SolidBrush(graph.NodeBorderColor), ((a.Source.Position.X + a.Destiny.Position.X) / 2), ((a.Source.Position.Y + a.Destiny.Position.Y) / 2));
                        }

                        repetidas = graph.EdgesList.FindAll(delegate (Edge repe) { if (repe.Source.Name == a.Source.Name && repe.Destiny.Name == a.Destiny.Name || (a.Source.Name == repe.Destiny.Name && a.Destiny.Name == repe.Source.Name)) return true; else return false; });

                        if (repetidas.Count > 1 && a.Painted == false)
                        {
                            if ((a.Destiny.Position.Y - a.Source.Position.Y) != 0)
                            {
                                g.DrawString(repetidas.Count.ToString(), new Font("Arial", 10), Brushes.Black, a.Source.Position.X + ((a.Destiny.Position.X - a.Source.Position.X) / 2) + 4, a.Source.Position.Y + ((a.Destiny.Position.Y - a.Source.Position.Y) / 2) + 4); foreach (Edge re in repetidas)
                                    re.Painted = true;

                            }
                        }
                    }
                    else
                    {
                        if (a.Source.Name == a.Destiny.Name)
                        {
                            g.DrawBezier(pendi, new Point(a.Source.Position.X - 10, a.Source.Position.Y - 5), new Point(a.Source.Position.X - 40, a.Source.Position.Y - 60), new Point(a.Source.Position.X + 40, a.Destiny.Position.Y - 60), new Point(a.Destiny.Position.X + 10, a.Destiny.Position.Y - 10));
                        }
                        else
                        {
                            if (graph.EdgesList.Find(delegate (Edge bus) { if (bus.Source.Name == a.Destiny.Name && bus.Destiny.Name == a.Source.Name) return true; else return false; }) == null)
                            {
                                double teta1 = Math.Atan2((double)(a.Destiny.Position.Y - a.Source.Position.Y), (double)(a.Destiny.Position.X - a.Source.Position.X));
                                float x1 = a.Source.Position.X + (float)((Math.Cos(teta1)) * (s.Height / 2));
                                float y1 = a.Source.Position.Y + (float)((Math.Sin(teta1)) * (s.Height / 2));

                                double teta2 = Math.Atan2(a.Source.Position.Y - a.Destiny.Position.Y, a.Source.Position.X - a.Destiny.Position.X);
                                float x2 = a.Destiny.Position.X + (float)((Math.Cos(teta2)) * (s.Height / 2));
                                float y2 = a.Destiny.Position.Y + (float)((Math.Sin(teta2)) * (s.Height / 2));
                                //Arista dirigida draw
                                if (a.Visited == true)
                                {
                                    g.DrawLine(vis, x1, y1, x2, y2);
                                }
                                else
                                {
                                    g.DrawLine(pendi, x1, y1, x2, y2);
                                }

                                if (graph.EdgesList.FindAll(delegate (Edge repe) { if (repe.Source.Name == a.Source.Name && repe.Destiny.Name == a.Destiny.Name) return true; else return false; }).Count > 1)
                                {
                                    if ((a.Destiny.Position.Y - a.Source.Position.Y) != 0)
                                    {
                                        g.DrawString(graph.EdgesList.FindAll(delegate (Edge repe) { if (repe.Source.Name == a.Source.Name && repe.Destiny.Name == a.Destiny.Name) return true; else return false; }).Count.ToString(), new Font("Arial", 10), Brushes.Black, a.Source.Position.X + ((a.Destiny.Position.X - a.Source.Position.X) / 2) + 4, a.Source.Position.Y + ((a.Destiny.Position.Y - a.Source.Position.Y) / 2) + 4);
                                    }
                                }

                            }
                            else
                            {
                                if (a.Painted == false)
                                {
                                    dy = a.Destiny.Position.Y - a.Source.Position.Y;
                                    dx = a.Destiny.Position.X - a.Source.Position.X;

                                    p3x = (dx * 1 / 3) + a.Source.Position.X;
                                    p3y = (dy * 1 / 3) + a.Source.Position.Y;
                                    p4x = (dx * 2 / 3) + a.Source.Position.X;
                                    p4y = (dy * 2 / 3) + a.Source.Position.Y;

                                    d = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
                                    r = .35 * d;

                                    if (a.Destiny.Position.X != a.Source.Position.X)
                                    {
                                        ang = Math.Atan((double)((double)dy / (double)dx));
                                    }
                                    else
                                    {
                                        ang = 90;
                                    }

                                    if (a.Destiny.Position.X > a.Source.Position.X)
                                    {
                                        an = ang + 89.8;
                                    }
                                    else
                                    {
                                        an = ang - 89.8;
                                    }

                                    B = new PointF((float)((r * Math.Cos(an)) + p4x), (float)((r * Math.Sin(an)) + p4y /*+ 15 * (an / Math.Abs(an))*/));
                                    A = new PointF((float)((r * Math.Cos(an)) + p3x), (float)((r * Math.Sin(an)) + p3y /*+ 15 * (an / Math.Abs(an))*/));



                                    if (a.Destiny.Position.X > a.Source.Position.X)
                                    {
                                        an = ang + 89.56;
                                    }
                                    else
                                    {
                                        an = ang - 89.56;
                                    }
                                    g.DrawBezier(pendi, new PointF(a.Source.Position.X + (float)((Math.Cos(an)) * (s.Height / 2)), a.Source.Position.Y + (float)((Math.Sin(an)) * (s.Height / 2))), A, B, new PointF(a.Destiny.Position.X + (float)((Math.Cos(an)) * (s.Height / 2)), a.Destiny.Position.Y + (float)((Math.Sin(an)) * (s.Height / 2))));

                                    a.Painted = true;
                                }
                            }
                            if (graph.EdgesList.FindAll(delegate (Edge repe) { if (repe.Source.Name == a.Source.Name && repe.Destiny.Name == a.Destiny.Name) return true; else return false; }).Count > 1)
                            {
                                if ((a.Destiny.Position.Y - a.Source.Position.Y) != 0)
                                {
                                    g.DrawString(graph.EdgesList.FindAll(delegate (Edge repe) { if (repe.Source.Name == a.Source.Name && repe.Destiny.Name == a.Destiny.Name) return true; else return false; }).Count.ToString(), new Font("Arial", 10), Brushes.Black, a.Destiny.Position.X, A.Y - 10);
                                }
                            }
                        }
                    }

                    if (graph.EdgeNamesVisible)
                    {
                        g.DrawRectangle(pen, a.Source.Position.X + ((a.Destiny.Position.X - a.Source.Position.X) / 2 - 5), a.Source.Position.Y + ((a.Destiny.Position.Y - a.Source.Position.Y) / 2) - 10, 5, 10);

                        g.DrawString(a.Name, new Font("Bold", 10), Brushes.Blue, a.Source.Position.X + ((a.Destiny.Position.X - a.Source.Position.X) / 2) - 5, a.Source.Position.Y + ((a.Destiny.Position.Y - a.Source.Position.Y) / 2) - 10);
                    }
                    if (graph.EdgeWeightVisible)
                    {
                        if (graph.EdgesList.Find(delegate (Edge bus) { if (bus.Source.Name == a.Destiny.Name && bus.Destiny.Name == a.Source.Name) return true; else return false; }) == null)
                        {
                            g.DrawString(a.Weight.ToString(), new Font("Bold", 10), Brushes.Blue, a.Source.Position.X + ((a.Destiny.Position.X - a.Source.Position.X) / 2) + 4, a.Source.Position.Y + ((a.Destiny.Position.Y - a.Source.Position.Y) / 2) + 4);
                        }
                        else
                        {
                            g.DrawString(a.Weight.ToString(), new Font("Bold", 10), Brushes.Blue, a.Destiny.Position.X, A.Y - 10);
                        }
                    }

                }
            }
            if (graph.EdgesList != null)
            {
                foreach (Edge des in graph.EdgesList)
                {
                    des.Painted = false;
                }
            }
            if (graph.Count > 0 && graph.NodeRadio != 0)
            {
                foreach (NodeP n in graph)
                {
                    SolidBrush visit = new SolidBrush(Color.Yellow);
                    pendi.Width = 3;
                    if (n.Selected == false)
                    {
                        nod = new SolidBrush(n.Color);
                    }
                    else
                    {
                        nod = new SolidBrush(Color.Red);
                    }

                    Rectangle re = new Rectangle(n.Position.X - (s.Height / 2), n.Position.Y - (s.Height / 2), s.Width, s.Height);
                    if (n.Visited == true)
                    {
                        g.FillEllipse(visit, re);
                    }
                    else
                    {
                        g.FillEllipse(nod, re);
                    }
                    g.DrawEllipse(pen, re);
                    g.DrawString(n.Name, new Font("Bold", graph.NodeRadio / 4), new SolidBrush(graph.NodeBorderColor), (n.Position.X - graph.NodeRadio / 4 + graph.NodeRadio / 12), (n.Position.Y - graph.NodeRadio / 4 + graph.NodeRadio / 12));

                }
            }
            pendi.Dispose();
            penNdi.Dispose();
            pen.Dispose();
        }

        private void Floyd_Paint(object sender, PaintEventArgs e)
        {
            Graphics nuevoGrafo = Graphics.FromImage(bmp4);

            nuevoGrafo.Clear(BackColor);
            DibujaG(nuevoGrafo, original);
            graficosCam.DrawImage(bmp4, 0, 0);
        }

        
    }
}
