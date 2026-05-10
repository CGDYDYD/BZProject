using System.Linq;
using static CoreFunction.mFunction;

namespace BoTech
{
    public sealed class SErrCode
    {
        #region"单例"
        private static SErrCode errcode;
        private static object obj = new object();

        public static SErrCode Default
        {
            get
            {
                if (errcode == null)
                {
                    lock (obj)
                    {
                        if (errcode == null)
                        {
                            errcode = new SErrCode();
                        }
                    }
                }
                return errcode;
            }
        }

        #endregion

        private SErrCode()
        {
        }

        public ErrCode GetCode(int Index)
        {
            ErrCode[] ERR = mErrCode.Where((W) => W.Index == Index).ToArray();
            return ERR?.Length > 0 ? ERR[0] : new ErrCode { Index = -1 };
        }
    }
}