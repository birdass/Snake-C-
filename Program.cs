using System;
using System.Collections.Generic;
using System.Linq;

namespace zmeika
{
    class Game {
        static Walls walls; //объявили
        static FoodFactory foodFactory;

        static readonly int x = 80; // Задаем начальные точки
        static readonly int y = 26;

        static void Main()
        {
            foodFactory = new FoodFactory(x, y, '@');
            foodFactory.CreateFood();
            walls = new Walls(x, y, '#'); // инициализировали
            Console.SetWindowSize(x + 1, y + 1); // Размер окна
            Console.SetBufferSize(x + 1, y + 1); // буфер окна консоли
            Console.CursorVisible = false; // Скрыли курсор
        }
    }

    struct Point // создаем точку которая содержит координаиы и делаем методы для вывода на экран
    {
        public int x { get; set; }
        public int y { get; set; }
        public char ch { get; set; }

        public static implicit operator Point((int, int, char) value) =>
            new Point { x = value.Item1, y = value.Item2, ch = value.Item3 };

        public void Draw()
        {
            DrawPoint(ch);
        }
        public void Clear() //стирание точки
        {
            DrawPoint(' ');
        }
        private void DrawPoint(char _ch)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(_ch);
        }
    }

    class Walls //создаем класс стен
    {
        private char ch;
        private List<Point> wall = new List<Point>();

        public Walls(int x, int y, char ch)
        {
            this.ch = ch;
            DrawHorizontal(x, 0);
            DrawHorizontal(x, y);
            DrawVertical(0, y);
            DrawVertical(x, y);

        }

        private void DrawHorizontal(int x, int y) // рисовка стен
        {
            for (int i = 0; i < x; i++)
            {
                Point p = (i, y, ch);
                p.Draw();
                wall.Add(p);
            }
        }

        private void DrawVertical(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                Point p = (x, i, ch);
                p.Draw();
                wall.Add(p);
            }
        }

    }

    class FoodFactory
    {
        int x;
        int y;
        char ch;
        public Point food { get; private set; }

        Random random = new Random();

        public FoodFactory(int x, int y, char ch)
        {
            this.x = x;
            this.y = y;
            this.ch = ch;
        }

        public void CreateFood()
        {
            food = (random.Next(2, x - 2), random.Next(2, y - 2), ch);
            food.Draw();
        }

        enum Direction
        {
            LEFT,
            RIGHT,
            UP,
            DOWN
        }

        class Snake
        {
            private List<Point> snake;
        }

    }


}
