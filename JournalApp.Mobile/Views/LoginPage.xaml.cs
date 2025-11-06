using Microsoft.Identity.Client;
using System.Diagnostics;
using JournalApp.Mobile.Helpers;

namespace JournalApp.Mobile.Views;

public partial class LoginPage : ContentPage
{
	// Read sensitive values from environment variables or user secrets
	private static readonly string ClientId = AppConfig.Get("JournalApp_ClientId");
	private static readonly string TenantId = AppConfig.Get("JournalApp_TenantId");
	private static readonly string RedirectUri = AppConfig.Get("JournalApp_RedirectUri");

	private IPublicClientApplication _pca;
	private AuthenticationResult? _authResult;

	public LoginPage()
	{
		InitializeComponent();
		_pca = PublicClientApplicationBuilder
			.Create(ClientId)
			.WithTenantId(TenantId)
			.WithRedirectUri(RedirectUri)
			.Build();
	}

	private async void OnLoginClicked(object sender, EventArgs e)
	{
		var scopes = new[] { "User.Read" };
		try
		{
			_authResult = await _pca.AcquireTokenInteractive(scopes)
				.WithParentActivityOrWindow(App.Current.MainPage)
				.ExecuteAsync();
			// TODO: Store _authResult.AccessToken securely (e.g., SecureStorage)
			// Use token for authenticated API calls
			// Navigate to main app page on success
		}
		catch (MsalException ex)
		{
			await DisplayAlert("Login Failed", ex.Message, "OK");
		}
	}

	private async void OnLogoutClicked(object sender, EventArgs e)
	{
		try
		{
			var accounts = await _pca.GetAccountsAsync();
			foreach (var account in accounts)
			{
				await _pca.RemoveAsync(account);
			}
			_authResult = null;
			// TODO: Remove token from SecureStorage
			// Redirect to login screen
		}
		catch (Exception ex)
		{
			Debug.WriteLine($"Logout failed: {ex.Message}");
		}
	}

	// TODO: Use SecureStorage for token management
	// You may need to add platform-specific configuration for SecureStorage
}