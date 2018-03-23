//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BlueFetchFeed.www.w3schools.com {
    using System.Diagnostics;
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "7.4.0.1033")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="TempConvertSoap", Namespace="https://www.w3schools.com/xml/")]
    public partial class TempConvert : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback FahrenheitToCelsiusOperationCompleted;
        
        private System.Threading.SendOrPostCallback CelsiusToFahrenheitOperationCompleted;
        
        /// CodeRemarks
        public TempConvert() {
            this.Url = "http://www.w3schools.com/xml/tempconvert.asmx";
        }
        
        public TempConvert(string url) {
            this.Url = url;
        }
        
        /// CodeRemarks
        public event FahrenheitToCelsiusCompletedEventHandler FahrenheitToCelsiusCompleted;
        
        /// CodeRemarks
        public event CelsiusToFahrenheitCompletedEventHandler CelsiusToFahrenheitCompleted;
        
        /// CodeRemarks
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://www.w3schools.com/xml/FahrenheitToCelsius", RequestNamespace="https://www.w3schools.com/xml/", ResponseNamespace="https://www.w3schools.com/xml/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string FahrenheitToCelsius(string Fahrenheit) {
            object[] results = this.Invoke("FahrenheitToCelsius", new object[] {
                        Fahrenheit});
            return ((string)(results[0]));
        }
        
        /// CodeRemarks
        public void FahrenheitToCelsiusAsync(string Fahrenheit) {
            this.FahrenheitToCelsiusAsync(Fahrenheit, null);
        }
        
        /// CodeRemarks
        public void FahrenheitToCelsiusAsync(string Fahrenheit, object userState) {
            if ((this.FahrenheitToCelsiusOperationCompleted == null)) {
                this.FahrenheitToCelsiusOperationCompleted = new System.Threading.SendOrPostCallback(this.OnFahrenheitToCelsiusOperationCompleted);
            }
            this.InvokeAsync("FahrenheitToCelsius", new object[] {
                        Fahrenheit}, this.FahrenheitToCelsiusOperationCompleted, userState);
        }
        
        private void OnFahrenheitToCelsiusOperationCompleted(object arg) {
            if ((this.FahrenheitToCelsiusCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.FahrenheitToCelsiusCompleted(this, new FahrenheitToCelsiusCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// CodeRemarks
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://www.w3schools.com/xml/CelsiusToFahrenheit", RequestNamespace="https://www.w3schools.com/xml/", ResponseNamespace="https://www.w3schools.com/xml/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CelsiusToFahrenheit(string Celsius) {
            object[] results = this.Invoke("CelsiusToFahrenheit", new object[] {
                        Celsius});
            return ((string)(results[0]));
        }
        
        /// CodeRemarks
        public void CelsiusToFahrenheitAsync(string Celsius) {
            this.CelsiusToFahrenheitAsync(Celsius, null);
        }
        
        /// CodeRemarks
        public void CelsiusToFahrenheitAsync(string Celsius, object userState) {
            if ((this.CelsiusToFahrenheitOperationCompleted == null)) {
                this.CelsiusToFahrenheitOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCelsiusToFahrenheitOperationCompleted);
            }
            this.InvokeAsync("CelsiusToFahrenheit", new object[] {
                        Celsius}, this.CelsiusToFahrenheitOperationCompleted, userState);
        }
        
        private void OnCelsiusToFahrenheitOperationCompleted(object arg) {
            if ((this.CelsiusToFahrenheitCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CelsiusToFahrenheitCompleted(this, new CelsiusToFahrenheitCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// CodeRemarks
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
    }
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "7.4.0.1033")]
    public delegate void FahrenheitToCelsiusCompletedEventHandler(object sender, FahrenheitToCelsiusCompletedEventArgs e);
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "7.4.0.1033")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FahrenheitToCelsiusCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal FahrenheitToCelsiusCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// CodeRemarks
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "7.4.0.1033")]
    public delegate void CelsiusToFahrenheitCompletedEventHandler(object sender, CelsiusToFahrenheitCompletedEventArgs e);
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "7.4.0.1033")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CelsiusToFahrenheitCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CelsiusToFahrenheitCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// CodeRemarks
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}