﻿#pragma checksum "..\..\AddPlaylistDialog.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A52A9E64BB2DE067441AE4D73E57FB7A635B3385CBBB0FADCE76A6440E3E34D9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Projekt_1;
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


namespace Projekt_1 {
    
    
    /// <summary>
    /// AddPlaylistDialog
    /// </summary>
    public partial class AddPlaylistDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\AddPlaylistDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LoginBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\AddPlaylistDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NewPlaylistName;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\AddPlaylistDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn;
        
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
            System.Uri resourceLocater = new System.Uri("/Projekt_1;component/addplaylistdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddPlaylistDialog.xaml"
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
            this.LoginBox = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.NewPlaylistName = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\AddPlaylistDialog.xaml"
            this.NewPlaylistName.LostFocus += new System.Windows.RoutedEventHandler(this.textBoxLostFocus);
            
            #line default
            #line hidden
            
            #line 14 "..\..\AddPlaylistDialog.xaml"
            this.NewPlaylistName.GotFocus += new System.Windows.RoutedEventHandler(this.textBoxGotFocus);
            
            #line default
            #line hidden
            
            #line 14 "..\..\AddPlaylistDialog.xaml"
            this.NewPlaylistName.KeyDown += new System.Windows.Input.KeyEventHandler(this.EnterDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\AddPlaylistDialog.xaml"
            this.btn.Click += new System.Windows.RoutedEventHandler(this.onCreateClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 21 "..\..\AddPlaylistDialog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.oncloseClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

