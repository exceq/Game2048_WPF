﻿#pragma checksum "..\..\..\View\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "21FD805B0375F2FBAD84E067EBC8A273CB5E7243A49D05BD3ED5324F5D50568D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Game2048.ViewModel;
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


namespace Game2048.View {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 63 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Area;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem x2;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem x3;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem x4;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem x6;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem x8;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel sp;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Viewbox GameOverLabel;
        
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
            System.Uri resourceLocater = new System.Uri("/Game2048_WPF;component/view/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\MainWindow.xaml"
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
            
            #line 9 "..\..\..\View\MainWindow.xaml"
            ((Game2048.View.MainWindow)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.Key_Up);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Area = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.x2 = ((System.Windows.Controls.MenuItem)(target));
            
            #line 71 "..\..\..\View\MainWindow.xaml"
            this.x2.Click += new System.Windows.RoutedEventHandler(this.GameChange_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.x3 = ((System.Windows.Controls.MenuItem)(target));
            
            #line 72 "..\..\..\View\MainWindow.xaml"
            this.x3.Click += new System.Windows.RoutedEventHandler(this.GameChange_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.x4 = ((System.Windows.Controls.MenuItem)(target));
            
            #line 73 "..\..\..\View\MainWindow.xaml"
            this.x4.Click += new System.Windows.RoutedEventHandler(this.GameChange_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.x6 = ((System.Windows.Controls.MenuItem)(target));
            
            #line 74 "..\..\..\View\MainWindow.xaml"
            this.x6.Click += new System.Windows.RoutedEventHandler(this.GameChange_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.x8 = ((System.Windows.Controls.MenuItem)(target));
            
            #line 75 "..\..\..\View\MainWindow.xaml"
            this.x8.Click += new System.Windows.RoutedEventHandler(this.GameChange_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 77 "..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Restart_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.sp = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 10:
            
            #line 89 "..\..\..\View\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Undo_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.GameOverLabel = ((System.Windows.Controls.Viewbox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

