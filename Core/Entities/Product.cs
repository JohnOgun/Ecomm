using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Product : BaseEntity
    // This creates a class called Product.
    // ": BaseEntity" means Product inherits from BaseEntity.
    // So it gets properties from BaseEntity (like Id).
    // This saves time because you don’t have to rewrite common properties.
    {
        public int ID { get; set; }
        // This is the Product's unique identifier (primary key in database).
        // NOTE: If BaseEntity already has Id, this may be duplicated.

        public required string Name { get; set; }
        // "required" means this value MUST be provided when creating a Product.
        // The object cannot be created without a Name.

        public string Description { get; set; }
        // Optional description of the product.

        public decimal Price { get; set; }
        // Stores the product price.

        public required string pictureUrl { get; set; }
        // Required image URL for the product.
        // Must be provided when creating the object.

        public required string Type { get; set; }
        // Required product type (e.g., Shoes, Electronics).

        public required string Brand { get; set; }
        // Required product brand (e.g., Nike, Apple).

        public int QuantityInStock { get; set; }
         
    }
}
