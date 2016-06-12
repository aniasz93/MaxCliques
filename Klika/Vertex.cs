using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klika
{
    class Vertex : IComparable<Vertex>
    {
        int x;

        int degree;
        List<Vertex> nbrs = new List<Vertex>();

        public int GetX()
        {
            return x;
        }

        public void SetX(int x)
        {
            this.x = x;
        }

        public int GetDegree()
        {
            return degree;
        }

        public void SetDegree(int degree)
        {
            this.degree = degree;
        }

        public List<Vertex> GetNeighbors()
        {
            return nbrs;
        }

        public void SetNeighbors(List<Vertex> nbrs)
        {
            this.nbrs = nbrs;
        }

        public void AddNeighbor(Vertex y)
        {
            this.nbrs.Add(y);
            if (!y.GetNeighbors().Contains(y))
            {
                y.GetNeighbors().Add(this);
                y.degree++;
            }
            this.degree++;

        }

        public void RemoveNeighbor(Vertex y)
        {
            this.nbrs.Remove(y);
            if (y.GetNeighbors().Contains(y))
            {
                y.GetNeighbors().Remove(this);
                y.degree--;
            }
            this.degree--;

        }

        public int CompareTo(Vertex o)
        {
            if (this.degree < o.degree)
            {
                return -1;
            }
            if (this.degree > o.degree)
            {
                return 1;
            }
            return 0;
        }
    }
}
