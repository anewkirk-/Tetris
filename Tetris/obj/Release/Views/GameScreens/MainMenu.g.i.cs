﻿#pragma checksum "..\..\..\..\Views\GameScreens\MainMenu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F36EBD86CF471ABD3B6DE9819B43DFC9"
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


namespace Tetris.Views.GameScreens {
    
    
    /// <summary>
    /// MainMenu
    /// </summary>
    public partial class MainMenu : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Views\GameScreens\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel MM_mainPanel;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Views\GameScreens\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MM_singlePlayer;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Views\GameScreens\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MM_twoPlayer;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Views\GameScreens\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MM_scoreBoards;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Views\GameScreens\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MM_options;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Views\GameScreens\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MM_quit;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Views\GameScreens\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MM_music;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Views\GameScreens\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MM_sfx;
        
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
            System.Uri resourceLocater = new System.Uri("/Tetris;component/views/gamescreens/mainmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\GameScreens\MainMenu.xaml"
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
            this.MM_mainPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.MM_singlePlayer = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.MM_twoPlayer = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.MM_scoreBoards = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.MM_options = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.MM_quit = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\Views\GameScreens\MainMenu.xaml"
            this.MM_quit.Click += new System.Windows.RoutedEventHandler(this.MM_quit_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.MM_music = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.MM_sfx = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

