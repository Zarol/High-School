﻿#pragma checksum "..\..\..\..\Job Listing Controls\ApplicationFreeResponseQuestion.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "06E86FD8C218BB683E0E0356145547D1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
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
    /// ApplicationFreeResponseQuestion
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class ApplicationFreeResponseQuestion : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\Job Listing Controls\ApplicationFreeResponseQuestion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderQuestion;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Job Listing Controls\ApplicationFreeResponseQuestion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridQuestion;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Job Listing Controls\ApplicationFreeResponseQuestion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtBlockQuestion;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Job Listing Controls\ApplicationFreeResponseQuestion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle rectMarqueQuestion;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Job Listing Controls\ApplicationFreeResponseQuestion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxAnswer;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Job Listing Controls\ApplicationFreeResponseQuestion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMaxChar;
        
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
            System.Uri resourceLocater = new System.Uri("/LunchMoneyMatch;component/job%20listing%20controls/applicationfreeresponsequesti" +
                    "on.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Job Listing Controls\ApplicationFreeResponseQuestion.xaml"
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
            this.borderQuestion = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.gridQuestion = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.txtBlockQuestion = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.rectMarqueQuestion = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 5:
            this.txtBoxAnswer = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\..\..\Job Listing Controls\ApplicationFreeResponseQuestion.xaml"
            this.txtBoxAnswer.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtBoxAnswer_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lblMaxChar = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
