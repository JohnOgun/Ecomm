using System;
using System.Collections.Generic;
using System.Text;
// Used for working with text (not used directly here).

namespace Core.Entities
// Groups this class inside the "Core.Entities" part of your project.
// (Small typo: should probably be "Entities")
{
    public class BaseEntity
    // This creates a base (parent) class.
    // Other classes can inherit from this class.
    {
        public int ID { get; set; }
        // This is a common ID property.
        // It will usually act as the Primary Key in the database.
        // Any class that inherits from BaseEntity will automatically have this ID.
    }
}