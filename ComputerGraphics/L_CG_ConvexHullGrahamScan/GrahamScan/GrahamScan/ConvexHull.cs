using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace GrahamScan
{
    //Создает выпуклую оболочку, используя алгоритм обхода Грэма
    public static class ConvexHull
    {
        //Three points are a counter-clockwise turn if ccw > 0, clockwise if
        //ccw < 0, and collinear if ccw = 0 because ccw is a determinant that
        //gives the signed area of the triangle formed by p1, p2 and p3.
        private static double ConterClockWise(Point p1, Point p2, Point p3)
        {
            return (p2.X - p1.X) * (p3.Y - p1.Y) - (p2.Y - p1.Y) * (p3.X - p1.X);
        }

        //Сортирует лист точек, используя PolarAngleComparer
        private static void SortByPolarAngle(List<Point> source)
        {
            Point point0;
            // determine the point with min Y
            double minY = source.Min(pointCoordY => pointCoordY.Y);
            var leftPoints = source.Where(point=>point.Y == minY);
            if (leftPoints.Count() > 1)
            {
                // if there are more than 1 point, get the point with min X
                double minX = leftPoints.Min(pointCoordX => pointCoordX.X);
                point0 = leftPoints.First(point => point.X == minX);
            }
            else
            {
                point0 = leftPoints.First();
            }
            source.Sort(new PolarAngleComparer(point0));
        }

        //Создает список точек выпуклой оболочки из заданного списка точек
        public static List<Point> CreateConvexHull(List<Point> source)
        {
            //1.создаёт стэк точек
            Stack<Point> result = new Stack<Point>();
            //2.сортирует точки по полярному углу
            SortByPolarAngle(source);
            //3.инициализирует стэк первыми двумя точками
            result.Push(source[0]);
            result.Push(source[1]);

            //4.проверяем каждую следующую точку
            for (int i = 2; i < source.Count; i++)
            {
                //5.угол между NEXT_TO_TOP[S], TOP[S], и p(i) совершает не левый поворот -> удалить если не вершина
                while (ConterClockWise(result.ElementAt(1), result.Peek(), source[i]) > 0)
                {
                    result.Pop();

                }
                result.Push(source[i]);
            }
            return new List<Point>(result);
        }

        //Сравнивает точки по полярному углу с точкой 0.
        class PolarAngleComparer : IComparer<Point>
        {
            private Point point0;

            //Создает экземпляр PolarAngleComparer
            public PolarAngleComparer(Point point0)
            {
                this.point0 = point0;
            }

            //Сравнивает 2 значения точки, чтобы определить значение с минимальным полярным углом к заданной нулевой точке
            /// <param name="a">1-ая точка</param>
            /// <param name="b">2-ая точка</param>
            /// <returns>a<b => value < 0; a==b => value == 0; a>b => value > 0</returns>
            public int Compare(Point a, Point b)
            {
                double angleA = (point0.X - a.X) / (a.Y - point0.Y);
                double angleB = (point0.X - b.X) / (b.Y - point0.Y);

                int result = (-angleA).CompareTo(-angleB);
                if (result == 0)
                {
                    double distanceA = (a - point0).LengthSquared;
                    double distanceB = (b - point0).LengthSquared;
                    result = distanceA.CompareTo(distanceB);
                }
                return result;
            }
        }

    }
}
