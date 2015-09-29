using FarPoint.Win.Spread;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TetrisGame.Enums;

namespace TetrisGame.Shape
{
    public class LShape : ITetrisShape
    {
        /// <summary>
        /// The sheetview object that represents a sheet of the spread
        /// </summary>
        private SheetView _sheet = null;

        /// <summary>
        /// The four cells that represents a shape
        /// </summary>
        //private Cell _center = null;
        //private int _centerRowIdx = 0;
        //private int _centerColIdx = 0;

        //private Cell _left = null;
        //private int _leftRowIdx = 0;
        //private int _leftColIdx = 0;

        //private Cell _right = null;
        //private int _rightRowIdx = 0;
        //private int _rightColIdx = 0;

        //private Cell _top = null;
        //private int _topRowIdx = 0;
        //private int _topColIdx = 0;

        /// <summary>
        /// The init location of the shape
        /// </summary>
        private int _initRowIdx = 0;
        private int _initColIdx = 0;

        /// <summary>
        /// The current direction of the shape
        /// </summary>
        private ShapeDirections _currentShapeDirection = ShapeDirections.FaceUp;

        public LShape(SheetView sheet, int rowIdx, int colIdx, ShapeDirections direction)
        {
            _sheet = sheet;
            _initColIdx = colIdx;
            _initRowIdx = rowIdx;
            _currentShapeDirection = direction;

            Initialize();
        }

        private void Initialize()
        {
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void Rotate()
        {
            throw new NotImplementedException();
        }

        public void MoveLeft()
        {
            throw new NotImplementedException();
        }

        public void MoveRight()
        {
            throw new NotImplementedException();
        }

        public void MoveDown()
        {
            throw new NotImplementedException();
        }

        public bool CanRotate(Enums.ShapeDirections nextDirection)
        {
            throw new NotImplementedException();
        }

        public bool CanMove(Enums.MovingDirections nextDirection)
        {
            throw new NotImplementedException();
        }

        public FarPoint.Win.Spread.Cell[] GetCells()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set SheetView object to contain this shape
        /// </summary>
        /// <param name="sheet">SheetView object</param>
        public void SetSheetView(SheetView sheet)
        {
            _sheet = sheet;
        }

        /// <summary>
        /// Reset all cells that forms the shape
        /// </summary>
        public void Reset()
        {
        }
    }
}