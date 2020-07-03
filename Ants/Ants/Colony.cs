using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using KonsoleGameEngine;

namespace Ants
{
    class Colony : GameEntity, IAntStructure
    {
        /// <summary>
        /// Model
        /// </summary>
        public Cell[] Model =
        {
            new Cell(0,0, "/") { IsWalkable = false },
            new Cell(1,0, "-") { IsWalkable = false },
            new Cell(2,0, "\\") { IsWalkable = false },
            new Cell(0,1, "|") { IsWalkable = false },
            new Cell(1,1, "^") { IsWalkable = false },
            new Cell(2,1, "|") { IsWalkable = false },
            new Cell(0,2, "\\") { IsWalkable = false },
            new Cell(1,2, "-") { IsWalkable = false },
            new Cell(2,2, "/") { IsWalkable = false }
        };
        public Cell[] _deploySpots;

        // Reference to the UI
        AntsUI _ui;
        // Structure ENUM from IAntStructure
        public AntEums ID { get { return AntEums.Colony; } }

        // Colony Fields
        private Queen _queen = new Queen();
        private List<Worker> _workers = new List<Worker>();
        private int _proteinSupply = 300;
        private int _sugarSupply = 0;


        /// <summary>
        /// Basic transform constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Colony(int x, int y)
        {
            foreach(Cell cell in Model)
            {
                cell.X += x;
                cell.Y += y;
            }

            _deploySpots = new Cell[6];
            for (int i = 0; i < 6; i++)
            {
                _deploySpots[i] = new Cell();
            }
            _deploySpots[0].X = Model[0].X;
            _deploySpots[0].Y = Model[0].Y - 1;
            _deploySpots[1].X = Model[1].X;
            _deploySpots[1].Y = Model[1].Y - 1;
            _deploySpots[2].X = Model[2].X;
            _deploySpots[2].Y = Model[2].Y - 1;


            _deploySpots[3].X = Model[6].X;
            _deploySpots[3].Y = Model[6].Y + 1;
            _deploySpots[4].X = Model[7].X;
            _deploySpots[4].Y = Model[7].Y + 1;
            _deploySpots[5].X = Model[8].X;
            _deploySpots[5].Y = Model[8].Y + 1;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override List<Cell> GetCells()
        {
            return Model.OfType<Cell>().ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Start()
        {        
            _ui = (AntsUI)_gameWorld.GetUI();

            Thread colonyThread = new Thread(Update);
            colonyThread.Start();
        }

        /// <summary>
        /// Update for Colony runs once a second. 
        /// </summary>
        private void Update()
        {
            _gameWorld.RegisterAndStartEntity(_queen);
            _queen.RegisterColony(this);

            while (true)
            {
                Thread.Sleep(1000);
                _ui.WorkersCount = _workers.Count;
                _ui.NestProtein = _proteinSupply;
                _ui.Sugar = _sugarSupply;
                _ui.QueenProtein = _queen.Protein;

                if (_proteinSupply > 0)
                {
                    _queen.ConsumeProtein();
                    _proteinSupply--;
                }



            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="worker"></param>
        public void RegisterWorker(Worker worker)
        {
            _workers.Add(worker);
        }
    }
}
