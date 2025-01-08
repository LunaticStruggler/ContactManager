using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class ContactService
{
    private List<Contact> contacts;
    private readonly string filePath;

    public ContactService()
    {
        contacts = new List<Contact>();
        filePath = "contacts.json";
        LoadContacts();
    }

    public ContactService(string filePath)
    {
        this.filePath = filePath;
        contacts = new List<Contact>();
        LoadContacts();
    }

    public List<Contact> GetAllContacts()
    {
        return contacts;
    }

    public void AddContact(Contact contact)
    {
        contacts.Add(contact);
        SaveContacts();
    }

    public void UpdateContact(Contact oldContact, Contact newContact)
    {
        var index = contacts.IndexOf(oldContact);
        if (index >= 0)
        {
            contacts[index] = newContact;
            SaveContacts();
        }
    }

    public void DeleteContact(Contact contact)
    {
        contacts.Remove(contact);
        SaveContacts();
    }

    private void SaveContacts()
    {
        string json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    private void LoadContacts()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            contacts = JsonConvert.DeserializeObject<List<Contact>>(json) ?? new List<Contact>();
        }
    }
}
