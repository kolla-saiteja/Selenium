Configure run settings UAT from Selenium\Specflow\RunSettings folder

Open test explorer and it will list the available tests. Select the test and click run to run the tests.


Specflow Test Execution Report
Project: Specflow
Configuration: Specflow
Test Assemblies: Specflow.dll
Start Time: 06/06/2023 15:06:33
Duration: 00:00:09.1705540
Test Threads: 2
Result: all tests passed
Success rate	Tests	Succeeded	Failed	Pending	Ignored	Skipped
100%	
1	1	0	0	0	0
Test Timeline Summary
thread
#0	
 
 
#1	
 
 	0s
Test Result View
sort by: time act time execution result descheights: time act time
8.4s	 	 
4.2s	 	 
0s	 	 
 	
 
 
 	 
Feature Summary
Feature	Success rate	Tests	Succeeded	Failed	Pending	Ignored	Skipped	Duration
AutomationTaskFeature	100%	
1	1	0	0	0	0	00:00:08.3961367
Error Summary
Test	Success rate	Tests	Succeeded	Failed	Pending	Ignored	Skipped
Scenario Summary
Feature: AutomationTaskFeature
Test	Success rate	Tests	Succeeded	Failed	Pending	Ignored	Skipped	Duration
Scenario: Katalon Task	100%	
1	1	0	0	0	0	00:00:08.3961367
Execution Details
Scenario: Katalon Task (in Specflow, AutomationTaskFeature)
Status: Succeeded
Start time: 06/06/2023 15:06:33
Execution time (sec): 8.3961367
Thread: #0
Steps	Trace	Result
Given I add 4 random items to my cart
done: AutomationtaskSteps.GivenIAddRandomItemsToMyCart(4) (2.2s)
Succeeded in 6.437s
When I view my cart
done: AutomationtaskSteps.WhenIViewMyCart() (0.9s)
Succeeded in 0.93s
Then I find total 4 items listed in my cart
done: AutomationtaskSteps.ThenIFindTotalItemsListedInMyCart(4) (0.0s)
Succeeded in 0.031s
When I search for lowest price item
done: AutomationtaskSteps.WhenISearchForLowestPriceItem() (0.1s)
Succeeded in 0.095s
And I am able to remove the lowest price item from my cart
done: AutomationtaskSteps.WhenIAmAbleToRemoveTheLowestPriceItemFromMyCart() (0.9s)
Succeeded in 0.856s
Then I am able to verify 3 items in my cart
done: AutomationtaskSteps.ThenIAmAbleToVerifyThreeItemsInMyCart(3) (0.0s)
Succeeded in 0.019s



