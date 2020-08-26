using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eShopping.Models
{

    public class Category
    {
        [Key]
        public int CategoryRowId { get; set; }
        [Required(ErrorMessage= "Category Id is Must")]
        [StringLength(20,ErrorMessage = "Category Id can be max 20 characters")]
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is Must")]
        [StringLength(200, ErrorMessage = "Category Name can be max 200 characters")]
        public string CategoeyName { get; set; }
        [Required(ErrorMessage = "Base Price is Must")]
        public int BasePrice { get; set; }
        // Expected one-to-many relationship
        public ICollection<Product> Products { get; set; }
    }

    public class Product
    {
        [Key] // Promary Identity Key
        public int ProductRowId { get; set; }
        [Required(ErrorMessage = "Product Id is Must")]
        [StringLength(20, ErrorMessage = "Product Id can be max 20 characters")]
        public string ProductId { get; set; }
        [Required(ErrorMessage = "Product Name is Must")]
        [StringLength(200, ErrorMessage = "Product Name can be max 200 characters")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Manufacturer is Must")]
        [StringLength(20, ErrorMessage = "Manufacturer can be max 20 characters")]
        public string Manufacturer { get; set; }
        [Required]
        public int Price { get; set; }
        [ForeignKey("CategoryRowId")] // Foreign Key
        public int CategoryRowId { get; set; }
        // referential Integrity
        public Category Category { get; set; }

    }
    public class Customer
    {
        [Key] // Primary Identity Key
        public int CustomerRowId { get; set; }
       
        [Required(ErrorMessage = "Customer Id is Must")]
        [StringLength(20, ErrorMessage = "Customer Id can be max 20 characters")]
        public string CustomerId { get; set; }
       
        [Required(ErrorMessage = "Customer Name is Must")]
        [StringLength(200, ErrorMessage = "Customer Name can be max 200 characters")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Customer Phone Number is Must")]
        [StringLength(12, ErrorMessage = "Customer Phone Number can be max 12 characters")]
        public string CustomerPhoneNumber { get; set; }

        [Required(ErrorMessage = "Customer Email Address is Must")]
        [StringLength(100, ErrorMessage = "Customer Email Address can be max 100 characters")]
        public string CustomerEmailAddress { get; set; }

        [Required(ErrorMessage = "Customer Password is Must")]
        [StringLength(100, ErrorMessage = "Customer Password can be max 100 characters")]
        public string CustomerPassword { get; set; }

        [Required(ErrorMessage = "Customer Date Of Bairth is Must")]
        [StringLength(100, ErrorMessage = "Customer Date Of Bairth can be max 100 characters")]
        public string CustomerDOB { get; set; }

        [Required(ErrorMessage = "Customer Address is Must")]
        [StringLength(200, ErrorMessage = "Manufacturer can be max 200 characters")]
        public string CustomerAddress { get; set; }

    }
}
