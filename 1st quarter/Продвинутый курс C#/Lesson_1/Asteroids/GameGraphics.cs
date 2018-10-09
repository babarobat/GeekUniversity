using System;
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
            Timer timer = new Timer { Interval = 50};
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


            _objects = new BaseObject[30];
            for (int i = 0; i < _objects.Length; i++)
            {
                var tmpPos = new Point(600, i * 20);
                var tmpDir = new Point(15-i, 15 -i);
                var tmpSize = new Size(20, 20);
                _objects[i] = new Star(tmpPos, tmpDir, tmpSize);
            }
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
