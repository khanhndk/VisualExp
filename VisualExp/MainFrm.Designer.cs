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
            ((System.ComponentModel.ISupportInitialize)(this.picData)).BeginInit();
            this.SuspendLayout();
            // 
            // picData
            // 
            this.picData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picData.Location = new System.Drawing.Point(12, 91);
            this.picData.Name = "picData";
            this.picData.Size = new System.Drawing.Size(500, 500);
            this.picData.TabIndex = 0;
            this.picData.TabStop = false;
            this.picData.Paint += new System.Windows.Forms.PaintEventHandler(this.picData_Paint);
            this.picData.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picData_MouseUp);
            // 
            // btnGenerateTest
            // 
            this.btnGenerateTest.Location = new System.Drawing.Point(534, 510);
            this.btnGenerateTest.Name = "btnGenerateTest";
            this.btnGenerateTest.Size = new System.Drawing.Size(95, 23);
            this.btnGenerateTest.TabIndex = 1;
            this.btnGenerateTest.Text = "Generate Test";
            this.btnGenerateTest.UseVisualStyleBackColor = true;
            this.btnGenerateTest.Click += new System.EventHandler(this.btnGenerateTest_Click);
            // 
            // btnLoadPredict
            // 
            this.btnLoadPredict.Location = new System.Drawing.Point(534, 568);
            this.btnLoadPredict.Name = "btnLoadPredict";
            this.btnLoadPredict.Size = new System.Drawing.Size(95, 23);
            this.btnLoadPredict.TabIndex = 2;
            this.btnLoadPredict.Text = "Load Predict";
            this.btnLoadPredict.UseVisualStyleBackColor = true;
            this.btnLoadPredict.Click += new System.EventHandler(this.btnLoadPredict_Click);
            // 
            // btnLoadTest
            // 
            this.btnLoadTest.Location = new System.Drawing.Point(534, 539);
            this.btnLoadTest.Name = "btnLoadTest";
            this.btnLoadTest.Size = new System.Drawing.Size(95, 23);
            this.btnLoadTest.TabIndex = 3;
            this.btnLoadTest.Text = "Load Test";
            this.btnLoadTest.UseVisualStyleBackColor = true;
            this.btnLoadTest.Click += new System.EventHandler(this.btnLoadTest_Click);
            // 
            // cbColor
            // 
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Items.AddRange(new object[] {
            "Unknown",
            "Red",
            "Green",
            "Blue"});
            this.cbColor.Location = new System.Drawing.Point(534, 122);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(95, 21);
            this.cbColor.TabIndex = 4;
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Single",
            "Sparse",
            "Dense"});
            this.cbType.Location = new System.Drawing.Point(534, 149);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(95, 21);
            this.cbType.TabIndex = 5;
            // 
            // txtCommand
            // 
            this.txtCommand.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommand.Location = new System.Drawing.Point(12, 12);
            this.txtCommand.Multiline = true;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(617, 73);
            this.txtCommand.TabIndex = 6;
            this.txtCommand.Text = "-s 26 -t 2 -g 20 -savemodel 0 -c 30 -lam 1 -mu 50 -e 0.001 -floss 0 -ploss 2 -T 2" +
    "000 -predict 1 train.scale.txt train.scale.txt a9a_1.csv";
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(534, 209);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(95, 23);
            this.btnSolve.TabIndex = 7;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // chkMulti
            // 
            this.chkMulti.AutoSize = true;
            this.chkMulti.Location = new System.Drawing.Point(534, 176);
            this.chkMulti.Name = "chkMulti";
            this.chkMulti.Size = new System.Drawing.Size(76, 17);
            this.chkMulti.TabIndex = 8;
            this.chkMulti.Text = "Multi Class";
            this.chkMulti.UseVisualStyleBackColor = true;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(534, 93);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(95, 23);
            this.btnLoadData.TabIndex = 9;
            this.btnLoadData.Text = "Load data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 601);
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
            this.Text = "SVM4C-GUI";
            ((System.ComponentModel.ISupportInitialize)(this.picData)).EndInit();
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
    }
}

