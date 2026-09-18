using Raylib_cs;

namespace GoapWorld.Graphics;

public class InterfaceGraphics
{
    // ============================================================
    // Méthodes
    // ============================================================

    public void Run()
    {
        Raylib.InitWindow(800, 600, "Goap Simulation");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.SkyBlue);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}