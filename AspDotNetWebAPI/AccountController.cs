Example of getting a user account from database using unique his/her email address or Id. Assume we have removed the segment "api" in the Route config for API. 

Invoke Web API:
--------------	

Usage: GET https://mybaseUrl/accounts/byEmail/myemail@somewhere.com
Usage: GET https://mybaseUrl/accounts/byId/1234
	

C# codes for AccountController:
------------------------------

    [RoutePrefix("accounts")]
    public class AccountController : ApiBaseController
    {
        private HttpStatusCode _statusCode; // status code of web api call which is returned from _accountService class
	private readonly IAccountService _accountService; // custom service class

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService; // Dependency Injection
        }
		
	/// <summary>
        /// Retrieve account information for the user associated with particular email address
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("byEmail")]
        public HttpResponseMessage GetAccount(string email)
        {
            // Account Query

            var account = _accountService.GetAccount(email);
            _statusCode = _accountService.StatusCode;

            return _statusCode == HttpStatusCode.OK
              ? Request.CreateResponse(_statusCode, account)
              : Request.CreateResponse(_statusCode, AccountService.ErrorCode);
        }
		
		// <summary>
        /// Retrieve account information for the user associated with particular id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("byId/{id:int}")]
        public HttpResponseMessage GetAccount(int id)
        {
            // Account Query

            var account = _accountService.GetAccount(id);
            _statusCode = _accountService.StatusCode;

            return _statusCode == HttpStatusCode.OK
              ? Request.CreateResponse(_statusCode, account)
              : Request.CreateResponse(_statusCode, AccountService.ErrorCode);
        }
    }
