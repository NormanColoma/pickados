	
		package PickadosGenPickadosRESTAzure.uiModels.DTO;
		
		import java.util.ArrayList;
		
		import org.json.JSONArray;
		import org.json.JSONException;
		import org.json.JSONObject;
		import  PickadosGenPickadosRESTAzure.uiModels.DTO.utils.*;
		import  PickadosGenPickadosRESTAzure.uiModels.DTO.enumerations.*;
		
		
		/**
		 * Code autogenerated. Do not modify this file.
		 */
		
		
		public class ResultDTO extends    		PickDTO
	    implements IDTO
	    {
				private Result result;
				public Result getResult () { return result; } 
				public void setResult  (Result value) { result = value;  } 
				    	 
				private Time matchtime;
				public Time getMatchtime () { return matchtime; } 
				public void setMatchtime  (Time value) { matchtime = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{
				
						  json.put("Result", this.result.getRawValue());
				
				
						  json.put("Matchtime", this.matchtime.getRawValue());
				
						
					}
					catch (JSONException e)
					{
						e.printStackTrace();
					}
				
				return json;
			}
		
			// endregion
		}
	   
	   
	   
		
	