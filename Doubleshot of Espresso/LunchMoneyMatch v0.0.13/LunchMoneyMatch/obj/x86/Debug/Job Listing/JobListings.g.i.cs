﻿#pragma checksum "..\..\..\..\Job Listing\JobListings.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5DBA38ADCC1E50ADF4C72536350273A0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
        
        
        #line 28 "..\..\..\..\Job Listing\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridRoot;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Job Listing\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridMatchRange;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Job Listing\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMatchRange;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Job Listing\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.RangeSlider rangeSliderMatch;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Job Listing\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblLeftBound;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Job Listing\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblRightBound;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Job Listing\JobListings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFilter;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Job Listing\JobListings.xaml"
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
            System.Uri resourceLocater = new System.Uri("/LunchMoneyMatch;component/job%20listing/joblistings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Job Listing\JobListings.xaml"
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
            
            #line 28 "..\..\..\..\Job Listing\JobListings.xaml"
            this.gridRoot.Loaded += new System.Windows.RoutedEventHandler(this.gridRoot_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.gridMatchRange = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.lblMatchRange = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.rangeSliderMatch = ((MahApps.Metro.Controls.RangeSlider)(target));
            return;
            case 5:
            this.lblLeftBound = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblRightBound = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.txtFilter = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

