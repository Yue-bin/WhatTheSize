using System.ComponentModel;
using Avalonia.Controls;

namespace WhatTheSize;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public bool IsFrozen
    {
        get;
        set
        {
            if (value != field)
            {
                field = value;
                if (value)
                {
                    WindowWidth = Width;
                    WindowHeight = Height;
                }
                OnPropertyChanged(nameof(IsFrozen));
            }
        }
    }

    public double WindowWidth
    {
        get => IsFrozen ? Width : field;
        set
        {
            if (value != field)
            {
                field = value;
                OnPropertyChanged(nameof(WindowWidth));
            }
        }
    }

    public double WindowHeight
    {
        get => IsFrozen ? Height : field;
        set
        {
            if (value != field)
            {
                field = value;
                OnPropertyChanged(nameof(WindowHeight));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}