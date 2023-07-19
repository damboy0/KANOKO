namespace KANOKO.Middlewares
{
    using KANOKO.Auth;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;

    public class JwtTokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IJWTAuthentication _jwtAuthentication;

        public JwtTokenMiddleware(RequestDelegate next, IJWTAuthentication jwtAuthentication)
        {
            _next = next;
            _jwtAuthentication = jwtAuthentication;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string token = await GetJwtTokenFromRequest(context.Request);

            if (!string.IsNullOrEmpty(token))
            {
                context.Request.Headers.Add("Authorization", "Bearer " + token);
            }

            await _next(context);
        }

        private async Task<string> GetJwtTokenFromRequest(HttpRequest request)
        {
            // Get the authorization header from the request
            string authorizationHeader = request.Headers["Authorization"].FirstOrDefault();

            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                // Extract the token from the authorization header
                string token = authorizationHeader.Substring("Bearer ".Length).Trim();

                return token;
            }

            return null; // Return null if the token is not found in the request
        }
    }

    public static class JwtTokenMiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtTokenMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtTokenMiddleware>();
        }
    }

}
