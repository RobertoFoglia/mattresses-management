﻿#pragma checksum "C:\Users\Fogli\Desktop\Activities\Personal\Repositories\mattresses-management\mattresses-management\mattresses-management\Views\ShellPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "017A25216CD85AC61F98F7B789E0ECEA7F2873F7B891F9FFD956DC9E0BF1C170"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mattresses_management.Views
{
    partial class ShellPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Microsoft_UI_Xaml_Controls_NavigationView_IsBackEnabled(global::Microsoft.UI.Xaml.Controls.NavigationView obj, global::System.Boolean value)
            {
                obj.IsBackEnabled = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_NavigationView_SelectedItem(global::Microsoft.UI.Xaml.Controls.NavigationView obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.SelectedItem = value;
            }
            public static void Set_mattresses_management_Behaviors_NavigationViewHeaderBehavior_DefaultHeader(global::mattresses_management.Behaviors.NavigationViewHeaderBehavior obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.DefaultHeader = value;
            }
            public static void Set_Microsoft_Xaml_Interactions_Core_InvokeCommandAction_Command(global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.Command = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class ShellPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IShellPage_Bindings
        {
            private global::mattresses_management.Views.ShellPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Microsoft.UI.Xaml.Controls.NavigationView obj2;
            private global::mattresses_management.Behaviors.NavigationViewHeaderBehavior obj3;
            private global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction obj4;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj2IsBackEnabledDisabled = false;
            private static bool isobj2SelectedItemDisabled = false;
            private static bool isobj3DefaultHeaderDisabled = false;
            private static bool isobj4CommandDisabled = false;

            private ShellPage_obj1_BindingsTracking bindingsTracking;

            public ShellPage_obj1_Bindings()
            {
                this.bindingsTracking = new ShellPage_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 20 && columnNumber == 13)
                {
                    isobj2IsBackEnabledDisabled = true;
                }
                else if (lineNumber == 21 && columnNumber == 13)
                {
                    isobj2SelectedItemDisabled = true;
                }
                else if (lineNumber == 39 && columnNumber == 21)
                {
                    isobj3DefaultHeaderDisabled = true;
                }
                else if (lineNumber == 52 && columnNumber == 45)
                {
                    isobj4CommandDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // Views\ShellPage.xaml line 17
                        this.obj2 = (global::Microsoft.UI.Xaml.Controls.NavigationView)target;
                        break;
                    case 3: // Views\ShellPage.xaml line 37
                        this.obj3 = (global::mattresses_management.Behaviors.NavigationViewHeaderBehavior)target;
                        break;
                    case 4: // Views\ShellPage.xaml line 52
                        this.obj4 = (global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction)target;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IShellPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::mattresses_management.Views.ShellPage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::mattresses_management.Views.ShellPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel(obj.ViewModel, phase);
                    }
                }
            }
            private void Update_ViewModel(global::mattresses_management.ViewModels.ShellViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ViewModel(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_IsBackEnabled(obj.IsBackEnabled, phase);
                        this.Update_ViewModel_Selected(obj.Selected, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_ItemInvokedCommand(obj.ItemInvokedCommand, phase);
                    }
                }
            }
            private void Update_ViewModel_IsBackEnabled(global::System.Boolean obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\ShellPage.xaml line 17
                    if (!isobj2IsBackEnabledDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_NavigationView_IsBackEnabled(this.obj2, obj);
                    }
                }
            }
            private void Update_ViewModel_Selected(global::Microsoft.UI.Xaml.Controls.NavigationViewItem obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ViewModel_Selected(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_Selected_Content(obj.Content, phase);
                    }
                }
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\ShellPage.xaml line 17
                    if (!isobj2SelectedItemDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_NavigationView_SelectedItem(this.obj2, obj, null);
                    }
                }
            }
            private void Update_ViewModel_Selected_Content(global::System.Object obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\ShellPage.xaml line 37
                    if (!isobj3DefaultHeaderDisabled)
                    {
                        XamlBindingSetters.Set_mattresses_management_Behaviors_NavigationViewHeaderBehavior_DefaultHeader(this.obj3, obj, null);
                    }
                }
            }
            private void Update_ViewModel_ItemInvokedCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\ShellPage.xaml line 52
                    if (!isobj4CommandDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_Xaml_Interactions_Core_InvokeCommandAction_Command(this.obj4, obj, null);
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class ShellPage_obj1_BindingsTracking
            {
                private global::System.WeakReference<ShellPage_obj1_Bindings> weakRefToBindingObj; 

                public ShellPage_obj1_BindingsTracking(ShellPage_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<ShellPage_obj1_Bindings>(obj);
                }

                public ShellPage_obj1_Bindings TryGetBindingObject()
                {
                    ShellPage_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_ViewModel(null);
                    UpdateChildListeners_ViewModel_Selected(null);
                }

                public void PropertyChanged_ViewModel(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    ShellPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::mattresses_management.ViewModels.ShellViewModel obj = sender as global::mattresses_management.ViewModels.ShellViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_ViewModel_IsBackEnabled(obj.IsBackEnabled, DATA_CHANGED);
                                bindings.Update_ViewModel_Selected(obj.Selected, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "IsBackEnabled":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_IsBackEnabled(obj.IsBackEnabled, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "Selected":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_Selected(obj.Selected, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::mattresses_management.ViewModels.ShellViewModel cache_ViewModel = null;
                public void UpdateChildListeners_ViewModel(global::mattresses_management.ViewModels.ShellViewModel obj)
                {
                    if (obj != cache_ViewModel)
                    {
                        if (cache_ViewModel != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_ViewModel).PropertyChanged -= PropertyChanged_ViewModel;
                            cache_ViewModel = null;
                        }
                        if (obj != null)
                        {
                            cache_ViewModel = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_ViewModel;
                        }
                    }
                }
                public void DependencyPropertyChanged_ViewModel_Selected_Content(global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop)
                {
                    ShellPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::Microsoft.UI.Xaml.Controls.NavigationViewItem obj = sender as global::Microsoft.UI.Xaml.Controls.NavigationViewItem;
                        if (obj != null)
                        {
                            bindings.Update_ViewModel_Selected_Content(obj.Content, DATA_CHANGED);
                        }
                    }
                }
                private global::Microsoft.UI.Xaml.Controls.NavigationViewItem cache_ViewModel_Selected = null;
                private long tokenDPC_ViewModel_Selected_Content = 0;
                public void UpdateChildListeners_ViewModel_Selected(global::Microsoft.UI.Xaml.Controls.NavigationViewItem obj)
                {
                    if (obj != cache_ViewModel_Selected)
                    {
                        if (cache_ViewModel_Selected != null)
                        {
                            cache_ViewModel_Selected.UnregisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.ContentControl.ContentProperty, tokenDPC_ViewModel_Selected_Content);
                            cache_ViewModel_Selected = null;
                        }
                        if (obj != null)
                        {
                            cache_ViewModel_Selected = obj;
                            tokenDPC_ViewModel_Selected_Content = obj.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.ContentControl.ContentProperty, DependencyPropertyChanged_ViewModel_Selected_Content);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\ShellPage.xaml line 17
                {
                    this.navigationView = (global::Microsoft.UI.Xaml.Controls.NavigationView)(target);
                }
                break;
            case 3: // Views\ShellPage.xaml line 37
                {
                    this.navigationViewHeaderBehavior = (global::mattresses_management.Behaviors.NavigationViewHeaderBehavior)(target);
                }
                break;
            case 6: // Views\ShellPage.xaml line 56
                {
                    this.shellFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // Views\ShellPage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    ShellPage_obj1_Bindings bindings = new ShellPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

