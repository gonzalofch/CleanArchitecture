using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBlazor.Domain.Tests.EntitiesTests.AddressTests;

public class AddressFieldsTests : IEnumerable<object[]>
{
    public readonly List<object[]> data = new List<object[]>()
    {
            new object[]{//1
                new Address(Guid.NewGuid(),null, "line 1", "line 2", "New York", "NY Region", "10001"),"The Name field is required."
            },
             new object[]{//2
                new Address(Guid.NewGuid(),"John Doe", null, "Line 2 ","New York", "NYRegion", "10001"),"The Line1 field is required."
            },
              new object[]{//3
                new Address(Guid.NewGuid(),"John Doe", "123 Main St", "Line 2 ",null, "NYRegion", "10001"),"The City field is required."
            },
               new object[]{//4
                new Address(Guid.NewGuid(),"John Doe", "123 Main St", "Line 2", "New York", null, "10001"),"The Region field is required."
            },
                new object[]{//5
                new Address(Guid.NewGuid(),"John Doe", "123 Main St","Line 2", "New York", "NYRegion", null), "The PostalCode field is required."
            },
                 new object[]{//6
                new Address(Guid.NewGuid(),"Jo", "123 Main St","Line 2", "New York", "NYRegion", "10001"),"Please use a Name bigger than 3 letters."
            },
                  new object[]{//7
                new Address(Guid.NewGuid(),"John Doe", "123", "Line 2","New York", "NYRegion", "10001"),"Please use an Address bigger than 5 letters."
            },
                  new object[]{//8
                new Address(Guid.NewGuid(),"John Doe", "123 Main St","Line 2", "New York", "N", "10001"),"Please use a Region bigger than 3 letters."
            },
                   new object[]{//9
               new Address(Guid.NewGuid(),"John Doe", "123 Main St","Line 2", "New York", "NYRegion", "1000"),"Please use a valid Postal Code with five numbers."
            },
        
                    new object[]{//10
               new Address(Guid.NewGuid(),"John Doe","John Doe", "123 Main St", "New York", "NYRegion", "100001"),"Please use a valid Postal Code with five numbers."
            },
                     new object[]{//11
               new Address(Guid.NewGuid(),"John Doe", "123 Main St","Line 2", "New York", "NYRegion", "1000"),"Please use a valid Postal Code with five numbers."
            },
    };


    public IEnumerator<object[]> GetEnumerator()
    {
        return data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return data.GetEnumerator();
    }
}
