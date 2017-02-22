	
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
		
		
		public class GoalDTO extends    		PickDTO
	    implements IDTO
	    {
				private Line line;
				public Line getLine () { return line; } 
				public void setLine  (Line value) { line = value;  } 
				    	 
				private Double quantity;
				public Double getQuantity () { return quantity; } 
				public void setQuantity  (Double value) { quantity = value;  } 
				    	 
				private Boolean asian;
				public Boolean getAsian () { return asian; } 
				public void setAsian  (Boolean value) { asian = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{
				
						  json.put("Line", this.line.getRawValue());
				
				
						  json.put("Quantity", this.quantity);
				
				
						  json.put("Asian", this.asian);
				
						
					}
					catch (JSONException e)
					{
						e.printStackTrace();
					}
				
				return json;
			}
		
			// endregion
		}
	   
	   
	   
		
	