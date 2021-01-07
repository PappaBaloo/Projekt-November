using System;
using Raylib_cs;

namespace base_defender
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "Get To The End");

            string scene = "MainMenu";

            float playerX = 400;
            float enemyX = 80;
            float enemyY = 20;


            while (!Raylib.WindowShouldClose())
            {


                Raylib.SetExitKey(0);

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
                        scene = "Death";

                    }
                    if (exitbuttonrecOverlapping)
                    {
                        Raylib.DrawRectangleRec(exitbuttonrec, Color.BLUE);
                    }

                    MenuWords();

                }

                else if (scene == "MainGame")
                {

                    //FPS Lock
                    Raylib.SetTargetFPS(400);

                    //REKTANGLAR FÖR SPELET
                    Rectangle playerrec = new Rectangle((int)playerX, 550, 40, 40);
                    Rectangle enemyrec = new Rectangle((int)enemyX, (int)enemyY, 30, 30);
                    Rectangle borderrecLeft = new Rectangle(0, 0, 50, 600);
                    Rectangle borderrecRight = new Rectangle(750, 0, 50, 600);
                    Rectangle borderrecBottom = new Rectangle(0, 600, 800, 50);

                    //BOOLS FÖR SPELET
                    bool borderLeftcheck = Raylib.CheckCollisionRecs(playerrec, borderrecLeft);
                    bool borderRightcheck = Raylib.CheckCollisionRecs(playerrec, borderrecRight);
                    bool enemyleftcheck = Raylib.CheckCollisionRecs(enemyrec, borderrecLeft);
                    bool enemyrightcheck = Raylib.CheckCollisionRecs(enemyrec, borderrecRight);
                    bool borderbottomcheck = Raylib.CheckCollisionRecs(playerrec, borderrecBottom);

                    //BORDER FÖR SPELAREN OCH TELEPORTING
                    if (borderLeftcheck)
                    {
                        playerX = 699;
                    }
                    else if (borderRightcheck)
                    {
                        playerX = 51;
                    }

                    //KONTROLL FÖR SPELAREN
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    {
                        playerX -= 0.8f;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                    {
                        playerX += 0.8f;
                    }

                    //FIENDE RÖRELSE

                    if (enemyY == 20)
                    {
                        enemyX += 0.6f;
                    }

                    else if (enemyY == 60)
                    {
                        enemyX -= 0.6f;
                    }

                    else if (enemyY == 100)
                    {
                        enemyX += 0.6f;
                    }

                    else if (enemyY == 140)
                    {
                        enemyX -= 0.6f;
                    }

                    else if (enemyY == 180)
                    {
                        enemyX += 0.6f;
                    }

                    else if (enemyY == 220)
                    {
                        enemyX -= 0.6f;
                    }

                    else if (enemyY == 260)
                    {
                        enemyX += 0.6f;
                    }

                    else if (enemyY == 300)
                    {
                        enemyX -= 0.6f;
                    }

                    else if (enemyY == 340)
                    {
                        enemyX += 0.6f;
                    }

                    else if (enemyY == 380)
                    {
                        enemyX -= 0.6f;
                    }

                    else if (enemyY == 420)
                    {
                        enemyX += 0.6f;
                    }

                    else if (enemyY == 460)
                    {
                        enemyX -= 0.6f;
                    }

                    if (enemyrightcheck)
                    {
                        enemyX--;
                        enemyY += 40;
                    }

                    if (enemyleftcheck)
                    {
                        enemyY += 40;
                        enemyX++;
                    }

                    if (enemyY == 500)
                    {
                        scene = "Death";
                    }



                    Raylib.ClearBackground(Color.SKYBLUE);

                    Raylib.DrawRectangleRec(playerrec, Color.DARKGREEN);
                    Raylib.DrawRectangleRec(enemyrec, Color.RED);
                    Raylib.DrawRectangleRec(borderrecLeft, Color.BLACK);
                    Raylib.DrawRectangleRec(borderrecRight, Color.BLACK);
                    Raylib.DrawText("Level 1", 300, 50, 60, Color.BLACK);

                }
                else if (scene == "Settings")
                {

                    Raylib.ClearBackground(Color.LIME);

                    Raylib.DrawText("nothing for now", 380, 280, 45, Color.MAGENTA);

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_D))
                    {
                        scene = "MainMenu";
                    }

                }
                else if (scene == "Death")
                {
                    Rectangle mouserec = new Rectangle(Raylib.GetMouseX(), Raylib.GetMouseY(), 1, 1);
                    Rectangle exitbuttonrec = new Rectangle(250, 350, 300, 100);

                    Raylib.DrawRectangleRec(exitbuttonrec, Color.RED);

                    bool exitbuttonrecOverlapping = Raylib.CheckCollisionRecs(mouserec, exitbuttonrec);
                    bool mouseleftdown = Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON);

                    Raylib.ClearBackground(Color.LIME);

                    if (exitbuttonrecOverlapping && mouseleftdown)
                    {
                        scene = "MainMenu";

                    }
                    if (exitbuttonrecOverlapping)
                    {
                        Raylib.DrawRectangleRec(exitbuttonrec, Color.BEIGE);
                    }

                    Raylib.DrawText("Restart", 280, 380, 45, Color.VIOLET);
                }
                Raylib.EndDrawing();
            }

        }

        static void MenuWords()
        {
            Raylib.DrawText("Get To The End", 90, 30, 80, Color.DARKGREEN);
            Raylib.DrawText("Play", 310, 155, 80, Color.DARKGREEN);
            Raylib.DrawText("Settings", 235, 310, 80, Color.DARKGREEN);
            Raylib.DrawText("Exit", 320, 460, 80, Color.DARKGREEN);
        }
    }
}
