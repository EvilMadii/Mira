namespace api.contracts.requests;

public record LoginRequest(string Username, string Password, string ClientIP);