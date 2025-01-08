using Xunit;
using System.IO;

public class ContactServiceTests
{
    private const string TestFilePath = "test_contacts.json";

    public ContactServiceTests()
    {
        if (File.Exists(TestFilePath))
        {
            File.Delete(TestFilePath);
        }
    }

    [Fact]
    public void AddContact_Should_AddContactToList()
    {
        var contactService = new ContactService(TestFilePath);
        var contact = new Contact
        {
            FirstName = "John",
            LastName = "Doe",
            Phone = "123456789",
            Email = "john.doe@example.com"
        };

        contactService.AddContact(contact);
        var allContacts = contactService.GetAllContacts();

        Assert.Single(allContacts);
        Assert.Contains(contact, allContacts);
    }

    [Fact]
    public void DeleteContact_Should_RemoveContactFromList()
    {
        var contactService = new ContactService(TestFilePath);
        var contact = new Contact
        {
            FirstName = "Jane",
            LastName = "Doe",
            Phone = "987654321",
            Email = "jane.doe@example.com"
        };

        contactService.AddContact(contact);
        contactService.DeleteContact(contact);
        var allContacts = contactService.GetAllContacts();

        Assert.Empty(allContacts);
    }

    [Fact]
    public void UpdateContact_Should_UpdateContactDetails()
    {
        var contactService = new ContactService(TestFilePath);
        var oldContact = new Contact
        {
            FirstName = "Old",
            LastName = "Name",
            Phone = "111111111",
            Email = "old@example.com"
        };
        var newContact = new Contact
        {
            FirstName = "New",
            LastName = "Name",
            Phone = "222222222",
            Email = "new@example.com"
        };

        contactService.AddContact(oldContact);
        contactService.UpdateContact(oldContact, newContact);
        var allContacts = contactService.GetAllContacts();

        Assert.Single(allContacts);
        Assert.Contains(newContact, allContacts);
        Assert.DoesNotContain(oldContact, allContacts);
    }

    [Fact]
    public void GetAllContacts_Should_ReturnAllContacts()
    {
        var contactService = new ContactService(TestFilePath);
        var contact1 = new Contact { FirstName = "Alice", LastName = "Smith", Phone = "12345", Email = "alice@example.com" };
        var contact2 = new Contact { FirstName = "Bob", LastName = "Johnson", Phone = "67890", Email = "bob@example.com" };

        contactService.AddContact(contact1);
        contactService.AddContact(contact2);
        var allContacts = contactService.GetAllContacts();

        Assert.Equal(2, allContacts.Count);
        Assert.Contains(contact1, allContacts);
        Assert.Contains(contact2, allContacts);
    }

    ~ContactServiceTests()
    {
        try
        {
            if (File.Exists(TestFilePath))
            {
                File.Delete(TestFilePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting test file: {ex.Message}");
        }
    }
}
