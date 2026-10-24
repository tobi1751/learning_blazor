using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Microsoft.VisualBasic;
using tasker.Models;

namespace tasker.Pages.Tasker;

public partial class Tasker
{
    private TaskerItem taskerItem = new();
    private List<TaskerItem> taskerItemsList = new();
    private InputText? textBoxTask { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadListAsync();
    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await textBoxTask!.Element!.Value.FocusAsync();
        }
    }

    private async Task addTask()
    {
        taskerItem.Id = Guid.NewGuid();
        taskerItemsList.Add(taskerItem);

        taskerItem = new();

        await SaveListAsync();
        await textBoxTask!.Element!.Value.FocusAsync();
    }

    private async void deleteTask(TaskerItem item)
    {
        taskerItemsList.Remove(item);
        await SaveListAsync();
    }
    private async void updateItem(TaskerItem item)
    {
        await SaveListAsync();
    }
    private async Task SaveListAsync()
    {
        string? taskerItemJson = JsonSerializer.Serialize(taskerItemsList);

        await JS.InvokeVoidAsync("localStorage.setItem", "TaskerList", taskerItemJson);
    }

    private async Task LoadListAsync()
    {
        try
        {
            string? taskerItemsJson = await JS.InvokeAsync<string>("localStorage.getItem", "TaskerList") ?? "[]";

            taskerItemsList = JsonSerializer.Deserialize<List<TaskerItem>>(taskerItemsJson)!;
        }
        catch
        {
            taskerItemsList = new();
            await SaveListAsync();
        }
    }
}