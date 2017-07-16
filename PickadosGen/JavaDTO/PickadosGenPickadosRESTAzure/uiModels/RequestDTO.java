	
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
		
		
		public class RequestDTO 	    implements IDTO
	    {
				private Integer post_oid;
				public Integer  getPost_oid () { return post_oid; } 
				public void setPost_oid (Integer value) { post_oid = value;  } 
				    	 
				private Integer id;
				public Integer getId () { return id; } 
				public void setId  (Integer value) { id = value;  } 
				    	 
				private RequestType type;
				public RequestType getType () { return type; } 
				public void setType  (RequestType value) { type = value;  } 
				    	 
				private String reason;
				public String getReason () { return reason; } 
				public void setReason  (String value) { reason = value;  } 
				    	 
				private RequestState state;
				public RequestState getState () { return state; } 
				public void setState  (RequestState value) { state = value;  } 
				    	 
				private java.util.Date date;
				public java.util.Date getDate () { return date; } 
				public void setDate  (java.util.Date value) { date = value;  } 
				    	 
				private String adminComment;
				public String getAdminComment () { return adminComment; } 
				public void setAdminComment  (String value) { adminComment = value;  } 
				    	 
				private java.util.Date changeDate;
				public java.util.Date getChangeDate () { return changeDate; } 
				public void setChangeDate  (java.util.Date value) { changeDate = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{

						if (this.post_oid != null)
						{
							json.put("Post_oid", this.post_oid.intValue());
						}
				
						  json.put("Id", this.id.intValue());
				
				
						  json.put("Type", this.type.getRawValue());
				
				
						  json.put("Reason", this.reason);
				
				
						  json.put("State", this.state.getRawValue());
				
				
						  json.put("Date", DateUtils.dateToFormatString(this.date));
				
				
						  json.put("AdminComment", this.adminComment);
				
				
						  json.put("ChangeDate", DateUtils.dateToFormatString(this.changeDate));
				
						
					}
					catch (JSONException e)
					{
						e.printStackTrace();
					}
				
				return json;
			}
		
			// endregion
		}
	   
	   
	   
		
	