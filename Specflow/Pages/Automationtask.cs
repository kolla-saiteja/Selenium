using OpenQA.Selenium;
using SeleniumFrameWork.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Specflow.Pages
{
    public class Automationtask
    {
        private readonly By _addtocartbutton= By.XPath("//*[text()='Add to cart']");
        private readonly By _viewCart= By.XPath("//a[text()='Cart']");
        private readonly By _cartItems = By.XPath("//*[@class='woocommerce-cart-form__cart-item cart_item']");
        private readonly By _productPrice = By.XPath("//*[@class='woocommerce-Price-amount amount']");
        private readonly By _removeButton = By.XPath("//*[@class='remove']");
        private readonly By _alert = By.XPath("//*[@class='woocommerce-message']");
 
        public void ClickAddToBasketButton(int productCount)
        {
            CommonMethods.WaitForElementPresence(_addtocartbutton);
            var addToCartButtons = CommonMethods.GetElementList(_addtocartbutton);
            if (productCount >0)
            {
                for(int i=0; i<productCount;i++)
                    addToCartButtons[i].Click();
            }
           
        }

        public void ClickViewCart()
        {
            CommonMethods.WaitForElementPresence(_viewCart);
            CommonMethods.ClickElement(_viewCart);
        }

        public bool CheckCartItemsCount(int productCount)
        {
            // Find items listed in your cart
            CommonMethods.WaitForElementPresence(_cartItems);
            var cartItems = CommonMethods.GetElementList(_cartItems);

            // Verify items in your cart
            if (cartItems.Count != productCount)
            {
                return false;
                //throw new Exception($"Expected {productCount} items in the cart but found " + cartItems.Count);
            }
            else
                return true;

        }

        private IWebElement GetLowestPricedItem()
        {
            // Find items listed in your cart
            var cartItems = CommonMethods.GetElementList(_cartItems);

            // Search for lowest price item
            var lowestItem = cartItems.OrderBy(x => x.FindElement(_productPrice).Text.Replace("$", "")).First();

            return lowestItem;
        }

        public bool CheckLowestItem()
        {
            var lowestItem = GetLowestPricedItem();
            if (lowestItem != null)
                return true;
            else
                return false;
                
        }

        public void RemoveItem()
        {
            var lowestItem = GetLowestPricedItem();
            var removeButton = lowestItem.FindElement(_removeButton);
            removeButton.Click();

            //wait for the alert to visible
            CommonMethods.WaitForElementPresence(_alert);
            

        }
    }

   
}
