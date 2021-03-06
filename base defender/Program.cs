﻿using System;
using Raylib_cs;

namespace base_defender
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "Get To The End");

            //STRING FOR THE SCENES AND GLOBAL FLOATS FOR OFTEN USED VALUES
            string scene = "MainMenu";
            float playerX = 400;
            float playerY = 500;
            float enemyX = 80;
            float enemyY = 60;
            float enemyX2 = 720;
            float enemyY2 = 60;

            //MUSIC
            //  Raylib.InitAudioDevice();
            // Music mainmusic = Raylib.LoadMusicStream("resources/slider.mp3");
            // Raylib.PlayMusicStream(mainmusic);


            //FPS LOCK
            Raylib.SetTargetFPS(400);

            //SPECIAL POINT COUNTER
            int SpecialPointCounter = 0;

            //RANDOM POSITIONS FOR SPECIAL POINTS
            Random SpecialPointXGenerator = new Random();
            Random SpecialPointYGenerator = new Random();
            int SpecialPoint1X = SpecialPointXGenerator.Next(80, 720);
            int SpecialPoint1Y = SpecialPointYGenerator.Next(80, 520);
            int SpecialPoint2X = SpecialPointXGenerator.Next(80, 720);
            int SpecialPoint2Y = SpecialPointYGenerator.Next(80, 520);
            int SpecialPoint3X = SpecialPointXGenerator.Next(80, 720);
            int SpecialPoint3Y = SpecialPointYGenerator.Next(80, 520);

            //I TRIED TO MAKE A FUNCTIONING TIMER
            // double timestarted = Raylib.GetTime();
            // double timeinmenu = Raylib.GetTime();


            while (!Raylib.WindowShouldClose())
            {
                Raylib.SetExitKey(0);

                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.GRAY);

                //   Raylib.UpdateMusicStream(mainmusic);

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
                        scene = "Level 1";
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

                //  else if (scene == "Username")
                //  {
                //      Rectangle textinput = new Rectangle(200, 290, 400, 50);
                //       Rectangle mouserec = new Rectangle(Raylib.GetMouseX(), Raylib.GetMouseY(), 1, 1);
                //       bool mouseleftdown = Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON);
                //      bool mouseovertextbox = Raylib.CheckCollisionRecs(textinput, mouserec);
                //     Raylib.DrawRectangleRec(textinput, Color.LIGHTGRAY);
                //
                //
                //       if (mouseovertextbox)
                //        {
                //             Raylib.DrawRectangleLinesEx(textinput, 5, Color.GREEN);
                //        }
                //
                //
                //
                //
                //         Raylib.ClearBackground(Color.BLUE);
                //
                //         Raylib.DrawText("Input Your Name Here", 235, 370, 30, Color.GREEN);
                //
                //
                //    }

                //Level 1
                else if (scene == "Level 1")
                {
                    //PLAYER AND ENEMY RECTANGLES
                    Rectangle playerrec = new Rectangle((int)playerX, (int)playerY, 40, 40);
                    Rectangle enemyrec = new Rectangle((int)enemyX, (int)enemyY, 30, 30);

                    //SPECIAL POINT RECTANGLES
                    Rectangle SpecialPoint1 = new Rectangle((int)SpecialPoint1X, (int)SpecialPoint1Y, 20, 20);

                    //BORDER RECTANGLES
                    Rectangle borderrecLeft = new Rectangle(0, 0, 50, 600);
                    Rectangle borderrecRight = new Rectangle(750, 0, 50, 600);
                    Rectangle borderrecBottom = new Rectangle(0, 550, 800, 50);
                    Rectangle borderrecTop = new Rectangle(0, 0, 800, 50);

                    //BOOLS FOR CHECKING COLLISIONS
                    bool borderLeftcheck = Raylib.CheckCollisionRecs(playerrec, borderrecLeft);
                    bool borderRightcheck = Raylib.CheckCollisionRecs(playerrec, borderrecRight);
                    bool enemyleftcheck = Raylib.CheckCollisionRecs(enemyrec, borderrecLeft);
                    bool enemyrightcheck = Raylib.CheckCollisionRecs(enemyrec, borderrecRight);
                    bool borderbottomcheck = Raylib.CheckCollisionRecs(playerrec, borderrecBottom);
                    bool bordertopcheck = Raylib.CheckCollisionRecs(borderrecTop, playerrec);
                    bool PlayerEnemyTouch = Raylib.CheckCollisionRecs(playerrec, enemyrec);
                    bool PlayerSpecialPoint1 = Raylib.CheckCollisionRecs(playerrec, SpecialPoint1);

                    //SPECIAL POINT PICKUP
                    if (PlayerSpecialPoint1)
                    {
                        SpecialPointCounter++;

                        SpecialPoint1X = 1;
                        SpecialPoint1Y = 1;

                    }

                    //SPECIAL POINT COUNTER DISPLAY
                    if (SpecialPointCounter == 0)
                    {
                        Raylib.DrawText("Score: 0", 70, 80, 26, Color.BLACK);
                    }
                    else if (SpecialPointCounter == 1)
                    {
                        Raylib.DrawText("Score: 1", 70, 80, 26, Color.BLACK);
                    }
                    else if (SpecialPointCounter == 2)
                    {
                        Raylib.DrawText("Score: 2", 70, 80, 26, Color.BLACK);
                    }
                    else if (SpecialPointCounter == 3)
                    {
                        Raylib.DrawText("Score: 3", 70, 80, 26, Color.BLACK);
                    }

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
                        playerX = 400;
                        playerY = 500;
                        enemyX = 80;
                        enemyY = 60;
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
                        enemyX -= 1f;
                    }

                    else if (enemyY == 100)
                    {
                        enemyX += 1f;
                    }

                    else if (enemyY == 140)
                    {
                        enemyX -= 1f;
                    }

                    else if (enemyY == 180)
                    {
                        enemyX += 1f;
                    }

                    else if (enemyY == 220)
                    {
                        enemyX -= 1f;
                    }

                    else if (enemyY == 260)
                    {
                        enemyX += 1f;
                    }

                    else if (enemyY == 300)
                    {
                        enemyX -= 1f;
                    }

                    else if (enemyY == 340)
                    {
                        enemyX += 1f;
                    }

                    else if (enemyY == 380)
                    {
                        enemyX -= 1f;
                    }

                    else if (enemyY == 420)
                    {
                        enemyX += 1f;
                    }

                    else if (enemyY == 460)
                    {
                        enemyX -= 1f;
                    }

                    else if (enemyY == 500)
                    {
                        enemyX += 1f;
                    }

                    if (enemyrightcheck)
                    {
                        enemyX -= 5;
                        enemyY += 40;
                    }

                    if (enemyleftcheck)
                    {
                        enemyY += 40;
                        enemyX += 5;
                    }

                    if (enemyY > 500)
                    {
                        scene = "Death";
                    }



                    Raylib.ClearBackground(Color.SKYBLUE);

                    Raylib.DrawText("Level 1", 300, 80, 60, Color.BLACK);
                    Raylib.DrawText("GET TO THE TOP BEFORE\n      THE EVIL BOXES!!!", 130, 300, 40, Color.RAYWHITE);
                    Raylib.DrawRectangleRec(playerrec, Color.DARKGREEN);
                    Raylib.DrawRectangleRec(enemyrec, Color.RED);
                    Raylib.DrawRectangleRec(borderrecLeft, Color.BLACK);
                    Raylib.DrawRectangleRec(borderrecRight, Color.BLACK);
                    Raylib.DrawRectangleRec(borderrecBottom, Color.BLACK);
                    Raylib.DrawRectangleRec(SpecialPoint1, Color.GOLD);
                    Raylib.DrawRectangleRec(borderrecTop, Color.BLACK);
                    Raylib.DrawRectangle(735, 490, 5, 50, Color.RED);
                    Raylib.DrawText("Exit For Enemies Only", 470, 505, 24, Color.BLACK);

                }
                //Level 2
                else if (scene == "Level 2")
                {

                    //PLAYER AND ENEMY RECTANGLES
                    Rectangle playerrec = new Rectangle((int)playerX, (int)playerY, 40, 40);
                    Rectangle enemyrec = new Rectangle((int)enemyX, (int)enemyY, 30, 30);

                    //SPECIAL POINT RECTANGLES
                    Rectangle SpecialPoint2 = new Rectangle((int)SpecialPoint2X, (int)SpecialPoint2Y, 20, 20);

                    //BORDER RECTANGLES
                    Rectangle borderrecLeft = new Rectangle(0, 0, 50, 600);
                    Rectangle borderrecRight = new Rectangle(750, 0, 50, 600);
                    Rectangle borderrecBottom = new Rectangle(0, 550, 800, 50);
                    Rectangle borderrecTop = new Rectangle(0, 0, 800, 50);

                    //BOOLS FOR CHECKING COLLISIONS
                    bool borderLeftcheck = Raylib.CheckCollisionRecs(playerrec, borderrecLeft);
                    bool borderRightcheck = Raylib.CheckCollisionRecs(playerrec, borderrecRight);
                    bool enemyleftcheck = Raylib.CheckCollisionRecs(enemyrec, borderrecLeft);
                    bool enemyrightcheck = Raylib.CheckCollisionRecs(enemyrec, borderrecRight);
                    bool borderbottomcheck = Raylib.CheckCollisionRecs(playerrec, borderrecBottom);
                    bool bordertopcheck = Raylib.CheckCollisionRecs(borderrecTop, playerrec);
                    bool PlayerEnemyTouch = Raylib.CheckCollisionRecs(playerrec, enemyrec);
                    bool PlayerSpecialPoint2 = Raylib.CheckCollisionRecs(playerrec, SpecialPoint2);

                    //SPECIAL POINT PICKUP SERVICE
                    if (PlayerSpecialPoint2)
                    {
                        SpecialPointCounter++;

                        SpecialPoint2X = 1;
                        SpecialPoint2Y = 1;
                    }

                    //SPECIAL POINT COUNTER DISPLAY
                    if (SpecialPointCounter == 0)
                    {
                        Raylib.DrawText("Score: 0", 70, 80, 26, Color.BLACK);
                    }
                    else if (SpecialPointCounter == 1)
                    {
                        Raylib.DrawText("Score: 1", 70, 80, 26, Color.BLACK);
                    }
                    else if (SpecialPointCounter == 2)
                    {
                        Raylib.DrawText("Score: 2", 70, 80, 26, Color.BLACK);
                    }
                    else if (SpecialPointCounter == 3)
                    {
                        Raylib.DrawText("Score: 3", 70, 80, 26, Color.BLACK);
                    }

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
                        scene = "Level 3";
                        playerX = 400;
                        playerY = 500;
                        enemyX = 80;
                        enemyY = 60;
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
                        enemyX -= 2f;
                    }

                    else if (enemyY == 100)
                    {
                        enemyX += 2f;
                    }

                    else if (enemyY == 140)
                    {
                        enemyX -= 2f;
                    }

                    else if (enemyY == 180)
                    {
                        enemyX += 2f;
                    }

                    else if (enemyY == 220)
                    {
                        enemyX -= 2f;
                    }

                    else if (enemyY == 260)
                    {
                        enemyX += 2f;
                    }

                    else if (enemyY == 300)
                    {
                        enemyX -= 2f;
                    }

                    else if (enemyY == 340)
                    {
                        enemyX += 2f;
                    }

                    else if (enemyY == 380)
                    {
                        enemyX -= 2f;
                    }

                    else if (enemyY == 420)
                    {
                        enemyX += 2f;
                    }

                    else if (enemyY == 460)
                    {
                        enemyX -= 2f;
                    }

                    else if (enemyY == 500)
                    {
                        enemyX += 2f;
                    }

                    if (enemyrightcheck)
                    {
                        enemyX -= 5;
                        enemyY += 40;
                    }

                    if (enemyleftcheck)
                    {
                        enemyY += 40;
                        enemyX += 5;
                    }

                    if (enemyY > 500)
                    {
                        scene = "Death";
                    }



                    Raylib.ClearBackground(Color.SKYBLUE);

                    Raylib.DrawText("Level 2", 300, 80, 60, Color.BLACK);
                    Raylib.DrawRectangleRec(playerrec, Color.DARKGREEN);
                    Raylib.DrawRectangleRec(enemyrec, Color.RED);
                    Raylib.DrawRectangleRec(borderrecLeft, Color.BLACK);
                    Raylib.DrawRectangleRec(borderrecRight, Color.BLACK);
                    Raylib.DrawRectangleRec(borderrecBottom, Color.BLACK);
                    Raylib.DrawRectangleRec(SpecialPoint2, Color.GOLD);
                    Raylib.DrawRectangleRec(borderrecTop, Color.BLACK);
                    Raylib.DrawRectangle(735, 490, 5, 50, Color.RED);
                    Raylib.DrawText("Exit For Enemies Only", 470, 505, 24, Color.BLACK);
                }
                //Level 3
                else if (scene == "Level 3")
                {

                    //PLAYER AND ENEMY RECTANGLES
                    Rectangle playerrec = new Rectangle((int)playerX, (int)playerY, 40, 40);
                    Rectangle enemyrec = new Rectangle((int)enemyX, (int)enemyY, 30, 30);
                    Rectangle enemyrec2 = new Rectangle((int)enemyX2, (int)enemyY2, 30, 30);

                    //SPECIAL POINT RECTANGLES
                    Rectangle SpecialPoint3 = new Rectangle((int)SpecialPoint3X, (int)SpecialPoint3Y, 20, 20);

                    //BORDER RECTANGLES
                    Rectangle borderrecLeft = new Rectangle(0, 0, 50, 600);
                    Rectangle borderrecRight = new Rectangle(750, 0, 50, 600);
                    Rectangle borderrecBottom = new Rectangle(0, 550, 800, 50);
                    Rectangle borderrecTop = new Rectangle(0, 0, 800, 50);

                    //BOOLS FOR CHECKING COLLISIONS
                    bool borderLeftcheck = Raylib.CheckCollisionRecs(playerrec, borderrecLeft);
                    bool borderRightcheck = Raylib.CheckCollisionRecs(playerrec, borderrecRight);
                    bool enemyleftcheck = Raylib.CheckCollisionRecs(enemyrec, borderrecLeft);
                    bool enemyrightcheck = Raylib.CheckCollisionRecs(enemyrec, borderrecRight);
                    bool enemyleftcheck2 = Raylib.CheckCollisionRecs(enemyrec2, borderrecLeft);
                    bool enemyrightcheck2 = Raylib.CheckCollisionRecs(enemyrec2, borderrecRight);
                    bool borderbottomcheck = Raylib.CheckCollisionRecs(playerrec, borderrecBottom);
                    bool bordertopcheck = Raylib.CheckCollisionRecs(borderrecTop, playerrec);
                    bool PlayerEnemyTouch = Raylib.CheckCollisionRecs(playerrec, enemyrec);
                    bool PlayerEnemyTouch2 = Raylib.CheckCollisionRecs(playerrec, enemyrec2);
                    bool PlayerSpecialPoint3 = Raylib.CheckCollisionRecs(playerrec, SpecialPoint3);

                    //SPECIAL POINT PICKUP SERVICE
                    if (PlayerSpecialPoint3)
                    {
                        SpecialPointCounter++;

                        SpecialPoint3X = 1;
                        SpecialPoint3Y = 1;
                    }

                    //SPECIAL POINT COUNTER DISPLAY
                    if (SpecialPointCounter == 0)
                    {
                        Raylib.DrawText("Score: 0", 70, 80, 26, Color.BLACK);
                    }
                    else if (SpecialPointCounter == 1)
                    {
                        Raylib.DrawText("Score: 1", 70, 80, 26, Color.BLACK);
                    }
                    else if (SpecialPointCounter == 2)
                    {
                        Raylib.DrawText("Score: 2", 70, 80, 26, Color.BLACK);
                    }
                    else if (SpecialPointCounter == 3)
                    {
                        Raylib.DrawText("Score: 3", 70, 80, 26, Color.BLACK);
                    }

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
                        scene = "You Win!";
                        playerX = 400;
                        playerY = 500;
                        enemyX = 80;
                        enemyY = 60;
                        enemyX2 = 720;
                        enemyY2 = 60;
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
                    else if (PlayerEnemyTouch2)
                    {
                        scene = "Death";
                    }

                    //ENEMY MOVEMENT
                    if (enemyY == 60)
                    {
                        enemyX -= 3f;
                    }

                    else if (enemyY == 100)
                    {
                        enemyX += 3f;
                    }

                    else if (enemyY == 140)
                    {
                        enemyX -= 3f;
                    }

                    else if (enemyY == 180)
                    {
                        enemyX += 3f;
                    }

                    else if (enemyY == 220)
                    {
                        enemyX -= 3f;
                    }

                    else if (enemyY == 260)
                    {
                        enemyX += 3f;
                    }

                    else if (enemyY == 300)
                    {
                        enemyX -= 3f;
                    }

                    else if (enemyY == 340)
                    {
                        enemyX += 3f;
                    }

                    else if (enemyY == 380)
                    {
                        enemyX -= 3f;
                    }

                    else if (enemyY == 420)
                    {
                        enemyX += 3f;
                    }

                    else if (enemyY == 460)
                    {
                        enemyX -= 3f;
                    }

                    else if (enemyY == 500)
                    {
                        enemyX += 3f;
                    }

                    if (enemyrightcheck)
                    {
                        enemyX -= 5;
                        enemyY += 40;
                    }

                    if (enemyleftcheck)
                    {
                        enemyY += 40;
                        enemyX += 5;
                    }

                    if (enemyY > 500)
                    {
                        scene = "Death";
                    }

                    //ENEMY2 MOVEMENT
                    if (enemyY2 == 60)
                    {
                        enemyX2 += 3f;
                    }

                    else if (enemyY2 == 100)
                    {
                        enemyX2 -= 3f;
                    }

                    else if (enemyY2 == 140)
                    {
                        enemyX2 += 3f;
                    }

                    else if (enemyY2 == 180)
                    {
                        enemyX2 -= 3f;
                    }

                    else if (enemyY2 == 220)
                    {
                        enemyX2 += 3f;
                    }

                    else if (enemyY2 == 260)
                    {
                        enemyX2 -= 3f;
                    }

                    else if (enemyY2 == 300)
                    {
                        enemyX2 += 3f;
                    }

                    else if (enemyY2 == 340)
                    {
                        enemyX2 -= 3f;
                    }

                    else if (enemyY2 == 380)
                    {
                        enemyX2 += 3f;
                    }

                    else if (enemyY2 == 420)
                    {
                        enemyX2 -= 3f;
                    }

                    else if (enemyY2 == 460)
                    {
                        enemyX2 += 3f;
                    }

                    else if (enemyY2 == 500)
                    {
                        enemyX2 -= 3f;
                    }

                    if (enemyrightcheck2)
                    {
                        enemyX2 -= 5;
                        enemyY2 += 40;
                    }

                    if (enemyleftcheck2)
                    {
                        enemyY2 += 40;
                        enemyX2 += 5;
                    }

                    if (enemyY2 > 500)
                    {
                        scene = "Death";
                    }



                    Raylib.ClearBackground(Color.SKYBLUE);

                    Raylib.DrawText("Level 3", 300, 80, 60, Color.BLACK);
                    Raylib.DrawRectangleRec(playerrec, Color.DARKGREEN);
                    Raylib.DrawRectangleRec(enemyrec, Color.RED);
                    Raylib.DrawRectangleRec(enemyrec2, Color.RED);
                    Raylib.DrawRectangleRec(borderrecLeft, Color.BLACK);
                    Raylib.DrawRectangleRec(borderrecRight, Color.BLACK);
                    Raylib.DrawRectangleRec(borderrecBottom, Color.BLACK);
                    Raylib.DrawRectangleRec(SpecialPoint3, Color.GOLD);
                    Raylib.DrawRectangleRec(borderrecTop, Color.BLACK);
                    Raylib.DrawRectangle(735, 490, 5, 50, Color.RED);
                    Raylib.DrawText("Exit For Enemies Only", 470, 505, 24, Color.BLACK);
                    Raylib.DrawRectangle(65, 490, 5, 50, Color.RED);
                    Raylib.DrawText("Exit For Enemies Only", 80, 505, 24, Color.BLACK);

                }
                else if (scene == "You Win!")
                {

                    //BACK TO MAIN MENU RECTANGLE AND MOUSE
                    Rectangle backtomenubutton = new Rectangle(300, 450, 280, 60);
                    Rectangle mouserec = new Rectangle(Raylib.GetMouseX(), Raylib.GetMouseY(), 1, 1);

                    //BOOL FOR BACK BUTTON
                    bool BackTomenuButtonCollision = Raylib.CheckCollisionRecs(backtomenubutton, mouserec);
                    bool mouseleftdown = Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON);

                    //BORDER RECTANGLES
                    Rectangle borderrecLeft = new Rectangle(0, 0, 50, 600);
                    Rectangle borderrecRight = new Rectangle(750, 0, 50, 600);
                    Rectangle borderrecBottom = new Rectangle(0, 550, 800, 50);
                    Rectangle borderrecTop = new Rectangle(0, 0, 800, 50);

                    Raylib.DrawRectangleRec(backtomenubutton, Color.VIOLET);

                    //BACK TO MENU BUTTON FUNCTIONS
                    if (BackTomenuButtonCollision)
                    {
                        Raylib.DrawRectangleRec(backtomenubutton, Color.BEIGE);
                    }
                    if (BackTomenuButtonCollision && mouseleftdown)
                    {

                        scene = "MainMenu";

                        enemyX = 80;
                        enemyY = 60;
                        enemyX2 = 720;
                        enemyY2 = 60;
                        playerX = 400;
                        playerY = 500;
                        SpecialPointCounter -= SpecialPointCounter;

                        //RENEW THE RANDOM POSITIONS
                        SpecialPoint1X = SpecialPointXGenerator.Next(80, 720);
                        SpecialPoint1Y = SpecialPointYGenerator.Next(80, 520);
                        SpecialPoint2X = SpecialPointXGenerator.Next(80, 720);
                        SpecialPoint2Y = SpecialPointYGenerator.Next(80, 520);
                        SpecialPoint3X = SpecialPointXGenerator.Next(80, 720);
                        SpecialPoint3Y = SpecialPointYGenerator.Next(80, 520);
                    }

                    Raylib.ClearBackground(Color.SKYBLUE);

                    Raylib.DrawRectangleRec(borderrecLeft, Color.BLACK);
                    Raylib.DrawRectangleRec(borderrecRight, Color.BLACK);
                    Raylib.DrawRectangleRec(borderrecBottom, Color.BLACK);
                    Raylib.DrawRectangleRec(borderrecTop, Color.BLACK);
                    Raylib.DrawText("You Won!\nCongratulations!!!", 200, 150, 50, Color.BLACK);
                    Raylib.DrawText(Convert.ToString(SpecialPointCounter), 550, 360, 70, Color.GOLD);
                    Raylib.DrawText("Your Score:", 120, 360, 68, Color.BLACK);
                    Raylib.DrawText("Back To Menu", 320, 465, 35, Color.WHITE);
                }
                else if (scene == "Settings")
                {

                    Raylib.ClearBackground(Color.LIME);

                    Rectangle mouserec = new Rectangle(Raylib.GetMouseX(), Raylib.GetMouseY(), 1, 1);
                    Rectangle BacktoMenubuttonrec = new Rectangle(250, 220, 300, 100);

                    Raylib.DrawRectangleRec(BacktoMenubuttonrec, Color.RED);

                    bool backbuttonrecOverlapping = Raylib.CheckCollisionRecs(mouserec, BacktoMenubuttonrec);
                    bool mouseleftdown = Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON);

                    if (backbuttonrecOverlapping)
                    {
                        Raylib.DrawRectangleRec(BacktoMenubuttonrec, Color.BEIGE);
                    }
                    if (backbuttonrecOverlapping && mouseleftdown)
                    {
                        scene = "MainMenu";

                        enemyX = 80;
                        enemyY = 60;
                        enemyX2 = 720;
                        enemyY2 = 60;
                        playerX = 400;
                        playerY = 500;

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
                        enemyX2 = 720;
                        enemyY2 = 60;
                        playerX = 400;
                        playerY = 500;
                        SpecialPointCounter -= SpecialPointCounter;

                        //RENEW THE RANDOM POSITIONS
                        SpecialPoint1X = SpecialPointXGenerator.Next(80, 720);
                        SpecialPoint1Y = SpecialPointYGenerator.Next(80, 520);
                        SpecialPoint2X = SpecialPointXGenerator.Next(80, 720);
                        SpecialPoint2Y = SpecialPointYGenerator.Next(80, 520);
                        SpecialPoint3X = SpecialPointXGenerator.Next(80, 720);
                        SpecialPoint3Y = SpecialPointYGenerator.Next(80, 520);

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

            //     Raylib.UnloadMusicStream(mainmusic);

            Raylib.CloseAudioDevice();
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
