using System;
using System.Collections.Generic;
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
        public static List< BaseObject> Objects;
        /// <summary>
        /// Желаемый FPS
        /// </summary>
        public const int TargetFPS = 60;
        
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
            foreach (var obj in Objects)
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
            foreach (var obj in Objects)
            {
                obj.Update();
            }
        }
       /// <summary>
       /// Создает обьекты на сцене
       /// </summary>
        public static void Load()
        {
            
            Objects = new List<BaseObject>();
            List<string> bgAdresses = ResourcesLoader.GetImage(TypeOf.backGround);

            Objects.Add( new BackGround(20, bgAdresses[0]));
            Objects.Add(new BackGround(70, bgAdresses[1]));
            Objects.Add(new BackGround(450, bgAdresses[2]));
            for (int i = 3; i < 10; i++)
            {
                Objects.Add(new Asteroid(ResourcesLoader.GetImage(TypeOf.asteroid)[0]));
            }
            Objects.Add(new Rocket(ResourcesLoader.GetImage(TypeOf.rocket)[0]));
        }
        /// <summary>
        /// Событие для таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            if (!FormManager.IsPaused)
            {
                DrawGraphics();
                UpdateGraphics();
            }                       
        }
        /// <summary>
        /// Как часто нужно вызывать срабатывание события Timer_tick для поддержания требуемого FPS?
        /// Округлено до int
        /// </summary>
        private static int _getTargetUpdatePerSecCount(int tragetUpdatePerSecCount)
        {
            return 1000 / tragetUpdatePerSecCount;
        }
       
    }
}
