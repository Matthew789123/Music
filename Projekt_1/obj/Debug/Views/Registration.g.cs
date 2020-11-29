﻿#pragma checksum "..\..\..\Views\Registration.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2E73BAACBB17903722ED6F6C0446CFFF405B221C24F2BBEFD2076045650868E3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Projekt_1.Views;
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


namespace Projekt_1.Views {
    
    
    /// <summary>
    /// Registration
    /// </summary>
    public partial class Registration : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Views\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UsernameBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Views\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label UsernameError;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Views\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmailBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Views\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label EmailError;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Views\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordBox;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Views\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PasswordBlock;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Views\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PasswordError;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Views\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox ConfirmBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Views\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ConfirmBlock;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Views\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ConfirmationError;
        
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
            System.Uri resourceLocater = new System.Uri("/Projekt_1;component/views/registration.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\Registration.xaml"
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
            this.UsernameBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\..\Views\Registration.xaml"
            this.UsernameBox.LostFocus += new System.Windows.RoutedEventHandler(this.usernameLostFocus);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\Views\Registration.xaml"
            this.UsernameBox.GotFocus += new System.Windows.RoutedEventHandler(this.usernameGotFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UsernameError = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.EmailBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\..\Views\Registration.xaml"
            this.EmailBox.LostFocus += new System.Windows.RoutedEventHandler(this.emailLostFocus);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\Views\Registration.xaml"
            this.EmailBox.GotFocus += new System.Windows.RoutedEventHandler(this.emailGotFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.EmailError = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.PasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 18 "..\..\..\Views\Registration.xaml"
            this.PasswordBox.LostFocus += new System.Windows.RoutedEventHandler(this.passwordLostFocus);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\Views\Registration.xaml"
            this.PasswordBox.GotFocus += new System.Windows.RoutedEventHandler(this.passwordGotFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.PasswordBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.PasswordError = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.ConfirmBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 24 "..\..\..\Views\Registration.xaml"
            this.ConfirmBox.LostFocus += new System.Windows.RoutedEventHandler(this.confirmLostFocus);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\Views\Registration.xaml"
            this.ConfirmBox.GotFocus += new System.Windows.RoutedEventHandler(this.confirmGotFocus);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ConfirmBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.ConfirmationError = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            
            #line 28 "..\..\..\Views\Registration.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.onRegisterButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

