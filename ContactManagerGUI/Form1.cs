using System;
using System.Windows.Forms;

namespace ContactManagerGUI
{
    public partial class Form1 : Form
    {
        private ContactService contactService;

        public Form1()
        {
            InitializeComponent();
            contactService = new ContactService();         }

                private void btnListContacts_Click(object sender, EventArgs e)
        {
                        var contacts = contactService.GetAllContacts(); 
                        if (contacts.Count == 0)             {
                MessageBox.Show("No contacts available.");
            }
            else
            {
                string contactList = string.Join(Environment.NewLine, contacts);
                MessageBox.Show(contactList, "Contacts");
            }
        }

                private void btnAddContact_Click(object sender, EventArgs e)
        {
                        string firstName = Microsoft.VisualBasic.Interaction.InputBox("Enter First Name:");
            string lastName = Microsoft.VisualBasic.Interaction.InputBox("Enter Last Name:");
            string email = Microsoft.VisualBasic.Interaction.InputBox("Enter Email:");

            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName) && !string.IsNullOrWhiteSpace(email))
            {
                var contact = new Contact
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email
                };

                contactService.AddContact(contact);                 MessageBox.Show("Contact added successfully!");
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }
        }
    }
}
