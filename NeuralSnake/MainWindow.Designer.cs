namespace NeuralSnake
{
    partial class MainWindow
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
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.GraphicArea = new System.Windows.Forms.PictureBox();
            this.GenerationLabel = new System.Windows.Forms.Label();
            this.MaxScoreLabel = new System.Windows.Forms.Label();
            this.BoardsListBox = new System.Windows.Forms.ListBox();
            this.InputTopLabel = new System.Windows.Forms.Label();
            this.InputRightLabel = new System.Windows.Forms.Label();
            this.InputBottomLabel = new System.Windows.Forms.Label();
            this.InputLeftLabel = new System.Windows.Forms.Label();
            this.InputFoodTopLabel = new System.Windows.Forms.Label();
            this.InputFoodRightLabel = new System.Windows.Forms.Label();
            this.OutputTopLabel = new System.Windows.Forms.Label();
            this.OutputRightLabel = new System.Windows.Forms.Label();
            this.OutputBottomLabel = new System.Windows.Forms.Label();
            this.OutputLeftLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.InputFoodBottomLabel = new System.Windows.Forms.Label();
            this.InputFoodLeftLabel = new System.Windows.Forms.Label();
            this.AvgScoreLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GraphicArea)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(12, 419);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(437, 419);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            // 
            // GraphicArea
            // 
            this.GraphicArea.Location = new System.Drawing.Point(12, 12);
            this.GraphicArea.Name = "GraphicArea";
            this.GraphicArea.Size = new System.Drawing.Size(500, 400);
            this.GraphicArea.TabIndex = 2;
            this.GraphicArea.TabStop = false;
            // 
            // GenerationLabel
            // 
            this.GenerationLabel.AutoSize = true;
            this.GenerationLabel.Location = new System.Drawing.Point(518, 12);
            this.GenerationLabel.Name = "GenerationLabel";
            this.GenerationLabel.Size = new System.Drawing.Size(71, 13);
            this.GenerationLabel.TabIndex = 3;
            this.GenerationLabel.Text = "Generation: 0";
            // 
            // MaxScoreLabel
            // 
            this.MaxScoreLabel.AutoSize = true;
            this.MaxScoreLabel.Location = new System.Drawing.Point(615, 12);
            this.MaxScoreLabel.Name = "MaxScoreLabel";
            this.MaxScoreLabel.Size = new System.Drawing.Size(68, 13);
            this.MaxScoreLabel.TabIndex = 4;
            this.MaxScoreLabel.Text = "Max score: 0";
            // 
            // BoardsListBox
            // 
            this.BoardsListBox.FormattingEnabled = true;
            this.BoardsListBox.Location = new System.Drawing.Point(521, 178);
            this.BoardsListBox.Name = "BoardsListBox";
            this.BoardsListBox.Size = new System.Drawing.Size(162, 264);
            this.BoardsListBox.TabIndex = 5;
            this.BoardsListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BoardsListBox_MouseDoubleClick);
            // 
            // InputTopLabel
            // 
            this.InputTopLabel.AutoSize = true;
            this.InputTopLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InputTopLabel.Location = new System.Drawing.Point(518, 64);
            this.InputTopLabel.Name = "InputTopLabel";
            this.InputTopLabel.Size = new System.Drawing.Size(43, 13);
            this.InputTopLabel.TabIndex = 6;
            this.InputTopLabel.Text = "Top: 0";
            // 
            // InputRightLabel
            // 
            this.InputRightLabel.AutoSize = true;
            this.InputRightLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InputRightLabel.Location = new System.Drawing.Point(518, 77);
            this.InputRightLabel.Name = "InputRightLabel";
            this.InputRightLabel.Size = new System.Drawing.Size(43, 13);
            this.InputRightLabel.TabIndex = 7;
            this.InputRightLabel.Text = "Rig: 0";
            // 
            // InputBottomLabel
            // 
            this.InputBottomLabel.AutoSize = true;
            this.InputBottomLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InputBottomLabel.Location = new System.Drawing.Point(518, 90);
            this.InputBottomLabel.Name = "InputBottomLabel";
            this.InputBottomLabel.Size = new System.Drawing.Size(43, 13);
            this.InputBottomLabel.TabIndex = 8;
            this.InputBottomLabel.Text = "Bot: 0";
            // 
            // InputLeftLabel
            // 
            this.InputLeftLabel.AutoSize = true;
            this.InputLeftLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InputLeftLabel.Location = new System.Drawing.Point(518, 103);
            this.InputLeftLabel.Name = "InputLeftLabel";
            this.InputLeftLabel.Size = new System.Drawing.Size(43, 13);
            this.InputLeftLabel.TabIndex = 9;
            this.InputLeftLabel.Text = "Lef: 0";
            // 
            // InputFoodTopLabel
            // 
            this.InputFoodTopLabel.AutoSize = true;
            this.InputFoodTopLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InputFoodTopLabel.Location = new System.Drawing.Point(518, 121);
            this.InputFoodTopLabel.Name = "InputFoodTopLabel";
            this.InputFoodTopLabel.Size = new System.Drawing.Size(43, 13);
            this.InputFoodTopLabel.TabIndex = 10;
            this.InputFoodTopLabel.Text = "FTo: 0";
            // 
            // InputFoodRightLabel
            // 
            this.InputFoodRightLabel.AutoSize = true;
            this.InputFoodRightLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InputFoodRightLabel.Location = new System.Drawing.Point(518, 134);
            this.InputFoodRightLabel.Name = "InputFoodRightLabel";
            this.InputFoodRightLabel.Size = new System.Drawing.Size(43, 13);
            this.InputFoodRightLabel.TabIndex = 11;
            this.InputFoodRightLabel.Text = "FRi: 0";
            // 
            // OutputTopLabel
            // 
            this.OutputTopLabel.AutoSize = true;
            this.OutputTopLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OutputTopLabel.Location = new System.Drawing.Point(615, 64);
            this.OutputTopLabel.Name = "OutputTopLabel";
            this.OutputTopLabel.Size = new System.Drawing.Size(55, 13);
            this.OutputTopLabel.TabIndex = 12;
            this.OutputTopLabel.Text = "Top: 0.0";
            // 
            // OutputRightLabel
            // 
            this.OutputRightLabel.AutoSize = true;
            this.OutputRightLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OutputRightLabel.Location = new System.Drawing.Point(615, 77);
            this.OutputRightLabel.Name = "OutputRightLabel";
            this.OutputRightLabel.Size = new System.Drawing.Size(55, 13);
            this.OutputRightLabel.TabIndex = 13;
            this.OutputRightLabel.Text = "Rig: 0.0";
            // 
            // OutputBottomLabel
            // 
            this.OutputBottomLabel.AutoSize = true;
            this.OutputBottomLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OutputBottomLabel.Location = new System.Drawing.Point(615, 90);
            this.OutputBottomLabel.Name = "OutputBottomLabel";
            this.OutputBottomLabel.Size = new System.Drawing.Size(55, 13);
            this.OutputBottomLabel.TabIndex = 14;
            this.OutputBottomLabel.Text = "Bot: 0.0";
            // 
            // OutputLeftLabel
            // 
            this.OutputLeftLabel.AutoSize = true;
            this.OutputLeftLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OutputLeftLabel.Location = new System.Drawing.Point(615, 103);
            this.OutputLeftLabel.Name = "OutputLeftLabel";
            this.OutputLeftLabel.Size = new System.Drawing.Size(55, 13);
            this.OutputLeftLabel.TabIndex = 15;
            this.OutputLeftLabel.Text = "Lef: 0.0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(518, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "INPUT";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(615, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "OUTPUT";
            // 
            // InputFoodBottomLabel
            // 
            this.InputFoodBottomLabel.AutoSize = true;
            this.InputFoodBottomLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InputFoodBottomLabel.Location = new System.Drawing.Point(518, 147);
            this.InputFoodBottomLabel.Name = "InputFoodBottomLabel";
            this.InputFoodBottomLabel.Size = new System.Drawing.Size(43, 13);
            this.InputFoodBottomLabel.TabIndex = 18;
            this.InputFoodBottomLabel.Text = "FBo: 0";
            // 
            // InputFoodLeftLabel
            // 
            this.InputFoodLeftLabel.AutoSize = true;
            this.InputFoodLeftLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InputFoodLeftLabel.Location = new System.Drawing.Point(518, 160);
            this.InputFoodLeftLabel.Name = "InputFoodLeftLabel";
            this.InputFoodLeftLabel.Size = new System.Drawing.Size(43, 13);
            this.InputFoodLeftLabel.TabIndex = 19;
            this.InputFoodLeftLabel.Text = "FLe: 0";
            // 
            // AvgScoreLabel
            // 
            this.AvgScoreLabel.AutoSize = true;
            this.AvgScoreLabel.Location = new System.Drawing.Point(615, 25);
            this.AvgScoreLabel.Name = "AvgScoreLabel";
            this.AvgScoreLabel.Size = new System.Drawing.Size(67, 13);
            this.AvgScoreLabel.TabIndex = 20;
            this.AvgScoreLabel.Text = "Avg score: 0";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 457);
            this.Controls.Add(this.AvgScoreLabel);
            this.Controls.Add(this.InputFoodLeftLabel);
            this.Controls.Add(this.InputFoodBottomLabel);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.OutputLeftLabel);
            this.Controls.Add(this.OutputBottomLabel);
            this.Controls.Add(this.OutputRightLabel);
            this.Controls.Add(this.OutputTopLabel);
            this.Controls.Add(this.InputFoodRightLabel);
            this.Controls.Add(this.InputFoodTopLabel);
            this.Controls.Add(this.InputLeftLabel);
            this.Controls.Add(this.InputBottomLabel);
            this.Controls.Add(this.InputRightLabel);
            this.Controls.Add(this.InputTopLabel);
            this.Controls.Add(this.BoardsListBox);
            this.Controls.Add(this.MaxScoreLabel);
            this.Controls.Add(this.GenerationLabel);
            this.Controls.Add(this.GraphicArea);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Name = "MainWindow";
            this.Text = "NeuroSnake";
            ((System.ComponentModel.ISupportInitialize)(this.GraphicArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.PictureBox GraphicArea;
        private System.Windows.Forms.Label GenerationLabel;
        private System.Windows.Forms.Label MaxScoreLabel;
        private System.Windows.Forms.ListBox BoardsListBox;
        private System.Windows.Forms.Label InputTopLabel;
        private System.Windows.Forms.Label InputRightLabel;
        private System.Windows.Forms.Label InputBottomLabel;
        private System.Windows.Forms.Label InputLeftLabel;
        private System.Windows.Forms.Label InputFoodTopLabel;
        private System.Windows.Forms.Label InputFoodRightLabel;
        private System.Windows.Forms.Label OutputTopLabel;
        private System.Windows.Forms.Label OutputRightLabel;
        private System.Windows.Forms.Label OutputBottomLabel;
        private System.Windows.Forms.Label OutputLeftLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label InputFoodBottomLabel;
        private System.Windows.Forms.Label InputFoodLeftLabel;
        private System.Windows.Forms.Label AvgScoreLabel;
    }
}

