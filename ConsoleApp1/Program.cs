namespace ConsoleApp1
{
    internal class Program
    {
        static int Main(string[] args)
        {
            int vertices; //количество вершин
            int edges;

            Console.Write("Введите количество вершин            : ");
            vertices = int.Parse(Console.ReadLine());
            Console.Write("Введите количество рёбер             : ");
            edges = int.Parse(Console.ReadLine());

            int[,] matrix = new int[vertices, vertices];

            Console.WriteLine("\nВведите рёбра (номера вершин от 0):");

            for (int i = 0; i < edges; i++)
            {
                Console.Write($"Ребро {i + 1} - вершина 1            : ");
                int v1 = int.Parse(Console.ReadLine());
                Console.Write($"Ребро {i + 1} - вершина 2            : ");
                int v2 = int.Parse(Console.ReadLine());

                matrix[v1, v2] = 1;
                matrix[v2, v1] = 1;
            }

            Console.WriteLine("\nМатрица смежности:");
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }

            // Проверка: является ли граф простым
            bool isSimple = true;
            for (int i = 0; i < vertices; i++)
            {
                if (matrix[i, i] != 0) // есть петля
                {
                    isSimple = false;
                    break;
                }
            }

            Console.WriteLine("\nГраф является простым: {0}", isSimple ? "Да" : "Нет");

            // Можно ли назвать нуль-графом
            bool isNullGraph = true;
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        isNullGraph = false;
                        break;
                    }
                }
                if (!isNullGraph) break;
            }

            Console.WriteLine("Граф является нуль-графом: {0}", isNullGraph ? "Да" : "Нет");

            // Найти максимальную степень вершины
            int maxDegree = 0;
            int maxVertex = 0;

            for (int i = 0; i < vertices; i++)
            {
                int degree = 0;
                for (int j = 0; j < vertices; j++)
                {
                    degree += matrix[i, j];
                }

                Console.WriteLine("Степень вершины {0}: {1}", i, degree);

                if (degree > maxDegree)
                {
                    maxDegree = degree;
                    maxVertex = i;
                }
            }


            Console.WriteLine("\nМаксимальная степень вершины: {0}", maxDegree);
            Console.WriteLine("Вершина с максимальной степенью: {0}", maxVertex);

            // Есть ли в графе висячие вершины (степень = 1)
            Console.WriteLine("\nВисячие вершины:");
            bool hasHanging = false;
            for (int i = 0; i < vertices; i++)
            {
                int degree = 0;
                for (int j = 0; j < vertices; j++)
                {
                    degree += matrix[i, j];
                }

                if (degree == 1)
                {
                    Console.WriteLine("Вершина {0}", i);
                    hasHanging = true;
                }
            }

            if (!hasHanging)
            {
                Console.WriteLine("Висячих вершин нет");
            }

            Console.ReadKey();
            return 0;
        }
    }
}
