﻿using System;
using System.Windows.Forms;
using System.Drawing;

namespace Asteroids
{
    /// <summary>
    /// Основной класс для отрисовки графики игры
    /// </summary>
    static class GameGraphics
    {
        /// <summary>
        /// Расширение с методами для графических буферов для двойной буферизации
        /// </summary>
        private static BufferedGraphicsContext _context;
        /// <summary>
        /// Буфер
        /// </summary>
        public static BufferedGraphics Buffer;
        /// <summary>
        /// Ширина экрана c игрой
        /// </summary>
        public static int Width { get; set;}
        /// <summary>
        /// Высота экрана c игрой
        /// </summary>
        public static int Height {get;set;}
        /// <summary>
        /// Массив объектов, которые будут инициализированы и отрисованы
        /// </summary>
        private static BaseObject[] _objects;
        /// <summary>
        /// Желаемый FPS
        /// </summary>
        public const int TargetFPS = 60;
        /// <summary>
        /// Как часто нужно вызывать срабатывание события Timer_tick для поддержания требуемого FPS? Округлено до int
        /// </summary>
        private static int _getTargetUpdatePerSecCount(int tragetUpdatePerSecCount)
        {
            return 1000 / tragetUpdatePerSecCount;
        }
        static GameGraphics() { }

        /// <summary>
        /// Инициализирует графику
        /// </summary>
        /// <param name="form">Форма для инициализации</param>
        public static void Init(Form form)
        {
            Graphics graphics = form.CreateGraphics();           
            _context = BufferedGraphicsManager.Current;
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(graphics, new Rectangle(0, 0, Width, Height));
            Load();
            Timer timer = new Timer { Interval = _getTargetUpdatePerSecCount(TargetFPS) };
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        /// <summary>
        /// Отривсовывает кадр
        /// </summary>
        public static void DrawGraphics()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (var obj in _objects)
            {
                obj.Draw();
            }
            Buffer.Render();
        }
        /// <summary>
        /// Смена кадра
        /// </summary>
        public static void UpdateGraphics()
        {
            foreach (var obj in _objects)
            {
                obj.Update();
            }
        }
       /// <summary>
       /// Создает обьекты на сцене
       /// </summary>
        public static void Load()
        {
            // сделать рандомное заполнение списка разными обьектами
            
            _objects = new BaseObject[4];
            _objects[0] = new BackGround(50, "Resources/BG_Stars.png");
            _objects[1] = new BackGround(100, "Resources/BG_Stars1.png");
            _objects[2] = new BackGround(800, "Resources/BG_Stars2.png");
            _objects[3] = new BackGround(60, "Resources/BG_Stars3.png");

        }
        /// <summary>
        /// Событие для таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            DrawGraphics();
            UpdateGraphics();
            
        }
    }
}
