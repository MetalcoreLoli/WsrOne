﻿#pragma checksum "..\..\..\..\View\TaskView\EditTaskWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4BAA13CF4A99F02ADA84BABB5D27B2AC12887B684C1D640ACF6A9DC052709C59"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Wsr1.View.TaskView;
using Wsr1.ViewModel;


namespace Wsr1.View.TaskView {
    
    
    /// <summary>
    /// EditTaskWindow
    /// </summary>
    public partial class EditTaskWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\View\TaskView\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wsr1.ViewModel.TaskViewModel taskVM;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\View\TaskView\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TitleBox;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\View\TaskView\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DifficultBox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\View\TaskView\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox NatureOfWorkBox;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\View\TaskView\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox StatusBox;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\View\TaskView\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateTimeBox;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\..\View\TaskView\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox GroupBox;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\..\View\TaskView\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ExecutorInGroup;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\..\View\TaskView\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButton;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\..\..\View\TaskView\EditTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DoneButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Wsr1;component/view/taskview/edittaskwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\TaskView\EditTaskWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.taskVM = ((Wsr1.ViewModel.TaskViewModel)(target));
            return;
            case 2:
            this.TitleBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.DifficultBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.NatureOfWorkBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.StatusBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.DateTimeBox = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.GroupBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.ExecutorInGroup = ((System.Windows.Controls.ListBox)(target));
            return;
            case 9:
            this.BackButton = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.DoneButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

