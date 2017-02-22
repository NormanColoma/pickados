	
		//
		// TipsterDTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class TipsterDTO :    		UsuarioDTO
	    {
		 
				var monthlyStats: [StatsDTO]?;
				    	 
		 
				var post: [PostDTO]?;
				    	 
		 
				var follow_to_oid: [Int]?;
				    	 
		 
				var followed_by_oid: [Int]?;
				    	 
		 
				var premium: Bool?;
				    	 
		 
				var subscription_fee: Double?;
				    	 
	   	   
			// MARK: - Constructor
			
			
			override init ()
			{
				super.init();
			}
			override func toDictionary() -> [String : AnyObject]
		
		   
			{
				var dictionary: [String : AnyObject] = [:];
				
				dictionary = super.toDictionary();
			


					dictionary["monthlyStats"] = NSNull();
					if (self.monthlyStats != nil)
					{
						var arrayOfDictionary: [[String : AnyObject]] = [];
						for item in self.monthlyStats!
						{
							arrayOfDictionary.append(item.toDictionary());
						}
						
						dictionary["monthlyStats"] = arrayOfDictionary;
					}
			

					dictionary["post"] = NSNull();
					if (self.post != nil)
					{
						var arrayOfDictionary: [[String : AnyObject]] = [];
						for item in self.post!
						{
							arrayOfDictionary.append(item.toDictionary());
						}
						
						dictionary["post"] = arrayOfDictionary;
					}
			

					dictionary["follow_to_oid"] = self.follow_to_oid;
			

					dictionary["followed_by_oid"] = self.followed_by_oid;
			

				
					dictionary["premium"] = self.premium;
				

				
					dictionary["subscription_fee"] = self.subscription_fee;
				
						
				return dictionary;
			}
		}
		
	