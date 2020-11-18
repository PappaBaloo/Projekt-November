using System;
using Raylib_cs;

namespace base_defender
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "Hello World");

            string scene = "intro";

            while (!Raylib.WindowShouldClose())
            {

                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.GRAY);

                if (scene == "MainMenu")
                {
                    Raylib.DrawRectangle(400, 300, 250, 50, Color.MAGENTA);
                }





                Raylib.EndDrawing();
            }

        }
    }
}
