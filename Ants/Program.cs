using KonsoleGameEngine;
using System;
using System.Threading;

namespace Ants
{
    class Program
    {
        static void Main(string[] args)
        {
            // KonsoleGameEngine
            GameWorld gameWorld = new GameWorld();
            GraphicsManager graphicsManager = new GraphicsManager(gameWorld);

            // Ant Game Entities
            AntsCursor cursor = new AntsCursor();
            AntsUI customUI = new AntsUI(cursor);
            Colony colony = new Colony(4,2);
            SugarFarm sugarFarm = new SugarFarm(1, 18);
            ProteinFarm proteinFarm = new ProteinFarm(40,11);
            Terrain terrain = new Terrain();

            // Register Cursor, UI and Entities
            gameWorld.RegisterCursor(cursor);
            gameWorld.RegisterUI(customUI);
            gameWorld.RegisterEntity(colony);
            gameWorld.RegisterEntity(sugarFarm);
            gameWorld.RegisterEntity(proteinFarm);
            gameWorld.RegisterEntity(terrain);

            // STANDARD UPDATE GAME LOOP
            gameWorld.Start();
            while(true)
            {
                gameWorld.Update();

                graphicsManager.Update();
                graphicsManager.Draw();

                Thread.Sleep(1);
            }
        }
    }
}
