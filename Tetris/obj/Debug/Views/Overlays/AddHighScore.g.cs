﻿#pragma checksum "..\..\..\..\Views\Overlays\AddHighScore.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B8DB532E568E92424834F8019326DAD0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
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


namespace Tetris.Views.Overlays {
    
    
    /// <summary>
    /// AddHighScore
    /// </summary>
    public partial class AddHighScore : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Views\Overlays\AddHighScore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label AHS_score;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Views\Overlays\AddHighScore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AHS_name;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Views\Overlays\AddHighScore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AHS_submit;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Views\Overlays\AddHighScore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AHS_cancel;
        
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
            System.Uri resourceLocater = new System.Uri("/Tetris;component/views/overlays/addhighscore.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Overlays\AddHighScore.xaml"
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
            this.AHS_score = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.AHS_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.AHS_submit = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\..\Views\Overlays\AddHighScore.xaml"
            this.AHS_submit.Click += new System.Windows.RoutedEventHandler(this.AHS_submit_Click_1);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AHS_cancel = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Views\Overlays\AddHighScore.xaml"
            this.AHS_cancel.Click += new System.Windows.RoutedEventHandler(this.AHS_cancel_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

