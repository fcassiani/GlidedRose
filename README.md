# GlidedRose
Updates on Class GlidedRose
	
	Two methods were added referencing the current item:
	
		IncrementQuality, increase item Quality if bellow 50
		
		DecreaseQuality, decrease item Quality if over 0

UpdateQuality method:
	
	Item iteration changed to foreach, referencing original object into the list
	
	Simplification of the prefix of the Item name, when there is an item with same prefix as 
		"Aged Brie", "Backstage Passes", "Sulfuras" or "Conjured" would enter in the correct condition 
		also treating in uppercase to do not mismatch the letters in case of typing incorrectly
	
	Switch case added instead of conditions to better organize the code by Item Type, for example:
		Sulfuras, Aged Brie, Backstage Passes, Conjured and default ( for normal items )
		all of them following the rules described in the kata requirements

Unit Tests:
	AprovalTest.cs:
		In this scenario the ThirtyDays.txt was corrected on the value of conjured items to calc correctely the double decrease, before it was decreasing quality by once.
		Also had to add "\r" on the output.Split() for a correct comparison of the Text file and the items array text output.

	GildedRoseTest.cs:
		Added 2 items with Different names with same prefix existing in the code such as "BackStage" and "conjured"
			to verfy if names prefix simplification is working also comparing the at the end the Quality value of the items
			for the Backstage and conjured item when SellIn bellow zero to doble decrease the Quality value.
	
 