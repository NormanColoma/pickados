	
		//
		// SportDTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class SportDTO 	    {
		 
				var competition: [CompetitionDTO]?;
				    	 
		 
				var id: Int?;
				    	 
		 
				var name: String?;
				    	 
		 
				var player_oid: [Int]?;
				    	 
		 
				var image: String?;
				    	 
	   	   
			// MARK: - Constructor
			
			
		
			init ()
			{
				// Empty constructor
			}
			 func toDictionary() -> [String : AnyObject]
		
		   
			{
				var dictionary: [String : AnyObject] = [:];
				
			


					dictionary["competition"] = NSNull();
					if (self.competition != nil)
					{
						var arrayOfDictionary: [[String : AnyObject]] = [];
						for item in self.competition!
						{
							arrayOfDictionary.append(item.toDictionary());
						}
						
						dictionary["competition"] = arrayOfDictionary;
					}
			

				
					dictionary["id"] = self.id;
				

				
					dictionary["name"] = self.name;
				

					dictionary["player_oid"] = self.player_oid;
			

				
					dictionary["image"] = self.image;
				
						
				return dictionary;
			}
		}
		
	