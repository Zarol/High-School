﻿#pragma checksum "..\..\..\NotificationControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B91F746A47E7E0428D5179E7A96D25A0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LunchMoneyMatch;
using MahApps.Metro.Behaviours;
using MahApps.Metro.Controls;
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


namespace LunchMoneyMatch {
    
    
    /// <summary>
    /// NotificationControl
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class NotificationControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 72 "..\..\..\NotificationControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridRoot;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\NotificationControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridContent;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\NotificationControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblContent;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\NotificationControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblIndex;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\NotificationControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemove;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\NotificationControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUp;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\NotificationControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDown;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LunchMoneyMatch;component/notificationcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\NotificationControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.gridRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.gridContent = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.lblContent = ((System.Windows.Controls.Label)(target));
            
            #line 102 "..\..\..\NotificationControl.xaml"
            this.lblContent.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.lblContent_PreviewMouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lblIndex = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.btnRemove = ((System.Windows.Controls.Button)(target));
            
            #line 104 "..\..\..\NotificationControl.xaml"
            this.btnRemove.Click += new System.Windows.RoutedEventHandler(this.btnRemove_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnUp = ((System.Windows.Controls.Button)(target));
            
            #line 111 "..\..\..\NotificationControl.xaml"
            this.btnUp.Click += new System.Windows.RoutedEventHandler(this.btnUp_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnDown = ((System.Windows.Controls.Button)(target));
            
            #line 118 "..\..\..\NotificationControl.xaml"
            this.btnDown.Click += new System.Windows.RoutedEventHandler(this.btnDown_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

