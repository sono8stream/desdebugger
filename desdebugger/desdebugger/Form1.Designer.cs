namespace desdebugger
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonStep = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBp = new System.Windows.Forms.TextBox();
            this.buttonInstrBp = new System.Windows.Forms.Button();
            this.textBoxGoto = new System.Windows.Forms.TextBox();
            this.buttonGoto = new System.Windows.Forms.Button();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonLaunch = new System.Windows.Forms.Button();
            this.radioButtonARM = new System.Windows.Forms.RadioButton();
            this.radioButtonThumb = new System.Windows.Forms.RadioButton();
            this.buttonStepOver = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listViewReg = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.listBoxDisasm = new System.Windows.Forms.ListBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.buttonWriteBp = new System.Windows.Forms.Button();
            this.buttonReadBp = new System.Windows.Forms.Button();
            this.listBoxBp = new System.Windows.Forms.ListBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonContinue
            // 
            this.buttonContinue.Location = new System.Drawing.Point(14, 54);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(111, 33);
            this.buttonContinue.TabIndex = 0;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // buttonStep
            // 
            this.buttonStep.Location = new System.Drawing.Point(131, 54);
            this.buttonStep.Name = "buttonStep";
            this.buttonStep.Size = new System.Drawing.Size(111, 33);
            this.buttonStep.TabIndex = 1;
            this.buttonStep.Text = "Step Into";
            this.buttonStep.UseVisualStyleBackColor = true;
            this.buttonStep.Click += new System.EventHandler(this.buttonStep_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Break Point";
            // 
            // textBoxBp
            // 
            this.textBoxBp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxBp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxBp.Location = new System.Drawing.Point(99, 104);
            this.textBoxBp.Name = "textBoxBp";
            this.textBoxBp.Size = new System.Drawing.Size(127, 22);
            this.textBoxBp.TabIndex = 3;
            // 
            // buttonInstrBp
            // 
            this.buttonInstrBp.Location = new System.Drawing.Point(232, 104);
            this.buttonInstrBp.Name = "buttonInstrBp";
            this.buttonInstrBp.Size = new System.Drawing.Size(90, 23);
            this.buttonInstrBp.TabIndex = 5;
            this.buttonInstrBp.Text = "Set Instr";
            this.buttonInstrBp.UseVisualStyleBackColor = true;
            this.buttonInstrBp.Click += new System.EventHandler(this.buttonInstrBp_click);
            // 
            // textBoxGoto
            // 
            this.textBoxGoto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxGoto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxGoto.Location = new System.Drawing.Point(554, 104);
            this.textBoxGoto.Name = "textBoxGoto";
            this.textBoxGoto.Size = new System.Drawing.Size(127, 22);
            this.textBoxGoto.TabIndex = 7;
            // 
            // buttonGoto
            // 
            this.buttonGoto.Location = new System.Drawing.Point(687, 104);
            this.buttonGoto.Name = "buttonGoto";
            this.buttonGoto.Size = new System.Drawing.Size(63, 23);
            this.buttonGoto.TabIndex = 8;
            this.buttonGoto.Text = "Goto";
            this.buttonGoto.UseVisualStyleBackColor = true;
            this.buttonGoto.Click += new System.EventHandler(this.buttonGoto_Click);
            // 
            // textBoxPort
            // 
            this.textBoxPort.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBoxPort.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxPort.Location = new System.Drawing.Point(53, 29);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(100, 22);
            this.textBoxPort.TabIndex = 13;
            this.textBoxPort.Text = "80";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Port";
            // 
            // buttonLaunch
            // 
            this.buttonLaunch.Location = new System.Drawing.Point(160, 29);
            this.buttonLaunch.Name = "buttonLaunch";
            this.buttonLaunch.Size = new System.Drawing.Size(148, 23);
            this.buttonLaunch.TabIndex = 15;
            this.buttonLaunch.Text = "Launch DeSmuME";
            this.buttonLaunch.UseVisualStyleBackColor = true;
            this.buttonLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);
            // 
            // radioButtonARM
            // 
            this.radioButtonARM.AutoSize = true;
            this.radioButtonARM.Checked = true;
            this.radioButtonARM.Location = new System.Drawing.Point(765, 107);
            this.radioButtonARM.Name = "radioButtonARM";
            this.radioButtonARM.Size = new System.Drawing.Size(57, 19);
            this.radioButtonARM.TabIndex = 17;
            this.radioButtonARM.TabStop = true;
            this.radioButtonARM.Text = "ARM";
            this.radioButtonARM.UseVisualStyleBackColor = true;
            this.radioButtonARM.CheckedChanged += new System.EventHandler(this.radioButtonARM_CheckedChanged);
            // 
            // radioButtonThumb
            // 
            this.radioButtonThumb.AutoSize = true;
            this.radioButtonThumb.Location = new System.Drawing.Point(828, 108);
            this.radioButtonThumb.Name = "radioButtonThumb";
            this.radioButtonThumb.Size = new System.Drawing.Size(71, 19);
            this.radioButtonThumb.TabIndex = 18;
            this.radioButtonThumb.Text = "Thumb";
            this.radioButtonThumb.UseVisualStyleBackColor = true;
            this.radioButtonThumb.CheckedChanged += new System.EventHandler(this.radioButtonThumb_CheckedChanged);
            // 
            // buttonStepOver
            // 
            this.buttonStepOver.Location = new System.Drawing.Point(248, 54);
            this.buttonStepOver.Name = "buttonStepOver";
            this.buttonStepOver.Size = new System.Drawing.Size(111, 33);
            this.buttonStepOver.TabIndex = 19;
            this.buttonStepOver.Text = "Step Over";
            this.buttonStepOver.UseVisualStyleBackColor = true;
            this.buttonStepOver.Click += new System.EventHandler(this.buttonStepOver_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(940, 106);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(148, 23);
            this.buttonRemove.TabIndex = 21;
            this.buttonRemove.Text = "Remove selected bp";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.listViewReg, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.vScrollBar1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxDisasm, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 133);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 449F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(810, 449);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // listViewReg
            // 
            this.listViewReg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewReg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1});
            this.listViewReg.HideSelection = false;
            this.listViewReg.Location = new System.Drawing.Point(576, 3);
            this.listViewReg.Name = "listViewReg";
            this.listViewReg.Size = new System.Drawing.Size(231, 443);
            this.listViewReg.TabIndex = 22;
            this.listViewReg.UseCompatibleStateImageBehavior = false;
            this.listViewReg.View = System.Windows.Forms.View.Details;
            this.listViewReg.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewReg_MouseDoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 1;
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 163;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 0;
            this.columnHeader1.Text = "No.";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar1.Location = new System.Drawing.Point(553, 0);
            this.vScrollBar1.Maximum = 1000;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(20, 449);
            this.vScrollBar1.TabIndex = 21;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // listBoxDisasm
            // 
            this.listBoxDisasm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxDisasm.FormattingEnabled = true;
            this.listBoxDisasm.ItemHeight = 15;
            this.listBoxDisasm.Location = new System.Drawing.Point(3, 3);
            this.listBoxDisasm.Name = "listBoxDisasm";
            this.listBoxDisasm.Size = new System.Drawing.Size(547, 439);
            this.listBoxDisasm.TabIndex = 7;
            this.listBoxDisasm.DoubleClick += new System.EventHandler(this.listBoxDisasm_DoubleClick);
            this.listBoxDisasm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxDisasm_KeyDown);
            this.listBoxDisasm.Resize += new System.EventHandler(this.listBoxDisasm_Resize);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 588);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(86, 15);
            this.statusLabel.TabIndex = 23;
            this.statusLabel.Text = "Status Label";
            // 
            // buttonWriteBp
            // 
            this.buttonWriteBp.Location = new System.Drawing.Point(328, 103);
            this.buttonWriteBp.Name = "buttonWriteBp";
            this.buttonWriteBp.Size = new System.Drawing.Size(90, 23);
            this.buttonWriteBp.TabIndex = 24;
            this.buttonWriteBp.Text = "Set Write";
            this.buttonWriteBp.UseVisualStyleBackColor = true;
            this.buttonWriteBp.Click += new System.EventHandler(this.buttonWriteBp_Click);
            // 
            // buttonReadBp
            // 
            this.buttonReadBp.Location = new System.Drawing.Point(424, 103);
            this.buttonReadBp.Name = "buttonReadBp";
            this.buttonReadBp.Size = new System.Drawing.Size(90, 23);
            this.buttonReadBp.TabIndex = 25;
            this.buttonReadBp.Text = "Set Read";
            this.buttonReadBp.UseVisualStyleBackColor = true;
            this.buttonReadBp.Click += new System.EventHandler(this.buttonReadBp_Click);
            // 
            // listBoxBp
            // 
            this.listBoxBp.FormattingEnabled = true;
            this.listBoxBp.ItemHeight = 15;
            this.listBoxBp.Location = new System.Drawing.Point(828, 133);
            this.listBoxBp.Name = "listBoxBp";
            this.listBoxBp.Size = new System.Drawing.Size(260, 439);
            this.listBoxBp.TabIndex = 26;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(365, 54);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(111, 33);
            this.buttonStop.TabIndex = 27;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 612);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.listBoxBp);
            this.Controls.Add(this.buttonReadBp);
            this.Controls.Add(this.buttonWriteBp);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonStepOver);
            this.Controls.Add(this.radioButtonThumb);
            this.Controls.Add(this.radioButtonARM);
            this.Controls.Add(this.buttonLaunch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.buttonGoto);
            this.Controls.Add(this.textBoxGoto);
            this.Controls.Add(this.buttonInstrBp);
            this.Controls.Add(this.textBoxBp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStep);
            this.Controls.Add(this.buttonContinue);
            this.Name = "Form1";
            this.Text = "desdebugger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonStep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBp;
        private System.Windows.Forms.Button buttonInstrBp;
        private System.Windows.Forms.TextBox textBoxGoto;
        private System.Windows.Forms.Button buttonGoto;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonLaunch;
        private System.Windows.Forms.RadioButton radioButtonARM;
        private System.Windows.Forms.RadioButton radioButtonThumb;
        private System.Windows.Forms.Button buttonStepOver;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listViewReg;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.ListBox listBoxDisasm;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button buttonWriteBp;
        private System.Windows.Forms.Button buttonReadBp;
        private System.Windows.Forms.ListBox listBoxBp;
        private System.Windows.Forms.Button buttonStop;
    }
}

