using Microsoft.AspNetCore.Components;

namespace tasker.Components.Message;

public partial class Message
{
    [Parameter, EditorRequired]
    public string DisplayMessage { get; set; } = "";
    [Parameter]
    public string Title { get; set; } = "";
    [Parameter, EditorRequired]
    public string CssClass { get; set; } = "";
}