
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
public class UsuarioDTOA extends DTOA
{
	// region - Members, getters and setters

	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }

	
<<<<<<< HEAD
	private String nif;
	public String getNif () { return nif; }
	public void setNif (String nif) { this.nif = nif; }
	
=======
>>>>>>> Fixed get all sports api method. Now showing each competition in their own sport.
	
	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public UsuarioDTOA ()
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
			
<<<<<<< HEAD

			if (!JSONObject.NULL.equals(json.opt("Nif")))
			{
			 
				this.nif = (String) json.opt("Nif");
			 
			}
=======
>>>>>>> Fixed get all sports api method. Now showing each competition in their own sport.
			
			
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
			
<<<<<<< HEAD
		
		  if (this.nif != null)
			json.put("Nif", this.nif);
		
=======
>>>>>>> Fixed get all sports api method. Now showing each competition in their own sport.
			
			
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
		UsuarioDTO dto = new UsuarioDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
<<<<<<< HEAD
	dto.setNif (this.getNif());

=======
>>>>>>> Fixed get all sports api method. Now showing each competition in their own sport.
		
		
		// Roles
		
		
		return dto;
	}

	// endregion
}

	