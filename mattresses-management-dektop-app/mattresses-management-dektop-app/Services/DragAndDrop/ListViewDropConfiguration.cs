﻿using System.Windows.Input;

using Windows.UI.Xaml;

namespace mattresses_management_dektop_app.Services.DragAndDrop
{
    public class ListViewDropConfiguration : DropConfiguration
    {
        public static readonly DependencyProperty DragItemsStartingCommandProperty =
            DependencyProperty.Register("DragItemsStartingCommand", typeof(ICommand), typeof(DropConfiguration), new PropertyMetadata(null));

        public static readonly DependencyProperty DragItemsCompletedCommandProperty =
            DependencyProperty.Register("DragItemsCompletedCommand", typeof(ICommand), typeof(DropConfiguration), new PropertyMetadata(null));

        public ICommand DragItemsStartingCommand
        {
            get { return (ICommand)GetValue(DragItemsStartingCommandProperty); }
            set { SetValue(DragItemsStartingCommandProperty, value); }
        }

        public ICommand DragItemsCompletedCommand
        {
            get { return (ICommand)GetValue(DragItemsCompletedCommandProperty); }
            set { SetValue(DragItemsCompletedCommandProperty, value); }
        }
    }
}
