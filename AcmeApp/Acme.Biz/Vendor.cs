using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages the vendors from whom we purchase our inventory.
    /// </summary>
    public class Vendor 
    {
        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
       public enum IncludeAddress { Yes, No};
        public enum SendCopy { Yes, No};

        
        
        /// <summary>
        /// Sends a product order to the vender
        /// </summary>
        /// <param name="product">Product to order</param>
        /// <param name="quantity">Quantity of the product</param>
        /// <param name="deliverBy">Requested Delivery</param>
        /// <param name="deliveryInstructions">Delivery Instruction</param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity, DateTimeOffset? deliverBy=null,string deliveryInstructions="Standard delivery")
        {
            if (deliverBy <= DateTimeOffset.Now) throw new ArgumentOutOfRangeException(nameof(deliverBy));
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity));
            }
            var success = false;
            var orderText = "Order from Acme Inc" + System.Environment.NewLine +
                "Product: " + product.ProductCode + System.Environment.NewLine +
                "Quantity: " + quantity;
            if (deliverBy.HasValue)
            {
                orderText += System.Environment.NewLine + "Deliver By: " + deliverBy.Value.ToString("d");
            }
            if (!String.IsNullOrWhiteSpace(deliveryInstructions))
            {
                orderText += System.Environment.NewLine + "Instructions: " + deliveryInstructions;
            }
            var emailServices = new EmailService();
            var confirmation = emailServices.SendMessage("New Order", orderText, this.Email);
            if (confirmation.StartsWith("Message sent:"))
            {
                success = true;
            }
            var operationResult = new OperationResult(success, orderText);
            return operationResult;
        }
        /// <summary>
        /// Send a Product order to the vender
        /// </summary>
        /// <param name="product">Product to oder</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="includeAddress">true to include shipping address</param>
        /// <param name="sendCopy">true to send a copy </param>
        /// <returns>Success flag and order text</returns>
        public OperationResult PlaceOrder(Product product,int quantity ,IncludeAddress includeAddress , SendCopy sendCopy)
        {
            var orderText = "Test ";
            if (includeAddress == IncludeAddress.Yes) orderText += "With Address";
            if (sendCopy == SendCopy.Yes) orderText += "With Copy"; 
            var operationResult = new OperationResult(true, orderText);
            return operationResult;
        }


        /// <summary>
        /// Sends an email to welcome a new vendor.
        /// </summary>
        /// <returns></returns>
        public string SendWelcomeEmail(string message)
        {
            var emailService = new EmailService();
            var subject = ("Hello " + this.CompanyName).Trim();
            var confirmation = emailService.SendMessage(subject,
                                                        message, 
                                                        this.Email);
            return confirmation;
        }
        public override string ToString()
        {
            string vendorInfo ="Vendor: "+this.CompanyName;
            string result;
            if (!String.IsNullOrWhiteSpace(vendorInfo))
            {
                result = vendorInfo.ToLower();
                result = vendorInfo.ToUpper();
                result = vendorInfo.Replace("Vendor", "Supplier");
                var length = vendorInfo.Length;
                var index = vendorInfo.IndexOf(":");
                var begins = vendorInfo.StartsWith("Vendor");
            }
           
            return vendorInfo;     
        }
        public string PrepareDirections()
        {
            var direction = @"Insert \r\n to define a new line";
            return direction;
        }
    }
}
