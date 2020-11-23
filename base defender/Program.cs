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

                    Rectangle mouserec = new Rectangle(Raylib.GetMouseX(), Raylib.GetMouseY(), 1, 1);
                    Rectangle playbuttonrec = new Rectangle(250, 150, 300, 100);
                    Rectangle settingbuttonrec = new Rectangle(200, 300, 400, 100);
                    Rectangle exitbuttonrec = new Rectangle(250, 450, 300, 100);

                    Raylib.DrawRectangleRec(playbuttonrec, Color.MAROON);
                    Raylib.DrawRectangleRec(settingbuttonrec, Color.MAROON);
                    Raylib.DrawRectangleRec(exitbuttonrec, Color.MAROON);


                    bool playbuttonareOverlapping = Raylib.CheckCollisionRecs(mouserec, playbuttonrec);
                    bool settingbuttonOverlapping = Raylib.CheckCollisionRecs(mouserec, settingbuttonrec);
                    bool exitbuttonrecOverlapping = Raylib.CheckCollisionRecs(mouserec, exitbuttonrec);

                    bool mouseleftdown = Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON);

                    if (playbuttonareOverlapping && mouseleftdown)
                    {
                        scene = "MainGame";
                    }
                    if (playbuttonareOverlapping)
                    {
                        Raylib.DrawRectangleRec(playbuttonrec, Color.BLUE);

                    }

                    if (settingbuttonOverlapping && mouseleftdown)
                    {
                        scene = "Settings";
                    }
                    if (settingbuttonOverlapping)
                    {
                        Raylib.DrawRectangleRec(settingbuttonrec, Color.BLUE);
                    }

                    if (exitbuttonrecOverlapping && mouseleftdown)
                    {
                        scene = "Exit";
                    }
                    if (exitbuttonrecOverlapping)
                    {
                        Raylib.DrawRectangleRec(exitbuttonrec, Color.BLUE);
                    }

                    Raylib.DrawText("Game", 280, 30, 80, Color.DARKGREEN);
                    Raylib.DrawText("Play", 280, 150, 80, Color.DARKGREEN);
                    Raylib.DrawText("Settings", 250, 310, 80, Color.DARKGREEN);
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
