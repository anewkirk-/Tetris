﻿#pragma checksum "..\..\..\..\Views\GameScreens\SinglePlayerGame.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B9072334DD290796BD9EC57917BB805C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
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
    /// SinglePlayerGame
    /// </summary>
    public partial class SinglePlayerGame : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\Views\GameScreens\SinglePlayerGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel SPG_mainPanel;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Views\GameScreens\SinglePlayerGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid SPG_playerOne_grid;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Views\GameScreens\SinglePlayerGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image SPG_playerOne_nextBlock;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Views\GameScreens\SinglePlayerGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label SPG_playerOne_score;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Views\GameScreens\SinglePlayerGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SPG_pause;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\Views\GameScreens\SinglePlayerGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SPG_save;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Views\GameScreens\SinglePlayerGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SPG_quit;
        
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
            System.Uri resourceLocater = new System.Uri("/Tetris;component/views/gamescreens/singleplayergame.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\GameScreens\SinglePlayerGame.xaml"
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
            this.SPG_mainPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.SPG_playerOne_grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.SPG_playerOne_nextBlock = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.SPG_playerOne_score = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.SPG_pause = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.SPG_save = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.SPG_quit = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

