namespace TD.CitizenAPI.Application.Identity.Tokens;

public record RefreshTokenRequest(string Token, string RefreshToken);