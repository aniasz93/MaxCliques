using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klika
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader sr = null;
            try
            {
                sr = new System.IO.StreamReader(@"D:\Uczelnia\UAM\Magisterka\I semestr\STD\Klika\Klika\klika.txt");
            }
            catch (Exception e)
            {
                return;
            }

            MaximalCliquesWithoutPivot ff = new MaximalCliquesWithoutPivot();
            Console.WriteLine("Program wyszukujący maksymalną klikę");
            try
            {
                int totalGraphs = ff.ReadTotalGraphCount(sr);
                for (int i = 0; i < totalGraphs; i++)
                {
                    ff.ReadNextGraph(sr);
                    ff.Bron_KerboschPivotExecute();

                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Exiting : " + e);
            }
            finally
            {
                try
                {
                    sr.Close();
                }
                catch (Exception f)
                {

                }
            }
            Console.ReadLine();
        } 
    }
}