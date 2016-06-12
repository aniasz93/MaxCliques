using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klika
{
    class MaximalCliquesWithoutPivot
    {
        int nodesCount; 
        List<Vertex> graph = new List<Vertex>(); 

        void InitGraph()
        { 
            graph.Clear(); 
            for (int i = 0; i < nodesCount; i++) {
                Vertex V = new Vertex(); 
                V.SetX(i); 
                graph.Add(V); 
            } 
        } 

        public int ReadTotalGraphCount(System.IO.StreamReader sr)
        {
            return int.Parse(sr.ReadLine()); 
        } 

        // Reads Input 
        public void ReadNextGraph(System.IO.StreamReader sr)
        {
            try {
                nodesCount = int.Parse(sr.ReadLine());
                int edgesCount = int.Parse(sr.ReadLine());
                InitGraph(); 

                for (int k = 0; k < edgesCount; k++) {
                    String[] strArr = sr.ReadLine().Split(' ');
                    int u = int.Parse(strArr[0]);
                    int v = int.Parse(strArr[1]);
                    Vertex vertU = graph[u]; 
                    Vertex vertV = graph[v]; 
                    vertU.AddNeighbor(vertV); 

                } 

            } catch (Exception e) { 
                e.StackTrace.ToString(); 
                throw e; 
            } 
        } 

        // Finds nbr of vertex i 
        List<Vertex> GetNeighbors(Vertex v)
        { 
            int i = v.GetX();
            return graph[i].GetNeighbors();
        } 

        // Intersection of two sets 
        List<Vertex> Intersect(List<Vertex> arlFirst, List<Vertex> arlSecond)
        {
            List<Vertex> arlHold = new List<Vertex>(arlFirst);
            List<Vertex> arlSecondTemp = new List<Vertex>(arlSecond);
            return arlHold.Intersect(arlSecondTemp).ToList();
        } 

        // Union of two sets 
        List<Vertex> Union(List<Vertex> arlFirst, List<Vertex> arlSecond)
        { 
            List<Vertex> arlHold = new List<Vertex>(arlFirst); 
            arlHold.Union(arlSecond); 
            return arlHold; 
        } 

        // Removes the neigbours 
        List<Vertex> RemoveNeighbors(List<Vertex> arlFirst, Vertex v)
        { 
            List<Vertex> arlHold = new List<Vertex>(arlFirst);
            List<Vertex> nbrsList = v.GetNeighbors();
            arlHold.RemoveAll(item => nbrsList.Contains(item));

            return arlHold.Where(a => v.GetNeighbors().All(n => a.GetX() != v.GetX())).ToList();
        } 

        // Version without a Pivot 
        void Bron_KerboschWithoutPivot(List<Vertex> R, List<Vertex> P, List<Vertex> X, String pre)
        { 
            if ((P.Count == 0) && (X.Count == 0))
            {
                PrintClique(R); 
                return; 
            } 
            Console.WriteLine(); 

            List<Vertex> P1 = new List<Vertex>(P); 

            foreach (Vertex v in P)
            { 
                R.Add(v); 
                Bron_KerboschWithoutPivot(R, Intersect(P1, GetNeighbors(v)), Intersect(X, GetNeighbors(v)), pre); 
                R.Remove(v); 
                P1.Remove(v); 
                X.Add(v); 
            } 
        } 

        public void Bron_KerboschPivotExecute()
        {
            List<Vertex> X = new List<Vertex>(); 
            List<Vertex> R = new List<Vertex>(); 
            List<Vertex> P = new List<Vertex>(graph); 
            Bron_KerboschWithoutPivot(R, P, X, ""); 
        } 

        void PrintClique(List<Vertex> R)
        { 
            Console.Write("\n    Klika maksymalna : "); 
            foreach (Vertex v in R)
            { 
                Console.Write(" " + (v.GetX())); 
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(); 
        } 

        String PrintSet(List<Vertex> Y)
        { 
            StringBuilder strBuild = new StringBuilder(); 

            strBuild.Append("{"); 
            foreach (Vertex v in Y)
            { 
                strBuild.Append("" + (v.GetX()) + ","); 
            }
            if (strBuild.Length != 1)
            {
                strBuild.Length = strBuild.Length - 1;
            } 
            strBuild.Append("}"); 
            return strBuild.ToString(); 
        } 
    }
}
