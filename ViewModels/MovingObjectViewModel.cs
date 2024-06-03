using System.Reactive;
using Avalonia.Media;
using ReactiveUI;

namespace MoveObject.ViewModels;

public class MovingObjectViewModel : ReactiveObject
{
    private double _xPosition;
    private double _yPosition;
    private const double StepSize = 5.0; // Hareket adım büyüklüğü
    private SolidColorBrush _color;
    private double _screenWidth = 800;
    private double _objectWidth = 10;

    public MovingObjectViewModel()
    {
        // Default değerler
        XPosition = 0;
        YPosition = 0;
        Color = SolidColorBrush.Parse("#FF0000"); // Siyah renk atanıyor.
        
        MoveCommand = ReactiveCommand.Create(MoveStep);

    }


    private void MoveStep()
    {
        // Nesnenin XPosition özelliğini adım büyüklüğü kadar artır
        XPosition += StepSize;

        // Ekranın sağ kenarına ulaşıldığında nesneyi ekranın soluna geri götür
        if (XPosition >= (_screenWidth - _objectWidth))
        {
            XPosition = 0;
        }
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

    public ReactiveCommand<Unit, Unit> MoveCommand { get; set; }

}