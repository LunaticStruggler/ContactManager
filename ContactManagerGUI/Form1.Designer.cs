namespace ContactManagerGUI
{
    partial class Form1
    {
                                private System.ComponentModel.IContainer components = null;

                                        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

                                private void InitializeComponent()
        {
            btnListContacts = new Button();
            btnAddContact = new Button();
            SuspendLayout();
                                                btnListContacts.Location = new Point(316, 85);
            btnListContacts.Name = "btnListContacts";
            btnListContacts.Size = new Size(116, 29);
            btnListContacts.TabIndex = 0;
            btnListContacts.Text = "List Contacts";
            btnListContacts.UseVisualStyleBackColor = true;
            btnListContacts.Click += btnListContacts_Click;
                                                btnAddContact.Location = new Point(316, 144);
            btnAddContact.Name = "btnAddContact";
            btnAddContact.Size = new Size(116, 29);
            btnAddContact.TabIndex = 1;
            btnAddContact.Text = "Add Contact";
            btnAddContact.UseVisualStyleBackColor = true;
            btnAddContact.Click += btnAddContact_Click;                                                 AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAddContact);
            Controls.Add(btnListContacts);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnListContacts;
        private Button btnAddContact;
    }
}
