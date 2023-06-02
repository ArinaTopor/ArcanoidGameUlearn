using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    public static class AxisCollision
    {

        public static bool CheckCollision(Rectangle rect1, Rectangle rect2)
        {
            // Проверка наличия разделяющей оси по осям x и y
            if (rect1.X + rect1.Width < rect2.X || rect2.X + rect2.Width < rect1.X)
                return false;

            if (rect1.Y + rect1.Height < rect2.Y || rect2.Y + rect2.Height < rect1.Y)
                return false;

            // Проверка наличия разделяющей оси по осям, параллельным сторонам прямоугольников
            if (!AxisSeparation(rect1, rect2, new Vector2(1, 0)))
                return false;

            if (!AxisSeparation(rect1, rect2, new Vector2(0, 1)))
                return false;

            return true;
        }
        public static Vector2 GetVertex(Rectangle rect, int i)
        {
            //получаем проекцию на каждую из осей
            Vector2[] vertices = new Vector2[4]
            {
                new Vector2(rect.X, rect.Y),
                new Vector2(rect.X + rect.Width, rect.Y),
                new Vector2(rect.X + rect.Width, rect.Y + rect.Height),
                new Vector2(rect.X, rect.Y + rect.Height)
            };
            return vertices[i];
        }

        private static bool AxisSeparation(Rectangle rect1, Rectangle rect2, Vector2 axis)
        {
            // Проекция вершин прямоугольников на ось
            var rect1Min = float.MaxValue;
            var rect1Max = float.MinValue;
            var rect2Min = float.MaxValue;
            var rect2Max = float.MinValue;
            for (int i = 0; i < 4; i++)
            {
                Vector2 vertexRect1 = GetVertex(rect1, i);
                Vector2 vertexRect2 = GetVertex(rect2, i);

                //с помощью DOT получаю скалярное произведение векторов
                float projectionRect1 = Vector2.Dot(vertexRect1, axis);
                float projectionRect2 = Vector2.Dot(vertexRect2, axis);

                rect1Min = Math.Min(rect1Min, projectionRect1);
                rect1Max = Math.Max(rect1Max, projectionRect1);
                rect2Min = Math.Min(rect2Min, projectionRect2);
                rect2Max = Math.Max(rect2Max, projectionRect2);
            }

            // Проверка наличия разделяющей проекции
            if (rect1Max < rect2Min || rect2Max < rect1Min)
                return false;

            return true;
        }
    }
}