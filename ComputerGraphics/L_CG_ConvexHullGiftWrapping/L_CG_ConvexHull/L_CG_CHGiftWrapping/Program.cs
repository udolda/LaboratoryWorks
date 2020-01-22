using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_CG_CHGiftWrapping
{
    public class Point
    {
        public int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Program
    {

        // Для нахождения ориентации упорядоченного триплета (p, q, r). 
        // Функция возвращает следующие значения
        // 0 --> p, q и r колинеарны 
        // 1 --> По часовой стрелке 
        // 2 --> Против часовой стрелки 
        public static int orientation(Point p, Point q, Point r)
        {
            int val = (q.y - p.y) * (r.x - q.x) - (q.x - p.x) * (r.y - q.y);

            if (val == 0) return 0; // коллинеарны
            return (val > 0) ? 1 : 2; // по или против часовой стрелки 
        }

        // Печатает выпуклую оболочку набора из n точек. 
        public static void convexHull(Point[] points, int n)
        {
            // Должно быть минимум три точки 
            if (n < 3) return;

            // Инициализация результирующего массива 
            List<Point> hull = new List<Point>();

            // Находит самую левую точку 
            int l = 0;
            for (int i = 1; i < n; i++)
                if (points[i].x < points[l].x) l = i;

            // Начиная с самой левой точки, движемся  
            // против часовой стрелки пока не дойдём до начальной точки
            // снова.
            int p = l, q;
            do
            {
                // Добавляем текущую точки в result
                hull.Add(points[p]);

                // Ищем точку q, такую что
                // ориентация(p, x, q) против часовой стрелки  
                // для всех точек x. Идея состоит в том,  
                // чтобы отслеживать последнюю посещаемую точку против часовой стрелки 
                // в q. Если какая-либо точка i сильнее
                // против часовой стрелки чем q, тогда обновляем q. 
                q = (p + 1) % n;

                for (int i = 0; i < n; i++)
                {
                    // Если i сильнее против часовой стрелки, чем
                    // текущая q, обновляем q 
                    if (orientation(points[p], points[i], points[q])
                                                        == 2)
                        q = i;
                }

                // Теперь q лежит дальше всех против часовой стрелки
                // по отношению к p. Ставим p как q для следующей итерации,  
                // так что q теперь добавлена к результату 'hull' 
                p = q;

            } while (p != l); // Пока не дошли до исходной точки

            // Печатает результат 
            foreach (Point temp in hull) Console.WriteLine("(" + temp.x + ", " + temp.y + ")");
        }

        /* Точка входа */
        public static void Main(String[] args)
        {
            const int n = 7;//8;
            Point[] points = new Point[n];
            points[0] = new Point(0, 3);
            points[1] = new Point(2, 3);
            points[2] = new Point(1, 1);
            points[3] = new Point(2, 1);
            points[4] = new Point(3, 0);
            points[5] = new Point(0, 0);
            points[6] = new Point(3, 3);
            //points[7] = new Point(4, 2);

            convexHull(points, n);

            Console.ReadKey();
        }
    }

}
