namespace Web
{
    using System.Net.Http.Json;
    using System.Text.Json;
    using Microsoft.JSInterop;

    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;
        private readonly AuthStateService _authStateService;
        private const string TokenKey = "authToken";

        public AuthService(HttpClient httpClient, IJSRuntime jsRuntime, AuthStateService authStateService)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
            _authStateService = authStateService;
        }

        public async Task<LoginResult> LoginAsync(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7111/api/auth/login", new { Username = username, Password = password });

            var token = await response.Content.ReadAsStringAsync();

            await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", TokenKey, token);

            if (response.IsSuccessStatusCode) {

                _authStateService.NotifyStateChanged();

                return new LoginResult { Success = true, Message = "Inicio de sesión exitoso" };
            }
            else
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                var errorMessage = errorResponse?.Message ?? "Error desconocido";

                return new LoginResult { Success = false, Message = errorMessage };
            }
        }

        public async Task LogoutAsync()
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", TokenKey);

            _authStateService.NotifyStateChanged();
        }

        public async Task<string> GetTokenAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", TokenKey);
        }

        public async Task<AuthResult> IsAuthenticatedAsync()
        {
            var token = await GetTokenAsync();
            if (string.IsNullOrEmpty(token))
            {
                return new AuthResult
                {
                    IsAuthenticated = false,
                    NombreUsuario = null,
                    Rol = null,
                    IdPersona = null
                };
            }

            var payload = DecodeJwt(token);
            var jsonPayload = JsonDocument.Parse(payload.ToString()).RootElement;

            var nombre_usuario = jsonPayload.GetProperty("nombre_usuario").GetString();
            var rol = jsonPayload.GetProperty("rol").GetString();
            var id_persona = jsonPayload.GetProperty("id_persona").GetString();

            return new AuthResult
            {
                IsAuthenticated = true,
                NombreUsuario = nombre_usuario,
                Rol = rol,
                IdPersona = id_persona
            };
        }

        private object DecodeJwt(string jwt)
        {
            var parts = jwt.Split('.');
            
            if (parts.Length != 3)
            {
                throw new ArgumentException("El JWT no está bien formado.");
            }

            var payload = parts[1];
            var jsonBytes = Convert.FromBase64String(EnsureTrailingEquals(payload));
            return JsonSerializer.Deserialize<object>(jsonBytes);
        }

        private string EnsureTrailingEquals(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: return base64 + "==";
                case 3: return base64 + "=";
                default: return base64;
            }
        }
    }

    public class AuthResult
    {
        public bool IsAuthenticated { get; set; }
        public string NombreUsuario { get; set; }
        public string Rol { get; set; }
        public string IdPersona { get; set; }
    }

    public class LoginResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class ErrorResponse
    {
        public string Message { get; set; }
    }
}