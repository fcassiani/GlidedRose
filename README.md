# GlidedRose

Getting Started:

Clone this project in your local machine and open the project with visual studio, in this case was used Visual Studio Community 2017 using .NET Core Framework.
Select the project and build the solution.

Requirements from the Kata to upgrade UpdateQuality Method:

	Updates on Class GlidedRose:
	
		Two methods were added referencing the current item:
	
			IncrementQuality, increase item Quality keeping it at maximum 50.
		
			DecreaseQuality, decrease item Quality keeping it on minimum 0.

	UpdateQuality method:
	
		Item iteration changed to foreach, referencing original object into the list.
	
		Simplification of the prefix of the Item name, when there is an item with same prefix as 
			"Aged Brie", "Backstage Passes", "Sulfuras" or "Conjured" would enter in the correct condition 
			also treating in uppercase to do not mismatch the letters in case of typing incorrectly.
	
		(Refactor) Switch case added instead of If conditions to better organize the code by Item Type, for example:
			Sulfuras, Aged Brie, Backstage Passes, Conjured and default ( for normal items )
			all of them following the rules described in the kata requirements
			(https://github.com/emilybache/GildedRose-Refactoring-Kata/blob/master/GildedRoseRequirements.txt).

		(Upgrade) Conjured Items case added :
			As the requirements says "conjured Items degrade twice as fast as normal items"
				and the current requirements says "Once sell by date has passed, Quality degrades twice as fast"
				was assumed that in conjured case when SellIn passed the Quality of item would drop 4 times faster.

Unit Tests:
	AprovalTest.cs:
		In this scenario the ThirtyDays.txt was corrected on the value of conjured items to calc correctely the double decrease, before it was decreasing quality by once.
		Also had to add "\r" on the output.Split() for a correct comparison of the Text file and the items array text output.

	GildedRoseTest.cs:
		Added 2 items with Different names with same prefix existing in the code such as "BackStage" and "conjured"
			to verfy if names prefix simplification is working also comparing the at the end the Quality value of the items
			for the Backstage and conjured item when SellIn bellow zero to doble decrease the Quality value.

	Running Automated tests:
		Go to the Test Manager tab, select the desired test to execute, right click and hit Execute Selected Tests.
		Or if desired Execute all Tests. 
	
 
 Author:
 Cassiani, Felipe - Initial Work - Leeroy