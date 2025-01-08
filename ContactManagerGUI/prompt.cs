using System;
using System.Windows.Forms;

public static class Prompt
{
    public static (string Name, string Phone, string Email) ShowDialog(string title)
    {
                Form prompt = new Form()
        {
            Width = 400,
            Height = 250,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            Text = title,
            StartPosition = FormStartPosition.CenterScreen
        };

                Label lblName = new Label() { Left = 20, Top = 20, Text = "Name:", Width = 340 };
        TextBox txtName = new TextBox() { Left = 20, Top = 50, Width = 340 };

                Label lblPhone = new Label() { Left = 20, Top = 80, Text = "Phone:", Width = 340 };
        TextBox txtPhone = new TextBox() { Left = 20, Top = 110, Width = 340 };

                Label lblEmail = new Label() { Left = 20, Top = 140, Text = "Email:", Width = 340 };
        TextBox txtEmail = new TextBox() { Left = 20, Top = 170, Width = 340 };

                Button confirmation = new Button() { Text = "OK", Left = 150, Top = 200, Width = 100, DialogResult = DialogResult.OK };

                confirmation.Click += (sender, e) => { prompt.Close(); };

                prompt.Controls.Add(lblName);
        prompt.Controls.Add(txtName);
        prompt.Controls.Add(lblPhone);
        prompt.Controls.Add(txtPhone);
        prompt.Controls.Add(lblEmail);
        prompt.Controls.Add(txtEmail);
        prompt.Controls.Add(confirmation);

        prompt.AcceptButton = confirmation;

                var result = prompt.ShowDialog();

                if (result == DialogResult.OK)
        {
            return (txtName.Text, txtPhone.Text, txtEmail.Text);
        }

        return (string.Empty, string.Empty, string.Empty);     }
}
