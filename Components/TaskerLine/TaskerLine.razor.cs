using Microsoft.AspNetCore.Components;
using tasker.Models;

namespace tasker.Components.TaskerLine;

public partial class TaskerLine
{
    [Parameter, EditorRequired]
    public TaskerItem? Item { get; set; }
    [Parameter]
    public bool IsCompleted { get; set; }
    [Parameter]
    public EventCallback<TaskerItem> OnDeleteCallBack { get; set; }
    [Parameter]
    public EventCallback<TaskerItem> OnUpdateCallBack { get; set; }

    private async Task deleteItem()
    {
        await OnDeleteCallBack.InvokeAsync(Item);
    }
    private async Task updateItem()
    {
        await OnUpdateCallBack.InvokeAsync(Item);
    }

    private string completed => Item?.IsComplete == true ? "completed" : "";
}