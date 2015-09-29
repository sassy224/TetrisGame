using FarPoint.Win.Spread;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TetrisGame.Enums;

namespace TetrisGame.Shape
{
    public interface ITetrisShape
    {
        /// <summary>
        /// Interface method to draw the shape
        /// </summary>
        void Draw();

        /// <summary>
        /// Interface method to rotate the shape
        /// </summary>
        void Rotate();

        /// <summary>
        /// Interface method to move the shape to the left
        /// </summary>
        void MoveLeft();

        /// <summary>
        /// Interface method to move the shape to the right
        /// </summary>
        void MoveRight();

        /// <summary>
        /// Interface method to move the shape down
        /// </summary>
        void MoveDown();

        /// <summary>
        /// Interface method to check if the shape can be rotated to the next shape direction
        /// </summary>
        /// <param name="nextDirection"></param>
        /// <returns></returns>
        bool CanRotate(ShapeDirections nextDirection);

        /// <summary>
        /// Interface method to check if the shape can be moved in a specfic direction
        /// </summary>
        /// <param name="nextDirection"></param>
        /// <returns></returns>
        bool CanMove(MovingDirections nextDirection);

        /// <summary>
        /// Interface method to get the Spread cells that form the shape
        /// </summary>
        /// <returns></returns>
        Cell[] GetCells();

        /// <summary>
        /// Interface method to set the SheetView object to contain the shape
        /// </summary>
        /// <param name="sheet"></param>
        void SetSheetView(SheetView sheet);

        /// <summary>
        /// Interface method to reset all the cells of the shape
        /// </summary>
        void Reset();
    }
}