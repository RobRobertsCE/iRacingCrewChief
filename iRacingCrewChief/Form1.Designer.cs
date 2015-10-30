namespace iRacingCrewChief
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
            this.flowBoard = new System.Windows.Forms.FlowLayoutPanel();
            this.leaderboardView1 = new iRacingCrewChief.Controls.LeaderboardView();
            this.leaderboardView2 = new iRacingCrewChief.Controls.LeaderboardView();
            this.leaderboardView3 = new iRacingCrewChief.Controls.LeaderboardView();
            this.lapTimeView3 = new iRacingCrewChief.Controls.LapTimeView();
            this.lapTimeView2 = new iRacingCrewChief.Controls.LapTimeView();
            this.lapTimeView1 = new iRacingCrewChief.Controls.LapTimeView();
            this.driverView1 = new iRacingCrewChief.Controls.DriverView();
            this.sessionStatusView = new iRacingCrewChief.Controls.SessionStatusView();
            this.flowBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowBoard
            // 
            this.flowBoard.Controls.Add(this.leaderboardView1);
            this.flowBoard.Controls.Add(this.leaderboardView2);
            this.flowBoard.Controls.Add(this.leaderboardView3);
            this.flowBoard.Location = new System.Drawing.Point(16, 344);
            this.flowBoard.Name = "flowBoard";
            this.flowBoard.Size = new System.Drawing.Size(888, 232);
            this.flowBoard.TabIndex = 5;
            // 
            // leaderboardView1
            // 
            this.leaderboardView1.BackColor = System.Drawing.SystemColors.Control;
            this.leaderboardView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderboardView1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.leaderboardView1.Location = new System.Drawing.Point(3, 3);
            this.leaderboardView1.Name = "leaderboardView1";
            this.leaderboardView1.Size = new System.Drawing.Size(877, 37);
            this.leaderboardView1.TabIndex = 6;
            // 
            // leaderboardView2
            // 
            this.leaderboardView2.BackColor = System.Drawing.SystemColors.Control;
            this.leaderboardView2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderboardView2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.leaderboardView2.Location = new System.Drawing.Point(3, 46);
            this.leaderboardView2.Name = "leaderboardView2";
            this.leaderboardView2.Size = new System.Drawing.Size(877, 37);
            this.leaderboardView2.TabIndex = 7;
            // 
            // leaderboardView3
            // 
            this.leaderboardView3.BackColor = System.Drawing.SystemColors.Control;
            this.leaderboardView3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderboardView3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.leaderboardView3.Location = new System.Drawing.Point(3, 89);
            this.leaderboardView3.Name = "leaderboardView3";
            this.leaderboardView3.Size = new System.Drawing.Size(877, 37);
            this.leaderboardView3.TabIndex = 8;
            // 
            // lapTimeView3
            // 
            this.lapTimeView3.DisplayInterval = true;
            this.lapTimeView3.DisplayLapMPH = true;
            this.lapTimeView3.DisplayLapMPHDelta = true;
            this.lapTimeView3.DisplayLapTimeDelta = true;
            this.lapTimeView3.Location = new System.Drawing.Point(24, 296);
            this.lapTimeView3.Name = "lapTimeView3";
            this.lapTimeView3.Padding = new System.Windows.Forms.Padding(3);
            this.lapTimeView3.Size = new System.Drawing.Size(600, 32);
            this.lapTimeView3.TabIndex = 4;
            // 
            // lapTimeView2
            // 
            this.lapTimeView2.DisplayInterval = true;
            this.lapTimeView2.DisplayLapMPH = true;
            this.lapTimeView2.DisplayLapMPHDelta = true;
            this.lapTimeView2.DisplayLapTimeDelta = true;
            this.lapTimeView2.Location = new System.Drawing.Point(24, 252);
            this.lapTimeView2.Name = "lapTimeView2";
            this.lapTimeView2.Padding = new System.Windows.Forms.Padding(3);
            this.lapTimeView2.Size = new System.Drawing.Size(600, 32);
            this.lapTimeView2.TabIndex = 3;
            // 
            // lapTimeView1
            // 
            this.lapTimeView1.DisplayInterval = true;
            this.lapTimeView1.DisplayLapMPH = true;
            this.lapTimeView1.DisplayLapMPHDelta = true;
            this.lapTimeView1.DisplayLapTimeDelta = true;
            this.lapTimeView1.Location = new System.Drawing.Point(24, 208);
            this.lapTimeView1.Name = "lapTimeView1";
            this.lapTimeView1.Padding = new System.Windows.Forms.Padding(3);
            this.lapTimeView1.Size = new System.Drawing.Size(600, 32);
            this.lapTimeView1.TabIndex = 2;
            // 
            // driverView1
            // 
            this.driverView1.DisplayClub = true;
            this.driverView1.DisplayTeam = false;
            this.driverView1.DisplayVehicle = true;
            this.driverView1.Location = new System.Drawing.Point(8, 160);
            this.driverView1.Name = "driverView1";
            this.driverView1.Size = new System.Drawing.Size(811, 26);
            this.driverView1.TabIndex = 1;
            // 
            // sessionStatusView
            // 
            this.sessionStatusView.Location = new System.Drawing.Point(8, 8);
            this.sessionStatusView.Name = "sessionStatusView";
            this.sessionStatusView.Size = new System.Drawing.Size(812, 139);
            this.sessionStatusView.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 596);
            this.Controls.Add(this.flowBoard);
            this.Controls.Add(this.lapTimeView3);
            this.Controls.Add(this.lapTimeView2);
            this.Controls.Add(this.lapTimeView1);
            this.Controls.Add(this.driverView1);
            this.Controls.Add(this.sessionStatusView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowBoard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SessionStatusView sessionStatusView;
        private Controls.DriverView driverView1;
        private Controls.LapTimeView lapTimeView1;
        private Controls.LapTimeView lapTimeView2;
        private Controls.LapTimeView lapTimeView3;
        private System.Windows.Forms.FlowLayoutPanel flowBoard;
        private Controls.LeaderboardView leaderboardView1;
        private Controls.LeaderboardView leaderboardView2;
        private Controls.LeaderboardView leaderboardView3;
    }
}

