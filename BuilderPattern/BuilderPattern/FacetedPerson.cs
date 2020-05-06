using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BuilderPattern
{
    //we need to create multi builder, for example, one for address and one for the employment of the person
    public class FacetedPerson
    {
        //address
        public string StreetAddress, Postcode, City;

        //employment
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    public class FPersonBuilder // facade
    {
        //reference! this is very important
        protected FacetedPerson facetedPerson = new FacetedPerson();
        public FPersonJobBuilder works => new FPersonJobBuilder(facetedPerson);
        public FPersonAddressBuilder lives => new FPersonAddressBuilder(facetedPerson);

        public static implicit operator FacetedPerson(FPersonBuilder pb)
        {
            return pb.facetedPerson;
        }
    }

    public class FPersonJobBuilder:FPersonBuilder
    {
        public FPersonJobBuilder(FacetedPerson fperson)
        {
            this.facetedPerson = fperson;
        }

        public FPersonJobBuilder At(string companyName)
        {
            facetedPerson.CompanyName = companyName;
            return this;
        }

        public FPersonJobBuilder AsA(string position)
        {
            facetedPerson.Position = position;
            return this;
        }

        public FPersonJobBuilder EarningIntAmount(int amount)
        {
            facetedPerson.AnnualIncome = amount;
            return this;
        }
    }

    public class FPersonAddressBuilder : FPersonBuilder
    {
        public FPersonAddressBuilder(FacetedPerson facetedPerson)
        {
            this.facetedPerson = facetedPerson;
        }

        public FPersonAddressBuilder At(string streetAddress)
        {
            this.facetedPerson.StreetAddress = streetAddress;
            return this;
        }

        public FPersonAddressBuilder WithPostcode(string zipcode)
        {
            this.facetedPerson.Postcode = zipcode;
            return this;
        }

        public FPersonAddressBuilder In(string city)
        {
            this.facetedPerson.City = city;
            return this;
        }
    }
}
