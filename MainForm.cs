using System;
using System.Drawing;
using System.Windows.Forms;

namespace EchoApp
{
    public partial class MainForm : Form
    {
        private TextBox inputTextBox = null!;
        private Label outputLabel = null!;
        private Button echoButton = null!;
        private Button clearButton = null!;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Form properties
            this.Text = "Echo Application";
            this.Size = new Size(500, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Input label
            Label inputLabel = new Label
            {
                Text = "Enter text:",
                Location = new Point(20, 20),
                Size = new Size(100, 20),
                Font = new Font("Segoe UI", 10F, FontStyle.Regular)
            };
            this.Controls.Add(inputLabel);

            // Input text box
            inputTextBox = new TextBox
            {
                Location = new Point(20, 50),
                Size = new Size(440, 25),
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            inputTextBox.KeyPress += InputTextBox_KeyPress;
            this.Controls.Add(inputTextBox);

            // Echo button
            echoButton = new Button
            {
                Text = "Echo",
                Location = new Point(20, 90),
                Size = new Size(100, 35),
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                BackColor = Color.LightBlue,
                FlatStyle = FlatStyle.Flat
            };
            echoButton.Click += EchoButton_Click;
            this.Controls.Add(echoButton);

            // Clear button
            clearButton = new Button
            {
                Text = "Clear",
                Location = new Point(140, 90),
                Size = new Size(100, 35),
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                BackColor = Color.LightCoral,
                FlatStyle = FlatStyle.Flat
            };
            clearButton.Click += ClearButton_Click;
            this.Controls.Add(clearButton);

            // Output label
            Label outputTitleLabel = new Label
            {
                Text = "Echoed text:",
                Location = new Point(20, 140),
                Size = new Size(100, 20),
                Font = new Font("Segoe UI", 10F, FontStyle.Regular)
            };
            this.Controls.Add(outputTitleLabel);

            outputLabel = new Label
            {
                Text = "",
                Location = new Point(20, 170),
                Size = new Size(440, 60),
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightYellow,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
            };
            this.Controls.Add(outputLabel);
        }

        private void EchoButton_Click(object? sender, EventArgs e)
        {
            EchoText();
        }

        private void ClearButton_Click(object? sender, EventArgs e)
        {
            inputTextBox.Clear();
            outputLabel.Text = "";
            inputTextBox.Focus();
        }

        private void InputTextBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                EchoText();
                e.Handled = true;
            }
        }

        private void EchoText()
        {
            string inputText = inputTextBox.Text.Trim();
            
            if (string.IsNullOrEmpty(inputText))
            {
                outputLabel.Text = "Please enter some text to echo!";
                return;
            }

            // Add timestamp to the echo
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            outputLabel.Text = $"[{timestamp}] {inputText}";
            
            // Clear the input after echoing
            inputTextBox.Clear();
            inputTextBox.Focus();
        }
    }
}
