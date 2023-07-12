namespace api.models.dto;

public record RegisterRequest(string UserName, string Password, string Email, string ClientIP);