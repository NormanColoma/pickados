
package PickadosGenPickadosRESTAzure.uiModels.DTOA;

import PickadosGenPickadosRESTAzure.uiModels.DTO.*;
import PickadosGenPickadosRESTAzure.uiModels.DTO.utils.*;
import PickadosGenPickadosRESTAzure.uiModels.DTO.enumerations.*;

import java.util.ArrayList;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

/**
 * Code autogenerated. Do not modify this file.
 */
public class CompetitionDTOA extends DTOA
{
	// region - Members, getters and setters

	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }

	
	private String name;
	public String getName () { return name; }
	public void setName (String name) { this.name = name; }
	
	private String place;
	public String getPlace () { return place; }
	public void setPlace (String place) { this.place = place; }
	
	
	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public CompetitionDTOA ()
	{
		// Empty constructor
	}
	
	@Override
	public void setFromJSON (JSONObject json)
	{
		try
		{
			if (!JSONObject.NULL.equals(json.opt("Id")))
			{
				this.id = (Integer) json.opt("Id");
			}
			

			if (!JSONObject.NULL.equals(json.opt("Name")))
			{
			 
				this.name = (String) json.opt("Name");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Place")))
			{
			 
				this.place = (String) json.opt("Place");
			 
			}
			
			
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
	}
	
	public JSONObject toJSON ()
	{
		JSONObject json = new JSONObject();
		
		try
		{
			if (this.id != null){
				json.put("Id", this.id);
			}
			
		
		  if (this.name != null)
			json.put("Name", this.name);
		
		
		  if (this.place != null)
			json.put("Place", this.place);
		
			
			
		}
		catch (JSONException e)
		{
			e.printStackTrace();
		}
		
		return json;
	}
	
	@Override 
	public IDTO toDTO ()
	{
		CompetitionDTO dto = new CompetitionDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
	dto.setName (this.getName());

	dto.setPlace (this.getPlace());

		
		
		// Roles
		
		
		return dto;
	}

	// endregion
}

	