// Updated by XamlIntelliSenseFileGenerator 11/27/2020 7:39:37 PM
#pragma checksum "..\..\..\Controls\PlayerTest.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8CDE9AE5CB45DEB3319E83165A8ACC976B50144464F6BFE8749487AFE88FDE28"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Projekt_1.Controls;
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


namespace Projekt_1.Controls
{


    /// <summary>
    /// PlayerTest
    /// </summary>
    public partial class PlayerTest : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Projekt_1;component/controls/playertest.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Controls\PlayerTest.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.myMediaElement = ((System.Windows.Controls.MediaElement)(target));

#line 16 "..\..\..\Controls\PlayerTest.xaml"
                    this.myMediaElement.MediaOpened += new System.Windows.RoutedEventHandler(this.Element_MediaOpened);

#line default
#line hidden

#line 16 "..\..\..\Controls\PlayerTest.xaml"
                    this.myMediaElement.MediaEnded += new System.Windows.RoutedEventHandler(this.Element_MediaEnded);

#line default
#line hidden
                    return;
                case 2:

#line 21 "..\..\..\Controls\PlayerTest.xaml"
                    ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnMouseDownPlayMedia);

#line default
#line hidden
                    return;
                case 3:

#line 24 "..\..\..\Controls\PlayerTest.xaml"
                    ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnMouseDownPauseMedia);

#line default
#line hidden
                    return;
                case 4:

#line 27 "..\..\..\Controls\PlayerTest.xaml"
                    ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnMouseDownStopMedia);

#line default
#line hidden
                    return;
                case 5:
                    this.volumeSlider = ((System.Windows.Controls.Slider)(target));

#line 31 "..\..\..\Controls\PlayerTest.xaml"
                    this.volumeSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.ChangeMediaVolume);

#line default
#line hidden
                    return;
                case 6:
                    this.speedRatioSlider = ((System.Windows.Controls.Slider)(target));

#line 36 "..\..\..\Controls\PlayerTest.xaml"
                    this.speedRatioSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.ChangeMediaSpeedRatio);

#line default
#line hidden
                    return;
                case 7:
                    this.timelineSlider = ((System.Windows.Controls.Slider)(target));

#line 41 "..\..\..\Controls\PlayerTest.xaml"
                    this.timelineSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.SeekToMediaPosition);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }
    }
}

