using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAPF.Model;

namespace MAPF.Service
{
    class GraphReader
    {
        public static Graph Read(String path)
        {
            List<Edge> result = new List<Edge>();
            string[] lines = File.ReadAllLines(path);
            int lineNumber = 0;

            foreach (var line in lines)
            {
                lineNumber++;
                bool zawieraWierzcholki = line.Contains("--");
                bool zawieraNazwe = line.Contains("Graph");
                if (zawieraWierzcholki)
                {
                    string rawLines = RemoveSpecialCharacters(line);
                    string[] edgeFromFile = rawLines.Split('-'); 

                    if (edgeFromFile.Length == 3)
                    {
                        Edge edge = new Edge();
                        edge.From = int.Parse(edgeFromFile[0]);
                        edge.To = int.Parse(edgeFromFile[2]);
                        result.Add(edge);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid data format");
                    }
                }


                System.Console.WriteLine(line);
                
            }

            Graph graphResult = new Graph();

            List<int> listaWierzcholkow = new List<int>();
            foreach (var wierzch in result)
            {
                listaWierzcholkow.Add(wierzch.From);
                listaWierzcholkow.Add(wierzch.To);

            }
            var unikatoweWierzcholki = listaWierzcholkow.Distinct().ToArray();
            
            graphResult.NVerticies = unikatoweWierzcholki.Length;
            graphResult.NEdges = result.Count;
            //result.RemoveAt(0);
            graphResult.Edges = result;
            return graphResult;
        }

        private static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == '-')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static void Save(Graph graph)
        {
            string[] lines = new string[graph.Edges.Count+2];
            int numerLinii = 0;
            lines[numerLinii] = "graph W {";

            foreach (Edge edge in graph.Edges)
            {
                numerLinii++;
                lines[numerLinii] = edge.From + " -- " + edge.To;
            }
            lines[lines.Length-1] = "}";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\msawicki\Desktop\UZ-Informatyka\Grafy-i-sieci\Lista2\Lista2Grafy\Lista2Grafy\w.txt"))
            {
                foreach (string line in lines)
                {
                        file.WriteLine(line);
                }
            }
            Console.WriteLine("Zapisano do pliku.");
        }

        public static void Save(Graph graph, string fileName)
        {
            string[] lines = new string[graph.Edges.Count + 2];
            int numerLinii = 0;
            lines[numerLinii] = "graph W {";

            foreach (Edge edge in graph.Edges)
            {
                numerLinii++;
                lines[numerLinii] = edge.From + " -- " + edge.To;
            }
            lines[lines.Length - 1] = "}";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\msawicki\Desktop\UZ-Informatyka\Grafy-i-sieci\Lista2\Lista2Grafy\Lista2Grafy\"+fileName))
            {
                foreach (string line in lines)
                {
                    file.WriteLine(line);
                }
            }
            Console.WriteLine("Zapisano do pliku.");
        }

        public static Graph ReadWithWeight(String path)
        {
            List<Edge> result = new List<Edge>();
            string[] lines = File.ReadAllLines(path);
            int lineNumber = 0;

            foreach (var line in lines)
            {
                lineNumber++;
                string[] edgeFromFile = line.Split(' ');

                if (edgeFromFile.Length == 3)
                {
                    Edge edge = new Edge();
                    edge.From = int.Parse(edgeFromFile[0]);
                    edge.To = int.Parse(edgeFromFile[1]);
                    edge.Weight = int.Parse(edgeFromFile[2]);
                    result.Add(edge);
                }
                else if (edgeFromFile.Length == 2)
                {
                    Console.WriteLine(" v - liczba wierzcholkow grafu G, e - liczba krawedzi grafu G");
                }
                else
                {
                    throw new ArgumentException("Invalid data format");
                }


                System.Console.WriteLine(line);

            }

            Graph graphResult = new Graph();

            List<int> listaWierzcholkow = new List<int>();
            foreach (var wierzch in result)
            {
                listaWierzcholkow.Add(wierzch.From);
                listaWierzcholkow.Add(wierzch.To);

            }
            var unikatoweWierzcholki = listaWierzcholkow.Distinct().ToArray();

            graphResult.NVerticies = unikatoweWierzcholki.Length;
            graphResult.NEdges = result.Count;
            //result.RemoveAt(0);
            graphResult.Edges = result;
            return graphResult;
        }

        public static void SaveWithWeight(Graph graph)
        {
            string[] lines = new string[graph.Edges.Count + 2];
            int numerLinii = 0;
            lines[numerLinii] = "graph W {";

            foreach (Edge edge in graph.Edges)
            {
                numerLinii++;
                lines[numerLinii] = edge.From + " -- " + edge.To + "[label=\"" + edge.Weight +"\"];";
            }
            lines[lines.Length - 1] = "}";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\msawicki\Desktop\University\Grafy-i-sieci\Lista3\Lista3Grafy\Lista3Grafy\wGraphViz.txt"))
            {
                foreach (string line in lines)
                {
                    file.WriteLine(line);
                }
            }
            Console.WriteLine("Zapisano do pliku.");
        }

    }
    //
}
