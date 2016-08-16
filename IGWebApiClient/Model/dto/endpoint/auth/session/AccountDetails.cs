namespace dto.endpoint.auth.session
{

    public class AccountDetails{
	///<Summary>
	///Account identifier
	///</Summary>
	public string accountId { get; set; }
	///<Summary>
	///Account name
	///</Summary>
	public string accountName { get; set; }
	///<Summary>
	///Indicates whether this account is the client's preferred account
	///</Summary>
	public bool preferred { get; set; }
	///<Summary>
	///Account type
	///</Summary>
	public string accountType { get; set; }
}
}
