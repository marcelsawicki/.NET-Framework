using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPF.Service
{
    class GraphService
    {
        public static void ShowEdgesNumber(Graph graph)
        {
            System.Console.WriteLine("Liczba krawedzi grafu: " + graph.NEdges.ToString());
        }

        public static void ShowVerticiesNumber(Graph graph)
        {
            System.Console.WriteLine("Liczba wierzcholkow grafu: " + graph.NVerticies.ToString());
        }

        public static void ShowEdges(Graph graph)
        {
            Console.WriteLine("Wyswietlanie krawedzi grafu.");
            foreach (Edge edge in graph.Edges)
            {
                System.Console.WriteLine("Krawedz: " + edge.From.ToString() + ", " + edge.To.ToString());
            }

        }

        public static void ZnajdzNajkrotszaDroge(Graph graphWithWeight)
        {
            int pWierzch = 1;
            int dWierzch = 2;

            try
            {
                Console.Write("Podaj pierwszy wierzcholek: ");
                string pierwszyWierzcholek = Console.ReadLine();
                pWierzch = int.Parse(pierwszyWierzcholek);

                Console.Write("Podaj drugi wierzcholek: ");
                string drugiWierzcholek = Console.ReadLine();
                dWierzch = int.Parse(drugiWierzcholek);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nie podano liczby we wlasciwym formacie.");
            }

            Dijkstra(pWierzch, dWierzch, graphWithWeight);
        }

        public static void ProblemKomiwojazeraBezWczytywaniaGrafu()
        {
            int[,] tabelaMiast = new int[10, 10] {
                { 0, 296, 133, 389, 311, 360, 558, 260, 168, 291},
                { 296, 0, 262, 272, 445, 564, 645, 450, 280, 82},
                { 133, 262, 0, 219, 201, 337, 449, 223, 287, 193},
                { 389, 272, 219, 0, 164, 459, 377, 277, 429, 194},
                { 311, 445, 201, 164, 0, 316, 243, 140, 467, 367},
                { 360, 564, 337, 459, 316, 0, 366, 170, 508, 531},
                { 558, 645, 449, 377, 243, 366, 0, 258, 711, 568},
                { 260, 450, 223, 277, 140, 170, 258, 0, 427, 416},
                { 168, 280, 287, 429, 467, 508, 711, 427, 0, 343},
                { 291, 82, 193, 194, 367, 531, 568, 416, 343, 0},
            };

            List<int> odwiedzoneMiasta = new List<int>();
            List<Roads> sciezka = new List<Roads>();
            Dictionary<int, string> slownikMiast = new Dictionary<int, string>();
            slownikMiast.Add(0, "Warszawa");
            slownikMiast.Add(1, "Kraków");
            slownikMiast.Add(2, "Łódź");
            slownikMiast.Add(3, "Wrocław");
            slownikMiast.Add(4, "Poznań");
            slownikMiast.Add(5, "Gdańsk");
            slownikMiast.Add(6, "Szczecin");
            slownikMiast.Add(7, "Bydgoszcz");
            slownikMiast.Add(8, "Lublin");
            slownikMiast.Add(9, "Katowice");

            Console.WriteLine("Proszę podać numer miasta z którego rozpoczyna trasę komiwojażer.");
            for (int k = 0; k < slownikMiast.Count; k++)
            {
                Console.WriteLine("{0} - {1}", k, slownikMiast[k]);
            }
            int miasto = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Rozpoczynam wedrowke z miasta {0}.", miasto);
            int miastoZktoregoStartuje = miasto;
            odwiedzoneMiasta.Add(miastoZktoregoStartuje);
            do
            {
                Roads drogaDoNajblizszegoMiasta = new Roads();
                int odleglosc = 1000000000;
                int kolejneMiasto = miasto;
                bool nieodwiedzone = true;

                for (int d = 0; d < tabelaMiast.GetLength(0); d++)
                {

                            if (tabelaMiast[miasto,d] < odleglosc && miasto!=d)
                            {
                                foreach (int odwiedzone in odwiedzoneMiasta)
                                {
                                    if (odwiedzone == d)
                                    {
                                        nieodwiedzone = false;
                                    }
                                }

                                if (nieodwiedzone)
                                {
                                    odleglosc = tabelaMiast[miasto, d];
                                    kolejneMiasto = d;
                                }
                                nieodwiedzone = true;
                            }
                    
                    drogaDoNajblizszegoMiasta.From = miasto;
                    drogaDoNajblizszegoMiasta.To = kolejneMiasto;
                    drogaDoNajblizszegoMiasta.HowLong = odleglosc;                    
                }
                odwiedzoneMiasta.Add(drogaDoNajblizszegoMiasta.To);
                miasto = drogaDoNajblizszegoMiasta.To;
                sciezka.Add(drogaDoNajblizszegoMiasta);
                Console.WriteLine("Jestem w miescie {0}, szukam najbliższego miasta. Najblizsze miasto to {1} do ktorego jest {2} km", slownikMiast[drogaDoNajblizszegoMiasta.From], slownikMiast[drogaDoNajblizszegoMiasta.To], drogaDoNajblizszegoMiasta.HowLong);
            }
            while (odwiedzoneMiasta.Count < tabelaMiast.GetLength(0));
            Console.WriteLine("Powrót z {0} do {1} to odległośc {2} km.", slownikMiast[odwiedzoneMiasta.Last()], slownikMiast[miastoZktoregoStartuje], tabelaMiast[miastoZktoregoStartuje, odwiedzoneMiasta.Last()]);
        }
        // koniec metody bez grafu 

        public static void ProblemKomiwojazera(Graph graph)
        {
            List<int> odwiedzoneMiasta = new List<int>();
            List<Roads> sciezka = new List<Roads>();
            Dictionary<int, string> slownikMiast = new Dictionary<int, string>();
            slownikMiast.Add(1, "Warszawa");
            slownikMiast.Add(2, "Kraków");
            slownikMiast.Add(3, "Łódź");
            slownikMiast.Add(4, "Wrocław");
            slownikMiast.Add(5, "Poznań");
            slownikMiast.Add(6, "Gdańsk");
            slownikMiast.Add(7, "Szczecin");
            slownikMiast.Add(8, "Bydgoszcz");
            slownikMiast.Add(9, "Lublin");
            slownikMiast.Add(10, "Katowice");

            Console.WriteLine("Proszę podać numer miasta z którego rozpoczyna trasę komiwojażer.");
            for(int k=1; k<=slownikMiast.Count;k++)
            {
                Console.WriteLine("{0} - {1}", k, slownikMiast[k]);
            }
            int miasto = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Rozpoczynam wedrowke z miasta {0}.",miasto);
            odwiedzoneMiasta.Add(miasto);
            do
            {
                Roads najblizszeMiasto = ZnajdzNajblizszeMiasto(graph, miasto, odwiedzoneMiasta, slownikMiast);
                odwiedzoneMiasta.Add(najblizszeMiasto.To);
                miasto = najblizszeMiasto.To;
                sciezka.Add(najblizszeMiasto);
            }
            while (odwiedzoneMiasta.Count < graph.NVerticies);
            int drogaDoPowrotu = 0;
            foreach (Edge edge in graph.Edges)
            {
                if(edge.From == odwiedzoneMiasta[odwiedzoneMiasta.Count - 1] && edge.To == odwiedzoneMiasta[0])
                {
                    drogaDoPowrotu = edge.Weight;
                }
            }
            int ostatnieMiasto = odwiedzoneMiasta[odwiedzoneMiasta.Count - 1];
            int dom = odwiedzoneMiasta[0];
            Console.WriteLine("Powrót: {0} do miasta {1}, dlugosc drogi: {2} km", slownikMiast[ostatnieMiasto], slownikMiast[dom], drogaDoPowrotu);
        }

        public static Roads ZnajdzNajblizszeMiasto(Graph graph, int miasto, List<int> odwiedzoneMiasta, Dictionary<int, string> slownikMiast)
        {
            Roads drogaDoNajblizszegoMiasta = new Roads();
            int odleglosc = 1000000000;
            int kolejneMiasto = miasto;
            bool nieodwiedzone = true;
            foreach (Edge road in graph.Edges)
            {
                if (road.From == miasto)
                {

                    if (road.Weight < odleglosc && road.To != miasto)
                    {
                        foreach (int odwiedzone in odwiedzoneMiasta)
                        {
                            if (odwiedzone == road.To)
                            {
                                nieodwiedzone = false;
                            }
                        }

                        if (nieodwiedzone)
                        {
                            odleglosc = road.Weight;
                            kolejneMiasto = road.To;
                        }
                        nieodwiedzone = true;
                    }
                }
            }
            drogaDoNajblizszegoMiasta.From = miasto;
            drogaDoNajblizszegoMiasta.To = kolejneMiasto;
            drogaDoNajblizszegoMiasta.HowLong = odleglosc;
            Console.WriteLine("Jestem w miescie {0}, szukam najbliższego miasta. Najblizsze miasto to {1} do ktorego jest {2} km", slownikMiast[miasto],slownikMiast[kolejneMiasto],odleglosc);
            return drogaDoNajblizszegoMiasta;
        }

        public static void ZnajdzNajkrotszeDrogiDlaKombinacjiBezPowtorzen(Graph graphWithWeight)
        {
            List<int> wierzcholki = ShowVerticies(graphWithWeight);
            List<Vertices> kombinacjeBezPowtorzen = new List<Vertices>();
            List<Vertices> kombinacjeZPowtorzeniami = new List<Vertices>();

            foreach (int from in wierzcholki)
            {
                foreach (int to in wierzcholki)
                {
                    Vertices para = new Vertices();
                    para.From = from;
                    para.To = to;
                    kombinacjeZPowtorzeniami.Add(para); 
                }
            }

            bool shouldBeAdded = true;
            foreach (var kombinacja in kombinacjeZPowtorzeniami)
            {
                foreach (var item in kombinacjeBezPowtorzen)
                {
                    if (item.From == kombinacja.From && item.To == kombinacja.To)
                    {
                        shouldBeAdded = false;
                    }
                    else if (item.To == kombinacja.From && item.From == kombinacja.To)
                    {
                        shouldBeAdded = false;
                    }
                }

                if (kombinacja.From == kombinacja.To)
                {
                    shouldBeAdded = false;
                }

                if (shouldBeAdded)
                {
                    kombinacjeBezPowtorzen.Add(kombinacja);
                }

                shouldBeAdded = true;
            }

            foreach (var couple in kombinacjeBezPowtorzen)
            {
                Dijkstra(couple.From, couple.To, graphWithWeight);
            }
            

        }

        public static void Dijkstra(int poczatek, int koniec, Graph graph)
        {
            List<int> wierzcholki = ShowVerticies(graph);
            const int INF = 1000000;
            Dictionary<int,int> shortest = new Dictionary<int,int>();
            List<int> collectionQ = new List<int>();
            int[] prev = new int[wierzcholki.Count()+1];

            foreach (int vertex in wierzcholki)
            {
                if (vertex != poczatek)
                {
                    shortest.Add(vertex,INF);
                }
                else
                {
                    shortest.Add(vertex,0);
                }

                collectionQ.Add(vertex);
            }
            int elementMinimalny = poczatek;
            while (collectionQ.Count > 0)
            {
                //szukaj elementu minimalnego
                Dictionary<int,int> szukamMinimum = new Dictionary<int,int>();
                foreach (int item in collectionQ)
                {
                    szukamMinimum[item] = (shortest[item]);
                }
                int wynik = szukamMinimum.OrderBy(x => x.Value).FirstOrDefault().Key;

                int wierzcholekDoUsunieciaZeZbioruQ = wynik;
                szukamMinimum.Clear();

                Stack<int> sasiadujaceWierzcholki = new Stack<int>();

                foreach (Edge edge in graph.Edges)
                {
                    if (wierzcholekDoUsunieciaZeZbioruQ == edge.From)
                    {
                        sasiadujaceWierzcholki.Push(edge.To);
                    }

                    if (wierzcholekDoUsunieciaZeZbioruQ == edge.To)
                    {
                        sasiadujaceWierzcholki.Push(edge.From);
                    }
                }
                int u = wierzcholekDoUsunieciaZeZbioruQ;
                foreach (int v in sasiadujaceWierzcholki)
                {
                    //Weaken(u, v, graph, out shortest, out prev);
                    int waga = GetEdgeWeight(u, v, graph);

                    if ((shortest[u] + waga) < shortest[v])
                    {
                        shortest[v] = (shortest[u] + waga);
                        prev[v] = u;
                    }
                }

                int qIndex = 0;
                int removeIndex = 0;
                foreach (int q in collectionQ)
                {
                    if (q == wierzcholekDoUsunieciaZeZbioruQ)
                    {
                        removeIndex = qIndex;
                    }
                    qIndex++;
                }
                sasiadujaceWierzcholki.Clear();
                collectionQ.RemoveAt(removeIndex);
            }
            Console.WriteLine("Najkrotsza droga pomiędzy wierzchołkami {0} i {1} wynosi: {2}.",poczatek,koniec,shortest[koniec]);
        }

        public static void Weaken(int u, int v, Graph graph, Dictionary<int, int> shortest, int[] prev)
        {
            int waga = GetEdgeWeight(u, v, graph);

            if ((shortest[u] + waga) < shortest[v])
            {
                shortest[u] = (shortest[u] + waga);
                prev[v] = u;
            }
        }

        public static int GetEdgeWeight(int u, int v, Graph graph)
        {
            int zwracanaWaga = 0;
            foreach (Edge edge in graph.Edges)
            {
                if ((edge.From == u && edge.To == v)|| (edge.From == v && edge.To == u))
                {
                    zwracanaWaga = edge.Weight;
                }
            }

            return zwracanaWaga;
        }

        public static Graph UtworzGrafKolo(Graph graph)
        {
            List<int> wierzcholki = GetVerticies(graph);
            int najwyzszy = wierzcholki.Last();

            Graph grafTypuKolo = new Graph();
            List<Edge> krawedzieGrafuKolo = new List<Edge>();
            Edge ostatniaKrawedz = graph.Edges.Last();

            foreach (Edge edge in graph.Edges)
            {
                Edge wierzcholekDodawany = new Edge();
                wierzcholekDodawany.From = edge.From;
                wierzcholekDodawany.To = edge.To;
                krawedzieGrafuKolo.Add(wierzcholekDodawany);
            }

            foreach (int wierzcholek in wierzcholki)
            {
                Edge krawedzKola = new Edge();
                krawedzKola.From = wierzcholek;
                krawedzKola.To = najwyzszy + 1;
                krawedzieGrafuKolo.Add(krawedzKola);
            }

            Console.WriteLine("Utworzylem graf typu kolo.");
            Console.WriteLine("graph W {");

            foreach (Edge edge in krawedzieGrafuKolo)
            {
                Console.WriteLine("{0} -- {1}", edge.From, edge.To);
            }

            Console.WriteLine("}");

            grafTypuKolo.Edges = krawedzieGrafuKolo;
            grafTypuKolo.NEdges = grafTypuKolo.Edges.Count();
            grafTypuKolo.NVerticies = najwyzszy + 1;

            return grafTypuKolo;

        }

        public static List<int> ShowVerticies(Graph graph)
        {
            Console.WriteLine("Wyswietlanie wierzcholkow grafu");
            int countVertices = 0;
            int[,] verticesMatrix = new int[graph.Edges.Count,2];

            List<int> vertices = new List<int>();

            foreach (Edge edge in graph.Edges)
            {
                bool addVertexFrom = true;

                foreach (int vertex in vertices)
                {
                    if (edge.From == vertex)
                    {
                        addVertexFrom = false;
                    }
                }

                if (addVertexFrom)
                {
                    vertices.Add(edge.From);
                }

                bool addVertexTo = true;

                foreach (int vertex in vertices)
                {
                    if (edge.To == vertex)
                    {
                        addVertexTo = false;
                    }
                }

                if (addVertexTo)
                {
                    vertices.Add(edge.To);
                }
            }

            // show list of vertices

            //foreach (int v in vertices)
            //{
            //    System.Console.WriteLine(v + " vertex");
            //}
            return vertices;
        }

        public static bool SprawdzCzyGrafEulerowski(Graph pobranyGrafEulerowski)
        {
            bool eulerowski = true;
            Console.WriteLine("Twierdzenie (Euler, 1736): Graf spójny G jest grafem eulerowskim wtedy i");
            Console.WriteLine("tylko wtedy, gdy stopień każdego wierzchołka grafu G jest liczbą parzystą.");
            bool czySpojny = SprawdzCzyGrafSpojny(pobranyGrafEulerowski);
            int[,] macierzAdjacencji = ShowNAdjacencyMatrix(pobranyGrafEulerowski);
            bool czyParzysteStopnie = SprawdzCzyStopnieWierzcholkowParzyste(macierzAdjacencji);

            if (czySpojny && czyParzysteStopnie)
            {
                Console.WriteLine("Graf jest grafem eulerowskim.");
            }
            else
            {
                Console.WriteLine("Graf nie jest grafem eulerowskim.");
                eulerowski = false;
            }

            return eulerowski;

        }

        private static bool SprawdzCzyStopnieWierzcholkowParzyste(int[,] adjacencyMatrix)
        {
            bool parzyste = true;
            List<int> sumowanieWierszy = new List<int>();
            int sumaPomocnicza = 0;
            for (int m = 1; m < adjacencyMatrix.GetLength(0); m++)
            {
                for (int g = 1; g < adjacencyMatrix.GetLength(0); g++)
                {
                    sumaPomocnicza += adjacencyMatrix[m, g];
                }
                sumowanieWierszy.Add(sumaPomocnicza);
                sumaPomocnicza = 0;
            }

            var tablicaSum = sumowanieWierszy.Distinct().ToArray();

            foreach (int item in tablicaSum)
            {
                if (item % 2 != 0)
                {
                    parzyste = false;
                }
            }

            if (parzyste)
            {
                Console.WriteLine("Stopnie wierzchołków grafu sa parzyste.");
            }
            else
            {
                Console.WriteLine("Nie wszystkie stopnie wierzchołków grafu są parzyste.");
            }

            return parzyste;
        }

        private static bool SprawdzCzyStopnieWierzcholkowParzysteOrazDwaNieparzyste(int[,] adjacencyMatrix)
        {
            bool parzyste = true;
            List<int> sumowanieWierszy = new List<int>();
            int sumaPomocnicza = 0;
            for (int m = 1; m < adjacencyMatrix.GetLength(0); m++)
            {
                for (int g = 1; g < adjacencyMatrix.GetLength(0); g++)
                {
                    sumaPomocnicza += adjacencyMatrix[m, g];
                }
                sumowanieWierszy.Add(sumaPomocnicza);
                sumaPomocnicza = 0;
            }

            var tablicaSum = sumowanieWierszy.ToArray();
            int ileNieparzystych = 0;
            foreach (int item in tablicaSum)
            {
                if (item % 2 != 0)
                {
                    parzyste = false;
                    ileNieparzystych++;
                }
            }

            if (parzyste)
            {
                Console.WriteLine("Stopnie wierzchołków grafu sa parzyste.");
            }
            else
            {
                Console.WriteLine("Nie wszystkie stopnie wierzchołków grafu są parzyste. {0} stopni nieparzystych.", ileNieparzystych);
            }

            if (ileNieparzystych == 2)
            {
                Console.WriteLine("Graf jest grafem półeulerowskim. {0} stopni nieparzystych.", ileNieparzystych);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool SprawdzCzyGrafPolEulerowski(Graph pobranyGrafEulerowski)
        {
            bool polEulerowski = false;
            Console.WriteLine("Graf spójny G jest grafem półeulerowskim wtedy i");
            Console.WriteLine("tylko wtedy, gdy ma dokładnie dwa wierzchołki nieparzystych stopni.");
            bool czySpojny = SprawdzCzyGrafSpojny(pobranyGrafEulerowski);
            int[,] macierzAdjacencji = ShowNAdjacencyMatrix(pobranyGrafEulerowski);
            bool czyParzysteStopnie = SprawdzCzyStopnieWierzcholkowParzyste(macierzAdjacencji);
            bool czyPolEulerowski = SprawdzCzyStopnieWierzcholkowParzysteOrazDwaNieparzyste(macierzAdjacencji);


            if (czySpojny && czyParzysteStopnie)
            {
                Console.WriteLine("Graf jest grafem eulerowskim.");
            }
            else if (czyPolEulerowski)
            {
                Console.WriteLine("Graf jest grafem półeulerowskim.");
                polEulerowski = true;
            }
            else
            {
                Console.WriteLine("Graf nie jest grafem półeulerowskim, nie jest tez grafem eulerowskim.");
            }

            return polEulerowski;

        }

        public static void SprawdzCzyGrafTypuKolo(Graph graph)
        {
            bool grafTypuKolo = false;
            // pobieram wszystkie wierzcholki i sprawdzam cz jest wierzcholek ktory
            // jest polaczony z wszystkimi innymi wierzcholkami
            List<int> wierzcholkiPobranegoGrafu = GetVerticies(graph);

            int sprawdzanyWierzcholek = 0;
            Stack<int> sasiadujaceWierzcholki = new Stack<int>();
            foreach (int wierzcholek in wierzcholkiPobranegoGrafu)
            {
                foreach (Edge edge in graph.Edges)
                {
                    if (wierzcholek == edge.From)
                    {
                       sasiadujaceWierzcholki.Push(edge.To);
                    }

                    if (wierzcholek == edge.To)
                    {
                      sasiadujaceWierzcholki.Push(edge.From);
                    }
                }

                if (sasiadujaceWierzcholki.Count == wierzcholkiPobranegoGrafu.Count - 1)
                {
                    Console.WriteLine("Wierzcholek grafu typu kolo do usuniecia: " + wierzcholek);
                    grafTypuKolo = true;
                    sprawdzanyWierzcholek = wierzcholek;
                }
                sasiadujaceWierzcholki.Clear();

            }

            List<Edge> tworzonyGrafCykliczny = new List<Edge>();

            // jesli jest taki wierzcholek to usuwam go i sprawdzam czy powstanie graf regularny drugiego stopnia i spojny
            if (grafTypuKolo)
            {
                Console.WriteLine("Graf jest grafem typu kolo, tworze graf cykliczny.");
                Graph grafCykliczny = UtworzGrafCykliczny(graph, sprawdzanyWierzcholek);
                GraphReader.Save(grafCykliczny, @"c.txt");
                Console.WriteLine("Zapisano utworzony graf cykliczny do pliku c.txt");
            }

        }

        private static Graph UtworzGrafCykliczny(Graph graph, int sprawdzanyWierzcholek)
        {
            Graph tworzonyGrafCykliczny = new Graph();
            List<Edge> tworzoneKrawedzieGrafuCyklicznego = new List<Edge>();
            foreach (Edge edge in graph.Edges)
            {
                if (sprawdzanyWierzcholek != edge.From && sprawdzanyWierzcholek != edge.To)
                {
                    Edge krawedzGrafuCyklicznego = new Edge();
                    krawedzGrafuCyklicznego.From = edge.From;
                    krawedzGrafuCyklicznego.To = edge.To;
                    tworzoneKrawedzieGrafuCyklicznego.Add(krawedzGrafuCyklicznego);
                }
            }

            tworzonyGrafCykliczny.Edges = tworzoneKrawedzieGrafuCyklicznego;
            tworzonyGrafCykliczny.NEdges = tworzoneKrawedzieGrafuCyklicznego.Count;
            tworzonyGrafCykliczny.NVerticies = GetVerticies(tworzonyGrafCykliczny).Count;
            return tworzonyGrafCykliczny;
        }

        private static List<int> GetVerticies(Graph graph)
        {
            int countVertices = 0;
            int[,] verticesMatrix = new int[graph.Edges.Count, 2];

            List<int> vertices = new List<int>();

            foreach (Edge edge in graph.Edges)
            {
                bool addVertexFrom = true;

                foreach (int vertex in vertices)
                {
                    if (edge.From == vertex)
                    {
                        addVertexFrom = false;
                    }
                }

                if (addVertexFrom)
                {
                    vertices.Add(edge.From);
                }

                bool addVertexTo = true;

                foreach (int vertex in vertices)
                {
                    if (edge.To == vertex)
                    {
                        addVertexTo = false;
                    }
                }

                if (addVertexTo)
                {
                    vertices.Add(edge.To);
                }
            }
            return vertices;
        }

        public static void CheckIfItIsMultigraph(Graph graph)
        {
            int countVertices =  0;
            int[,] verticesMatrix = new int[graph.Edges.Count, 2];

            foreach (Edge edge in graph.Edges)
            {
                
                for (int s = 0; s < verticesMatrix.GetLength(0); s++)
                {
                    verticesMatrix[s, 0] = edge.From;
                    verticesMatrix[s, 1] = edge.To;
                }
            }

            for (int u = 0; u < verticesMatrix.GetLength(0); u++)
            {
                for (int b = 0; b < verticesMatrix.GetLength(0); b++)
                {
                    if (verticesMatrix[u, 0] == verticesMatrix[b, 1] && verticesMatrix[u, 1] == verticesMatrix[b, 0])
                    {
                        System.Console.WriteLine("Duplikat");
                    }
                }
            }

            /*
                countVertices++;
                System.Console.WriteLine("Liczba wierzcholkow grafu G wynosi: " +countVertices);
                System.Console.WriteLine("Zbiór wierzcholkow V= " + countVertices);
             */
        }

        public static int[,] ShowNAdjacencyMatrix(Graph graph)
        {
            int matrixRow = 0;
            int[,] adjacencyMatrixPreparation = new int[graph.NEdges, 2];
            foreach (Edge item in graph.Edges)
            {

                adjacencyMatrixPreparation[matrixRow, 0] = item.From;
                adjacencyMatrixPreparation[matrixRow, 1] = item.To;
                matrixRow++;
            }

            int[,] adjacencyMatrix = new int[graph.NVerticies+1, graph.NVerticies+1];


            for (int k = 0; k <= graph.NVerticies; k++)
            {
                for (int d = 0; d <= graph.NVerticies; d++)
                {
                    for (int j = 0; j < adjacencyMatrixPreparation.GetLength(0); j++)
                    {
                        if (adjacencyMatrixPreparation[j, 0]==(k) && adjacencyMatrixPreparation[j, 1]==(d))
                        {
                            adjacencyMatrix[k, d]++;
                        }

                        if (adjacencyMatrixPreparation[j, 1] == (k) && adjacencyMatrixPreparation[j, 0] == (d))
                        {
                            adjacencyMatrix[k, d]++;
                        }
                    }
                }
            }

            System.Console.WriteLine("Macierz adjacencji");
            for (int m = 1; m < adjacencyMatrix.GetLength(0); m++)
            {
                for (int g = 1; g < adjacencyMatrix.GetLength(0); g++)
                {
                    System.Console.Write(adjacencyMatrix[m, g]);
                    System.Console.Write(", ");
                }
                System.Console.WriteLine();
            }
            return adjacencyMatrix;
        }

        public static bool SprawdzCzyGrafJestRegularny(Graph graph)
        {
            bool regularny = false;
            int matrixRow = 0;
            int[,] adjacencyMatrixPreparation = new int[graph.NEdges, 2];
            foreach (Edge item in graph.Edges)
            {

                adjacencyMatrixPreparation[matrixRow, 0] = item.From;
                adjacencyMatrixPreparation[matrixRow, 1] = item.To;
                matrixRow++;
            }

            int[,] adjacencyMatrix = new int[graph.NVerticies + 1, graph.NVerticies + 1];


            for (int k = 0; k <= graph.NVerticies; k++)
            {
                for (int d = 0; d <= graph.NVerticies; d++)
                {
                    for (int j = 0; j < adjacencyMatrixPreparation.GetLength(0); j++)
                    {
                        if (adjacencyMatrixPreparation[j, 0] == (k) && adjacencyMatrixPreparation[j, 1] == (d))
                        {
                            adjacencyMatrix[k, d]++;
                        }

                        if (adjacencyMatrixPreparation[j, 1] == (k) && adjacencyMatrixPreparation[j, 0] == (d))
                        {
                            adjacencyMatrix[k, d]++;
                        }
                    }
                }
            }

            List<int> sumowanieWierszy = new List<int>();
            int sumaPomocnicza = 0;
            for (int m = 1; m < adjacencyMatrix.GetLength(0); m++)
            {
                for (int g = 1; g < adjacencyMatrix.GetLength(0); g++)
                {
                    sumaPomocnicza += adjacencyMatrix[m, g];
                }
                sumowanieWierszy.Add(sumaPomocnicza);
                sumaPomocnicza = 0;
            }

            var tablicaSum = sumowanieWierszy.Distinct().ToArray();
            if (tablicaSum.Length > 1)
            {
                Console.WriteLine("Graf nie jest grafem regularnym.");
            }
            else
            {
                Console.WriteLine("Graf jest grafem regularnym.");
                Console.WriteLine("Stopien grafu regularnego: " +tablicaSum[0]);
                regularny = true;
            }

            return regularny;
        }

        public static void ShowIncidenceMatrix(Graph graph)
        {
            int[,] incidenceMatrix = new int[graph.NVerticies+1, graph.NEdges+1];
            int matrixRow = 0;
            int[,] incidenceMatrixPreparation = new int[graph.Edges.Count, 3];
            foreach (Edge item in graph.Edges)
            {

                incidenceMatrixPreparation[matrixRow, 0] = item.From;
                incidenceMatrixPreparation[matrixRow, 1] = item.To;
                incidenceMatrixPreparation[matrixRow, 2] = matrixRow + 1;
                matrixRow++;
            }


            for (int k = 1; k < incidenceMatrix.GetLength(0); k++)
            {
                for (int j = 1; j < incidenceMatrix.GetLength(1); j++)
                {
                    for (int g = 0; g < incidenceMatrixPreparation.GetLength(0); g++)
                    {
                        if (incidenceMatrixPreparation[g, 0] == k && incidenceMatrixPreparation[g, 2] == j)
                        {
                            incidenceMatrix[k, j]++;
                        }

                        if (incidenceMatrixPreparation[g, 1] == k && incidenceMatrixPreparation[g, 2] == j)
                        {
                            incidenceMatrix[k, j]++;
                        }
                    }
                                    
                }
            }


            System.Console.WriteLine("macierz incydencji");
            for (int m = 1; m < incidenceMatrix.GetLength(0); m++)
            {
                for (int g = 1; g < incidenceMatrix.GetLength(1); g++)
                {
                    System.Console.Write(incidenceMatrix[m, g]);
                    System.Console.Write(", ");
                }
                System.Console.WriteLine();
            }
        }

        public static void SprawdzCzyGrafCykliczny(Graph graph)
        {
            int matrixRow = 0;
            int[,] adjacencyMatrixPreparation = new int[graph.NEdges, 2];
            foreach (Edge item in graph.Edges)
            {

                adjacencyMatrixPreparation[matrixRow, 0] = item.From;
                adjacencyMatrixPreparation[matrixRow, 1] = item.To;
                matrixRow++;
            }

            int[,] adjacencyMatrix = new int[graph.NVerticies + 1, graph.NVerticies + 1];


            for (int k = 0; k <= graph.NVerticies; k++)
            {
                for (int d = 0; d <= graph.NVerticies; d++)
                {
                    for (int j = 0; j < adjacencyMatrixPreparation.GetLength(0); j++)
                    {
                        if (adjacencyMatrixPreparation[j, 0] == (k) && adjacencyMatrixPreparation[j, 1] == (d))
                        {
                            adjacencyMatrix[k, d]++;
                        }

                        if (adjacencyMatrixPreparation[j, 1] == (k) && adjacencyMatrixPreparation[j, 0] == (d))
                        {
                            adjacencyMatrix[k, d]++;
                        }
                    }
                }
            }

            System.Console.WriteLine("Macierz adjacencji");
            for (int m = 1; m < adjacencyMatrix.GetLength(0); m++)
            {
                for (int g = 1; g < adjacencyMatrix.GetLength(0); g++)
                {
                    System.Console.Write(adjacencyMatrix[m, g]);
                    System.Console.Write(", ");
                }
                System.Console.WriteLine();
            }

            List<int> sumowanieWierszy = new List<int>();
            int sumaPomocnicza = 0;
            System.Console.WriteLine("sumuje wiersze i sprawdzam czy graf jest regularny stopnia 2");
            for (int m = 1; m < adjacencyMatrix.GetLength(0); m++)
            {
                for (int g = 1; g < adjacencyMatrix.GetLength(0); g++)
                {
                    System.Console.Write(adjacencyMatrix[m, g]);
                    System.Console.Write(", ");
                    sumaPomocnicza += adjacencyMatrix[m, g];
                }
                sumowanieWierszy.Add(sumaPomocnicza);
                System.Console.WriteLine();
                sumaPomocnicza = 0;
            }

            foreach (int wynik in sumowanieWierszy)
            {
                Console.WriteLine("Zsumowany wiersz: " + wynik);
            }
            var tablicaSum = sumowanieWierszy.Distinct().ToArray();
            if (tablicaSum.Length > 1)
            {
                Console.WriteLine("Graf nie jest grafem regularnym. Graf nie jest grafem cyklicznym.");
            }
            else
            {
                Console.WriteLine("Graf jest grafem regularnym.");
                Console.WriteLine("Stopien grafu regularnego: " + tablicaSum[0]);
                if (tablicaSum[0] == 2)
                {
                    Console.WriteLine("Graf jest grafem regularnym stopnia drugiego.");
                    Console.WriteLine("Jesli jest takze spojny to jest grafem cyklicznym.");
                }
                else
                {
                    Console.WriteLine("Graf nie jest grafem regularnym stopnia drugiego, dlatego nie bedzie tez grafem cyklicznym.");
                }
            }
        }
        public static bool SprawdzCzyGrafSpojny(Graph graph)
        {
            bool spojny = false;
            int zadanyWierzcholek = graph.Edges[0].From;
            int odwiedzonyWierzcholek = zadanyWierzcholek;
            // na stosie bede odkladal wierzcholki do odwiedzenia
            Stack<int> stos = new Stack<int>();
            Stack<int> bylem = new Stack<int>();
            List<int> wszystkieWierzcholki = new List<int>();
            stos.Push(odwiedzonyWierzcholek);
            // w kolekcji visited bede przechowywal dane czy wierzcholek byl odwiedzony
            // wyszukaj wszystkich sasiadow dla wierzcholka 1

            while (stos.Count > 0)
            {
                odwiedzonyWierzcholek = stos.Pop();
                bylem.Push(odwiedzonyWierzcholek);
                foreach (Edge edge in graph.Edges)
                {
                    wszystkieWierzcholki.Add(edge.From);
                    wszystkieWierzcholki.Add(edge.To);

                    if (odwiedzonyWierzcholek == edge.From)
                    {
                        if (!stos.Contains(edge.To))
                        {
                            if (!bylem.Contains(edge.To))
                            {
                                stos.Push(edge.To);
                            }                         
                        }
                    }

                    if (odwiedzonyWierzcholek == edge.To)
                    {
                        if (!stos.Contains(edge.From))
                        {
                            if (!bylem.Contains(edge.From))
                            {
                                stos.Push(edge.From);
                            }
                        }
                        
                    }
                }
            }
            List<int> wierzchokiGrafu = wszystkieWierzcholki.Distinct().ToList();
            if (wierzchokiGrafu.Count == bylem.Count)
            {
                Console.WriteLine("Graf jest grafem spójnym.");
                spojny = true;
            }
            else
            {
                Console.WriteLine("Graf nie jest grafem spójnym.");
            }

            return spojny;
        }
    }
}
