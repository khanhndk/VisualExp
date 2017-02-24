namespace VisualExp
{
    partial class MainFrm
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
            this.picData = new System.Windows.Forms.PictureBox();
            this.btnGenerateTest = new System.Windows.Forms.Button();
            this.btnLoadPredict = new System.Windows.Forms.Button();
            this.btnLoadTest = new System.Windows.Forms.Button();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.btnSolve = new System.Windows.Forms.Button();
            this.chkMulti = new System.Windows.Forms.CheckBox();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.chkRegression = new System.Windows.Forms.CheckBox();
            this.nmZoom = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nmHideLabel = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmHideLabel)).BeginInit();
            this.SuspendLayout();
            // 
            // picData
            // 
            this.picData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picData.Location = new System.Drawing.Point(12, 100);
            this.picData.Name = "picData";
            this.picData.Size = new System.Drawing.Size(500, 500);
            this.picData.TabIndex = 0;
            this.picData.TabStop = false;
            this.picData.Paint += new System.Windows.Forms.PaintEventHandler(this.picData_Paint);
            this.picData.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picData_MouseUp);
            // 
            // btnGenerateTest
            // 
            this.btnGenerateTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerateTest.Location = new System.Drawing.Point(533, 519);
            this.btnGenerateTest.Name = "btnGenerateTest";
            this.btnGenerateTest.Size = new System.Drawing.Size(95, 23);
            this.btnGenerateTest.TabIndex = 1;
            this.btnGenerateTest.Text = "Generate Test";
            this.btnGenerateTest.UseVisualStyleBackColor = true;
            this.btnGenerateTest.Click += new System.EventHandler(this.btnGenerateTest_Click);
            // 
            // btnLoadPredict
            // 
            this.btnLoadPredict.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadPredict.Location = new System.Drawing.Point(533, 577);
            this.btnLoadPredict.Name = "btnLoadPredict";
            this.btnLoadPredict.Size = new System.Drawing.Size(95, 23);
            this.btnLoadPredict.TabIndex = 2;
            this.btnLoadPredict.Text = "Load Predict";
            this.btnLoadPredict.UseVisualStyleBackColor = true;
            this.btnLoadPredict.Click += new System.EventHandler(this.btnLoadPredict_Click);
            // 
            // btnLoadTest
            // 
            this.btnLoadTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadTest.Location = new System.Drawing.Point(533, 548);
            this.btnLoadTest.Name = "btnLoadTest";
            this.btnLoadTest.Size = new System.Drawing.Size(95, 23);
            this.btnLoadTest.TabIndex = 3;
            this.btnLoadTest.Text = "Load Test";
            this.btnLoadTest.UseVisualStyleBackColor = true;
            this.btnLoadTest.Click += new System.EventHandler(this.btnLoadTest_Click);
            // 
            // cbColor
            // 
            this.cbColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Items.AddRange(new object[] {
            "Unknown",
            "Red",
            "Green",
            "Blue",
            "Violet",
            "Teal"});
            this.cbColor.Location = new System.Drawing.Point(534, 134);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(95, 21);
            this.cbColor.TabIndex = 4;
            // 
            // cbType
            // 
            this.cbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Single",
            "Sparse",
            "Dense"});
            this.cbType.Location = new System.Drawing.Point(534, 161);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(95, 21);
            this.cbType.TabIndex = 5;
            // 
            // txtCommand
            // 
            this.txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCommand.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommand.Location = new System.Drawing.Point(12, 12);
            this.txtCommand.Multiline = true;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(617, 82);
            this.txtCommand.TabIndex = 6;
            this.txtCommand.Text = "-s 26 -t 2 -g 20 -savemodel 0 -c 30 -lam 1 -mu 50 -e 0.001 -floss 0 -ploss 2 -T 2" +
    "000 -predict 1 train.scale.txt train.scale.txt a9a_1.csv";
            // 
            // btnSolve
            // 
            this.btnSolve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSolve.Location = new System.Drawing.Point(534, 243);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(95, 23);
            this.btnSolve.TabIndex = 7;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // chkMulti
            // 
            this.chkMulti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkMulti.AutoSize = true;
            this.chkMulti.Checked = true;
            this.chkMulti.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMulti.Location = new System.Drawing.Point(534, 188);
            this.chkMulti.Name = "chkMulti";
            this.chkMulti.Size = new System.Drawing.Size(76, 17);
            this.chkMulti.TabIndex = 8;
            this.chkMulti.Text = "Multi Class";
            this.chkMulti.UseVisualStyleBackColor = true;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadData.Location = new System.Drawing.Point(534, 105);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(95, 23);
            this.btnLoadData.TabIndex = 9;
            this.btnLoadData.Text = "Load data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // chkRegression
            // 
            this.chkRegression.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkRegression.AutoSize = true;
            this.chkRegression.Location = new System.Drawing.Point(534, 211);
            this.chkRegression.Name = "chkRegression";
            this.chkRegression.Size = new System.Drawing.Size(79, 17);
            this.chkRegression.TabIndex = 10;
            this.chkRegression.Text = "Regression";
            this.chkRegression.UseVisualStyleBackColor = true;
            // 
            // nmZoom
            // 
            this.nmZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nmZoom.Enabled = false;
            this.nmZoom.Location = new System.Drawing.Point(579, 447);
            this.nmZoom.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmZoom.Name = "nmZoom";
            this.nmZoom.Size = new System.Drawing.Size(49, 20);
            this.nmZoom.TabIndex = 11;
            this.nmZoom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmZoom.ValueChanged += new System.EventHandler(this.nmZoom_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(536, 450);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Zoom:";
            // 
            // nmHideLabel
            // 
            this.nmHideLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nmHideLabel.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmHideLabel.Location = new System.Drawing.Point(533, 339);
            this.nmHideLabel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmHideLabel.Name = "nmHideLabel";
            this.nmHideLabel.Size = new System.Drawing.Size(95, 20);
            this.nmHideLabel.TabIndex = 13;
            this.nmHideLabel.ValueChanged += new System.EventHandler(this.nmHideLabel_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(551, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Hide Label";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 612);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nmHideLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nmZoom);
            this.Controls.Add(this.chkRegression);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.chkMulti);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.cbColor);
            this.Controls.Add(this.btnLoadTest);
            this.Controls.Add(this.btnLoadPredict);
            this.Controls.Add(this.btnGenerateTest);
            this.Controls.Add(this.picData);
            this.Name = "MainFrm";
            this.Text = "VisualExp";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmHideLabel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picData;
        private System.Windows.Forms.Button btnGenerateTest;
        private System.Windows.Forms.Button btnLoadPredict;
        private System.Windows.Forms.Button btnLoadTest;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.CheckBox chkMulti;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.CheckBox chkRegression;
        private System.Windows.Forms.NumericUpDown nmZoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nmHideLabel;
        private System.Windows.Forms.Label label2;
    }
}

