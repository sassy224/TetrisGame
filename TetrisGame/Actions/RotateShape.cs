using FarPoint.Win.Spread;
using FarPoint.Win.Spread.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TetrisGame.Enums;
using TetrisGame.Shape;

namespace TetrisGame.Actions
{
    class RotateShape : FarPoint.Win.Spread.Action
    {
        private ITetrisShape _currentShape = null;

        public RotateShape(ITetrisShape shape)
        {
            _currentShape = shape;
        }

        public override void PerformAction(object source)
        {
            if (source is SpreadView)
            {
                //SpreadView spread = (SpreadView)source;
                //SheetView sheet = spread.Sheets[spread.ActiveSheetIndex];

                if (_currentShape != null)
                    _currentShape.Rotate();
            }
        }
    }
}