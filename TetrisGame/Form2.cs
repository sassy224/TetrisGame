using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.DrawingSpace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TetrisGame.Actions;
using TetrisGame.Enums;
using TetrisGame.Shape;

namespace TetrisGame
{
    public partial class Form2 : Form
    {
        /// <summary>
        /// Variable to hold the shape in the preview section
        /// </summary>
        private ITetrisShape _pendingShape = null;
        /// <summary>
        /// Variable to hold the shape in the game
        /// </summary>
        private ITetrisShape _currentShape = null;
        /// <summary>
        /// A random generator
        /// </summary>
        private Random _random = new Random();
        /// <summary>
        /// Flag to check whelther the game is over
        /// </summary>
        private bool _isGameOver = false;
        /// <summary>
        /// Variable to hold the current shape direction of the shape
        /// </summary>
        private ShapeDirections _currentDirection = ShapeDirections.FaceDown;
        /// <summary>
        /// Variable to hold the current Shape model
        /// </summary>
        private TetrisShapes _currentShapeModel = TetrisShapes.TShape;
        /// <summary>
        /// Variable to store the rectangle shape object of the spread
        /// </summary>
        private PSShape _rectGameOver;
        /// <summary>
        /// Variable to store the selection range of the preview section
        /// </summary>
        private Cell _previewRange = null;
        /// <summary>
        /// Variable to store the selection range of the game section
        /// </summary>
        private Cell _gameRange = null;
        /// <summary>
        /// Variable to store the current level setting of the game
        /// </summary>
        private string _currentLevel;

        public Form2()
        {
            InitializeComponent();

            //Set default cursor
            fpSpread1.SetCursor(FarPoint.Win.Spread.CursorType.Normal, System.Windows.Forms.Cursors.Default);

            //Set focus to button cell
            fpSpread1_Sheet1.SetActiveCell(1, 1, true);

            //Save the shape to object and remove it from the spread
            _rectGameOver = fpSpread1_Sheet1.GetShape("rectGameOver");
            fpSpread1_Sheet1.RemoveShape("rectGameOver");

            //Save ranges
            _previewRange = fpSpread1_Sheet1.Cells[1, 16, 3, 19];
            _gameRange = fpSpread1_Sheet1.Cells[5, 1, Constants.MAX_HEIGHT + Constants.BASE_HEIGHT_OFFSET, Constants.MAX_WIDTH + Constants.BASE_WIDTH_OFFSET];
            _currentLevel = GameLevels.Normal.ToString();
        }

        /// <summary>
        /// Method that fires when ButtonCellType is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == 1 && e.Row == 1)
            {
                GameStart();
                //Change focus from the button so that when user presses the space bar, it won't perform a click on the button again
                fpSpread1.Focus();
            }
        }

        private void tmTick_Tick(object sender, EventArgs e)
        {
            if (_currentShape.CanMove(MovingDirections.Down))
            {
                //Move the shape down
                _currentShape.MoveDown();
            }
            else
            {
                //Shape can't be moved down, check for cleared rows
                CheckRows();

                //Continue when the game is not over yet
                if (!_isGameOver)
                {
                    //Assign pending shape to current shape
                    _currentShape = GenerateRandomShape(false);

                    //Create new pending shape
                    _pendingShape.Reset();
                    _pendingShape = GenerateRandomShape(true);

                    //Remap action for new shape
                    MapCustomActions();
                }
            }
        }

        /// <summary>
        /// Reset the board and start the game
        /// </summary>
        private void GameStart()
        {
            //Stop ticking
            tmTick.Stop();

            //Remove shape
            fpSpread1_Sheet1.RemoveShape("rectGameOver");
            //Clear ranges
            _previewRange.ResetCellType();
            _gameRange.ResetCellType();

            //Create random shapes
            _currentShape = GenerateRandomShape(false);

            _pendingShape = GenerateRandomShape(true);
            fpSpread1_Sheet1.Cells[2, 12].Text = "0";
            _isGameOver = false;

            //Map custom action
            MapCustomActions(true);

            //Start ticking
            tmTick.Start();
        }

        /// <summary>
        /// Stop everything, show Game Over
        /// </summary>
        private void GameOver()
        {
            tmTick.Stop();
            fpSpread1_Sheet1.AddShape(_rectGameOver);
            _isGameOver = true;

            _currentShape = null;
            _pendingShape = null;

            //Because _currentShape is now null, calling MapCustomAction again will act as remove custom the custom actions
            MapCustomActions();
        }

        /// <summary>
        /// Check for cleared rows
        /// </summary>
        private void CheckRows()
        {
            //Get cells from shape
            Cell[] cells = _currentShape.GetCells();
            //A shape is built by 4 cells, find the lowest row index of the 4 cells
            int minRowIdx = Math.Min(Math.Min(cells[0].Row.Index, cells[1].Row.Index), Math.Min(cells[2].Row.Index, cells[3].Row.Index));

            //Check minRowIdx
            if (minRowIdx <= Constants.BASE_HEIGHT_OFFSET) //cells reach top of the border
            {
                GameOver();
                return;
            }

            List<int> lstClearedRowIdxes = new List<int>();

            for (int row = fpSpread1_Sheet1.RowCount - 1; row >= minRowIdx; row--)
            {
                bool cleared = true;
                for (int col = Constants.BASE_WIDTH_OFFSET; col < Constants.MAX_WIDTH + Constants.BASE_WIDTH_OFFSET; col++)
                {
                    //If there's any row that is not of ButtonCellType, skip it
                    if ((fpSpread1_Sheet1.Cells[row, col].CellType == null))
                    {
                        cleared = false;
                        break;
                    }
                }

                if (cleared)
                {
                    lstClearedRowIdxes.Add(row);
                }
            }

            int removedCount = 0;

            foreach (int rowIdx in lstClearedRowIdxes)
            {
                //Remove the row
                fpSpread1_Sheet1.Rows.Get(rowIdx + removedCount).Remove();
                //Add a new one at the top
                fpSpread1_Sheet1.Rows.Add(Constants.BASE_HEIGHT_OFFSET, 1);

                //Update color for newly created cells
                this.fpSpread1_Sheet1.Cells.Get(5, 0).BackColor = System.Drawing.SystemColors.ControlLight;
                this.fpSpread1_Sheet1.Cells.Get(5, 0).ForeColor = System.Drawing.Color.Silver;
                this.fpSpread1_Sheet1.Cells.Get(5, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
                this.fpSpread1_Sheet1.Cells.Get(5, 19).BackColor = System.Drawing.SystemColors.ControlLight;
                this.fpSpread1_Sheet1.Cells.Get(5, 19).ForeColor = System.Drawing.Color.Silver;
                this.fpSpread1_Sheet1.Cells.Get(5, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;

                //Update score
                fpSpread1_Sheet1.Cells[2, 12].Text = (Int32.Parse(fpSpread1_Sheet1.Cells[2, 12].Text) + 100).ToString();

                //Increase the count so next row will be removed correctly
                removedCount++;
            }
        }

        /// <summary>
        /// Generate a new random shape
        /// </summary>
        /// <param name="forPreview">Flag to check whether this shape is generated for preview</param>
        /// <returns>New instance of ITetrisShape class</returns>
        private ITetrisShape GenerateRandomShape(bool forPreview)
        {
            ITetrisShape shape = null;

            if (forPreview)
            {
                //Create a random direction
                _currentDirection = (ShapeDirections)_random.Next(1, 4);
            }

            //Init location
            int colIdx = 17;
            int rowIdx = 2;

            if (!forPreview)
            {
                colIdx = _random.Next(2, Constants.MAX_WIDTH - 2);
                rowIdx = 6;
            }

            if (forPreview)
            {
                //Create a random shape
                _currentShapeModel = (TetrisShapes)_random.Next(1, 4);
            }

            switch (_currentShapeModel)
            {
                case TetrisShapes.TShape:
                    shape = new TShape(fpSpread1_Sheet1, rowIdx, colIdx, _currentDirection);
                    break;

                case TetrisShapes.SShape:
                    shape = new SShape(fpSpread1_Sheet1, rowIdx, colIdx);
                    break;

                case TetrisShapes.DotShape:
                    shape = new DotShape(fpSpread1_Sheet1, rowIdx, colIdx, _currentDirection);
                    break;
            }

            return shape;
        }

        /// <summary>
        /// Map arrow keys with custom actions
        /// </summary>
        /// <param name="isInit"></param>
        private void MapCustomActions(bool isInit = false)
        {
            InputMap im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            ActionMap am = fpSpread1.GetActionMap();

            if (isInit)
            {
                //Map both keys with/without modifier Control
                im.Put(new Keystroke(Keys.Down, Keys.None), "MoveShapeDown");
                im.Put(new Keystroke(Keys.Down, Keys.Control), "MoveShapeDown");

                im.Put(new Keystroke(Keys.Left, Keys.None), "MoveShapeLeft");
                im.Put(new Keystroke(Keys.Left, Keys.Control), "MoveShapeLeft");

                im.Put(new Keystroke(Keys.Right, Keys.None), "MoveShapeRight");
                im.Put(new Keystroke(Keys.Right, Keys.Control), "MoveShapeRight");

                im.Put(new Keystroke(Keys.Up, Keys.None), "MoveShapeUp");
                im.Put(new Keystroke(Keys.Up, Keys.Control), "MoveShapeUp");

                im.Put(new Keystroke(Keys.Space, Keys.None), "RotateShape");
                im.Put(new Keystroke(Keys.Space, Keys.Control), "RotateShape");
            }

            am.Put("MoveShapeDown", new MoveShape(_currentShape, MovingDirections.Down));
            am.Put("MoveShapeLeft", new MoveShape(_currentShape, MovingDirections.Left));
            am.Put("MoveShapeRight", new MoveShape(_currentShape, MovingDirections.Right));
            am.Put("MoveShapeUp", new MoveShape(_currentShape, MovingDirections.Up));
            am.Put("RotateShape", new RotateShape(_currentShape));
        }

        /// <summary>
        /// Overwrite method to process arrow key
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    //Capture up arrow key
        //    if (keyData == Keys.Up)
        //    {
        //        //Do nothing
        //        return true;
        //    }
        //    //Capture down arrow key
        //    if (keyData == Keys.Down)
        //    {
        //        if (!_isGameOver && _currentShape != null && _currentShape.CanMove(MovingDirections.Down))
        //            _currentShape.MoveDown();
        //        return true;
        //    }
        //    //Capture left arrow key
        //    if (keyData == Keys.Left)
        //    {
        //        if (!_isGameOver && _currentShape != null && _currentShape.CanMove(MovingDirections.Left))
        //            _currentShape.MoveLeft();
        //        return true;
        //    }
        //    //Capture right arrow key
        //    if (keyData == Keys.Right)
        //    {
        //        if (!_isGameOver && _currentShape != null && _currentShape.CanMove(MovingDirections.Right))
        //            _currentShape.MoveRight();
        //        return true;
        //    }

        //    //Capture Space key
        //    if (keyData == Keys.Space)
        //    {
        //        if (!_isGameOver)
        //        {
        //            if (_currentShape == null)
        //            {
        //                //Game hasn't been started yet, start it
        //                GameStart();
        //            }
        //            else
        //            {
        //                _currentShape.Rotate();
        //            }
        //        }

        //        return true;
        //    }

        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        /// <summary>
        /// Method that fires up when user closes the ComboBoxCellType
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_ComboCloseUp(object sender, EditorNotifyEventArgs e)
        {
            if (e.Row == 3 && e.Column == 3)
            {
                //Check if user selected new value
                string selectedLevel = fpSpread1_Sheet1.Cells[3, 3].Text;
                if (selectedLevel != _currentLevel)
                {
                    if (selectedLevel.Equals(GameLevels.Slow.ToString(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        tmTick.Interval = (int)GameLevels.Slow;
                    }
                    else if (selectedLevel.Equals(GameLevels.Normal.ToString(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        tmTick.Interval = (int)GameLevels.Normal;
                    }
                    else
                    {
                        tmTick.Interval = (int)GameLevels.Fast;
                    }
                    _currentLevel = selectedLevel;
                }
            }
        }

        /// <summary>
        /// Capture cell click event to not allow user to select any cells
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_CellClick(object sender, CellClickEventArgs e)
        {
            if ((e.Row == 3 && e.Column == 3) || (e.Column == 1 && e.Row == 1))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Capture cell double click event to not allow user to go into edit mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_CellDoubleClick(object sender, CellClickEventArgs e)
        {
            e.Cancel = true;
        }
    }
}