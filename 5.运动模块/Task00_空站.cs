using XStation;
using static CoreFunction.mFunction;
using static ParName.名称枚举;

namespace 运动模块
{
    /// <summary>
    /// 可以用来显示MES PDCA的log什么的，存专门的文件log 做一些测试什么的
    /// </summary>
    public class Task00_空站 : mWorkShare
    {
        #region 私有变量

        private const Task_ID task_ID = Task_ID.Task00_空站;

        #endregion 私有变量

        #region 工站交互

        private static Task00_空站 mInstance;

        public static Task00_空站 Instance => mInstance ?? (mInstance = new Task00_空站());

        #endregion 工站交互

        #region 点位名称

        #endregion 点位名称

        #region 基础功能

        public override void Initialize()
        {
            TaskID = (short)task_ID;
            WkManager.BindStation((short)task_ID, task_ID.ToString(), this);

            _Logs = new LogsHelper.cLogs(TaskName, TaskID);
            base.Initialize();
            State = State.WAITRUN;//方便可以直接点手动触发按钮
            StaHomeOK = true;//测试站，打开就回零OK
        }

        public override void Homing()
        {
            base.Homing();
            StaHomeOK = true;
        }

        public override void Err(string CtrName, string ErrInfo)
        {
            switch (CtrName)
            {
                case "DoAndDi":
                    if (State != State.RUNNING && State != State.MANUAL)
                    {
                        return;
                    }
                    break;

                case "Moving":
                    break;
            }
        }

        #endregion 基础功能

        #region 流程枚举

        private enum Workstep
        {
            流程开始 = 10,
        }

        #endregion 流程枚举

        #region 自动流程

        /// <summary>
        /// 主程序
        /// </summary>
        public override void AutoRun()
        {
            switch (WorkStep_Int)
            {
                case (int)Workstep.流程开始:

                    break;
            }
        }

        #endregion 自动流程

        #region 安全防呆

        #endregion 安全防呆

        #region 私有方法

        #endregion 私有方法
    }
}