using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MoveObject.ViewModels;

namespace MoveObject.Views;

public partial class MovingObjectView : UserControl
{
    public MovingObjectView()
    {
        this.InitializeComponent();
        this.DataContext = new MovingObjectViewModel();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}