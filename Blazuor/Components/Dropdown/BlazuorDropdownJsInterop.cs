using Microsoft.JSInterop;

namespace Blazuor.Components.Dropdown;

public class BlazuorDropdownJsInterop(IJSRuntime IJSRuntime_) : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask = new(() => IJSRuntime_.InvokeAsync<IJSObjectReference>("import", "./_content/Blazuor/js/Dropdown/blazuorDropdownJsInterop.js").AsTask());

    public async ValueTask RegisterBlazuorDropdownOutsideClick(string BlazuorDropdownId, DotNetObjectReference<BlazuorDropdown> BlazuorDropdownRef)
    {
        var module = await moduleTask.Value;

        await module.InvokeVoidAsync("registerBlazuorDropdownOutsideClick", BlazuorDropdownId, BlazuorDropdownRef);
    }

    public async ValueTask UnregisterBlazuorDropdownOutsideClick(string BlazuorDropdownId)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("unregisterBlazuorDropdownOutsideClick", BlazuorDropdownId);
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            try
            {
                var module = await moduleTask.Value;
                await module.InvokeVoidAsync("dispose");
            }
            catch
            {
                // Circuit disconnected during DisposeAsync
            }
        }

        GC.SuppressFinalize(this);
    }
}