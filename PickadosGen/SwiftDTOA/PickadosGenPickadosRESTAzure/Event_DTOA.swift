//
// Event_DTOA.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation
import SwiftyJSON
		
class Event_DTOA : DTOA
{
	// MARK: - Properties

	var id: Int?;
	
	var date: NSDate?;
	
	
	
	
	
	// MARK: - Constructor
	
	init ()
	{
		// Empty constructor
	}
	
	
	
	// MARK: - JSON <-> DTOA
	
	required init (fromJSONObject json: JSON)
	{
		self.id = json["Id"].object as? Int
		
	
	
		self.date = NSDate.initFromString(json["Date"].object as? String);
		
		
	}
	
	func toDictionary() -> [String : AnyObject]
	{
		var dictionary: [String : AnyObject] = [:];
		
		dictionary["Id"] = self.id;
		
	

	
		dictionary["Date"] = self.date?.toString();
	
	
		
		
		
		return dictionary;
	}
}

	