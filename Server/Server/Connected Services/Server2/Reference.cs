﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Server.Server2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Server2.ICalculatorService")]
    public interface ICalculatorService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculatorService/GetSum", ReplyAction="http://tempuri.org/ICalculatorService/GetSumResponse")]
        int GetSum(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculatorService/GetSum", ReplyAction="http://tempuri.org/ICalculatorService/GetSumResponse")]
        System.Threading.Tasks.Task<int> GetSumAsync(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculatorService/GetMultiply", ReplyAction="http://tempuri.org/ICalculatorService/GetMultiplyResponse")]
        int GetMultiply(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculatorService/GetMultiply", ReplyAction="http://tempuri.org/ICalculatorService/GetMultiplyResponse")]
        System.Threading.Tasks.Task<int> GetMultiplyAsync(int a, int b);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICalculatorServiceChannel : Server.Server2.ICalculatorService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalculatorServiceClient : System.ServiceModel.ClientBase<Server.Server2.ICalculatorService>, Server.Server2.ICalculatorService {
        
        public CalculatorServiceClient() {
        }
        
        public CalculatorServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CalculatorServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetSum(int a, int b) {
            return base.Channel.GetSum(a, b);
        }
        
        public System.Threading.Tasks.Task<int> GetSumAsync(int a, int b) {
            return base.Channel.GetSumAsync(a, b);
        }
        
        public int GetMultiply(int a, int b) {
            return base.Channel.GetMultiply(a, b);
        }
        
        public System.Threading.Tasks.Task<int> GetMultiplyAsync(int a, int b) {
            return base.Channel.GetMultiplyAsync(a, b);
        }
    }
}
