﻿using System;
using System.Windows;
using Marten.Schema.Identity;

namespace Arbor.Guidy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GenerateAndShowNewGuid();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            GenerateAndShowNewGuid();
        }

        private void GenerateAndShowNewGuid()
        {
            Guid guid = GenerateNewGuid();

            GuidTextBox.Text = FormatGuid(guid);

            try
            {
                DateTimeOffset dateTimeOffset = CombGuidIdGeneration.GetTimestamp(guid);

                if (dateTimeOffset.Date > new DateTime(1900, 1, 1) && dateTimeOffset.Date < new DateTime(2200, 1, 1))
                {
                    CombGuidDateLabel.Content = dateTimeOffset.DateTime.ToString("O");
                }
                else
                {
                    ShowNoCombGuid("Date of out range");
                }
            }
            catch (Exception ex)
            {
                ShowNoCombGuid(ex.Message);
            }
        }


        private void ShowNoCombGuid(string message)
        {
            CombGuidDateLabel.Content = $"Not a COMB GUID {message}";
        }

        private string FormatGuid(Guid guid)
        {
            return guid.ToString().ToUpperInvariant();
        }

        private Guid GenerateNewGuid()
        {
            Guid resultGuid = StandardGuidRadioButton.IsChecked.IsTrue()
                ? Guid.NewGuid()
                : CombGuidIdGeneration.NewGuid();

            return resultGuid;
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(GuidTextBox.Text))
            {
                Clipboard.SetText(GuidTextBox.Text);
            }
        }
    }

    public static class BoolExtensions
    {
        public static bool IsTrue(this bool? value)
        {
            return value.HasValue && value.Value;
        }
    }
}