using System;
using System.Windows.Forms;

namespace InitOpenGL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //вызываю команду инициализации
            simpleOpenGlControl1.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //при загрузке формы загружаются точки
            GenPoint();
            //включаем таймер
        }

        //Массив координат точек. Глобальная переменная по 2 значения на  20 точек
        float[] Coord = new float[1440];
        //переменная для генерации координат
        Random r = new Random();
        //Метод получения координаты
        float GenNumber()
        {
             /*генератор может создавать */
                float X=1;
            /*пока неправельное значение не будем его отдавать*/
             while ((0.9f < X  ) || (0.01f > X) ) 
                { 
                 /*генерируем новое значение*/
                    X=(float)Math.Pow(0.9, r.Next(-100, 100));
                }
            /*все хорошо ворзвращаем его в ответ*/
             return X;
        }

        void GenPoint()
        {
            
            /*количество элементов массивов для заполнения */
            int step = Coord.Length/4;
            /*генерируем 20 точек*/
            for (int Index = 0; Index < step; Index++) Coord[Index] = GenNumber();
           /*******************************************************************************/
            /*отражаем точки относительно оси Y*/
            for (int Index = 0; Index < step; Index++)
                /*если номер четный это значит что это Y отражае по нему координаты*/
                if (Index % 2 == 0) /*если четная */
                    Coord[step + Index] = -Coord[Index]; /*ортажаем координату X*/
                else /*если не четное чисо*/ 
                    Coord[step + Index] = Coord[Index]; /* просто переносим как есть*/
            /*******************************************************************************/
            step *= 2; /*вторая часть окна */
            for (int Index = 0; Index < step; Index++)
                /*если номер четный это значит что это X отражае по нему координаты*/
                if (Index % 2 == 0) 
                    Coord[step + Index] = Coord[Index]; /*X оставляем как есть*/
                else 
                    Coord[step + Index] = -Coord[Index];/*Y переносим вниз */
            /*******************************************************************************/

        }

        void MovePoint() 
        {
            float Speed = 0.001f;
            /*количество элементов массивов для заполнения */
            int step = Coord.Length / 4; ;
            /*перемещаем первые 80 точек по осям X и Y*/
            for (int Index = 0; Index < step; Index+=2)
            {
                float A = Coord[Index] + Speed,
                      B = Coord[Index + 1] + Speed;
                if((A>1)||(B>1))
                {   
                    A=GenNumber();
                    B=GenNumber();
                }
                Coord[Index] = A;
                Coord[Index + 1] = B;
                /*проверяем какое из значений вышло за границ*/
            }  
            /*отрображаем все точки по старой схеме*/
            /*******************************************************************************/
            /*отражаем точки относительно оси Y*/
            for (int Index = 0; Index < step; Index++)
                /*если номер четный это значит что это Y отражае по нему координаты*/
                if (Index % 2 == 0) /*если четная */
                    Coord[step + Index] = -Coord[Index]; /*ортажаем координату X*/
                else /*если не четное чисо*/
                    Coord[step + Index] = Coord[Index]; /* просто переносим как есть*/
            /*******************************************************************************/
            step *= 2; /*вторая часть окна */
            for (int Index = 0; Index < step; Index++)
                /*если номер четный это значит что это X отражае по нему координаты*/
                if (Index % 2 == 0)
                    Coord[step + Index] = Coord[Index]; /*X оставляем как есть*/
                else
                    Coord[step + Index] = -Coord[Index];/*Y переносим вниз */
            /*******************************************************************************/
        }
     
        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            MovePoint();
            /*устанвливем в черный цвет */
            Tao.OpenGl.Gl.glClearColor(0, 0, 0, 0);
            /*сообщаем что нужно очистить два буфера */
            Tao.OpenGl.Gl.glClear(
                       Tao.OpenGl.Gl.GL_COLOR_BUFFER_BIT | //очистка буфера цвета
                       Tao.OpenGl.Gl.GL_DEPTH_BUFFER_BIT   //очистка буфера глубины
                       );

            /*включаем буфер точек*/
            Tao.OpenGl.Gl.glEnableClientState(Tao.OpenGl.Gl.GL_VERTEX_ARRAY);
            /*загружаем данные буфер*/
            Tao.OpenGl.Gl.glVertexPointer(2, // количество координат на одну точку
                                          Tao.OpenGl.Gl.GL_FLOAT, //тип данных точки 
                                          0, // смещение координат для чтения следующей точки 
                                          Coord); //масси точек
            /*сообщаем что нужно рисовать точку или точки*/
            Tao.OpenGl.Gl.glBegin(Tao.OpenGl.Gl.GL_POINTS);
            /*перебираем все элементы точек */
            for (int P = 0; P < (Coord.Length/2); P++)
                /*сообщаем что хотим нарисовать элемент с номером 0 */
                Tao.OpenGl.Gl.glArrayElement(P);
            /*сообщаем что завершили рисовать точку или точки*/
            Tao.OpenGl.Gl.glEnd();
            /*перерисовываем окно */
            simpleOpenGlControl1.Invalidate();
        }

    }
}
