using static CoreFunction.mFunction;

namespace BoTech
{
    public sealed class 网络通讯
    {
        #region 通讯事件

        public static void mTcpData(short Index) //网口接收数据
        {
            if (TcpInfo[Index].Received) //端口收到数据
            {
                TcpInfo[Index].Data = TcpInfo[Index].Data; //本行无实际意义,仅指示收到的数据
                TcpInfo[Index].Received = false; //端口收到状态复位
            }
        }

        #endregion 通讯事件
    }
}