namespace GoogleNotifier
{
    partial class FormGoogleNotifier
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
            this.comboBoxGoogleCastReceivers = new System.Windows.Forms.ComboBox();
            this.openFileDialogCredentials = new System.Windows.Forms.OpenFileDialog();
            this.textBoxJsonCredendials = new System.Windows.Forms.TextBox();
            this.buttonSelectJson = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelIPAddress = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.checkBoxRemoteEnabled = new System.Windows.Forms.CheckBox();
            this.checkBoxRequireAuthToken = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxAuthToken = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonToSpeech = new System.Windows.Forms.Button();
            this.textBoxToSpeech = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxVoiceLanguages = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelWebServerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerWebServerWatchdog = new System.Windows.Forms.Timer(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxVoice = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxGoogleCastReceivers
            // 
            this.comboBoxGoogleCastReceivers.FormattingEnabled = true;
            this.comboBoxGoogleCastReceivers.Location = new System.Drawing.Point(27, 239);
            this.comboBoxGoogleCastReceivers.Name = "comboBoxGoogleCastReceivers";
            this.comboBoxGoogleCastReceivers.Size = new System.Drawing.Size(536, 21);
            this.comboBoxGoogleCastReceivers.TabIndex = 0;
            // 
            // openFileDialogCredentials
            // 
            this.openFileDialogCredentials.DefaultExt = "JSON Files | *.JSON";
            this.openFileDialogCredentials.Title = "Google Credentials File";
            // 
            // textBoxJsonCredendials
            // 
            this.textBoxJsonCredendials.Location = new System.Drawing.Point(74, 188);
            this.textBoxJsonCredendials.Name = "textBoxJsonCredendials";
            this.textBoxJsonCredendials.Size = new System.Drawing.Size(408, 20);
            this.textBoxJsonCredendials.TabIndex = 1;
            // 
            // buttonSelectJson
            // 
            this.buttonSelectJson.Location = new System.Drawing.Point(488, 186);
            this.buttonSelectJson.Name = "buttonSelectJson";
            this.buttonSelectJson.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectJson.TabIndex = 2;
            this.buttonSelectJson.Text = "Select";
            this.buttonSelectJson.UseVisualStyleBackColor = true;
            this.buttonSelectJson.Click += new System.EventHandler(this.buttonSelectJson_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "File:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Default Cast Devices:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Internal Web Server";
            // 
            // labelIPAddress
            // 
            this.labelIPAddress.BackColor = System.Drawing.SystemColors.Window;
            this.labelIPAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelIPAddress.Location = new System.Drawing.Point(84, 288);
            this.labelIPAddress.Name = "labelIPAddress";
            this.labelIPAddress.Size = new System.Drawing.Size(114, 20);
            this.labelIPAddress.TabIndex = 7;
            this.labelIPAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "IP Address:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(220, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Port:";
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Location = new System.Drawing.Point(255, 288);
            this.numericUpDownPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(81, 20);
            this.numericUpDownPort.TabIndex = 11;
            this.numericUpDownPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBoxRemoteEnabled
            // 
            this.checkBoxRemoteEnabled.AutoSize = true;
            this.checkBoxRemoteEnabled.Location = new System.Drawing.Point(26, 317);
            this.checkBoxRemoteEnabled.Name = "checkBoxRemoteEnabled";
            this.checkBoxRemoteEnabled.Size = new System.Drawing.Size(192, 17);
            this.checkBoxRemoteEnabled.TabIndex = 12;
            this.checkBoxRemoteEnabled.Text = "Enable Remote Access Commands";
            this.checkBoxRemoteEnabled.UseVisualStyleBackColor = true;
            // 
            // checkBoxRequireAuthToken
            // 
            this.checkBoxRequireAuthToken.AutoSize = true;
            this.checkBoxRequireAuthToken.Location = new System.Drawing.Point(26, 340);
            this.checkBoxRequireAuthToken.Name = "checkBoxRequireAuthToken";
            this.checkBoxRequireAuthToken.Size = new System.Drawing.Size(122, 17);
            this.checkBoxRequireAuthToken.TabIndex = 13;
            this.checkBoxRequireAuthToken.Text = "Require Auth Token";
            this.checkBoxRequireAuthToken.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 366);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Token:";
            // 
            // textBoxAuthToken
            // 
            this.textBoxAuthToken.Location = new System.Drawing.Point(70, 363);
            this.textBoxAuthToken.Name = "textBoxAuthToken";
            this.textBoxAuthToken.Size = new System.Drawing.Size(486, 20);
            this.textBoxAuthToken.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Text:";
            // 
            // buttonToSpeech
            // 
            this.buttonToSpeech.Location = new System.Drawing.Point(488, 45);
            this.buttonToSpeech.Name = "buttonToSpeech";
            this.buttonToSpeech.Size = new System.Drawing.Size(75, 23);
            this.buttonToSpeech.TabIndex = 17;
            this.buttonToSpeech.Text = "To Speech";
            this.buttonToSpeech.UseVisualStyleBackColor = true;
            this.buttonToSpeech.Click += new System.EventHandler(this.buttonToSpeech_Click);
            // 
            // textBoxToSpeech
            // 
            this.textBoxToSpeech.Location = new System.Drawing.Point(56, 48);
            this.textBoxToSpeech.Name = "textBoxToSpeech";
            this.textBoxToSpeech.Size = new System.Drawing.Size(426, 20);
            this.textBoxToSpeech.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Google Cloud Credential JSON";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Text To Speech:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(23, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Default Voice:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Language:";
            // 
            // comboBoxVoiceLanguages
            // 
            this.comboBoxVoiceLanguages.FormattingEnabled = true;
            this.comboBoxVoiceLanguages.Location = new System.Drawing.Point(95, 106);
            this.comboBoxVoiceLanguages.Name = "comboBoxVoiceLanguages";
            this.comboBoxVoiceLanguages.Size = new System.Drawing.Size(208, 21);
            this.comboBoxVoiceLanguages.TabIndex = 22;
            this.comboBoxVoiceLanguages.SelectedIndexChanged += new System.EventHandler(this.comboBoxVoiceLanguages_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(311, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Gender:";
            // 
            // comboBoxGender
            // 
            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Location = new System.Drawing.Point(360, 106);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(106, 21);
            this.comboBoxGender.TabIndex = 24;
            this.comboBoxGender.SelectedIndexChanged += new System.EventHandler(this.comboBoxGender_SelectedIndexChanged);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(343, 288);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 25;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelWebServerStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 398);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(588, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 26;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(104, 17);
            this.toolStripStatusLabel1.Text = "Web Server Status:";
            // 
            // toolStripStatusLabelWebServerStatus
            // 
            this.toolStripStatusLabelWebServerStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabelWebServerStatus.ForeColor = System.Drawing.Color.Maroon;
            this.toolStripStatusLabelWebServerStatus.Name = "toolStripStatusLabelWebServerStatus";
            this.toolStripStatusLabelWebServerStatus.Size = new System.Drawing.Size(81, 17);
            this.toolStripStatusLabelWebServerStatus.Text = "Not Listening";
            // 
            // timerWebServerWatchdog
            // 
            this.timerWebServerWatchdog.Interval = 1000;
            this.timerWebServerWatchdog.Tick += new System.EventHandler(this.timerWebServerWatchdog_Tick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(47, 137);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Voice:";
            // 
            // comboBoxVoice
            // 
            this.comboBoxVoice.FormattingEnabled = true;
            this.comboBoxVoice.Location = new System.Drawing.Point(95, 134);
            this.comboBoxVoice.Name = "comboBoxVoice";
            this.comboBoxVoice.Size = new System.Drawing.Size(371, 21);
            this.comboBoxVoice.TabIndex = 28;
            // 
            // FormGoogleNotifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 420);
            this.Controls.Add(this.comboBoxVoice);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.comboBoxGender);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBoxVoiceLanguages);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonToSpeech);
            this.Controls.Add(this.textBoxToSpeech);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxAuthToken);
            this.Controls.Add(this.checkBoxRequireAuthToken);
            this.Controls.Add(this.checkBoxRemoteEnabled);
            this.Controls.Add(this.numericUpDownPort);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelIPAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSelectJson);
            this.Controls.Add(this.textBoxJsonCredendials);
            this.Controls.Add(this.comboBoxGoogleCastReceivers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGoogleNotifier";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Google Notifier";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGoogleNotifier_FormClosing);
            this.Load += new System.EventHandler(this.FormGoogleNotifier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxGoogleCastReceivers;
        private System.Windows.Forms.OpenFileDialog openFileDialogCredentials;
        private System.Windows.Forms.TextBox textBoxJsonCredendials;
        private System.Windows.Forms.Button buttonSelectJson;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelIPAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownPort;
        private System.Windows.Forms.CheckBox checkBoxRemoteEnabled;
        private System.Windows.Forms.CheckBox checkBoxRequireAuthToken;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxAuthToken;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonToSpeech;
        private System.Windows.Forms.TextBox textBoxToSpeech;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxVoiceLanguages;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxGender;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelWebServerStatus;
        private System.Windows.Forms.Timer timerWebServerWatchdog;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBoxVoice;
    }
}

