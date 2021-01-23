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
            float playerY = 500;
            float enemyX = 80;
            float enemyY = 60;


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
                    bool mouseleftdown = Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON);

                    if (playbuttonareOverlapping && mouseleftdown)
                    {
                        scene = "MainGame";
                    }
                    if (playbuttonareOverlapping)
                    {
                        Raylib.DrawRectangleRec(playbuttonrec, Color.BEIGE);
                    }

                    if (settingbuttonOverlapping && mouseleftdown)
                    {
                        scene = "Settings";
                    }
                    if (settingbuttonOverlapping)
                    {
                        Raylib.DrawRectangleRec(settingbuttonrec, Color.BEIGE);
                    }

                    if (exitbuttonrecOverlapping && mouseleftdown)
                    {
                        Raylib.CloseWindow();
                    }
                    if (exitbuttonrecOverlapping)
                    {
                        Raylib.DrawRectangleRec(exitbuttonrec, Color.BEIGE);
                    }

                    MenuWords();

                }

                else if (scene == "MainGame")
                {

                    //FPS LOCK
                    Raylib.SetTargetFPS(400);

                    //IMPORTANT RECTANGLES USED
                    Rectangle playerrec = new Rectangle((int)playerX, (int)playerY, 40, 40);
                    Rectangle enemyrec = new Rectangle((int)enemyX, (int)enemyY, 30, 30);
                    Rectangle borderrecLeft = new Rectangle(0, 0, 50, 600);
                    Rectangle borderrecRight = new Rectangle(750, 0, 50, 600);
                    Rectangle borderrecBottom = new Rectangle(0, 550, 800, 50);
                    Rectangle borderrecTop = new Rectangle(0, 0, 800, 50);

                    //BOOLS FOR MAIN GAME
                    bool borderLeftcheck = Raylib.CheckCollisionRecs(playerrec, borderrecLeft);
                    bool borderRightcheck = Raylib.CheckCollisionRecs(playerrec, borderrecRight);
                    bool enemyleftcheck = Raylib.CheckCollisionRecs(enemyrec, borderrecLeft);
                    bool enemyrightcheck = Raylib.CheckCollisionRecs(enemyrec, borderrecRight);
                    bool borderbottomcheck = Raylib.CheckCollisionRecs(playerrec, borderrecBottom);
                    bool bordertopcheck = Raylib.CheckCollisionRecs(borderrecTop, playerrec);
                    bool PlayerEnemyTouch = Raylib.CheckCollisionRecs(playerrec, enemyrec);

                    //BORDERS FOR PLAYER AND SIDE TELEPORTING
                    if (borderLeftcheck)
                    {
                        playerX = 699;
                    }
                    else if (borderRightcheck)
                    {
                        playerX = 51;
                    }
                    else if (borderbottomcheck)
                    {
                        playerY = 500;
                    }
                    else if (bordertopcheck)
                    {
                        scene = "Level 2";
                    }

                    //CONTROLS FOR THE PLAYER
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    {
                        playerX -= 0.45f;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                    {
                        playerX += 0.45f;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                    {
                        playerY -= 0.45f;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                    {
                        playerY += 0.45f;
                    }

                    //ENEMY KILL FUNCTION
                    if (PlayerEnemyTouch)
                    {
                        scene = "Death";
                    }

                    //ENEMY MOVEMENT
                    if (enemyY == 60)
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

                    else if (enemyY == 500)
                    {
                        enemyX += 0.6f;
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

                    if (enemyY > 500)
                    {
                        scene = "Death";
                    }



                    Raylib.ClearBackground(Color.SKYBLUE);

                    Raylib.DrawText("Level 1", 300, 80, 60, Color.BLACK);
                    Raylib.DrawRectangleRec(playerrec, Color.DARKGREEN);
                    Raylib.DrawRectangleRec(enemyrec, Color.RED);
                    Raylib.DrawRectangleRec(borderrecLeft, Color.BLACK);
                    Raylib.DrawRectangleRec(borderrecRight, Color.BLACK);
                    Raylib.DrawRectangleRec(borderrecBottom, Color.BLACK);
                    Raylib.DrawRectangleRec(borderrecTop, Color.BLACK);
                    Raylib.DrawRectangle(685, 530, 50, 5, Color.RED);
                    Raylib.DrawText("Exit", 680, 500, 30, Color.BLACK);

                }
                else if (scene == "Settings")
                {

                    Raylib.ClearBackground(Color.LIME);

                    Rectangle mouserec = new Rectangle(Raylib.GetMouseX(), Raylib.GetMouseY(), 1, 1);
                    Rectangle BacktoMenubuttonrec = new Rectangle(250, 220, 300, 100);

                    Raylib.DrawRectangleRec(BacktoMenubuttonrec, Color.RED);

                    bool backbuttonrecOverlapping = Raylib.CheckCollisionRecs(mouserec, BacktoMenubuttonrec);
                    bool mouseleftdown = Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON);

                    if (backbuttonrecOverlapping && mouseleftdown)
                    {
                        scene = "MainMenu";

                        enemyX = 80;
                        enemyY = 60;
                        playerX = 400;
                        playerY = 500;

                    }
                    if (backbuttonrecOverlapping)
                    {
                        Raylib.DrawRectangleRec(BacktoMenubuttonrec, Color.BEIGE);
                    }

                    Raylib.DrawText("Back", 255, 220, 45, Color.VIOLET);
                    Raylib.DrawText("nothing for now", 300, 150, 45, Color.MAGENTA);

                }
                else if (scene == "Death")
                {
                    Rectangle mouserec = new Rectangle(Raylib.GetMouseX(), Raylib.GetMouseY(), 1, 1);
                    Rectangle exitbuttonrec = new Rectangle(250, 350, 300, 100);

                    Raylib.DrawRectangleRec(exitbuttonrec, Color.RED);

                    bool exitbuttonrecOverlapping = Raylib.CheckCollisionRecs(mouserec, exitbuttonrec);
                    bool mouseleftdown = Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON);

                    Raylib.ClearBackground(Color.LIME);

                    if (exitbuttonrecOverlapping && mouseleftdown)
                    {
                        scene = "MainMenu";

                        enemyX = 80;
                        enemyY = 60;
                        playerX = 400;
                        playerY = 500;

                    }
                    if (exitbuttonrecOverlapping)
                    {
                        Raylib.DrawRectangleRec(exitbuttonrec, Color.BEIGE);
                    }

                    Raylib.DrawText("Restart", 280, 380, 45, Color.VIOLET);
                    Raylib.DrawText("You Died", 260, 100, 72, Color.WHITE);
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
