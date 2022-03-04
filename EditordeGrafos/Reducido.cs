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
                n.Level = 0;
                //para hacer las comparaciones en el algoritmo de Tarjan
                n.ValorComponente = 0;
            }
        }


        private NodeP getMayor(List<NodeP> ordenados)
        {
            NodeP res = ordenados[ordenados.Count - 1];

            foreach(NodeP nodo in ordenados)
            {
                if (nodo.Visited == false)
                {
                    res = nodo;
                }
            }
            return res;
        }



        //el algoritmo de Tarjan retornará componentes conexos del grafo dirijido
        public List<List<NodeP>> getComponentes_FC(Graph gr)
        {
            //se inicializa la lista de componentes que será retornada
            List<List<NodeP>> allComponents = new List<List<NodeP>>();

            //Se inicializa el contador en 1
            count = 1;
            //Se inicializa el numero de arbol ó componente en 0
            int num_Arbol = 0;

            //ya que cualquier nodo dentro de un componente puede ser tratado como raiz en el componente
            //llamamos a un recorrido en profundidad con el auxiliar de Tarjan a todos los nodos
            //con el orden prestablecido en el grafo
            foreach (NodeP n in gr)
            {
                //Si el nodo no ha sido visitado en el recorrido, se visita y se generara un nuevo componente 
                //por lo que la variable de numero de arbol incrementa 
                if (n.Visited == false)
                {
                    //List<NodeP> comp = new List<NodeP>();
                    getComponentes_FC_Aux(n, num_Arbol, gr);//busqueda en profundidad con el algoritmo de Tarjan
                    num_Arbol++;//Siguiente numero en el componente.
                }
            }//despues de este ciclo se finaizo el recorrido en profundidad de el grafo original

            //conseguimos enumerar todos los nodos 

            //desvisitar los nodos para hacer su recorridfo en profundidad en el grafo inverso
            gr.setAllNodesAs(false);

            //obtenemos el nodo con mayor nivel
           
            

            List<NodeP>  ordenados = gr.OrderBy(NodeP => NodeP.Level).ToList();

            while (gr.allVisited() == false)
            {

                NodeP nodoInicioInversa = getMayor(ordenados);

                List<NodeP> componentesFC = new List<NodeP>();

                getComponentes_FC_Aux_Inversa(nodoInicioInversa, num_Arbol, gr, componentesFC);
                allComponents.Add(componentesFC);

            }


            return allComponents;
        }

      

        //se almacenan temporalmente los vertices que han sido visitados en la busqueda,
        //pero que aun no se han asociado a un componente
        Stack<NodeP> pilaNodos = new Stack<NodeP>();
   

        private void getComponentes_FC_Aux(NodeP n,int num_Arbol, Graph g)
        {
            n.Visited = true;//marcar el nodo como visitado.
            n.Level = count;//se le asigna un valor a el nivel del nodo y se suma uno al contador para el recorrido de los nodos siguientes.
           
            n.ValorComponente = count;
            count++;
            pilaNodos.Push(n);//se le agrega en el stack auxiliar el nodo

            n.Ntree = num_Arbol;//Se le asigna un numero de árbol o componente, al nodo que se visita
            visitaNodo.Add(n);//lista de nodos visitados en el recorrido.


            //Lista de nodos a visitar por el nodo actual
            List<NodeP> nodosVecinos = new List<NodeP>();
            foreach (Edge ed in g.edgesList)
            {
                if (n.Name == ed.Source.Name)
                {
                    nodosVecinos.Add(ed.Destiny);
                }
            }
            nodosVecinos = nodosVecinos.OrderBy(NodeP => NodeP.Name).ToList();



            foreach (NodeP nodeP in nodosVecinos)//por cada vecino del nodo actual hará una visita
            {
                if (nodeP.Level == 0)//si el vecino no ha sido visitado se procede a visitarlo 
                {
                    getComponentes_FC_Aux(nodeP, num_Arbol, g);//se ejecuta la busqueda en profundidad recursiva sobre esta misma funcion con el nodo vecino
                    //n.ValorComponente = Math.Min(n.ValorComponente, nodeP.ValorComponente);
                }
                /*else//si el nodo ya ha sido visitado se tiene un retroceso 
                {
                    if(pilaNodos.Contains(nodeP))// si el nodo ya fué visitado y está en la pila
                    {
                        n.ValorComponente = Math.Min(n.ValorComponente, nodeP.Level);
                    }
                }*/
            }
        }


       

        private void getComponentes_FC_Aux_Inversa(NodeP n, int num_Arbol, Graph g, List<NodeP> componente)
        {
            componente.Add(n);
            n.Visited = true;//marcar el nodo como visitado.

            //Lista de nodos a visitar por el nodo actual
            List<NodeP> nodosPadre = new List<NodeP>();
            foreach (Edge ed in g.edgesList)
            {
                if (n.Name == ed.Destiny.Name)
                {
                    nodosPadre.Add(ed.Source);
                }
            }
            nodosPadre = nodosPadre.OrderBy(NodeP => NodeP.Name).ToList();
            


            foreach (NodeP nodeP in nodosPadre)//por cada vecino inverso del nodo actual hará una visita
            {
                if (nodeP.Visited == false)//si el vecino no ha sido visitado se procede a visitarlo 
                {
                    getComponentes_FC_Aux_Inversa(nodeP, num_Arbol, g, componente);//se ejecuta la busqueda en profundidad recursiva sobre esta misma funcion con el nodo vecino     
                }
                /*else//si el nodo ya ha sido visitado se tiene un retroceso 
                {
                    if (pilaNodos.Contains(nodeP))// si el nodo ya fué visitado y está en la pila
                    {
                        n.ValorComponente = Math.Min(n.ValorComponente, nodeP.Level);
                    }
                }*/
            }
        }



        private void buttonMuestra_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            getComponentes_FC(original);
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
