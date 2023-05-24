
namespace VLC_Client_Form
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Play = new System.Windows.Forms.Button();
            this.Btn_Pause = new System.Windows.Forms.Button();
            this.Btn_Stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Tb_RemoteIP = new System.Windows.Forms.TextBox();
            this.Txt_Port = new System.Windows.Forms.Label();
            this.Tb_RemotePort = new System.Windows.Forms.TextBox();
            this.Btn_Add = new System.Windows.Forms.Button();
            this.Txt_CurrentTime = new System.Windows.Forms.Label();
            this.CurrentTimeSlider = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_TotalTime = new System.Windows.Forms.Label();
            this.Btn_Backward = new System.Windows.Forms.Button();
            this.Btn_Forward = new System.Windows.Forms.Button();
            this.VolumeSlider = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Txt_CurrentVolume = new System.Windows.Forms.Label();
            this.Cb_Loop = new System.Windows.Forms.CheckBox();
            this.Btn_Load = new System.Windows.Forms.Button();
            this.Tb_VideoSettingFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MessageBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentTimeSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Play
            // 
            this.Btn_Play.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_Play.Location = new System.Drawing.Point(12, 12);
            this.Btn_Play.Name = "Btn_Play";
            this.Btn_Play.Size = new System.Drawing.Size(90, 90);
            this.Btn_Play.TabIndex = 0;
            this.Btn_Play.Text = "Play";
            this.Btn_Play.UseVisualStyleBackColor = true;
            this.Btn_Play.Click += new System.EventHandler(this.Btn_Play_Click);
            // 
            // Btn_Pause
            // 
            this.Btn_Pause.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_Pause.Location = new System.Drawing.Point(108, 12);
            this.Btn_Pause.Name = "Btn_Pause";
            this.Btn_Pause.Size = new System.Drawing.Size(90, 90);
            this.Btn_Pause.TabIndex = 1;
            this.Btn_Pause.Text = "Pause";
            this.Btn_Pause.UseVisualStyleBackColor = true;
            this.Btn_Pause.Click += new System.EventHandler(this.Btn_Pause_Click);
            // 
            // Btn_Stop
            // 
            this.Btn_Stop.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_Stop.Location = new System.Drawing.Point(204, 12);
            this.Btn_Stop.Name = "Btn_Stop";
            this.Btn_Stop.Size = new System.Drawing.Size(90, 90);
            this.Btn_Stop.TabIndex = 2;
            this.Btn_Stop.Text = "Stop";
            this.Btn_Stop.UseVisualStyleBackColor = true;
            this.Btn_Stop.Click += new System.EventHandler(this.Btn_Stop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Remote IP";
            // 
            // Tb_RemoteIP
            // 
            this.Tb_RemoteIP.Location = new System.Drawing.Point(108, 258);
            this.Tb_RemoteIP.Name = "Tb_RemoteIP";
            this.Tb_RemoteIP.Size = new System.Drawing.Size(186, 22);
            this.Tb_RemoteIP.TabIndex = 6;
            this.Tb_RemoteIP.Text = "192.168.2.100";
            // 
            // Txt_Port
            // 
            this.Txt_Port.AutoSize = true;
            this.Txt_Port.Location = new System.Drawing.Point(10, 289);
            this.Txt_Port.Name = "Txt_Port";
            this.Txt_Port.Size = new System.Drawing.Size(63, 12);
            this.Txt_Port.TabIndex = 7;
            this.Txt_Port.Text = "Remote Port";
            // 
            // Tb_RemotePort
            // 
            this.Tb_RemotePort.Location = new System.Drawing.Point(108, 286);
            this.Tb_RemotePort.Name = "Tb_RemotePort";
            this.Tb_RemotePort.Size = new System.Drawing.Size(186, 22);
            this.Tb_RemotePort.TabIndex = 8;
            this.Tb_RemotePort.Text = "20000";
            // 
            // Btn_Add
            // 
            this.Btn_Add.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_Add.Location = new System.Drawing.Point(12, 108);
            this.Btn_Add.Name = "Btn_Add";
            this.Btn_Add.Size = new System.Drawing.Size(90, 90);
            this.Btn_Add.TabIndex = 13;
            this.Btn_Add.Text = "Add";
            this.Btn_Add.UseVisualStyleBackColor = true;
            this.Btn_Add.Click += new System.EventHandler(this.Btn_Add_Click);
            // 
            // Txt_CurrentTime
            // 
            this.Txt_CurrentTime.AutoSize = true;
            this.Txt_CurrentTime.Location = new System.Drawing.Point(650, 12);
            this.Txt_CurrentTime.Name = "Txt_CurrentTime";
            this.Txt_CurrentTime.Size = new System.Drawing.Size(33, 12);
            this.Txt_CurrentTime.TabIndex = 14;
            this.Txt_CurrentTime.Text = "label4";
            // 
            // CurrentTimeSlider
            // 
            this.CurrentTimeSlider.Location = new System.Drawing.Point(300, 12);
            this.CurrentTimeSlider.Name = "CurrentTimeSlider";
            this.CurrentTimeSlider.Size = new System.Drawing.Size(344, 45);
            this.CurrentTimeSlider.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "0";
            // 
            // Txt_TotalTime
            // 
            this.Txt_TotalTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_TotalTime.AutoSize = true;
            this.Txt_TotalTime.Location = new System.Drawing.Point(633, 45);
            this.Txt_TotalTime.Name = "Txt_TotalTime";
            this.Txt_TotalTime.Size = new System.Drawing.Size(11, 12);
            this.Txt_TotalTime.TabIndex = 17;
            this.Txt_TotalTime.Text = "0";
            this.Txt_TotalTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Btn_Backward
            // 
            this.Btn_Backward.Location = new System.Drawing.Point(302, 63);
            this.Btn_Backward.Name = "Btn_Backward";
            this.Btn_Backward.Size = new System.Drawing.Size(75, 23);
            this.Btn_Backward.TabIndex = 18;
            this.Btn_Backward.Text = "<<";
            this.Btn_Backward.UseVisualStyleBackColor = true;
            this.Btn_Backward.Click += new System.EventHandler(this.Btn_Backward_Click);
            // 
            // Btn_Forward
            // 
            this.Btn_Forward.Location = new System.Drawing.Point(569, 63);
            this.Btn_Forward.Name = "Btn_Forward";
            this.Btn_Forward.Size = new System.Drawing.Size(75, 23);
            this.Btn_Forward.TabIndex = 19;
            this.Btn_Forward.Text = ">>";
            this.Btn_Forward.UseVisualStyleBackColor = true;
            this.Btn_Forward.Click += new System.EventHandler(this.Btn_Forward_Click);
            // 
            // VolumeSlider
            // 
            this.VolumeSlider.Location = new System.Drawing.Point(300, 92);
            this.VolumeSlider.Maximum = 100;
            this.VolumeSlider.Name = "VolumeSlider";
            this.VolumeSlider.Size = new System.Drawing.Size(104, 45);
            this.VolumeSlider.TabIndex = 20;
            this.VolumeSlider.ValueChanged += new System.EventHandler(this.VolumeChange);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(381, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 22;
            this.label6.Text = "100";
            // 
            // Txt_CurrentVolume
            // 
            this.Txt_CurrentVolume.AutoSize = true;
            this.Txt_CurrentVolume.Location = new System.Drawing.Point(410, 92);
            this.Txt_CurrentVolume.Name = "Txt_CurrentVolume";
            this.Txt_CurrentVolume.Size = new System.Drawing.Size(33, 12);
            this.Txt_CurrentVolume.TabIndex = 23;
            this.Txt_CurrentVolume.Text = "label7";
            // 
            // Cb_Loop
            // 
            this.Cb_Loop.AutoSize = true;
            this.Cb_Loop.Location = new System.Drawing.Point(569, 92);
            this.Cb_Loop.Name = "Cb_Loop";
            this.Cb_Loop.Size = new System.Drawing.Size(49, 16);
            this.Cb_Loop.TabIndex = 24;
            this.Cb_Loop.Text = "Loop";
            this.Cb_Loop.UseVisualStyleBackColor = true;
            this.Cb_Loop.CheckedChanged += new System.EventHandler(this.Cb_Loop_CheckedChanged);
            // 
            // Btn_Load
            // 
            this.Btn_Load.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_Load.Location = new System.Drawing.Point(108, 108);
            this.Btn_Load.Name = "Btn_Load";
            this.Btn_Load.Size = new System.Drawing.Size(90, 90);
            this.Btn_Load.TabIndex = 25;
            this.Btn_Load.Text = "讀取影片設定檔";
            this.Btn_Load.UseVisualStyleBackColor = true;
            this.Btn_Load.Click += new System.EventHandler(this.Btn_Load_Click);
            // 
            // Tb_VideoSettingFilePath
            // 
            this.Tb_VideoSettingFilePath.Location = new System.Drawing.Point(108, 314);
            this.Tb_VideoSettingFilePath.Name = "Tb_VideoSettingFilePath";
            this.Tb_VideoSettingFilePath.Size = new System.Drawing.Size(186, 22);
            this.Tb_VideoSettingFilePath.TabIndex = 27;
            this.Tb_VideoSettingFilePath.Text = "D:\\Syooian\\WorkProjects\\A0079\\MovingTheater\\Client\\MovingTheaterClient\\OfficeVide" +
    "o.json";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "影片設定檔路徑";
            // 
            // MessageBox
            // 
            this.MessageBox.Location = new System.Drawing.Point(12, 342);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MessageBox.Size = new System.Drawing.Size(282, 96);
            this.MessageBox.TabIndex = 28;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.Tb_VideoSettingFilePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Btn_Load);
            this.Controls.Add(this.Cb_Loop);
            this.Controls.Add(this.Txt_CurrentVolume);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.VolumeSlider);
            this.Controls.Add(this.Btn_Forward);
            this.Controls.Add(this.Btn_Backward);
            this.Controls.Add(this.Txt_TotalTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CurrentTimeSlider);
            this.Controls.Add(this.Txt_CurrentTime);
            this.Controls.Add(this.Btn_Add);
            this.Controls.Add(this.Tb_RemotePort);
            this.Controls.Add(this.Txt_Port);
            this.Controls.Add(this.Tb_RemoteIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Stop);
            this.Controls.Add(this.Btn_Pause);
            this.Controls.Add(this.Btn_Play);
            this.Name = "Form1";
            this.Text = "VLC控制Server Form版";
            ((System.ComponentModel.ISupportInitialize)(this.CurrentTimeSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Play;
        private System.Windows.Forms.Button Btn_Pause;
        private System.Windows.Forms.Button Btn_Stop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tb_RemoteIP;
        private System.Windows.Forms.Label Txt_Port;
        private System.Windows.Forms.TextBox Tb_RemotePort;
        private System.Windows.Forms.Button Btn_Add;
        private System.Windows.Forms.Label Txt_CurrentTime;
        private System.Windows.Forms.TrackBar CurrentTimeSlider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Txt_TotalTime;
        private System.Windows.Forms.Button Btn_Backward;
        private System.Windows.Forms.Button Btn_Forward;
        private System.Windows.Forms.TrackBar VolumeSlider;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Txt_CurrentVolume;
        private System.Windows.Forms.CheckBox Cb_Loop;
        private System.Windows.Forms.Button Btn_Load;
        private System.Windows.Forms.TextBox Tb_VideoSettingFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MessageBox;
    }
}

