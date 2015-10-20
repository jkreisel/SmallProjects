namespace TicTacToeGUI
{
    partial class ticTacToeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ticTacToeForm));
            this.agent1Btn = new System.Windows.Forms.Button();
            this.agent2Btn = new System.Windows.Forms.Button();
            this.agent1Lbl = new System.Windows.Forms.Label();
            this.agent2Lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.xWinsBox = new System.Windows.Forms.TextBox();
            this.oWinsBox = new System.Windows.Forms.TextBox();
            this.drawsBox = new System.Windows.Forms.TextBox();
            this.simCountInput = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.loadGraphCheckBox = new System.Windows.Forms.CheckBox();
            this.simulateBtn = new System.Windows.Forms.Button();
            this.backgroundSimulator = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.simCountInput)).BeginInit();
            this.SuspendLayout();
            // 
            // agent1Btn
            // 
            this.agent1Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agent1Btn.Location = new System.Drawing.Point(20, 40);
            this.agent1Btn.Name = "agent1Btn";
            this.agent1Btn.Size = new System.Drawing.Size(90, 40);
            this.agent1Btn.TabIndex = 0;
            this.agent1Btn.Text = "Random";
            this.agent1Btn.UseVisualStyleBackColor = true;
            this.agent1Btn.Click += new System.EventHandler(this.agent1Btn_Click);
            // 
            // agent2Btn
            // 
            this.agent2Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agent2Btn.Location = new System.Drawing.Point(20, 120);
            this.agent2Btn.Name = "agent2Btn";
            this.agent2Btn.Size = new System.Drawing.Size(90, 40);
            this.agent2Btn.TabIndex = 1;
            this.agent2Btn.Text = "Random";
            this.agent2Btn.UseVisualStyleBackColor = true;
            this.agent2Btn.Click += new System.EventHandler(this.agent2Btn_Click);
            // 
            // agent1Lbl
            // 
            this.agent1Lbl.AutoSize = true;
            this.agent1Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agent1Lbl.Location = new System.Drawing.Point(20, 20);
            this.agent1Lbl.Name = "agent1Lbl";
            this.agent1Lbl.Size = new System.Drawing.Size(67, 20);
            this.agent1Lbl.TabIndex = 2;
            this.agent1Lbl.Text = "X Player";
            // 
            // agent2Lbl
            // 
            this.agent2Lbl.AutoSize = true;
            this.agent2Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agent2Lbl.Location = new System.Drawing.Point(20, 100);
            this.agent2Lbl.Name = "agent2Lbl";
            this.agent2Lbl.Size = new System.Drawing.Size(68, 20);
            this.agent2Lbl.TabIndex = 3;
            this.agent2Lbl.Text = "O Player";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(300, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "O Wins";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(300, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "X Wins";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(300, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Draws";
            // 
            // xWinsBox
            // 
            this.xWinsBox.Enabled = false;
            this.xWinsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xWinsBox.Location = new System.Drawing.Point(300, 40);
            this.xWinsBox.Name = "xWinsBox";
            this.xWinsBox.ReadOnly = true;
            this.xWinsBox.Size = new System.Drawing.Size(100, 26);
            this.xWinsBox.TabIndex = 9;
            // 
            // oWinsBox
            // 
            this.oWinsBox.Enabled = false;
            this.oWinsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oWinsBox.Location = new System.Drawing.Point(300, 90);
            this.oWinsBox.Name = "oWinsBox";
            this.oWinsBox.ReadOnly = true;
            this.oWinsBox.Size = new System.Drawing.Size(100, 26);
            this.oWinsBox.TabIndex = 10;
            // 
            // drawsBox
            // 
            this.drawsBox.Enabled = false;
            this.drawsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawsBox.Location = new System.Drawing.Point(300, 140);
            this.drawsBox.Name = "drawsBox";
            this.drawsBox.ReadOnly = true;
            this.drawsBox.Size = new System.Drawing.Size(100, 26);
            this.drawsBox.TabIndex = 11;
            // 
            // simCountInput
            // 
            this.simCountInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simCountInput.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.simCountInput.Location = new System.Drawing.Point(160, 80);
            this.simCountInput.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.simCountInput.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.simCountInput.Name = "simCountInput";
            this.simCountInput.Size = new System.Drawing.Size(90, 26);
            this.simCountInput.TabIndex = 12;
            this.simCountInput.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(160, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Games:";
            // 
            // loadGraphCheckBox
            // 
            this.loadGraphCheckBox.AutoSize = true;
            this.loadGraphCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.loadGraphCheckBox.Enabled = false;
            this.loadGraphCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadGraphCheckBox.Location = new System.Drawing.Point(137, 120);
            this.loadGraphCheckBox.MaximumSize = new System.Drawing.Size(145, 150);
            this.loadGraphCheckBox.MinimumSize = new System.Drawing.Size(0, 50);
            this.loadGraphCheckBox.Name = "loadGraphCheckBox";
            this.loadGraphCheckBox.Size = new System.Drawing.Size(145, 50);
            this.loadGraphCheckBox.TabIndex = 14;
            this.loadGraphCheckBox.Text = "Persist Knowledgebase";
            this.loadGraphCheckBox.UseVisualStyleBackColor = true;
            // 
            // simulateBtn
            // 
            this.simulateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simulateBtn.Location = new System.Drawing.Point(150, 190);
            this.simulateBtn.Name = "simulateBtn";
            this.simulateBtn.Size = new System.Drawing.Size(100, 40);
            this.simulateBtn.TabIndex = 15;
            this.simulateBtn.Text = "Simulate";
            this.simulateBtn.UseVisualStyleBackColor = true;
            this.simulateBtn.Click += new System.EventHandler(this.simulateBtn_Click);
            // 
            // backgroundSimulator
            // 
            this.backgroundSimulator.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundSimulator_DoWork);
            this.backgroundSimulator.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundSimulator_RunWorkerCompleted);
            // 
            // ticTacToeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 250);
            this.Controls.Add(this.simulateBtn);
            this.Controls.Add(this.loadGraphCheckBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.simCountInput);
            this.Controls.Add(this.drawsBox);
            this.Controls.Add(this.oWinsBox);
            this.Controls.Add(this.xWinsBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.agent2Lbl);
            this.Controls.Add(this.agent1Lbl);
            this.Controls.Add(this.agent2Btn);
            this.Controls.Add(this.agent1Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ticTacToeForm";
            this.Text = "TicTacToe";
            ((System.ComponentModel.ISupportInitialize)(this.simCountInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button agent1Btn;
        private System.Windows.Forms.Button agent2Btn;
        private System.Windows.Forms.Label agent1Lbl;
        private System.Windows.Forms.Label agent2Lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox xWinsBox;
        private System.Windows.Forms.TextBox oWinsBox;
        private System.Windows.Forms.TextBox drawsBox;
        private System.Windows.Forms.NumericUpDown simCountInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox loadGraphCheckBox;
        private System.Windows.Forms.Button simulateBtn;
        private System.ComponentModel.BackgroundWorker backgroundSimulator;
    }
}

