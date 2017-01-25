using System;
using static Acme.Common.LoggingService;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

namespace Acme.Biz
{
    public class Product
    {
        public Product()
        {
            Console.WriteLine("Product instance created");
            // this.ProductVendor = new Vendor();
            this.MinimumPrice = .96m;
            this.Category = "Tool";

        }
        public Product(int productId, string productName, string description):this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
            if (ProductName.StartsWith("Bulk"))
            {
                this.MinimumPrice = 9.99m;
            }
            Console.WriteLine("Product instance had a name: "+ ProductName);
        }
        public const double InchesPerMeter = 39.37;
        public readonly decimal MinimumPrice;
        private DateTime? availablityDate;
        internal string Category { get; set; }
        public int SequenceNumber { get; set; } = 1;
        public string ProductCode => String.Format($"{this.Category}-{this.SequenceNumber:00000}");
       
        public DateTime? AvailablityDate
        {
            get { return availablityDate; }
            set { availablityDate = value; }
        }

        private string productName;

        public string ProductName
        {
            get
            {
                var formattedValue = productName?.Trim();
                return formattedValue  ;
            }
            set
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product Name must be at least 3 characters";

                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product Name cannot be more than 20 characters";
                }
                else
                {
                    productName = value;
                }
            }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
        private Vendor productVendor;

        public Vendor ProductVendor
        {
            get {
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor; }
            set { productVendor = value; }
        }

        public string ValidationMessage { get; private set; }

        public string SayHello()
        {
          //  var vendor = new Vendor();
          //  vendor.SendWelcomeEmail("Message from product");

            var emailService =new EmailService();
            var confirmation = emailService.SendMessage("New Product." , this.productName, "sales@abc.com");
            var result = LogAction("saying Hello");
            return "Hello " + ProductName + "(" + ProductId + "): " + Description + "Available on: " + AvailablityDate?.ToShortDateString();
        }

    }
}
