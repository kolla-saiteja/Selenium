using Microsoft.VisualStudio.TestTools.UnitTesting;
using Specflow.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Specflow.StepDefinations
{
    [Binding]
    public class AutomationtaskSteps
    {
        readonly Automationtask _automationtask;
        public AutomationtaskSteps()
        {
            _automationtask = new Automationtask();
           
        }
        [Given(@"I add (.*) random items to my cart")]
        public void GivenIAddRandomItemsToMyCart(int productCount)
        {
            _automationtask.ClickAddToBasketButton(productCount);
        }


        [When(@"I view my cart")]
        public void WhenIViewMyCart()
        {
            _automationtask.ClickViewCart();
        }

        [Then(@"I find total (.*) items listed in my cart")]
        public void ThenIFindTotalItemsListedInMyCart(int productCount)
        {
            Assert.IsTrue(_automationtask.CheckCartItemsCount(productCount));
        }


        [When(@"I search for lowest price item")]
        public void WhenISearchForLowestPriceItem()
        {
          Assert.IsTrue(_automationtask.CheckLowestItem());
        }

        [When(@"I am able to remove the lowest price item from my cart")]
        public void WhenIAmAbleToRemoveTheLowestPriceItemFromMyCart()
        {
            _automationtask.RemoveItem();
        }

        [Then(@"I am able to verify (.*) items in my cart")]
        public void ThenIAmAbleToVerifyThreeItemsInMyCart(int productCount)
        {
            Assert.IsTrue(_automationtask.CheckCartItemsCount(productCount));
        }

    }
}
