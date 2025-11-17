using System;
using System.ComponentModel;
using Avalonia.Controls;

namespace WhatTheSize;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    public MainWindow()
    {
        InitializeComponent();
        SizeChanged += (_, _) =>
        {
            Console.WriteLine($"Size changed: {WindowSizeText}");
            Console.WriteLine($"  Actual size: {Width} x {Height}");
            Console.WriteLine($"  Client size: {ClientSize.Width} x {ClientSize.Height}");
            Console.WriteLine($"  Recorded size: {WindowWidth} x {WindowHeight}");
            Console.WriteLine();
            OnPropertyChanged(nameof(WindowSizeText));
        };
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
                    WindowWidth = ClientSize.Width;
                    WindowHeight = ClientSize.Height;
                }
                OnPropertyChanged(nameof(IsFrozen));
            }
        }
    }

    public double WindowWidth
    {
        get => IsFrozen ? field : ClientSize.Width;
        set
        {
            if (value != field)
            {
                field = value;
                OnPropertyChanged(nameof(WindowSizeText));
            }
        }
    }

    public double WindowHeight
    {
        get => IsFrozen ? field : ClientSize.Height;
        set
        {
            if (value != field)
            {
                field = value;
                OnPropertyChanged(nameof(WindowSizeText));
            }
        }
    }

    public string WindowSizeText => $"{WindowWidth} x {WindowHeight}";

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}