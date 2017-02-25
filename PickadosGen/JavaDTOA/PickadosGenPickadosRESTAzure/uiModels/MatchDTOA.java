
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
public class MatchDTOA extends DTOA
{
	// region - Members, getters and setters

	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }

	
	private String stadium;
	public String getStadium () { return stadium; }
	public void setStadium (String stadium) { this.stadium = stadium; }
	
	private java.util.Date date;
	public java.util.Date getDate () { return date; }
	public void setDate (java.util.Date date) { this.date = date; }
	
	
	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public MatchDTOA ()
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
			

			if (!JSONObject.NULL.equals(json.opt("Stadium")))
			{
			 
				this.stadium = (String) json.opt("Stadium");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Date")))
			{
			 
			 	String stringDate = (String) json.opt("Date");
				this.date = DateUtils.stringToDateFormat(stringDate);
			 
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
			
		
		  if (this.stadium != null)
			json.put("Stadium", this.stadium);
		
		
		  if (this.date != null)
			json.put("Date", DateUtils.dateToFormatString(this.date));
		
			
			
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
		MatchDTO dto = new MatchDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
	dto.setStadium (this.getStadium());

	dto.setDate (this.getDate());

		
		
		// Roles
		
		
		return dto;
	}

	// endregion
}

	