﻿#pragma checksum "..\..\..\..\..\userControls\gestionMenu\UserControlVentas.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10E2F00E575DAE99A83545B0CE9F692D30557DBA"
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


namespace Vistas.userControls.gestionMenu {
    
    
    /// <summary>
    /// UserControlVentas
    /// </summary>
    public partial class UserControlVentas : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\..\userControls\gestionMenu\UserControlVentas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridGestionVentas;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\userControls\gestionMenu\UserControlVentas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridCliente;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\..\userControls\gestionMenu\UserControlVentas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgUsers;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\userControls\gestionMenu\UserControlVentas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTitleOption;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\userControls\gestionMenu\UserControlVentas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridEntradas;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\userControls\gestionMenu\UserControlVentas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridVentas;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\userControls\gestionMenu\UserControlVentas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridPasaje;
        
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
            System.Uri resourceLocater = new System.Uri("/Vistas;component/usercontrols/gestionmenu/usercontrolventas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\userControls\gestionMenu\UserControlVentas.xaml"
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
            this.GridGestionVentas = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.GridCliente = ((System.Windows.Controls.Grid)(target));
            
            #line 16 "..\..\..\..\..\userControls\gestionMenu\UserControlVentas.xaml"
            this.GridCliente.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.GridCliente_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.imgUsers = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.lblTitleOption = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.GridEntradas = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.GridVentas = ((System.Windows.Controls.Grid)(target));
            
            #line 26 "..\..\..\..\..\userControls\gestionMenu\UserControlVentas.xaml"
            this.GridVentas.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.GridPasaje_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.GridPasaje = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

