namespace TetrisGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.FpSpread fpSpread1;
            FarPoint.Win.Spread.FpSpread fpSpread2;
            this.sheetMain = new FarPoint.Win.Spread.SheetView();
            this.sheetPreview = new FarPoint.Win.Spread.SheetView();
            this.lblLevel = new System.Windows.Forms.Label();
            this.cboLevel = new System.Windows.Forms.ComboBox();
            this.lblPointsText = new System.Windows.Forms.Label();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.tmTick = new System.Windows.Forms.Timer(this.components);
            this.lblPointsValue = new System.Windows.Forms.Label();
            this.pnlGameOver = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            fpSpread2 = new FarPoint.Win.Spread.FpSpread();
            ((System.ComponentModel.ISupportInitialize)(fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(fpSpread2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetPreview)).BeginInit();
            this.pnlGameOver.SuspendLayout();
            this.SuspendLayout();
            // 
            // fpSpread1
            // 
            fpSpread1.AccessibleDescription = "";
            fpSpread1.AllowUndo = false;
            fpSpread1.AllowUserZoom = false;
            fpSpread1.AutoClipboard = false;
            fpSpread1.BorderCollapse = FarPoint.Win.Spread.BorderCollapse.Collapse;
            fpSpread1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            fpSpread1.CausesValidation = false;
            fpSpread1.CellNoteIndicatorVisible = false;
            fpSpread1.ClipboardOptions = FarPoint.Win.Spread.ClipboardOptions.NoHeaders;
            fpSpread1.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            fpSpread1.EnableCrossSheetReference = false;
            fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            fpSpread1.Location = new System.Drawing.Point(12, 79);
            fpSpread1.MoveActiveOnFocus = false;
            fpSpread1.Name = "fpSpread1";
            fpSpread1.RetainSelectionBlock = false;
            fpSpread1.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.sheetMain});
            fpSpread1.Size = new System.Drawing.Size(520, 520);
            fpSpread1.TabIndex = 0;
            fpSpread1.TabStop = false;
            fpSpread1.TabStripInsertTab = false;
            fpSpread1.TabStripPlacement = FarPoint.Win.Spread.TabStripPlacement.Bottom;
            fpSpread1.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            fpSpread1.TabStripRatio = 0D;
            fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            // 
            // sheetMain
            // 
            this.sheetMain.Reset();
            sheetMain.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.sheetMain.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            sheetMain.ColumnCount = 26;
            sheetMain.RowCount = 26;
            this.sheetMain.AllowNoteEdit = false;
            this.sheetMain.AutoGenerateColumns = false;
            this.sheetMain.ColumnHeader.Visible = false;
            this.sheetMain.Columns.Default.Width = 20F;
            this.sheetMain.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.sheetMain.RowHeader.Visible = false;
            this.sheetMain.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // fpSpread2
            // 
            fpSpread2.AccessibleDescription = "";
            fpSpread2.AllowUndo = false;
            fpSpread2.AllowUserZoom = false;
            fpSpread2.AutoClipboard = false;
            fpSpread2.BorderCollapse = FarPoint.Win.Spread.BorderCollapse.Collapse;
            fpSpread2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            fpSpread2.CausesValidation = false;
            fpSpread2.CellNoteIndicatorVisible = false;
            fpSpread2.ClipboardOptions = FarPoint.Win.Spread.ClipboardOptions.NoHeaders;
            fpSpread2.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            fpSpread2.EnableCrossSheetReference = false;
            fpSpread2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            fpSpread2.Location = new System.Drawing.Point(367, 10);
            fpSpread2.MoveActiveOnFocus = false;
            fpSpread2.Name = "fpSpread2";
            fpSpread2.RetainSelectionBlock = false;
            fpSpread2.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            fpSpread2.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.sheetPreview});
            fpSpread2.Size = new System.Drawing.Size(60, 60);
            fpSpread2.TabIndex = 7;
            fpSpread2.TabStop = false;
            fpSpread2.TabStripInsertTab = false;
            fpSpread2.TabStripPlacement = FarPoint.Win.Spread.TabStripPlacement.Bottom;
            fpSpread2.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            fpSpread2.TabStripRatio = 0D;
            fpSpread2.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            // 
            // sheetPreview
            // 
            this.sheetPreview.Reset();
            sheetPreview.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.sheetPreview.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            sheetPreview.ColumnCount = 3;
            sheetPreview.RowCount = 3;
            this.sheetPreview.AllowNoteEdit = false;
            this.sheetPreview.AutoGenerateColumns = false;
            this.sheetPreview.ColumnHeader.Visible = false;
            this.sheetPreview.Columns.Default.Width = 20F;
            this.sheetPreview.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.sheetPreview.RowHeader.Visible = false;
            this.sheetPreview.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(11, 28);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(33, 13);
            this.lblLevel.TabIndex = 1;
            this.lblLevel.Text = "Level";
            // 
            // cboLevel
            // 
            this.cboLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLevel.FormattingEnabled = true;
            this.cboLevel.Location = new System.Drawing.Point(51, 25);
            this.cboLevel.Name = "cboLevel";
            this.cboLevel.Size = new System.Drawing.Size(98, 21);
            this.cboLevel.TabIndex = 2;
            this.cboLevel.SelectedIndexChanged += new System.EventHandler(this.cboLevel_SelectedIndexChanged);
            // 
            // lblPointsText
            // 
            this.lblPointsText.AutoSize = true;
            this.lblPointsText.Location = new System.Drawing.Point(448, 28);
            this.lblPointsText.Name = "lblPointsText";
            this.lblPointsText.Size = new System.Drawing.Size(39, 13);
            this.lblPointsText.TabIndex = 3;
            this.lblPointsText.Text = "Points:";
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(172, 25);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(75, 23);
            this.btnNewGame.TabIndex = 4;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // tmTick
            // 
            this.tmTick.Tick += new System.EventHandler(this.tmTick_Tick);
            // 
            // lblPointsValue
            // 
            this.lblPointsValue.AutoSize = true;
            this.lblPointsValue.Location = new System.Drawing.Point(484, 28);
            this.lblPointsValue.Name = "lblPointsValue";
            this.lblPointsValue.Size = new System.Drawing.Size(13, 13);
            this.lblPointsValue.TabIndex = 5;
            this.lblPointsValue.Text = "0";
            // 
            // pnlGameOver
            // 
            this.pnlGameOver.Controls.Add(this.label1);
            this.pnlGameOver.Location = new System.Drawing.Point(172, 278);
            this.pnlGameOver.Name = "pnlGameOver";
            this.pnlGameOver.Size = new System.Drawing.Size(200, 100);
            this.pnlGameOver.TabIndex = 6;
            this.pnlGameOver.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Over";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Next shape";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 611);
            this.Controls.Add(this.label2);
            this.Controls.Add(fpSpread2);
            this.Controls.Add(this.pnlGameOver);
            this.Controls.Add(this.lblPointsValue);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.lblPointsText);
            this.Controls.Add(this.cboLevel);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(fpSpread1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tetris Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(fpSpread2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetPreview)).EndInit();
            this.pnlGameOver.ResumeLayout(false);
            this.pnlGameOver.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FarPoint.Win.Spread.SheetView sheetMain;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.ComboBox cboLevel;
        private System.Windows.Forms.Label lblPointsText;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Timer tmTick;
        private System.Windows.Forms.Label lblPointsValue;
        private System.Windows.Forms.Panel pnlGameOver;
        private System.Windows.Forms.Label label1;
        private FarPoint.Win.Spread.SheetView sheetPreview;
        private System.Windows.Forms.Label label2;

    }
}

