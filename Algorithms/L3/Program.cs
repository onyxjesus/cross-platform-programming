using System;
using System.Collections.Generic;
using System.IO;

namespace L3
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader inp = new StreamReader("input.txt");
            int N = Int32.Parse(inp.ReadLine());
            Dictionary<string, List<string>> G = new Dictionary<string, List<string>>();
            
            for (int i = 0; i < N; i++)
            {
                string key = inp.ReadLine();
                G.Add(key, new List<string>());
                
                int k = Int32.Parse(inp.ReadLine());
                for (int j = 0; j < k; j++)
                    G[key].Add(inp.ReadLine());
                inp.ReadLine();
            }
            foreach (var key in G.Keys)
            {
                var res = BFS(G, key);
                Console.WriteLine(BFS(G, key) ? "YES":"NO");
            }
        }
        public static bool BFS(Dictionary<string, List<string>> G, string k)
        {
            Dictionary<string, bool> isVisited = new Dictionary<string, bool>();
            foreach (var key in G.Keys)
            {
                isVisited.Add(key, false);
            }
            Queue<string> q = new Queue<string>();
            q.Enqueue(k);
            isVisited[k] = true;
            while (q.Count!=0)
            {
                var neighbours = G[q.Dequeue()];
                foreach (var neighbour in neighbours)
                {
                    if (neighbour == k)
                        return true;
                    if (!isVisited[neighbour])
                    {
                        q.Enqueue(neighbour);
                        isVisited[neighbour] = true;
                    }
                }
            }
            return false;
        }
    }

}
