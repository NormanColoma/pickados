//
// TipsterDTOA.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation
import SwiftyJSON
		
class TipsterDTOA : DTOA
{
	// MARK: - Properties

	var id: Int?;
	
	var alias: String?;
	var email: String?;
	var created_at: NSDate?;
	var premium: Bool?;
	var subscription_fee: Double?;
	var nif: String?;
	
	
	
	
	
	// MARK: - Constructor
	
	init ()
	{
		// Empty constructor
	}
	
	
	
	// MARK: - JSON <-> DTOA
	
	required init (fromJSONObject json: JSON)
	{
		self.id = json["Id"].object as? Int
		
	
		self.alias = json["Alias"].object as? String;
		self.email = json["Email"].object as? String;
	
		self.created_at = NSDate.initFromString(json["Created_at"].object as? String);
		self.premium = json["Premium"].object as? Bool;
		self.subscription_fee = json["Subscription_fee"].object as? Double;
		self.nif = json["Nif"].object as? String;
		
		
	}
	
	func toDictionary() -> [String : AnyObject]
	{
		var dictionary: [String : AnyObject] = [:];
		
		dictionary["Id"] = self.id;
		
	

	
		dictionary["Alias"] = self.alias;
	
	

	
		dictionary["Email"] = self.email;
	
	

	
		dictionary["Created_at"] = self.created_at?.toString();
	
	

	
		dictionary["Premium"] = self.premium;
	
	

	
		dictionary["Subscription_fee"] = self.subscription_fee;
	
	

	
		dictionary["Nif"] = self.nif;
	
	
		
		
		
		return dictionary;
	}
}

	