using System;
using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;

namespace WhatTheSize;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    public MainWindow()
    {
        InitializeComponent();
        SizeChanged += (_, _) =>
        {
            var size = GetSize();
            TextBlock_Size.Text = $"{size.Width} x {size.Height}";
        };
    }

    public void CheckBox_Checked(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        savedSize = ClientSize;
        isFrozen = true;
    }

    public void CheckBox_Unchecked(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        isFrozen = false;
        var size = GetSize();
        TextBlock_Size.Text = $"{size.Width} x {size.Height}";
    }

    private Size GetSize()
    {
        return isFrozen ? savedSize : ClientSize;
    }

    private bool isFrozen = false;
    private Size savedSize;
}