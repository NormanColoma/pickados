	
		//
		// PostDTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class PostDTO 	    {
		 
				var id: Int?;
				    	 
		 
				var created_at: NSTimeInterval?;
				    	 
		 
				var modified_at: NSTimeInterval?;
				    	 
		 
				var stake: Double?;
				    	 
		 
				var description: String?;
				    	 
		 
				var private_: Bool?;
				    	 
		 
				var pick_oid: [Int]?;
				    	 
		 
				var tipster_oid: Int?;
				    	 
		 
				var totalOdd: Double?;
				    	 
		 
				var postResult: PickResult?;
				    	 
	   	   
			// MARK: - Constructor
			
			
		
			init ()
			{
				// Empty constructor
			}
			 func toDictionary() -> [String : AnyObject]
		
		   
			{
				var dictionary: [String : AnyObject] = [:];
				
			


				
					dictionary["id"] = self.id;
				

				
					dictionary["created_at"] = self.created_at;
				

				
					dictionary["modified_at"] = self.modified_at;
				

				
					dictionary["stake"] = self.stake;
				

				
					dictionary["description"] = self.description;
				

				
					dictionary["private_"] = self.private_;
				

					dictionary["pick_oid"] = self.pick_oid;
			

					dictionary["tipster_oid"] = self.tipster_oid;
			

				
					dictionary["totalOdd"] = self.totalOdd;
				

				
					dictionary["postResult"] = self.postResult?.rawValue;
				
						
				return dictionary;
			}
		}
		
	