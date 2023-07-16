namespace api.contracts.requests;

public record RegisterRequest(string UserName, string Password, string Email, string ClientIP);