﻿#pragma checksum "..\..\..\ClientMenuWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F1FEED4FE362462CE33F70FB45FC4361F5A8FD6E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using VPKS;


namespace VPKS {
    
    
    /// <summary>
    /// ClientMenuWindow
    /// </summary>
    public partial class ClientMenuWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\ClientMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox foodListBox;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\ClientMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTextBox;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\ClientMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox weightTextBox;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\ClientMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox costTextBox;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\ClientMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox caloriesTextBox;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\ClientMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button toCartButton;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\ClientMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label userNameLabel;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\ClientMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exitButton;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\ClientMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cartButton;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\ClientMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button orderHistoryButton;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\ClientMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button currentOrderButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/VPKS;V1.0.0.0;component/clientmenuwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ClientMenuWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.foodListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 30 "..\..\..\ClientMenuWindow.xaml"
            this.foodListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.foodListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.nameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.weightTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.costTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.caloriesTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.toCartButton = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\ClientMenuWindow.xaml"
            this.toCartButton.Click += new System.Windows.RoutedEventHandler(this.toCartButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.userNameLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.exitButton = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\ClientMenuWindow.xaml"
            this.exitButton.Click += new System.Windows.RoutedEventHandler(this.exitButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.cartButton = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\ClientMenuWindow.xaml"
            this.cartButton.Click += new System.Windows.RoutedEventHandler(this.cartButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.orderHistoryButton = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\..\ClientMenuWindow.xaml"
            this.orderHistoryButton.Click += new System.Windows.RoutedEventHandler(this.orderHistoryButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.currentOrderButton = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\ClientMenuWindow.xaml"
            this.currentOrderButton.Click += new System.Windows.RoutedEventHandler(this.currentOrderButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

