﻿using System;

public class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName} - {Phone} - {Email}";
    }
}
