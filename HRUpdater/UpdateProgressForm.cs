using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartBooksUpdater
{
    public class UpdateProgressForm : Form
    {
        private ProgressBar progressBar;
        private Label lblStatus;
        private Label lblTitle;

        public UpdateProgressForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Đang cập nhật Human Resource...";
            this.Size = new Size(450, 150);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.BackColor = Color.White;

            lblTitle = new Label
            {
                Text = "⚙️ Đang cập nhật...",
                Location = new Point(20, 15),
                Size = new Size(400, 25),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 102, 204)
            };
            this.Controls.Add(lblTitle);

            lblStatus = new Label
            {
                Text = "Đang chuẩn bị...",
                Location = new Point(20, 50),
                Size = new Size(400, 30),
                Font = new Font("Segoe UI", 9F)
            };
            this.Controls.Add(lblStatus);

            progressBar = new ProgressBar
            {
                Location = new Point(20, 85),
                Size = new Size(400, 25),
                Style = ProgressBarStyle.Continuous,
                Minimum = 0,
                Maximum = 100,
                Value = 0
            };
            this.Controls.Add(progressBar);
        }

        public void UpdateProgress(int percentage, string message = null)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateProgress(percentage, message)));
                return;
            }

            progressBar.Value = Math.Min(Math.Max(percentage, 0), 100);
            if (!string.IsNullOrEmpty(message))
            {
                lblStatus.Text = message;
            }
            Application.DoEvents();
        }

        public void SetStatus(string status)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SetStatus(status)));
                return;
            }

            lblStatus.Text = status;
            Application.DoEvents();
        }
    }
}