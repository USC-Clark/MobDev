using ToDoList;
using System.Collections.ObjectModel;
using System.Linq;

namespace ToDoList;

public partial class MainPage : ContentPage
{
    ObservableCollection<ToDoClass> todoList = new();
    int selectedId = -1;

    public MainPage()
    {
        InitializeComponent();
        todoLV.ItemsSource = todoList;
    }

    private void AddToDoItem(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(titleEntry.Text))
            return;

        todoList.Add(new ToDoClass
        {
            id = todoList.Count + 1,
            title = titleEntry.Text,
            detail = detailsEditor.Text
        });

        ResetForm();
    }

    private void DeleteToDoItem(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        int id = int.Parse(btn.ClassId);

        var item = todoList.FirstOrDefault(x => x.id == id);
        if (item != null)
            todoList.Remove(item);
    }

    private void EditToDoItem(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        int id = int.Parse(btn.ClassId);

        var item = todoList.FirstOrDefault(x => x.id == id);
        if (item == null) return;

        selectedId = id;

        titleEntry.Text = item.title;
        detailsEditor.Text = item.detail;

        addBtn.IsVisible = false;
        editBtn.IsVisible = true;
        cancelBtn.IsVisible = true;
    }

    private void SaveEdit(object sender, EventArgs e)
    {
        var item = todoList.FirstOrDefault(x => x.id == selectedId);
        if (item == null) return;

        item.title = titleEntry.Text;
        item.detail = detailsEditor.Text;

        ResetForm();
    }

    private void CancelEdit(object sender, EventArgs e)
    {
        ResetForm();
    }

    private void ResetForm()
    {
        titleEntry.Text = "";
        detailsEditor.Text = "";

        addBtn.IsVisible = true;
        editBtn.IsVisible = false;
        cancelBtn.IsVisible = false;

        selectedId = -1;
    }
}