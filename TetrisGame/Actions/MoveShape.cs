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
    class MoveShape : FarPoint.Win.Spread.Action
    {
        private ITetrisShape _currentShape = null;
        private MovingDirections _movingDirection;

        public MoveShape(ITetrisShape shape, MovingDirections direction)
        {
            _currentShape = shape;
            _movingDirection = direction;
        }

        public override void PerformAction(object source)
        {
            if (source is SpreadView)
            {
                //SpreadView spread = (SpreadView)source;
                //SheetView sheet = spread.Sheets[spread.ActiveSheetIndex];

                switch (_movingDirection)
                {
                    case MovingDirections.Down:
                        if (_currentShape != null && _currentShape.CanMove(MovingDirections.Down))
                        {
                            _currentShape.MoveDown();
                        }
                        break;

                    case MovingDirections.Left:
                        if (_currentShape != null && _currentShape.CanMove(MovingDirections.Left))
                        {
                            _currentShape.MoveLeft();
                        }
                        break;

                    case MovingDirections.Right:
                        if (_currentShape != null && _currentShape.CanMove(MovingDirections.Right))
                        {
                            _currentShape.MoveRight();
                        }
                        break;
                }
            }
        }
    }
}