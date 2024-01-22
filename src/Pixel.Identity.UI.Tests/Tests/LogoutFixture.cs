﻿using Microsoft.Extensions.Configuration;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Pixel.Identity.UI.Tests.Helpers;
using Pixel.Identity.UI.Tests.PageModels;
using System.Threading.Tasks;

namespace Pixel.Identity.UI.Tests;

[TestFixture, Order(20)]
internal class LogoutFixture : PageTest
{
    private IConfiguration configuration;
    private string baseUrl;
  
    /// <summary>
    /// constructor
    /// </summary>
    public LogoutFixture()
    {
        configuration = ConfigurationFactory.Create();
        baseUrl = configuration["BaseUrl"];
    }

    /// <summary>
    /// Validate that it should be possible to sign out
    /// </summary>
    /// <returns></returns>
    [Ignore("Logout doesn't properly navigate to authentication/logged-out but gets stuck at authentication/logout-callback on docker builds")]
    [Test, Order(1)]
    public async Task Validate_That_Can_Sign_Out()
    {
        var loginPage = new LoginPage(this.Page);      
        await loginPage.GoToAsync(baseUrl);
        await loginPage.LoginAsync(configuration["UserEmail"], configuration["UserSecret"], false);
        var logoutPage = new LogoutPage(this.Page);
        await logoutPage.LogoutAsync();
        await Expect(this.Page.Locator("#loginPageLink")).ToBeVisibleAsync();
    }

}
