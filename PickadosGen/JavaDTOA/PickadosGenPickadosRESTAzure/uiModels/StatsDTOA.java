
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
public class StatsDTOA extends DTOA
{
	// region - Members, getters and setters

	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }

	
	private Double benefit;
	public Double getBenefit () { return benefit; }
	public void setBenefit (Double benefit) { this.benefit = benefit; }
	
	private Double stakeAverage;
	public Double getStakeAverage () { return stakeAverage; }
	public void setStakeAverage (Double stakeAverage) { this.stakeAverage = stakeAverage; }
	
	private float yield;
	public float getYield () { return yield; }
	public void setYield (float yield) { this.yield = yield; }
	
	private Double oddAverage;
	public Double getOddAverage () { return oddAverage; }
	public void setOddAverage (Double oddAverage) { this.oddAverage = oddAverage; }
	
	private Integer totalPicks;
	public Integer getTotalPicks () { return totalPicks; }
	public void setTotalPicks (Integer totalPicks) { this.totalPicks = totalPicks; }
	
	private Double oddAccumulator;
	public Double getOddAccumulator () { return oddAccumulator; }
	public void setOddAccumulator (Double oddAccumulator) { this.oddAccumulator = oddAccumulator; }
	
	private Double totalStaked;
	public Double getTotalStaked () { return totalStaked; }
	public void setTotalStaked (Double totalStaked) { this.totalStaked = totalStaked; }
	
	
	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public StatsDTOA ()
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
			

			if (!JSONObject.NULL.equals(json.opt("Benefit")))
			{
			 
			 	String stringDouble = String.valueOf(json.opt("Benefit"));
 				this.benefit = Double.parseDouble(stringDouble);
			 
			}

			if (!JSONObject.NULL.equals(json.opt("StakeAverage")))
			{
			 
			 	String stringDouble = String.valueOf(json.opt("StakeAverage"));
 				this.stakeAverage = Double.parseDouble(stringDouble);
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Yield")))
			{
			 
				this.yield = (float) json.opt("Yield");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("OddAverage")))
			{
			 
			 	String stringDouble = String.valueOf(json.opt("OddAverage"));
 				this.oddAverage = Double.parseDouble(stringDouble);
			 
			}

			if (!JSONObject.NULL.equals(json.opt("TotalPicks")))
			{
			 
				this.totalPicks = (Integer) json.opt("TotalPicks");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("OddAccumulator")))
			{
			 
			 	String stringDouble = String.valueOf(json.opt("OddAccumulator"));
 				this.oddAccumulator = Double.parseDouble(stringDouble);
			 
			}

			if (!JSONObject.NULL.equals(json.opt("TotalStaked")))
			{
			 
			 	String stringDouble = String.valueOf(json.opt("TotalStaked"));
 				this.totalStaked = Double.parseDouble(stringDouble);
			 
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
			
		
		  if (this.benefit != null)
			json.put("Benefit", this.benefit);
		
		
		  if (this.stakeAverage != null)
			json.put("StakeAverage", this.stakeAverage);
		
		
		  if (this.yield != null)
			json.put("Yield", this.yield);
		
		
		  if (this.oddAverage != null)
			json.put("OddAverage", this.oddAverage);
		
		
		  if (this.totalPicks != null)
			json.put("TotalPicks", this.totalPicks.intValue());
		
		
		  if (this.oddAccumulator != null)
			json.put("OddAccumulator", this.oddAccumulator);
		
		
		  if (this.totalStaked != null)
			json.put("TotalStaked", this.totalStaked);
		
			
			
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
		StatsDTO dto = new StatsDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
	dto.setBenefit (this.getBenefit());

	dto.setStakeAverage (this.getStakeAverage());

	dto.setYield (this.getYield());

	dto.setOddAverage (this.getOddAverage());

	dto.setTotalPicks (this.getTotalPicks());

	dto.setOddAccumulator (this.getOddAccumulator());

	dto.setTotalStaked (this.getTotalStaked());

		
		
		// Roles
		
		
		return dto;
	}

	// endregion
}

	