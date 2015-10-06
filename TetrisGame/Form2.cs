using FarPoint.Win;
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
    private TetrisShapes _currentShapeModel = TetrisShapes.IShape;
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
    /// <summary>
    /// Variable to store the current side setting for LShape and ZShape
    /// </summary>
    private bool _isLeft = false;
    /// <summary>
    /// Variable custom message filter
    /// </summary>
    private PreventWheelMouseFilter msgFliter = new PreventWheelMouseFilter();
    /// <summary>
    /// Flag to check whether the game is paused
    /// </summary>
    private bool _isPaused = false;

    public Form2()
    {
      InitializeComponent();

      //Register the custom message filter
      Application.AddMessageFilter(msgFliter);

      //Set default cursor
      fpSpread1.SetCursor(FarPoint.Win.Spread.CursorType.Normal, System.Windows.Forms.Cursors.Default);

      //Set focus to button cell
      //sheet1.SetActiveCell(1, 1, true);
      fpSpread1.FocusRenderer = new DefaultFocusIndicatorRenderer(0);

      //Save the shape to object and remove it from the spread
      _rectGameOver = sheet1.GetShape("rectGameOver");
      sheet1.RemoveShape("rectGameOver");

      //Save ranges
      _previewRange = sheet1.Cells[1, 16, 3, 19];
      _gameRange = sheet1.Cells[5, 1, Constants.MAX_HEIGHT + Constants.BASE_HEIGHT_OFFSET, Constants.MAX_WIDTH + Constants.BASE_WIDTH_OFFSET];
      _currentLevel = GameLevels.Normal.ToString();

      MapCustomActions(true);

      fpSpread1.MouseWheel += fpSpread1_MouseWheel; ;
    }

    void fpSpread1_MouseWheel(object sender, MouseEventArgs e)
    {
      ((HandledMouseEventArgs)e).Handled = true;
      //((HandledMouseEventArgs)e).
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
        _currentShape.Move(MovingDirections.Down);
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
          if (_pendingShape != null)
            _pendingShape.ResetCells();
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
      sheet1.RemoveShape("rectGameOver");
      //Clear ranges
      _previewRange.ResetCellType();
      _gameRange.ResetCellType();

      //Create random shapes
      _currentShape = GenerateRandomShape(false);

      _pendingShape = GenerateRandomShape(true);
      sheet1.Cells[2, 12].Text = "0";
      _isGameOver = false;
      _isPaused = false;

      //Map custom action
      MapCustomActions();

      //Start ticking
      tmTick.Start();
    }

    /// <summary>
    /// Stop everything, show Game Over
    /// </summary>
    private void GameOver()
    {
      tmTick.Stop();
      sheet1.AddShape(_rectGameOver);
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
      //A shape is built by multiple cells, find the lowest row index of all cells
      int minRowIdx = Constants.MAX_HEIGHT + Constants.BASE_HEIGHT_OFFSET;
      for (int i = 0; i < cells.Length; i++)
      {
        minRowIdx = Math.Min(cells[i].Row.Index, minRowIdx);
      }

      //Check minRowIdx
      if (minRowIdx <= Constants.BASE_HEIGHT_OFFSET) //cells reach top of the border
      {
        GameOver();
        return;
      }

      List<int> lstClearedRowIdxes = new List<int>();

      for (int row = sheet1.RowCount - 1; row >= minRowIdx; row--)
      {
        bool cleared = true;
        for (int col = Constants.BASE_WIDTH_OFFSET; col < Constants.MAX_WIDTH + Constants.BASE_WIDTH_OFFSET; col++)
        {
          //If there's any row that is not of ButtonCellType, skip it
          if ((sheet1.Cells[row, col].CellType == null))
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
        sheet1.Rows.Get(rowIdx + removedCount).Remove();
        //Add a new one at the top
        sheet1.Rows.Add(Constants.BASE_HEIGHT_OFFSET, 1);

        //Update color for newly created cells
        this.sheet1.Cells.Get(5, 0).BackColor = System.Drawing.SystemColors.ControlLight;
        this.sheet1.Cells.Get(5, 0).ForeColor = System.Drawing.Color.Silver;
        this.sheet1.Cells.Get(5, 0).VisualStyles = FarPoint.Win.VisualStyles.Off;
        this.sheet1.Cells.Get(5, 19).BackColor = System.Drawing.SystemColors.ControlLight;
        this.sheet1.Cells.Get(5, 19).ForeColor = System.Drawing.Color.Silver;
        this.sheet1.Cells.Get(5, 19).VisualStyles = FarPoint.Win.VisualStyles.Off;

        //Update score
        sheet1.Cells[2, 10].Text = (Int32.Parse(sheet1.Cells[2, 10].Text) + 100).ToString();

        //Increase the count so next row will be removed correctly
        removedCount++;
      }
    }

    /// <summary>
    /// Check location of the new shape, if there's any obstacle, game over
    /// </summary>
    /// <param name="shape"></param>
    /// <param name="colIdx"></param>
    /// <param name="rowIdx"></param>
    private bool CheckLocationOfNewShape(TetrisShapes shape, ShapeDirections direction, int colIdx, int rowIdx, bool isLeft)
    {
      bool canDraw = true;
      Cell left = sheet1.Cells[rowIdx, colIdx - 1];
      Cell center = sheet1.Cells[rowIdx, colIdx];
      Cell right = sheet1.Cells[rowIdx, colIdx + 1];

      Cell bottom = sheet1.Cells[rowIdx + 1, colIdx];
      Cell bottomLeft = sheet1.Cells[rowIdx + 1, colIdx - 1];
      Cell bottomRight = sheet1.Cells[rowIdx + 1, colIdx + 1];

      if (center.CellType != null)
      {
        return false;
      }

      switch (shape)
      {
        case TetrisShapes.DotShape:
          //Already checked center
          break;

        case TetrisShapes.IShape:
          switch (direction)
          {
            case ShapeDirections.FaceDown:
            case ShapeDirections.FaceUp:
              //x
              //x
              //x
              if (left.CellType != null || right.CellType != null)
                canDraw = false;

              break;

            case ShapeDirections.FaceLeft:
            case ShapeDirections.FaceRight:
              //xxx
              if (bottom.CellType != null)
                canDraw = false;

              break;
          }
          break;

        case TetrisShapes.LShape:
          switch (direction)
          {
            case ShapeDirections.FaceDown:
              if (isLeft)
              {
                //xxx
                //  x
                if (left.CellType != null || bottomRight.CellType != null)
                  canDraw = false;
              }
              else
              {
                ///xxx
                ///x
                if (left.CellType != null || bottomLeft.CellType != null)
                  canDraw = false;
              }
              break;

            case ShapeDirections.FaceUp:
              //x    or  x
              //xxx    xxx
              if (left.CellType != null || right.CellType != null)
                canDraw = false;
              break;

            case ShapeDirections.FaceLeft:
              if (_isLeft)
              {
                // x
                // x
                //xx
                if (bottom.CellType != null || bottomLeft.CellType != null)
                  canDraw = false;
              }
              else
              {
                //x
                //x
                //xx
                if (bottom.CellType != null || bottomRight.CellType != null)
                  canDraw = false;
              }
              break;

            case ShapeDirections.FaceRight:
              if (_isLeft)
              {
                //xx
                //x
                //x
                if (bottom.CellType != null)
                  canDraw = false;
              }
              else
              {
                //x
                //x
                //xx
                if (bottom.CellType != null || bottomRight.CellType != null)
                  canDraw = false;
              }
              break;
          }
          break;

        case TetrisShapes.SShape:
          //xx
          //xx
          if (bottom.CellType != null || bottomRight.CellType != null)
            canDraw = false;
          break;

        case TetrisShapes.TShape:
          switch (direction)
          {
            case ShapeDirections.FaceDown:
              //xxx
              // x
              if (left.CellType != null || right.CellType != null || bottom.CellType != null)
                canDraw = false;

              break;

            case ShapeDirections.FaceUp:
              // x
              //xxx
              if (left.CellType != null || right.CellType != null)
                canDraw = false;

              break;

            case ShapeDirections.FaceLeft:
              // x
              //xx
              // x
              if (left.CellType != null || bottom.CellType != null)
                canDraw = false;

              break;

            case ShapeDirections.FaceRight:
              //x
              //xx
              //x
              if (right.CellType != null || bottom.CellType != null)
                canDraw = false;

              break;
          }
          break;

        case TetrisShapes.ZShape:
          switch (direction)
          {
            case ShapeDirections.FaceDown:
              if (_isLeft)
              {
                //
                //xx
                // xx
                if (left.CellType != null || bottom.CellType != null || bottomLeft.CellType != null)
                  canDraw = false;
              }
              else
              {
                //
                // xx
                //xx
                if (bottomLeft.CellType != null || bottom.CellType != null || right.CellType != null)
                  canDraw = false;
              }
              break;

            case ShapeDirections.FaceUp:
              if (_isLeft)
              {
                //xx
                // xx
                //
                if (right.CellType != null)
                  canDraw = false;
              }
              else
              {
                // xx
                //xx
                //
                if (left.CellType != null)
                  canDraw = false;
              }
              break;

            case ShapeDirections.FaceLeft:
              if (_isLeft)
              {
                // x
                //xx
                //x
                if (bottomLeft.CellType != null || left.CellType != null)
                  canDraw = false;
              }
              else
              {
                //x
                //xx
                // x
                if (right.CellType != null || bottomRight.CellType != null)
                  canDraw = false;
              }
              break;

            case ShapeDirections.FaceRight:
              if (_isLeft)
              {
                // x
                //xx
                //x
                if (bottom.CellType != null || right.CellType != null)
                  canDraw = false;
              }
              else
              {
                //x
                //xx
                // x
                if (bottomRight.CellType != null || right.CellType != null)
                  canDraw = false;
              }
              break;
          }
          break;
      }

      return canDraw;
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
        //Create a random side
        _isLeft = _random.Next() % 2 == 1;
      }

      if (forPreview)
      {
        //Create a random direction
        _currentDirection = (ShapeDirections)_random.Next(1, 5);
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
        _currentShapeModel = (TetrisShapes)_random.Next(1, 7);
      }

      //Check location of new shape before draw it. If it can't be drawn, game over
      if (!forPreview)
      {
        if (!CheckLocationOfNewShape(_currentShapeModel, _currentDirection, colIdx, rowIdx, _isLeft))
          GameOver();
      }

      switch (_currentShapeModel)
      {
        case TetrisShapes.TShape:
          shape = new TShape(sheet1, rowIdx, colIdx, _currentDirection);
          break;

        case TetrisShapes.SShape:
          shape = new SShape(sheet1, rowIdx, colIdx);
          break;

        case TetrisShapes.DotShape:
          shape = new DotShape(sheet1, rowIdx, colIdx);
          break;

        case TetrisShapes.LShape:
          shape = new LShape(sheet1, rowIdx, colIdx, _currentDirection, _isLeft);
          break;

        case TetrisShapes.IShape:
          shape = new IShape(sheet1, rowIdx, colIdx, _currentDirection);
          break;

        case TetrisShapes.ZShape:
          shape = new ZShape(sheet1, rowIdx, colIdx, _currentDirection, _isLeft);
          break;

        default:
          shape = new TShape(sheet1, rowIdx, colIdx, _currentDirection);
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

        im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F2, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
        im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
        im.Put(new FarPoint.Win.Spread.Keystroke(Keys.End, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
        im.Put(new FarPoint.Win.Spread.Keystroke(Keys.PageDown, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
      }

      if (_isPaused)
      {
        am.Put("MoveShapeDown", new MoveShape(null, MovingDirections.Down));
        am.Put("MoveShapeLeft", new MoveShape(null, MovingDirections.Left));
        am.Put("MoveShapeRight", new MoveShape(null, MovingDirections.Right));
        am.Put("MoveShapeUp", new MoveShape(null, MovingDirections.Up));
        am.Put("RotateShape", new RotateShape(null));
      }
      else
      {
        am.Put("MoveShapeDown", new MoveShape(_currentShape, MovingDirections.Down));
        am.Put("MoveShapeLeft", new MoveShape(_currentShape, MovingDirections.Left));
        am.Put("MoveShapeRight", new MoveShape(_currentShape, MovingDirections.Right));
        am.Put("MoveShapeUp", new MoveShape(_currentShape, MovingDirections.Up));
        am.Put("RotateShape", new RotateShape(_currentShape));
      }
    }

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
        string selectedLevel = sheet1.Cells[3, 3].Text;
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

    /// <summary>
    /// Capture key down event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void fpSpread1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.N && (e.Modifiers == Keys.Control || e.Modifiers == Keys.Alt))
      {
        GameStart();
        e.Handled = true;
      }
      else if (e.KeyCode == Keys.L && (e.Modifiers == Keys.Control || e.Modifiers == Keys.Alt))
      {
        sheet1.SetActiveCell(3, 3);
        fpSpread1.EditMode = true;

        Cell cboCell = sheet1.Cells[3, 3];
        //cboCell.Editor.StartEditing(null, false, false);
        cboCell.Editor.ShowSubEditor();

        e.Handled = true;
      }
      else if (e.KeyCode == Keys.P && (e.Modifiers == Keys.Control || e.Modifiers == Keys.Alt))
      {
        fpSpread1.EditMode = false;

        if (_currentShape != null) //Game already started
        {
          if (_isPaused)
          {
            tmTick.Start();
            _rectGameOver.Text = "Game Over!";
            sheet1.RemoveShape("rectGameOver");
            _isPaused = false;
            MapCustomActions();
          }
          else
          {
            tmTick.Stop();
            _rectGameOver.Text = "Paused!";
            sheet1.AddShape(_rectGameOver);
            _isPaused = true;
            MapCustomActions();
          }
          e.Handled = true;
        }
      }
    }

    /// <summary>
    /// Handle combo select changes event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void fpSpread1_ComboSelChange(object sender, EditorNotifyEventArgs e)
    {
      if (e.Row == 3 && e.Column == 3)
      {
        //Check if user selected new value
        string selectedLevel = sheet1.Cells[3, 3].Text;
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

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      tmTick.Stop();
      MapCustomActions();

      string message = "Are you sure that you would like to exit the game?";
      string caption = "Exit game";
      DialogResult result = MessageBox.Show(message, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);
      if (result == DialogResult.No)
      {
        e.Cancel = true;

        tmTick.Start();
        MapCustomActions();
      }
    }

    public static void CloseCancel()
    {
    }
  }
}

public class PreventWheelMouseFilter : IMessageFilter
{
  public bool PreFilterMessage(ref Message m)
  {
    // Intercept the wheel mouse button message.
    if (m.Msg == 0x20a)
    {
      return true;
    }
    return false;
  }
}