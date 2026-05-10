using Microsoft.VisualBasic;
using MotionFunction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using UserHelper;
using static BoTech.网络通讯;
using static CoreFunction.mFunction;
using static FilePath.mFilePath;

namespace BoTech
{
    internal sealed class 窗体加载
    {
        #region 工程窗体初始化

        public static void me_Initial()
        {
            ManagedThreadId = Thread.CurrentThread.ManagedThreadId;
            ExeIsRun = true;      //程序已运行
            SysState = State.WAITRESET;
            IsSysStop = false;

            GetPar();        //获取参数
            TCPIPInitial();  //TCP初始化

            //加载工站信息
            StaLoad.TaskLoad();

            MotionDll.SetSpeedRatio(1);// 整体AXIS的速度百分比参数，参数设置为0-1

            MotionDll.CardLoad(1, (short)Card_Num); //卡初始化，返回值请转换为二进制再按位判断

            if (!CardIndex[1].CardOpen)
            {
                Interaction.MsgBox("卡加载失败，请检查！", MsgBoxStyle.Information, "提示");
            }

            SysState = State.WAITRESET;
            mGlobal.IsLoadFrmEngineering = true;


        }

        public static void GetPar()  //获取重要系统参数
        {
            #region "参数读取"

            ReadXml($"{BZ_ExePath}SysPar.xml", ref SysPar);    //读取系统关键参数
            ReadXml($"{BZ_ExePath}Station.xml", ref mStation); //读取工位相关参数
            ReadXml($"{BZ_ExePath}ErrCode.xml", ref mErrCode); // 读取错误码相关参数
            ReadXml($"{BZ_ParPath}CardPar.xml", ref CardIndex); //读取卡配置相关参数
            ReadXml($"{BZ_ParPath}ParInput.xml", ref m_Input); //读取输入相关参数
            ReadXml($"{BZ_ParPath}ParOutput.xml", ref m_Output); //读取输出相关参数
            ReadXml($"{BZ_ParPath}ParMachine.xml", ref AxisIndex); //读取轴相关参数
            ReadPosData($"{BZ_ParPath}PosData.dat", ref Pos); //读取点位参数
            ReadXml($"{BZ_ParPath}ParData.xml", ref mParList); //读取设定及补偿参数
            ReadXml($"{BZ_ParPath}PortData.xml", ref mCommPar); //读取通讯相关参数

            #endregion "参数读取"

            Card_Num = SysPar.CardNum;          //卡数量设定
            Axis_Num = SysPar.AxisNum;          //轴数量设定
            Input_Num = SysPar.InputNum;        //输入点数量设定
            Output_Num = SysPar.OutputNum;      //输出点数量设定
            Conveyor_Num = SysPar.ConveyorNum;  //流水线数量设定
            Par_Num = SysPar.ParNum;            //参数数量设定
            MotionDll.GetCardPar(SysPar.CardNum);     //将系统卡参数传递给底层函数
            MotionDll.GetAxisPar(SysPar.AxisNum);  //将系统轴参数传递给底层函数
        }

        public static void TCPIPInitial()
        {
            try
            {
                Zcm2018.PublicPar.TcpLoad(SysPar.TcpIPNum, SysPar.TcpIPStart);
                for (int i = SysPar.TcpIPStart; i <= SysPar.TcpIPStart + SysPar.TcpIPNum - 1; i++)
                {
                    TcpIP[i].PortOpen();
                    TcpIP[i].mDataRec += mTcpData;
                }
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
            }
        }

        #endregion 工程窗体初始化

        #region ICT新增需求

        /// <summary>
        /// 新界面，错误码读取；
        /// </summary>
        public static void ReadAlarmMessage()
        {
            DataTable dt = EPPlusHelper.ExcelToDataTable($"{BZ_NewPar}AlarmMessages.xlsx");
            List<AlarmInfo> Tem = new List<AlarmInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AlarmInfo ainfo = new AlarmInfo
                {
                    Index = Convert.ToInt32(dt.Rows[i][0]),
                    ErrorCode = (string)dt.Rows[i][1],
                    MessageE = (string)dt.Rows[i][4],
                    MessageVN = (string)dt.Rows[i][10],
                };
                Tem.Add(ainfo);
            }
            GlobalVar.appHiveControl.ErrorInfoList = Tem;
        }

        #endregion ICT新增需求
    }
}