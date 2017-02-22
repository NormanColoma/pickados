	
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
		
		
		public class PlayerDTO 	    implements IDTO
	    {
				private Integer club_team_oid;
				public Integer  getClub_team_oid () { return club_team_oid; } 
				public void setClub_team_oid (Integer value) { club_team_oid = value;  } 
				    	 
				private Integer national_team_oid;
				public Integer  getNational_team_oid () { return national_team_oid; } 
				public void setNational_team_oid (Integer value) { national_team_oid = value;  } 
				    	 
				private Integer id;
				public Integer getId () { return id; } 
				public void setId  (Integer value) { id = value;  } 
				    	 
				private String name;
				public String getName () { return name; } 
				public void setName  (String value) { name = value;  } 
				    	 
				private ArrayList<Integer> scorer_oid;
				public ArrayList<Integer>  getScorer_oid () { return scorer_oid; } 
				public void setScorer_oid (ArrayList<Integer> value) { scorer_oid = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{

						if (this.club_team_oid != null)
						{
							json.put("Club_team_oid", this.club_team_oid.intValue());
						}

						if (this.national_team_oid != null)
						{
							json.put("National_team_oid", this.national_team_oid.intValue());
						}
				
						  json.put("Id", this.id.intValue());
				
				
						  json.put("Name", this.name);
				

						if (this.scorer_oid != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.scorer_oid.size(); ++i)
							{
								jsonArray.put(this.scorer_oid.get(i));
							}
							json.put("Scorer_oid", jsonArray);
						}
		
						
					}
					catch (JSONException e)
					{
						e.printStackTrace();
					}
				
				return json;
			}
		
			// endregion
		}
	   
	   
	   
		
	