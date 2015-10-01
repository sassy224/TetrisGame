using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TetrisGame.Enums;

namespace TetrisGame.Shape
{
    public class LShape : BaseShape
    {
        /// <summary>
        /// Flag to determine whether the L part is on the left or on the right
        /// </summary>
        private bool _isLeft = false;

        public LShape(SheetView sheet, int rowIdx, int colIdx, ShapeDirections direction, bool isLeft)
            : base(sheet, rowIdx, colIdx)
        {
            _currentShapeDirection = direction;
            _isLeft = isLeft;

            Initialize();
        }

        private void Initialize()
        {
            //The default shape is
            //x  or  x
            //x      x
            //xx    xx

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
            if (_currentShapeDirection == ShapeDirections.FaceUp)
            {
                //  x or x
                //xxx    xxx

                _leftColIdx = _centerColIdx - 1;
                _leftRowIdx = _centerRowIdx;

                _rightColIdx = _centerColIdx + 1;
                _rightRowIdx = _centerRowIdx;

                if (_isLeft)
                {
                    _topLeftColIdx = _leftColIdx;
                    _topLeftRowIdx = _leftRowIdx - 1;
                }
                else
                {
                    _topRightColIdx = _rightColIdx;
                    _topRightRowIdx = _rightRowIdx - 1;
                }
            }
            else if (_currentShapeDirection == ShapeDirections.FaceRight)
            {
                //x  or  xx
                //x      x
                //xx     x

                _topColIdx = _centerColIdx;
                _topRowIdx = _centerRowIdx - 1;

                _bottomColIdx = _centerColIdx;
                _bottomRowIdx = _centerRowIdx + 1;

                if (_isLeft)
                {
                    _topRightColIdx = _topColIdx + 1;
                    _topRightRowIdx = _topRowIdx;
                }
                else
                {
                    _bottomRightColIdx = _bottomColIdx + 1;
                    _bottomRightRowIdx = _bottomRowIdx;
                }
            }
            else if (_currentShapeDirection == ShapeDirections.FaceDown)
            {
                //xxx or xxx
                //x        x
                _leftColIdx = _centerColIdx - 1;
                _leftRowIdx = _centerRowIdx;

                _rightColIdx = _centerColIdx + 1;
                _rightRowIdx = _centerRowIdx;

                if (_isLeft)
                {
                    _bottomRightColIdx = _rightColIdx;
                    _bottomRightRowIdx = _rightRowIdx + 1;
                }
                else
                {
                    _bottomLeftColIdx = _leftColIdx;
                    _bottomLeftRowIdx = _leftRowIdx + 1;
                }
            }
            else //Face left
            {
                //xx or  x
                // x     x
                // x    xx
                _topColIdx = _centerColIdx;
                _topRowIdx = _centerRowIdx - 1;

                _bottomColIdx = _centerColIdx;
                _bottomRowIdx = _centerRowIdx + 1;

                if (_isLeft)
                {
                    _bottomLeftColIdx = _bottomColIdx - 1;
                    _bottomLeftRowIdx = _bottomRowIdx;
                }
                else
                {
                    _topLeftColIdx = _topColIdx - 1;
                    _topLeftRowIdx = _topRowIdx;
                }
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
            // x0             0x0
            //0x0             0x0
            //0xx (right) and xx (left)

            //The shape can be rotated if there's no ButtonCellType in its (current top right, current right, current left
            //and current bottom left cells) or (current top right, current right, current left and current top left cells)
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

            switch (nextShape)
            {
                case ShapeDirections.FaceDown:
                    //Current is FaceRight

                    if (_isLeft)
                    {
                        loc1ColIdx = _centerColIdx - 1;
                        loc1RowIdx = _centerRowIdx;

                        loc2ColIdx = _centerColIdx + 1;
                        loc2RowIdx = _centerRowIdx;

                        loc3ColIdx = _bottomColIdx - 1;
                        loc3RowIdx = _bottomRowIdx;

                        loc4ColIdx = _bottomColIdx + 1;
                        loc4RowIdx = _bottomRowIdx;
                    }
                    else
                    {
                        loc1ColIdx = _topColIdx + 1;
                        loc1RowIdx = _topRowIdx;

                        loc2ColIdx = _centerColIdx - 1;
                        loc2RowIdx = _centerRowIdx;

                        loc3ColIdx = _centerColIdx + 1;
                        loc3RowIdx = _centerRowIdx;

                        loc4ColIdx = _bottomColIdx - 1;
                        loc4RowIdx = _bottomRowIdx;
                    }

                    break;

                case ShapeDirections.FaceLeft:
                    //Current is FaceDown
                    if (_isLeft)
                    {
                        loc1ColIdx = _leftColIdx;
                        loc1RowIdx = _leftRowIdx - 1;

                        loc2ColIdx = _centerColIdx;
                        loc2RowIdx = _centerRowIdx - 1;

                        loc3ColIdx = _leftColIdx;
                        loc3RowIdx = _leftRowIdx + 1;

                        loc4ColIdx = _centerColIdx;
                        loc4RowIdx = _centerRowIdx + 1;
                    }
                    else
                    {
                        loc1ColIdx = _leftColIdx;
                        loc1RowIdx = _leftRowIdx - 1;

                        loc2ColIdx = _centerColIdx;
                        loc2RowIdx = _centerRowIdx - 1;

                        loc3ColIdx = _centerColIdx;
                        loc3RowIdx = _centerRowIdx + 1;

                        loc4ColIdx = _rightColIdx;
                        loc4RowIdx = _rightRowIdx + 1;
                    }
                    break;

                case ShapeDirections.FaceUp:
                    //Current is FaceLeft
                    if (_isLeft)
                    {
                        loc1ColIdx = _topColIdx - 1;
                        loc1RowIdx = _topRowIdx;

                        loc2ColIdx = _topColIdx + 1;
                        loc2RowIdx = _topRowIdx;

                        loc3ColIdx = _centerColIdx - 1;
                        loc3RowIdx = _centerRowIdx;

                        loc4ColIdx = _centerColIdx + 1;
                        loc4RowIdx = _centerRowIdx;
                    }
                    else
                    {
                        loc1ColIdx = _topColIdx + 1;
                        loc1RowIdx = _topRowIdx;

                        loc2ColIdx = _centerColIdx - 1;
                        loc2RowIdx = _centerRowIdx;

                        loc3ColIdx = _centerColIdx + 1;
                        loc3RowIdx = _centerRowIdx;

                        loc4ColIdx = _bottomColIdx - 1;
                        loc4RowIdx = _bottomRowIdx;
                    }
                    break;

                case ShapeDirections.FaceRight:
                    //Current is FaceUp
                    if (_isLeft)
                    {
                        loc1ColIdx = _centerColIdx;
                        loc1RowIdx = _centerRowIdx - 1;

                        loc2ColIdx = _rightColIdx;
                        loc2RowIdx = _rightRowIdx - 1;

                        loc3ColIdx = _centerColIdx;
                        loc3RowIdx = _centerRowIdx + 1;

                        loc4ColIdx = _rightColIdx;
                        loc4RowIdx = _rightRowIdx + 1;
                    }
                    else
                    {
                        loc1ColIdx = _leftColIdx;
                        loc1RowIdx = _leftRowIdx - 1;

                        loc2ColIdx = _centerColIdx;
                        loc2RowIdx = _centerRowIdx - 1;

                        loc3ColIdx = _centerColIdx;
                        loc3RowIdx = _centerRowIdx + 1;

                        loc4ColIdx = _rightColIdx;
                        loc4RowIdx = _rightRowIdx + 1;
                    }
                    break;
            }

            //When the center cell reaches borders, can't rotate
            if (_centerColIdx == BORDER_LEFT || _centerColIdx == BORDER_RIGHT - 1 || _centerRowIdx == BORDER_BOTTOM - 1)
                return false;

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
            //The shapes are built from 4 cells so we need to check 4 next locations
            //Locations are from left to right, top to bottom
            int loc1RowIdx = 0;
            int loc1ColIdx = 0;
            int loc2RowIdx = 0;
            int loc2ColIdx = 0;
            int loc3RowIdx = 0;
            int loc3ColIdx = 0;
            int loc4RowIdx = 0;
            int loc4ColIdx = 0;

            ICellType nextCellType1 = null;
            ICellType nextCellType2 = null;
            ICellType nextCellType3 = null;
            ICellType nextCellType4 = null;

            //Compute the original locations
            switch (_currentShapeDirection)
            {
                case ShapeDirections.FaceDown:
                    if (_isLeft)
                    {
                        loc1ColIdx = _leftColIdx;
                        loc1RowIdx = _leftRowIdx;

                        loc2ColIdx = _centerColIdx;
                        loc2RowIdx = _centerRowIdx;

                        loc3ColIdx = _rightColIdx;
                        loc3RowIdx = _rightRowIdx;

                        loc4ColIdx = _bottomRightColIdx;
                        loc4RowIdx = _bottomRightRowIdx;
                    }
                    else
                    {
                        loc1ColIdx = _leftColIdx;
                        loc1RowIdx = _leftRowIdx;

                        loc2ColIdx = _centerColIdx;
                        loc2RowIdx = _centerRowIdx;

                        loc3ColIdx = _rightColIdx;
                        loc3RowIdx = _rightRowIdx;

                        loc4ColIdx = _bottomLeftColIdx;
                        loc4RowIdx = _bottomLeftRowIdx;
                    }

                    break;

                case ShapeDirections.FaceLeft:
                    if (_isLeft)
                    {
                        loc1ColIdx = _topColIdx;
                        loc1RowIdx = _topRowIdx;

                        loc2ColIdx = _centerColIdx;
                        loc2RowIdx = _centerRowIdx;

                        loc3ColIdx = _bottomLeftColIdx;
                        loc3RowIdx = _bottomLeftRowIdx;

                        loc4ColIdx = _bottomColIdx;
                        loc4RowIdx = _bottomRowIdx;
                    }
                    else
                    {
                        loc1ColIdx = _topLeftColIdx;
                        loc1RowIdx = _topLeftRowIdx;

                        loc2ColIdx = _topColIdx;
                        loc2RowIdx = _topRowIdx;

                        loc3ColIdx = _centerColIdx;
                        loc3RowIdx = _centerRowIdx;

                        loc4ColIdx = _bottomColIdx;
                        loc4RowIdx = _bottomRowIdx;
                    }
                    break;

                case ShapeDirections.FaceRight:
                    if (_isLeft)
                    {
                        loc1ColIdx = _topColIdx;
                        loc1RowIdx = _topRowIdx;

                        loc2ColIdx = _topRightColIdx;
                        loc2RowIdx = _topRightRowIdx;

                        loc3ColIdx = _centerColIdx;
                        loc3RowIdx = _centerRowIdx;

                        loc4ColIdx = _bottomColIdx;
                        loc4RowIdx = _bottomRowIdx;
                    }
                    else
                    {
                        loc1ColIdx = _topColIdx;
                        loc1RowIdx = _topRowIdx;

                        loc2ColIdx = _centerColIdx;
                        loc2RowIdx = _centerRowIdx;

                        loc3ColIdx = _bottomColIdx;
                        loc3RowIdx = _bottomRowIdx;

                        loc4ColIdx = _bottomRightColIdx;
                        loc4RowIdx = _bottomRightRowIdx;
                    }
                    break;

                case ShapeDirections.FaceUp:
                    if (_isLeft)
                    {
                        loc1ColIdx = _topLeftColIdx;
                        loc1RowIdx = _topLeftRowIdx;

                        loc2ColIdx = _leftColIdx;
                        loc2RowIdx = _leftRowIdx;

                        loc3ColIdx = _centerColIdx;
                        loc3RowIdx = _centerRowIdx;

                        loc4ColIdx = _rightColIdx;
                        loc4RowIdx = _rightRowIdx;
                    }
                    else
                    {
                        loc1ColIdx = _topRightColIdx;
                        loc1RowIdx = _topRightRowIdx;

                        loc2ColIdx = _leftColIdx;
                        loc2RowIdx = _leftRowIdx;

                        loc3ColIdx = _centerColIdx;
                        loc3RowIdx = _centerRowIdx;

                        loc4ColIdx = _rightColIdx;
                        loc4RowIdx = _rightRowIdx;
                    }
                    break;
            }

            //Compute the next locations
            switch (nextDirection)
            {
                case MovingDirections.Right:
                    loc1ColIdx = loc1ColIdx + 1;
                    loc2ColIdx = loc2ColIdx + 1;
                    loc3ColIdx = loc3ColIdx + 1;
                    loc4ColIdx = loc4ColIdx + 1;
                    break;

                case MovingDirections.Left:
                    loc1ColIdx = loc1ColIdx - 1;
                    loc2ColIdx = loc2ColIdx - 1;
                    loc3ColIdx = loc3ColIdx - 1;
                    loc4ColIdx = loc4ColIdx - 1;
                    break;

                case MovingDirections.Down:
                    loc1RowIdx = loc1RowIdx + 1;
                    loc2RowIdx = loc2RowIdx + 1;
                    loc3RowIdx = loc3RowIdx + 1;
                    loc4RowIdx = loc4RowIdx + 1;
                    break;
            }

            if (loc1ColIdx < BORDER_LEFT || loc2ColIdx < BORDER_LEFT || loc3ColIdx < BORDER_LEFT || loc4ColIdx < BORDER_LEFT
                || loc1ColIdx >= BORDER_RIGHT || loc2ColIdx >= BORDER_RIGHT || loc3ColIdx >= BORDER_RIGHT || loc4ColIdx >= BORDER_RIGHT
                || loc1RowIdx >= BORDER_BOTTOM || loc2RowIdx >= BORDER_BOTTOM || loc3RowIdx >= BORDER_BOTTOM || loc4RowIdx >= BORDER_BOTTOM)
                return false;

            //The shape can be moved if the cells at the next location are not ButtonCellType
            nextCellType1 = _sheet.Cells[loc1RowIdx, loc1ColIdx].CellType;
            nextCellType2 = _sheet.Cells[loc2RowIdx, loc2ColIdx].CellType;
            nextCellType3 = _sheet.Cells[loc3RowIdx, loc3ColIdx].CellType;
            nextCellType4 = _sheet.Cells[loc4RowIdx, loc4ColIdx].CellType;

            switch (_currentShapeDirection)
            {
                case ShapeDirections.FaceDown:
                    switch (nextDirection)
                    {
                        case MovingDirections.Down:
                            //Shape is facing down and moving down
                            if (_isLeft)
                            {
                                if (nextCellType1 != null || nextCellType2 != null || nextCellType4 != null)
                                    return false;
                            }
                            else
                            {
                                if (nextCellType2 != null || nextCellType3 != null || nextCellType4 != null)
                                    return false;
                            }
                            break;

                        case MovingDirections.Left:
                            //Shape is facing down and moving left
                            if (_isLeft)
                            {
                                if (nextCellType1 != null || nextCellType4 != null)
                                    return false;
                            }
                            else
                            {
                                if (nextCellType1 != null || nextCellType4 != null)
                                    return false;
                            }
                            break;

                        case MovingDirections.Right:
                            //Shape is facing down and moving right
                            if (_isLeft)
                            {
                                if (nextCellType3 != null || nextCellType4 != null)
                                    return false;
                            }
                            else
                            {
                                if (nextCellType3 != null || nextCellType4 != null)
                                    return false;
                            }
                            break;
                    }

                    break;

                case ShapeDirections.FaceLeft:
                    switch (nextDirection)
                    {
                        case MovingDirections.Down:
                            //Shape is facing left and moving down
                            if (_isLeft)
                            {
                                if (nextCellType3 != null || nextCellType4 != null)
                                    return false;
                            }
                            else
                            {
                                if (nextCellType1 != null || nextCellType4 != null)
                                    return false;
                            }
                            break;

                        case MovingDirections.Left:
                            //Shape is facing left and moving left
                            if (_isLeft)
                            {
                                if (nextCellType1 != null || nextCellType2 != null || nextCellType3 != null)
                                    return false;
                            }
                            else
                            {
                                if (nextCellType1 != null || nextCellType3 != null || nextCellType4 != null)
                                    return false;
                            }
                            break;

                        case MovingDirections.Right:
                            //Shape is facing left and moving right
                            if (_isLeft)
                            {
                                if (nextCellType1 != null || nextCellType2 != null || nextCellType4 != null)
                                    return false;
                            }
                            else
                            {
                                if (nextCellType2 != null || nextCellType3 != null || nextCellType4 != null)
                                    return false;
                            }
                            break;
                    }
                    break;

                case ShapeDirections.FaceRight:
                    switch (nextDirection)
                    {
                        case MovingDirections.Down:
                            //Shape is facing right and moving down
                            if (_isLeft)
                            {
                                if (nextCellType2 != null || nextCellType4 != null)
                                    return false;
                            }
                            else
                            {
                                if (nextCellType3 != null || nextCellType4 != null)
                                    return false;
                            }
                            break;

                        case MovingDirections.Left:
                            //Shape is facing right and moving left
                            if (_isLeft)
                            {
                                if (nextCellType1 != null || nextCellType3 != null || nextCellType4 != null)
                                    return false;
                            }
                            else
                            {
                                if (nextCellType1 != null || nextCellType2 != null || nextCellType3 != null)
                                    return false;
                            }
                            break;

                        case MovingDirections.Right:
                            //Shape is facing right and moving right
                            if (_isLeft)
                            {
                                if (nextCellType2 != null || nextCellType3 != null || nextCellType4 != null)
                                    return false;
                            }
                            else
                            {
                                if (nextCellType1 != null || nextCellType2 != null || nextCellType4 != null)
                                    return false;
                            }
                            break;
                    }
                    break;

                case ShapeDirections.FaceUp:
                    switch (nextDirection)
                    {
                        case MovingDirections.Down:
                            //Shape is facing up and moving down
                            if (_isLeft)
                            {
                                if (nextCellType2 != null || nextCellType3 != null || nextCellType4 != null)
                                    return false;
                            }
                            else
                            {
                                if (nextCellType2 != null || nextCellType3 != null || nextCellType4 != null)
                                    return false;
                            }
                            break;

                        case MovingDirections.Left:
                            //Shape is facing up and moving left
                            if (_isLeft)
                            {
                                if (nextCellType1 != null || nextCellType2 != null)
                                    return false;
                            }
                            else
                            {
                                if (nextCellType1 != null || nextCellType2 != null)
                                    return false;
                            }
                            break;

                        case MovingDirections.Right:
                            //Shape is facing up and moving right
                            if (_isLeft)
                            {
                                if (nextCellType1 != null || nextCellType4 != null)
                                    return false;
                            }
                            else
                            {
                                if (nextCellType1 != null || nextCellType4 != null)
                                    return false;
                            }
                            break;
                    }
                    break;
            }

            return true;
        }
    }
}