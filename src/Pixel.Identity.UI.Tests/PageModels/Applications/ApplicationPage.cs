﻿using Microsoft.Playwright;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pixel.Identity.UI.Tests.PageModels.Applications;

internal class ApplicationPage
{
    protected readonly IPage page;

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="page"></param>
    public ApplicationPage(IPage page)
    {
        this.page = page;
    }

    /// <summary>
    /// Set client id
    /// </summary>
    /// <param name="clientId"></param>
    /// <returns></returns>
    public async Task SetClientId(string clientId)
    {
        await this.page.Locator("input#txtClientId").FillAsync(clientId);
    }

    /// <summary>
    /// Set display name
    /// </summary>
    /// <param name="displayName"></param>
    /// <returns></returns>
    public async Task SetDisplayName(string displayName)
    {
        await this.page.Locator("input#txtDisplayName").FillAsync(displayName);
    }

    /// <summary>
    /// Set client secret
    /// </summary>
    /// <param name="clientSecret"></param>
    /// <returns></returns>
    public async Task SetClientSecret(string clientSecret)
    {
        await this.page.Locator("input#txtClientSecret").FillAsync(clientSecret);
    }

    /// <summary>
    /// Set json web key set for the client
    /// </summary>
    /// <param name="jsonWebKeySet"></param>
    /// <returns></returns>
    public async Task SetJsonWebKey(string jsonWebKeySet)
    {
        await this.page.Locator("textarea#txtJsonWebKeySet").FillAsync(jsonWebKeySet);
    }

    /// <summary>
    /// Set the application type for client
    /// </summary>
    /// <param name="applicationType"></param>
    /// <returns></returns>
    public async Task SetApplicationType(string applicationType)
    {
        await this.page.Locator("input#cbApplicationType").ClickAsync();
        var count = await this.page.Locator("div.mud-popover-provider div.mud-list div.mud-list-item-text").CountAsync();
        for (int i = 0; i < count; i++)
        {
            if ((await this.page.Locator("div.mud-popover-provider div.mud-list div.mud-list-item-text").Nth(i).InnerTextAsync()).Equals(applicationType))
            {
                await this.page.Locator("div.mud-popover-provider div.mud-list div.mud-list-item-text").Nth(i).ClickAsync();
                break;
            }
        }
    }

    /// <summary>
    /// Select client type in dropdown
    /// </summary>
    /// <returns></returns>
    public async Task SetClientType(string clientType)
    {
        await this.page.Locator("input#cbClientType").ClickAsync();
        var count = await this.page.Locator("div.mud-popover-provider div.mud-list div.mud-list-item-text").CountAsync();
        for (int i = 0; i < count; i++)
        {
            if ((await this.page.Locator("div.mud-popover-provider div.mud-list div.mud-list-item-text").Nth(i).InnerTextAsync()).Equals(clientType))
            {
                await this.page.Locator("div.mud-popover-provider div.mud-list div.mud-list-item-text").Nth(i).ClickAsync();
                break;
            }
        }
    }

    /// <summary>
    /// Select consent type in dropdown
    /// </summary>
    /// <returns></returns>
    public async Task SetConsentType(string consentType)
    {
        await this.page.Locator("input#cbConsentType").ClickAsync();
        var count = await this.page.Locator("div.mud-popover-provider div.mud-list div.mud-list-item-text").CountAsync();
        for (int i = 0; i < count; i++)
        {
            if ((await this.page.Locator("div.mud-popover-provider div.mud-list div.mud-list-item-text").Nth(i).InnerTextAsync()).Equals(consentType))
            {
                await this.page.Locator("div.mud-popover-provider div.mud-list div.mud-list-item-text").Nth(i).ClickAsync();
                break;
            }
        }
    }

    /// <summary>
    /// set redirect uri 
    /// </summary>
    /// <param name="redirectUri"></param>
    /// <returns></returns>
    public async Task AddRedirectUri(IEnumerable<string> redirectUris)
    {
        foreach (var uri in redirectUris)
        {
            await this.page.Locator("button#btnAddRedirectUri").ClickAsync();
            var dialog = this.page.Locator("div[role='dialog']");
            await dialog.Locator("input#txtUri").FillAsync(uri);
            await dialog.Locator("button#btnAddUri").ClickAsync();
        }
    }  

    /// <summary>
    /// remove redirect uri 
    /// </summary>
    /// <param name="redirectUri"></param>
    /// <returns></returns>
    public async Task RemoveRedirectUri(IEnumerable<string> redirectUris)
    {
        foreach (var uri in redirectUris)
        {
            int count = await this.page.Locator("div#redirectUriCollection div.mud-grid-item").CountAsync();
            for (int i = 0; i < count; i++)
            {
                var text = await this.page.Locator("div#redirectUriCollection div.mud-grid-item").Nth(i).InnerTextAsync();
                if (text.Trim().Equals(uri))
                {
                    var deleteButton = this.page.Locator("div#redirectUriCollection div.mud-grid-item button").Nth(i);
                    await deleteButton.ClickAsync();                    
                }
            }
        }
    }

    /// <summary>
    /// set post logout redirect uri 
    /// </summary>
    /// <param name="postLogoutRedirectUri"></param>
    /// <returns></returns>
    public async Task AddPostLogoutRedirectUri(IEnumerable<string> postLogoutRedirectUris)
    {
        foreach (var uri in postLogoutRedirectUris)
        {
            await this.page.Locator("button#btnAddPostLogoutRedirectUri").ClickAsync();
            var dialog = this.page.Locator("div[role='dialog']");
            await dialog.Locator("input#txtUri").FillAsync(uri);
            await dialog.Locator("button#btnAddUri").ClickAsync();
        }
    }

    /// <summary>
    /// remove post logout redirect uri 
    /// </summary>
    /// <param name="redirectUri"></param>
    /// <returns></returns>
    public async Task RemovePostLogoutRedirectUri(IEnumerable<string> postLogoutRedirectUris)
    {
        foreach (var uri in postLogoutRedirectUris)
        {
            int count = await this.page.Locator("div#postLogoutRedirectUriCollection div.mud-grid-item").CountAsync();
            for (int i = 0; i < count; i++)
            {
                var text = await this.page.Locator("div#postLogoutRedirectUriCollection div.mud-grid-item").Nth(i).InnerTextAsync();
                if (text.Trim().Equals(uri))
                {
                    var deleteButton = this.page.Locator("div#postLogoutRedirectUriCollection div.mud-grid-item button").Nth(i);
                    await deleteButton.ClickAsync();
                }
            }
        }
    }

    /// Add specified scope to list of scope permissions
    /// </summary>
    /// <param name="scope"></param>
    /// <returns></returns>
    public async Task<bool> TryAddScope(string scope)
    {
        await this.page.Locator("button#btnAddScope").ClickAsync();
        var dialog = this.page.Locator("div[role='dialog']");
        await dialog.Locator("input.mud-select-input").FillAsync(scope);
        this.page.Locator("div.mud-popover-provider div.mud-list div.mud-list-item-text");
        await this.page.Locator("div.mud-popover-provider div.mud-list div.mud-list-item-text").WaitForAsync(new LocatorWaitForOptions()
        {
             State = WaitForSelectorState.Visible,
             Timeout = 5000
        });
        var exists = (await this.page.Locator("div.mud-popover-provider div.mud-list div.mud-list-item-text").CountAsync()) == 1;
        if (exists)
        {
            await this.page.Locator("div.mud-popover-provider div.mud-list div.mud-list-item-text").ClickAsync();
            await dialog.Locator("button#btnAddScope").ClickAsync();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Add specified permission
    /// </summary>
    /// <returns></returns>
    public async Task AddPermission(string permission)
    {
        int count = await this.page.Locator("#toggleItem").CountAsync();
        for (int i = 0; i < count; i++)
        {
            var text = await this.page.Locator("#toggleItem").Nth(i).InnerTextAsync();
            if (text.Trim().Equals(permission))
            {
                var toggleButton = this.page.Locator("#toggleItem button").Nth(i);
                //await toggleButton.ClickAsync();
                var isPressed = await toggleButton.GetAttributeAsync("aria-pressed");
                if (isPressed?.Equals("false") ?? false)
                {
                    await toggleButton.ClickAsync();
                    break;
                }

            }
        }
    }

    /// <summary>
    /// Remove specified permission
    /// </summary>
    /// <returns></returns>
    public async Task RemovePermission(string permission)
    {
        int count = await this.page.Locator("#toggleItem").CountAsync();
        for (int i = 0; i < count; i++)
        {
            var text = await this.page.Locator("#toggleItem").Nth(i).InnerTextAsync();
            if (text.Trim().Equals(permission))
            {
                var toggleButton = this.page.Locator("#toggleItem button").Nth(i);
                //await toggleButton.ClickAsync();
                var isPressed = await toggleButton.GetAttributeAsync("aria-pressed");
                if (isPressed?.Equals("true") ?? false)
                {
                    await toggleButton.ClickAsync();
                    break;
                }
            }
        }
    }

    /// <summary>
    /// set redirect uri 
    /// </summary>
    /// <param name="redirectUri"></param>
    /// <returns></returns>
    public async Task AddSetting(string key, string value)
    {
        await this.page.Locator("button#btnAddSetting").ClickAsync();
        var dialog = this.page.Locator("div[role='dialog']");
        await dialog.Locator("input#cbSetting").ClickAsync();
        var count = await this.page.Locator("div.mud-popover-provider div.mud-list div.mud-list-item-text").CountAsync();
        for (int i = 0; i < count; i++)
        {
            if ((await this.page.Locator("div.mud-popover-provider div.mud-list div.mud-list-item-text").Nth(i).InnerTextAsync()).Equals(key))
            {
                await this.page.Locator("div.mud-popover-provider div.mud-list div.mud-list-item-text").Nth(i).ClickAsync();
                break;
            }
        }
        await dialog.Locator("input#txtSettingValue").FillAsync(value);
        await dialog.PressAsync("Tab");
        await dialog.Locator("button#btnAddNewSetting").ClickAsync();
    }

    /// <summary>
    /// remove redirect uri 
    /// </summary>
    /// <param name="redirectUri"></param>
    /// <returns></returns>
    public async Task RemoveSetting(string setting)
    {
        int count = await this.page.Locator("div#settingsPanel div.mud-grid-item").CountAsync();
        for (int i = 0; i < count; i++)
        {
            var text = await this.page.Locator("div#settingsPanel div.mud-grid-item").Nth(i).InnerTextAsync();
            if (text.StartsWith(setting))
            {
                var deleteButton = this.page.Locator("div#settingsPanel div.mud-grid-item button").Nth(i);
                await deleteButton.ClickAsync();
            }
        }
    }
}
