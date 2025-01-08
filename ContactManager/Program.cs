using System;
using System.Collections.Generic;

namespace ContactManager
{
    public class Program
    {
        static void Main(string[] args)
        {
            ContactService contactService = new ContactService();

            while (true)
            {
                Console.WriteLine("Contact Manager");
                Console.WriteLine("1. List Contacts");
                Console.WriteLine("2. Add Contact");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListContacts(contactService);
                        break;
                    case "2":
                        AddContact(contactService);
                        break;
                    case "3":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private static void ListContacts(ContactService contactService)
        {
            var contacts = contactService.GetAllContacts();

            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts available.");
            }
            else
            {
                Console.WriteLine("Contacts:");
                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact);
                }
            }
        }

        private static void AddContact(ContactService contactService)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name) &&
                !string.IsNullOrWhiteSpace(phone) &&
                !string.IsNullOrWhiteSpace(email))
            {
                var contact = new Contact
                {
                    Name = name,
                    Phone = phone,
                    Email = email
                };

                contactService.AddContact(contact);
                Console.WriteLine("Contact added successfully!");
            }
            else
            {
                Console.WriteLine("All fields are required!");
            }
        }
    }

    public class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Phone: {Phone}, Email: {Email}";
        }
    }

    public class ContactService
    {
        private List<Contact> contacts = new List<Contact>();
        private readonly string filePath = "contacts.json";

        public ContactService()
        {
            LoadContacts();
        }

        public List<Contact> GetAllContacts() => contacts;

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
            SaveContacts();
        }

        public void SaveContacts()
        {
            File.WriteAllText(filePath, Newtonsoft.Json.JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        private void LoadContacts()
        {
            if (File.Exists(filePath))
            {
                contacts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Contact>>(File.ReadAllText(filePath)) ?? new List<Contact>();
            }
        }
    }
}
