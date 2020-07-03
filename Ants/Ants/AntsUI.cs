using KonsoleGameEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ants
{
    class AntsUI : KonsoleUI
    {
        private AntsCursor cursor;
        public int WorkersCount { get; set; }
        public Cell SelectedCell { get; set; }
        public int NestProtein { get; set; }
        public int QueenProtein { get; set; }
        public int Sugar { get; set; }

        public AntsUI(AntsCursor cursor)
        {
            this.cursor = cursor;
        }

        public override void Update()
        {
            _uiBufferBuilder.Clear();

            _uiBufferBuilder.Append("!!Ants!!\n");
            _uiBufferBuilder.Append("(Idle: " + WorkersCount + ") " +
                                    "(P: " + NestProtein.ToString("000") + 
                                  ") (S: " + Sugar.ToString("00") + 
                                  ") (Q.PRo: " + QueenProtein.ToString("00)"));

            _uiBufferBuilder.Append("\nCur Pos: X" + cursor.X.ToString("00") + " - Y" +  cursor.Y.ToString("00")) ;
            string currentSelectionString = cursor._activeStructure.ToString();
            if (currentSelectionString != "NULL")
            {
                if (cursor._activeStructure == AntEums.Colony)
                    _uiBufferBuilder.Append("\nColony: R)ecall - A)ttack - S)cout");
                if (cursor._activeStructure == AntEums.ProteinFarm)
                    _uiBufferBuilder.Append("\nProtein: A)ssign - U)nassign");
                if (cursor._activeStructure == AntEums.SugarFarm)
                    _uiBufferBuilder.Append("\nSugar: A)ssign - U)nassign");
            }
            _uiBuffer = _uiBufferBuilder.ToString();
        }
    }
}
