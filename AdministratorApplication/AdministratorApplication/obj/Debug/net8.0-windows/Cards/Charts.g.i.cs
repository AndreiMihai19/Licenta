﻿#pragma checksum "..\..\..\..\Cards\Charts.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87F9C7EAF39A7FF468D388F642B1EC05D674A910"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AdministratorApplication.Employee_Status;
using LiveCharts.Wpf;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace AdministratorApplication.Employee_Status {
    
    
    /// <summary>
    /// Charts
    /// </summary>
    public partial class Charts : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\Cards\Charts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AdministratorApplication.Employee_Status.TotalHoursCard totalHourscard1;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Cards\Charts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBNames;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Cards\Charts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBMonths;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\Cards\Charts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBYears;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Admin App;component/cards/charts.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Cards\Charts.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.totalHourscard1 = ((AdministratorApplication.Employee_Status.TotalHoursCard)(target));
            return;
            case 2:
            this.CBNames = ((System.Windows.Controls.ComboBox)(target));
            
            #line 55 "..\..\..\..\Cards\Charts.xaml"
            this.CBNames.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CBNames_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CBMonths = ((System.Windows.Controls.ComboBox)(target));
            
            #line 68 "..\..\..\..\Cards\Charts.xaml"
            this.CBMonths.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CBMonths_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CBYears = ((System.Windows.Controls.ComboBox)(target));
            
            #line 79 "..\..\..\..\Cards\Charts.xaml"
            this.CBYears.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CBYears_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

