﻿#pragma checksum "..\..\..\..\Job Listing Controls\JobListings.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DD40C52A9EAB3657828AFCEDBDEFD18B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
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
    /// JobListings
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class JobListings : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\..\Job Listing Controls\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridRoot;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Job Listing Controls\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridItems;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Job Listing Controls\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition columnItems;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Job Listing Controls\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition columnApplication;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Job Listing Controls\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelMatches;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Job Listing Controls\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridSplitter gridSplitterMain;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Job Listing Controls\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.MetroContentControl contentControlApplication;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Job Listing Controls\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridJobApplication;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\Job Listing Controls\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridMatchRange;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Job Listing Controls\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMatchRange;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Job Listing Controls\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.RangeSlider rangeSliderMatch;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Job Listing Controls\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblLeftBound;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Job Listing Controls\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblRightBound;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\Job Listing Controls\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFilter;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Job Listing Controls\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;
        
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
            System.Uri resourceLocater = new System.Uri("/LunchMoneyMatch;component/job%20listing%20controls/joblistings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Job Listing Controls\JobListings.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 30 "..\..\..\..\Job Listing Controls\JobListings.xaml"
            this.gridRoot.Loaded += new System.Windows.RoutedEventHandler(this.gridRoot_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.gridItems = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.columnItems = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 4:
            this.columnApplication = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 5:
            this.stackPanelMatches = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.gridSplitterMain = ((System.Windows.Controls.GridSplitter)(target));
            return;
            case 7:
            this.contentControlApplication = ((MahApps.Metro.Controls.MetroContentControl)(target));
            return;
            case 8:
            this.gridJobApplication = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.gridMatchRange = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            this.lblMatchRange = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.rangeSliderMatch = ((MahApps.Metro.Controls.RangeSlider)(target));
            return;
            case 12:
            this.lblLeftBound = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.lblRightBound = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.txtFilter = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\..\Job Listing Controls\JobListings.xaml"
            this.btnSearch.Click += new System.Windows.RoutedEventHandler(this.btnSearch_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

