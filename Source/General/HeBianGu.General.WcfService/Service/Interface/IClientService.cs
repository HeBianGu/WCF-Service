using System;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace HeBianGu.General.WcfService
{
    /// <summary> Wcf服务调用接口客户端调用 </summary>
    public interface IClientService
    {
        /// <summary>
        /// 客户端调用带有callback的服务
        /// </summary>
        /// <typeparam name="I"> 接口 </typeparam>
        /// <typeparam name="R"> 返回值 </typeparam>
        /// <typeparam name="C"> callback类型 </typeparam>
        /// <param name="action"> 执行的方法 </param>
        /// <param name="callBack"> callback </param>
        /// <returns></returns>
        R DuplexCall<I,R,C>(Func<I, R> action, C callBack) where I : class where R : class, ICallResult;

        /// <summary>
        /// 客户端调用服务
        /// </summary>
        /// <typeparam name="I"> 接口 </typeparam>
        /// <typeparam name="R"> 返回值 </typeparam>
        /// <param name="action"> 执行接口的方法 </param>
        /// <returns></returns>
        R Call<I, R>(Func<I, R> action) where R : class, ICallResult;


        /// <summary>
        /// 客户端调用带有callback的服务
        /// </summary>
        /// <typeparam name="I"> 接口 </typeparam>
        /// <typeparam name="R"> 返回值 </typeparam>
        /// <typeparam name="C"> callback类型 </typeparam>
        /// <param name="action"> 执行的方法 </param>
        /// <param name="callBack"> callback </param>
        /// <returns></returns>
        Task<R> DuplexCallAsync<I, R, C>(Func<I, R> action, C callBack) where I : class where R : class, ICallResult;

        /// <summary>
        /// 客户端调用服务
        /// </summary>
        /// <typeparam name="I"> 接口 </typeparam>
        /// <typeparam name="R"> 返回值 </typeparam>
        /// <param name="action"> 执行接口的方法 </param>
        /// <returns></returns>
        Task<R> CallAsync<I, R>(Func<I, R> action) where R : class, ICallResult;

    }
}