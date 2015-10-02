using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TetrisGame.Enums;

namespace TetrisGame.Shape
{
    public class IShape : BaseShape
    {
        public IShape(SheetView sheet, int rowIdx, int colIdx, ShapeDirections direction)
            : base(sheet, rowIdx, colIdx)
        {
            Initialize();

            _currentShapeDirection = direction;
        }

        private void Initialize()
        {
            //Center cell
            _centerColIdx = _initColIdx;
            _centerRowIdx = _initRowIdx;

            //Compute locations for other cells
            ComputeLocations();

            //Draw the shape
            Draw();
        }

        /// <summary>
        /// Function to compute location for other cells except the center one
        /// </summary>
        private void ComputeLocations()
        {
            //Compute locations for other cells
            if (_currentShapeDirection == ShapeDirections.FaceUp || _currentShapeDirection == ShapeDirections.FaceDown)
            {
                _leftColIdx = _centerColIdx - 1;
                _leftRowIdx = _centerRowIdx;

                _rightColIdx = _centerColIdx + 1;
                _rightRowIdx = _centerRowIdx;
            }
            else if (_currentShapeDirection == ShapeDirections.FaceRight || _currentShapeDirection == ShapeDirections.FaceLeft)
            {
                _topColIdx = _centerColIdx;
                _topRowIdx = _centerRowIdx - 1;

                _bottomColIdx = _centerColIdx;
                _bottomRowIdx = _centerRowIdx + 1;
            }
        }

        /// <summary>
        /// Rotate the shape, in order from up -> right -> down -> left -> up
        /// </summary>
        public override void Rotate()
        {
            switch (_currentShapeDirection)
            {
                case ShapeDirections.FaceUp:
                    if (CanRotate(ShapeDirections.FaceRight))
                    {
                        //Update current direction to new direction
                        _currentShapeDirection = ShapeDirections.FaceRight;
                    }
                    break;

                case ShapeDirections.FaceRight:
                    if (CanRotate(ShapeDirections.FaceDown))
                    {
                        //Update current direction to new direction
                        _currentShapeDirection = ShapeDirections.FaceDown;
                    }
                    break;

                case ShapeDirections.FaceDown:
                    if (CanRotate(ShapeDirections.FaceLeft))
                    {
                        //Update current direction to new direction
                        _currentShapeDirection = ShapeDirections.FaceLeft;
                    }
                    break;

                case ShapeDirections.FaceLeft:
                    if (CanRotate(ShapeDirections.FaceUp))
                    {
                        //Update current direction to new direction
                        _currentShapeDirection = ShapeDirections.FaceUp;
                    }
                    break;
            }

            ResetLocations();
            ResetCells();
            ComputeLocations();
            Draw();

            //Save new locations of cell
            SaveLocations();
        }

        /// <summary>
        /// Check if the shape can be rotated to the next direction
        /// </summary>
        /// <param name="nextShape">The next shape after the rotation</param>
        /// <returns>true if can rotate, false otherwise</returns>
        public override bool CanRotate(ShapeDirections nextShape)
        {
            //Consider the default shape
            // x0       00
            //0x0       xxx
            //0x   and   00

            //The shape can be rotated if there's no ButtonCellType in its (current top right, current right, current left
            //and current bottom left cells) or (current top left, current left, current bottom and current bottom right cells)
            //or 4 locations

            //The order of 4 locations will be from left to right, top to bottom
            int loc1ColIdx = 0;
            int loc1RowIdx = 0;

            int loc2ColIdx = 0;
            int loc2RowIdx = 0;

            int loc3RowIdx = 0;
            int loc3ColIdx = 0;

            int loc4ColIdx = 0;
            int loc4RowIdx = 0;

            ICellType nextCellType1 = null;
            ICellType nextCellType2 = null;
            ICellType nextCellType3 = null;
            ICellType nextCellType4 = null;

            //Work around to fix a bug where the shape direction doesn't match the location of the cells
            if (_currentShapeDirection == ShapeDirections.FaceDown || _currentShapeDirection == ShapeDirections.FaceUp)
            {
                if (_left == null || _right == null)
                {
                    _currentShapeDirection = ShapeDirections.FaceLeft;
                    nextShape = ShapeDirections.FaceDown;
                }
            }
            else
            {
                if (_top == null || _bottom == null)
                {
                    _currentShapeDirection = ShapeDirections.FaceDown;
                    nextShape = ShapeDirections.FaceLeft;
                }
            }

            switch (nextShape)
            {
                case ShapeDirections.FaceDown:
                    //Currentis FaceRight
                    loc1ColIdx = _topColIdx + 1;
                    loc1RowIdx = _topRowIdx;

                    loc2ColIdx = _centerColIdx - 1;
                    loc2RowIdx = _centerRowIdx;

                    loc3ColIdx = _centerColIdx + 1;
                    loc3RowIdx = _centerRowIdx;

                    loc4ColIdx = _bottomColIdx - 1;
                    loc4RowIdx = _bottomRowIdx;

                    break;

                case ShapeDirections.FaceUp:
                    //Current is FaceLeft
                    loc1ColIdx = _topColIdx + 1;
                    loc1RowIdx = _topRowIdx;

                    loc2ColIdx = _centerColIdx - 1;
                    loc2RowIdx = _centerRowIdx;

                    loc3ColIdx = _centerColIdx + 1;
                    loc3RowIdx = _centerRowIdx;

                    loc4ColIdx = _bottomColIdx - 1;
                    loc4RowIdx = _bottomRowIdx;

                    break;

                case ShapeDirections.FaceLeft:
                    //Current is FaceDown
                    loc1ColIdx = _leftColIdx;
                    loc1RowIdx = _leftRowIdx - 1;

                    loc2ColIdx = _centerColIdx;
                    loc2RowIdx = _centerRowIdx - 1;

                    loc3ColIdx = _centerColIdx;
                    loc3RowIdx = _centerRowIdx + 1;

                    loc4ColIdx = _rightColIdx;
                    loc4RowIdx = _rightRowIdx + 1;
                    break;

                case ShapeDirections.FaceRight:
                    //Current is FaceUp
                    loc1ColIdx = _leftColIdx;
                    loc1RowIdx = _leftRowIdx - 1;

                    loc2ColIdx = _centerColIdx;
                    loc2RowIdx = _centerRowIdx - 1;

                    loc3ColIdx = _centerColIdx;
                    loc3RowIdx = _centerRowIdx + 1;

                    loc4ColIdx = _rightColIdx;
                    loc4RowIdx = _rightRowIdx + 1;
                    break;
            }

            //When the center cell reaches borders, can't rotate
            if (_centerColIdx == BORDER_LEFT || _centerColIdx == BORDER_RIGHT - 1 || _centerRowIdx == BORDER_BOTTOM - 1)
                return false;

            //if (loc1ColIdx < BORDER_LEFT || loc2ColIdx < BORDER_LEFT || loc3ColIdx < BORDER_LEFT
            //    || loc1ColIdx >= BORDER_RIGHT || loc2ColIdx >= BORDER_RIGHT || loc3ColIdx >= BORDER_RIGHT
            //    || loc1RowIdx >= BORDER_BOTTOM || loc2RowIdx >= BORDER_BOTTOM || loc3RowIdx >= BORDER_BOTTOM)
            //    return false;

            nextCellType1 = _sheet.Cells[loc1RowIdx, loc1ColIdx].CellType;
            nextCellType2 = _sheet.Cells[loc2RowIdx, loc2ColIdx].CellType;
            nextCellType3 = _sheet.Cells[loc3RowIdx, loc3ColIdx].CellType;
            nextCellType4 = _sheet.Cells[loc4RowIdx, loc4ColIdx].CellType;

            if (nextCellType1 != null || nextCellType2 != null || nextCellType3 != null || nextCellType4 != null)
                return false;

            return true;
        }

        /// <summary>
        /// Check if the shape can move in the desinated direction
        /// </summary>
        /// <param name="nextDirection">The direction the shape is going to be moved</param>
        /// <returns>true if it can move, false otherwise</returns>
        public override bool CanMove(MovingDirections nextDirection)
        {
            //The shape can be moved if the cells at the next location are nulll
            //The shapes are built from 3 cells so we need to check 3 next locations
            //Locations are from left to right, top to bottom
            int loc1RowIdx = 0;
            int loc1ColIdx = 0;
            int loc2RowIdx = 0;
            int loc2ColIdx = 0;
            int loc3RowIdx = 0;
            int loc3ColIdx = 0;

            ICellType nextCellType1 = null;
            ICellType nextCellType2 = null;
            ICellType nextCellType3 = null;

            //Work around to fix a bug where the shape direction doesn't match the location of the cells
            if (_currentShapeDirection == ShapeDirections.FaceDown || _currentShapeDirection == ShapeDirections.FaceUp)
            {
                if (_left == null || _right == null)
                {
                    _currentShapeDirection = ShapeDirections.FaceLeft;
                }
            }
            else
            {
                if (_top == null || _bottom == null)
                {
                    _currentShapeDirection = ShapeDirections.FaceDown;
                }
            }

            //Compute the original locations
            switch (_currentShapeDirection)
            {
                case ShapeDirections.FaceDown:
                    loc1ColIdx = _leftColIdx;
                    loc1RowIdx = _leftRowIdx;

                    loc2ColIdx = _centerColIdx;
                    loc2RowIdx = _centerRowIdx;

                    loc3ColIdx = _rightColIdx;
                    loc3RowIdx = _rightRowIdx;

                    break;

                case ShapeDirections.FaceUp:
                    loc1ColIdx = _leftColIdx;
                    loc1RowIdx = _leftRowIdx;

                    loc2ColIdx = _centerColIdx;
                    loc2RowIdx = _centerRowIdx;

                    loc3ColIdx = _rightColIdx;
                    loc3RowIdx = _rightRowIdx;

                    break;

                case ShapeDirections.FaceLeft:
                    loc1ColIdx = _topColIdx;
                    loc1RowIdx = _topRowIdx;

                    loc2ColIdx = _centerColIdx;
                    loc2RowIdx = _centerRowIdx;

                    loc3ColIdx = _bottomColIdx;
                    loc3RowIdx = _bottomRowIdx;

                    break;

                case ShapeDirections.FaceRight:
                    loc1ColIdx = _topColIdx;
                    loc1RowIdx = _topRowIdx;

                    loc2ColIdx = _centerColIdx;
                    loc2RowIdx = _centerRowIdx;

                    loc3ColIdx = _bottomColIdx;
                    loc3RowIdx = _bottomRowIdx;

                    break;
            }

            //Compute the next locations
            switch (nextDirection)
            {
                case MovingDirections.Right:
                    loc1ColIdx = loc1ColIdx + 1;
                    loc2ColIdx = loc2ColIdx + 1;
                    loc3ColIdx = loc3ColIdx + 1;
                    break;

                case MovingDirections.Left:
                    loc1ColIdx = loc1ColIdx - 1;
                    loc2ColIdx = loc2ColIdx - 1;
                    loc3ColIdx = loc3ColIdx - 1;
                    break;

                case MovingDirections.Down:
                    loc1RowIdx = loc1RowIdx + 1;
                    loc2RowIdx = loc2RowIdx + 1;
                    loc3RowIdx = loc3RowIdx + 1;
                    break;
            }

            if (loc1ColIdx < BORDER_LEFT || loc2ColIdx < BORDER_LEFT || loc3ColIdx < BORDER_LEFT
                || loc1ColIdx >= BORDER_RIGHT || loc2ColIdx >= BORDER_RIGHT || loc3ColIdx >= BORDER_RIGHT
                || loc1RowIdx >= BORDER_BOTTOM || loc2RowIdx >= BORDER_BOTTOM || loc3RowIdx >= BORDER_BOTTOM)
                return false;

            //The shape can be moved if the cells at the next location are not ButtonCellType
            nextCellType1 = _sheet.Cells[loc1RowIdx, loc1ColIdx].CellType;
            nextCellType2 = _sheet.Cells[loc2RowIdx, loc2ColIdx].CellType;
            nextCellType3 = _sheet.Cells[loc3RowIdx, loc3ColIdx].CellType;

            switch (_currentShapeDirection)
            {
                case ShapeDirections.FaceDown:
                    switch (nextDirection)
                    {
                        case MovingDirections.Down:
                            //Shape is facing down/up and moving down
                            if (nextCellType2 != null || nextCellType3 != null || nextCellType1 != null)
                                return false;
                            break;

                        case MovingDirections.Left:
                            //Shape is facing down/up and moving left
                            if (nextCellType1 != null)
                                return false;
                            break;

                        case MovingDirections.Right:
                            //Shape is facing down/up and moving right

                            if (nextCellType3 != null)
                                return false;
                            break;
                    }

                    break;

                case ShapeDirections.FaceUp:
                    switch (nextDirection)
                    {
                        case MovingDirections.Down:
                            //Shape is facing down/up and moving down
                            if (nextCellType2 != null || nextCellType3 != null || nextCellType1 != null)
                                return false;
                            break;

                        case MovingDirections.Left:
                            //Shape is facing down/up and moving left
                            if (nextCellType1 != null)
                                return false;
                            break;

                        case MovingDirections.Right:
                            //Shape is facing down/up and moving right

                            if (nextCellType3 != null)
                                return false;
                            break;
                    }

                    break;

                case ShapeDirections.FaceRight:
                    switch (nextDirection)
                    {
                        case MovingDirections.Down:
                            if (nextCellType3 != null)
                                return false;
                            break;

                        case MovingDirections.Left:
                            if (nextCellType1 != null || nextCellType2 != null || nextCellType3 != null)
                                return false;
                            break;

                        case MovingDirections.Right:
                            //Shape is facing right and moving right
                            if (nextCellType1 != null || nextCellType2 != null || nextCellType3 != null)
                                return false;
                            break;
                    }
                    break;

                case ShapeDirections.FaceLeft:
                    switch (nextDirection)
                    {
                        case MovingDirections.Down:
                            if (nextCellType3 != null)
                                return false;
                            break;

                        case MovingDirections.Left:
                            if (nextCellType1 != null || nextCellType2 != null || nextCellType3 != null)
                                return false;
                            break;

                        case MovingDirections.Right:
                            //Shape is facing right and moving right
                            if (nextCellType1 != null || nextCellType2 != null || nextCellType3 != null)
                                return false;
                            break;
                    }
                    break;
            }

            return true;
        }
    }
}