using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;

namespace AvaloniaApplication1.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        Tasks = CreateTasks();
    }

    private List<ProjectTask> CreateTasks()
    {
        List<ProjectTask> projectTasks = new();
        projectTasks.Add(new() { Name = "'Trade Central' Web Site" });
        projectTasks.Add(new() { Name = "'Six Sigma' Mobile App" });
        projectTasks[0].Tasks.Add(new() { Name = "Market research", HighPriority = true });
        projectTasks[0].Tasks.Add(new() { Name = "Create a sitemap" });
        projectTasks[1].Tasks.Add(new() { Name = "Define objectives and requirements" });
        projectTasks[1].Tasks.Add(new() { Name = "Design UI/UX" });
        return projectTasks;    
    }

    public List<ProjectTask> Tasks { get; }

    [RelayCommand]
    public void Update()
    {
        Tasks[0].Tasks[1].HighPriority = !Tasks[0].Tasks[1].HighPriority;
    }
}

public partial class ProjectTask : ObservableObject
{
    [ObservableProperty]  
    private bool highPriority;

    [ObservableProperty]
    private string? name;


    public List<ProjectTask> Tasks { get; } = new();

    public bool HasTasks => Tasks.Count > 0;
}