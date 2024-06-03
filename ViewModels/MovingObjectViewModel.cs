using System.Reactive;
using Avalonia.Media;
using ReactiveUI;

namespace MoveObject.ViewModels;

public class MovingObjectViewModel : ReactiveObject
{
    private double _xPosition;
    private double _yPosition;
    private SolidColorBrush _color;

    public MovingObjectViewModel()
    {
        
        // Default değerler
        XPosition = 0;
        YPosition = 0;
        Color = SolidColorBrush.Parse("#FF0000"); // Siyah renk atanıyor.
        
        MoveCommand = ReactiveCommand.Create(() =>
        {
            // Komut işlemleri burada gerçekleştirilir
            Move(10, 10); // Örnek olarak, nesneyi 10 birim sağa ve aşağıya taşıyalım
        });
    }


    public double XPosition
    {
        get => _xPosition;
        set => this.RaiseAndSetIfChanged(ref _xPosition, value);
    }

    public double YPosition
    {
        get => _yPosition;
        set => this.RaiseAndSetIfChanged(ref _yPosition, value);
    }

    public SolidColorBrush Color
    {
        get => _color;
        set => this.RaiseAndSetIfChanged(ref _color, value);
    }
    
    public void Move(double deltaX, double deltaY)
    {
        XPosition += deltaX;
        YPosition += deltaY;
    }
    
    public ReactiveCommand<Unit, Unit> MoveCommand { get; set; }

}