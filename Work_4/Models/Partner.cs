using System;
using System.Collections.Generic;

namespace Work_4.Models;

public partial class Partner
{
    public int Id { get; set; }

    public int IdOfPartner { get; set; }

    public string Name { get; set; } = null!;

    public string LegalAdress { get; set; } = null!;

    public string Tin { get; set; } = null!;

    public string FullnameOfDirector { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public short Rating { get; set; }

    public Partner() { }

    public Partner(int idOfPartner, string name, string legalAdress, string tin, string nameOfDirector, string phoneNumber, string email, short rating)
    {
        IdOfPartner = idOfPartner;
        Name = name;
        LegalAdress = legalAdress;
        Tin = tin;
        FullnameOfDirector = nameOfDirector;
        PhoneNumber = phoneNumber;
        Email = email;
        Rating = rating;
    }



    public virtual ICollection<FromProductsToPartner> FromProductsToPartners { get; set; } = new List<FromProductsToPartner>();

    public virtual TypesOfPartner IdOfPartnerNavigation { get; set; } = null!;
}
