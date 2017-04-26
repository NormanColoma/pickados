//
// PostDTOA.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation
import SwiftyJSON
		
class PostDTOA : DTOA
{
	// MARK: - Properties

	var id: Int?;
	
	var created_at: NSDate?;
	var description: String?;
	var postResult: PickResult?;
	var stake: Double?;
	var totalOdd: Double?;
	
	/* Rol: Post o--> Pick */
	var getAllPickOfPost: [PickDTOA]?;

	
	
	
	
	// MARK: - Constructor
	
	init ()
	{
		// Empty constructor
	}
	
	
	
	// MARK: - JSON <-> DTOA
	
	required init (fromJSONObject json: JSON)
	{
		self.id = json["Id"].object as? Int
		
	
	
		self.created_at = NSDate.initFromString(json["Created_at"].object as? String);
		self.description = json["Description"].object as? String;
		if let enumValue = json["PostResult"].object as? Int
		{
			self.postResult = PickResult(rawValue: enumValue);
		}
		self.stake = json["Stake"].object as? Double;
		self.totalOdd = json["TotalOdd"].object as? Double;
		
		if (json["GetAllPickOfPost"] != JSON.null)
		{
			self.getAllPickOfPost = [];
			for subJson in json["GetAllPickOfPost"].arrayValue
			{
				self.getAllPickOfPost!.append(PickDTOA(fromJSONObject: subJson));
			}
		}

		
	}
	
	func toDictionary() -> [String : AnyObject]
	{
		var dictionary: [String : AnyObject] = [:];
		
		dictionary["Id"] = self.id;
		
	

	
		dictionary["Created_at"] = self.created_at?.toString();
	
	

	
		dictionary["Description"] = self.description;
	
	

	
		dictionary["PostResult"] = self.postResult?.rawValue;
	
	

	
		dictionary["Stake"] = self.stake;
	
	

	
		dictionary["TotalOdd"] = self.totalOdd;
	
	
		
		dictionary["GetAllPickOfPost"] = NSNull();
		if (self.getAllPickOfPost != nil)
		{
			var arrayOfDictionary: [[String : AnyObject]] = [];
			for item in self.getAllPickOfPost!
			{
				arrayOfDictionary.append(item.toDictionary());
			}
			
			dictionary["GetAllPickOfPost"] = arrayOfDictionary;
		}

		
		
		return dictionary;
	}
}

	