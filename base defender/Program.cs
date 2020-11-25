using System;
using Raylib_cs;

namespace base_defender
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "Game");

            string scene = "MainMenu";

            float playerX = 400;
            float enemyX = 20;
            float enemyY = 20;

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
                    Raylib.ClearBackground(Color.MAGENTA);
                    Raylib.DrawRectangleRec(playbuttonrec, Color.RED);
                    Raylib.DrawRectangleRec(settingbuttonrec, Color.RED);
                    Raylib.DrawRectangleRec(exitbuttonrec, Color.RED);

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

                    MenuWords();

                }

                else if (scene == "MainGame")
                {


                    Rectangle playerrec = new Rectangle((int)playerX, 550, 40, 40);
                    Rectangle enemyrec = new Rectangle((int)enemyX, (int)enemyY, 20, 20);
                    Rectangle borderrecLeft = new Rectangle(5, 0, 1, 600);
                    Rectangle borderrecRight = new Rectangle(795, 0, 1, 600);

                    bool borderLeftcheck = Raylib.CheckCollisionRecs(playerrec, borderrecLeft);
                    bool borderRightcheck = Raylib.CheckCollisionRecs(playerrec, borderrecRight);

                    if (borderLeftcheck)
                    {
                        playerX += 0.5f;
                    }
                    else if (borderRightcheck)
                    {
                        playerX -= 0.5f;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    {
                        playerX -= 0.5f;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                    {
                        playerX += 0.5f;
                    }



                    Raylib.ClearBackground(Color.SKYBLUE);

                    Raylib.DrawRectangleRec(playerrec, Color.DARKGREEN);

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

        static void MenuWords()
        {
            Raylib.DrawText("Game", 280, 30, 80, Color.DARKGREEN);
            Raylib.DrawText("Play", 280, 150, 80, Color.DARKGREEN);
            Raylib.DrawText("Settings", 250, 310, 80, Color.DARKGREEN);
            Raylib.DrawText("Exit", 280, 450, 80, Color.DARKGREEN);
        }

    }
}
