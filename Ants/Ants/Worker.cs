using KonsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Ants
{
    class Worker : GameEntity
    {

        Cell Model = new Cell(0, 0, ".");

        private int _sugarSupply;
        private bool _sugarFull;
        private int _proteinSupply;
        private bool _proteinFull;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Worker (int x, int y)
        {
            Model.X += x;
            Model.Y += y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override List<Cell> GetCells()
        {
            return new List<Cell> { Model };
        }

        public override void Start()
        {
            Thread updateThread = new Thread(Update);
            updateThread.Start();
        }

        public void Update()
        {
            Random rng = new Random();
            int direction = 0;
            while(true)
            {
                Thread.Sleep(300);
                direction = rng.Next(4);
                if (direction == 0 && Model.X != 0
                    && _gameWorld.GetCell(Model.X-1, Model.Y).IsWalkable)
                    Model.X -= 1;

                if (direction == 1 && Model.X != _gameWorld.X - 1
                    && _gameWorld.GetCell(Model.X + 1, Model.Y).IsWalkable)
                    Model.X += 1;

                if (direction == 2 && Model.Y != 0
                    && _gameWorld.GetCell(Model.X, Model.Y-1).IsWalkable)
                    Model.Y -= 1;

                if (direction == 3 && Model.Y != _gameWorld.Y - 1
                    && _gameWorld.GetCell(Model.X, Model.Y+1).IsWalkable)
                    Model.Y += 1;
            }
        }
    }
}
