	
		//
		// Event_DTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class Event_DTO 	    {
		 
				var id: Int?;
				    	 
		 
				var competition_oid: Int?;
				    	 
		 
				var pick_rel: [PickDTO]?;
				    	 
		 
				var date: NSDate?;
				    	 
	   	   
			// MARK: - Constructor
			
			
		
			init ()
			{
				// Empty constructor
			}
			 func toDictionary() -> [String : AnyObject]
		
		   
			{
				var dictionary: [String : AnyObject] = [:];
				
			


				
					dictionary["id"] = self.id;
				

					dictionary["competition_oid"] = self.competition_oid;
			

					dictionary["pick_rel"] = NSNull();
					if (self.pick_rel != nil)
					{
						var arrayOfDictionary: [[String : AnyObject]] = [];
						for item in self.pick_rel!
						{
							arrayOfDictionary.append(item.toDictionary());
						}
						
						dictionary["pick_rel"] = arrayOfDictionary;
					}
			

				
					dictionary["date"] = self.date?.toString();
				
						
				return dictionary;
			}
		}
		
	