namespace api.models.dto;

public record LoginRequest(string Username, string Password, string ClientIP);