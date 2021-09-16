using System;
using System.ServiceModel.Channels;

namespace HeBianGu.General.WcfService
{
    /// <summary> Wcf服务调用接口 服务端调用 </summary>
    public interface IServerService
    {
        /// <summary> 用于注册服务端服务 I 接口 instance 实现 </summary>
        void Register<I>(object instance);

        /// <summary> 用于注册服务端服务 I 接口 T 实现 </summary>
        void Register<I, T>() where T : class;

        /// <summary> 用于注册服务端服务 I 接口 T 实现 Param 初始化绑定参数 </summary>
        void Register<I, T>(Action<Binding> bindingBuilder = null) where T : class;
    }
}