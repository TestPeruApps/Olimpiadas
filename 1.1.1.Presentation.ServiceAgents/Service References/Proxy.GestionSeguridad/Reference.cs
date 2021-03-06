﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Olimpiadas.Presentation.ServiceAgents.Proxy.GestionSeguridad {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="PROMPERU.GestionSeguridadService", ConfigurationName="Proxy.GestionSeguridad.IGestionSeguridadService", SessionMode=System.ServiceModel.SessionMode.NotAllowed)]
    public interface IGestionSeguridadService {
        
        [System.ServiceModel.OperationContractAttribute(Action="PROMPERU.GestionSeguridadService/IGestionSeguridadService/UsuarioListarMenu", ReplyAction="PROMPERU.GestionSeguridadService/IGestionSeguridadService/UsuarioListarMenuRespon" +
            "se")]
        [System.ServiceModel.FaultContractAttribute(typeof(Olimpiadas.Application.Dto.Fault.ServiceErrorResponseDto), Action="PROMPERU.GestionSeguridadService/IGestionSeguridadService/UsuarioListarMenuServic" +
            "eErrorResponseDtoFault", Name="ServiceErrorResponseDto", Namespace="http://schemas.datacontract.org/2004/07/Olimpiadas.Application.Dto.Fault")]
        Olimpiadas.Application.Dto.GestionSeguridad.Usuarios.ObtenerPermisosResponseDto UsuarioListarMenu(short usuarioId);
        
        [System.ServiceModel.OperationContractAttribute(Action="PROMPERU.GestionSeguridadService/IGestionSeguridadService/UsuarioListarMenu", ReplyAction="PROMPERU.GestionSeguridadService/IGestionSeguridadService/UsuarioListarMenuRespon" +
            "se")]
        System.Threading.Tasks.Task<Olimpiadas.Application.Dto.GestionSeguridad.Usuarios.ObtenerPermisosResponseDto> UsuarioListarMenuAsync(short usuarioId);
        
        [System.ServiceModel.OperationContractAttribute(Action="PROMPERU.GestionSeguridadService/IGestionSeguridadService/UsuarioValidarLogin", ReplyAction="PROMPERU.GestionSeguridadService/IGestionSeguridadService/UsuarioValidarLoginResp" +
            "onse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Olimpiadas.Application.Dto.Fault.ServiceErrorResponseDto), Action="PROMPERU.GestionSeguridadService/IGestionSeguridadService/UsuarioValidarLoginServ" +
            "iceErrorResponseDtoFault", Name="ServiceErrorResponseDto", Namespace="http://schemas.datacontract.org/2004/07/Olimpiadas.Application.Dto.Fault")]
        Olimpiadas.Application.Dto.GestionSeguridad.Usuarios.UsuarioDto UsuarioValidarLogin(Olimpiadas.Application.Dto.GestionSeguridad.Usuarios.ValidarLoginRequestDto request);
        
        [System.ServiceModel.OperationContractAttribute(Action="PROMPERU.GestionSeguridadService/IGestionSeguridadService/UsuarioValidarLogin", ReplyAction="PROMPERU.GestionSeguridadService/IGestionSeguridadService/UsuarioValidarLoginResp" +
            "onse")]
        System.Threading.Tasks.Task<Olimpiadas.Application.Dto.GestionSeguridad.Usuarios.UsuarioDto> UsuarioValidarLoginAsync(Olimpiadas.Application.Dto.GestionSeguridad.Usuarios.ValidarLoginRequestDto request);
        
        [System.ServiceModel.OperationContractAttribute(Action="PROMPERU.GestionSeguridadService/IGestionSeguridadService/Prueba", ReplyAction="PROMPERU.GestionSeguridadService/IGestionSeguridadService/PruebaResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Olimpiadas.Application.Dto.Fault.ServiceErrorResponseDto), Action="PROMPERU.GestionSeguridadService/IGestionSeguridadService/PruebaServiceErrorRespo" +
            "nseDtoFault", Name="ServiceErrorResponseDto", Namespace="http://schemas.datacontract.org/2004/07/Olimpiadas.Application.Dto.Fault")]
        string Prueba();
        
        [System.ServiceModel.OperationContractAttribute(Action="PROMPERU.GestionSeguridadService/IGestionSeguridadService/Prueba", ReplyAction="PROMPERU.GestionSeguridadService/IGestionSeguridadService/PruebaResponse")]
        System.Threading.Tasks.Task<string> PruebaAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGestionSeguridadServiceChannel : Olimpiadas.Presentation.ServiceAgents.Proxy.GestionSeguridad.IGestionSeguridadService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GestionSeguridadServiceClient : System.ServiceModel.ClientBase<Olimpiadas.Presentation.ServiceAgents.Proxy.GestionSeguridad.IGestionSeguridadService>, Olimpiadas.Presentation.ServiceAgents.Proxy.GestionSeguridad.IGestionSeguridadService {
        
        public GestionSeguridadServiceClient() {
        }
        
        public GestionSeguridadServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GestionSeguridadServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GestionSeguridadServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GestionSeguridadServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Olimpiadas.Application.Dto.GestionSeguridad.Usuarios.ObtenerPermisosResponseDto UsuarioListarMenu(short usuarioId) {
            return base.Channel.UsuarioListarMenu(usuarioId);
        }
        
        public System.Threading.Tasks.Task<Olimpiadas.Application.Dto.GestionSeguridad.Usuarios.ObtenerPermisosResponseDto> UsuarioListarMenuAsync(short usuarioId) {
            return base.Channel.UsuarioListarMenuAsync(usuarioId);
        }
        
        public Olimpiadas.Application.Dto.GestionSeguridad.Usuarios.UsuarioDto UsuarioValidarLogin(Olimpiadas.Application.Dto.GestionSeguridad.Usuarios.ValidarLoginRequestDto request) {
            return base.Channel.UsuarioValidarLogin(request);
        }
        
        public System.Threading.Tasks.Task<Olimpiadas.Application.Dto.GestionSeguridad.Usuarios.UsuarioDto> UsuarioValidarLoginAsync(Olimpiadas.Application.Dto.GestionSeguridad.Usuarios.ValidarLoginRequestDto request) {
            return base.Channel.UsuarioValidarLoginAsync(request);
        }
        
        public string Prueba() {
            return base.Channel.Prueba();
        }
        
        public System.Threading.Tasks.Task<string> PruebaAsync() {
            return base.Channel.PruebaAsync();
        }
    }
}
