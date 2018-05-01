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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BoardsListBox = new System.Windows.Forms.ListBox();
            this.InputTopLabel = new System.Windows.Forms.Label();
            this.InputRightLabel = new System.Windows.Forms.Label();
            this.InputBottomLabel = new System.Windows.Forms.Label();
            this.InputLeftLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.OutputTopLabel = new System.Windows.Forms.Label();
            this.OutputRightLabel = new System.Windows.Forms.Label();
            this.OutputBottomLabel = new System.Windows.Forms.Label();
            this.OutputLeftLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(518, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Generation: 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(615, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Max score: 0";
            // 
            // BoardsListBox
            // 
            this.BoardsListBox.FormattingEnabled = true;
            this.BoardsListBox.Location = new System.Drawing.Point(521, 152);
            this.BoardsListBox.Name = "BoardsListBox";
            this.BoardsListBox.Size = new System.Drawing.Size(162, 290);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(518, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "--reserved--";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(518, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "--reserved--";
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
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 457);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.OutputLeftLabel);
            this.Controls.Add(this.OutputBottomLabel);
            this.Controls.Add(this.OutputRightLabel);
            this.Controls.Add(this.OutputTopLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.InputLeftLabel);
            this.Controls.Add(this.InputBottomLabel);
            this.Controls.Add(this.InputRightLabel);
            this.Controls.Add(this.InputTopLabel);
            this.Controls.Add(this.BoardsListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox BoardsListBox;
        private System.Windows.Forms.Label InputTopLabel;
        private System.Windows.Forms.Label InputRightLabel;
        private System.Windows.Forms.Label InputBottomLabel;
        private System.Windows.Forms.Label InputLeftLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label OutputTopLabel;
        private System.Windows.Forms.Label OutputRightLabel;
        private System.Windows.Forms.Label OutputBottomLabel;
        private System.Windows.Forms.Label OutputLeftLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}

