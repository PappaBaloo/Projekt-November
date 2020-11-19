using System;
using Raylib_cs;

namespace base_defender
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "Hello World");

            string scene = "MainMenu";

            while (!Raylib.WindowShouldClose())
            {

                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.GRAY);

                if (scene == "MainMenu")
                {
                    Raylib.DrawText("Game", 280, 30, 80, Color.DARKGREEN);
                    Raylib.DrawRectangle(250, 150, 300, 100, Color.MAROON);
                    Raylib.DrawText("Play", 280, 150, 80, Color.DARKGREEN);
                    Raylib.DrawRectangle(250, 300, 300, 100, Color.MAROON);
                    Raylib.DrawText("Settings", 280, 300, 80, Color.DARKGREEN);
                    Raylib.DrawRectangle(250, 450, 300, 100, Color.MAROON);
                    Raylib.DrawText("Exit", 280, 450, 80, Color.DARKGREEN);

                }
                else if (scene == "MainGame")
                {

                }
                else if (scene == "Settings")
                {

                }
                else if (scene == "Exit")
                {

                }




                Raylib.EndDrawing();
            }

        }
    }
}
