using LParamManag.Interface;
using LParamManag.Manage.Collection;
using System;

namespace LParamManag.Manage
{
    // 上下文类
    public class ParamContext<T, U>
    {
        private IGenericParam<T, U> _paymentStrategy;

        public ParamContext(string ParamType, string path)
        {
            _paymentStrategy = ParamFactory<T, U>.CreateParamStrategy(ParamType, path);
        }

        public T this[string Key, int index]
        {
            get { return _paymentStrategy.GetValue(Key, index); }
            set { _paymentStrategy.SetValue(Key, index, value); }
        }
    }

    // 工厂类
    public class ParamFactory<T, U>
    {
        public static IGenericParam<T, U> CreateParamStrategy(string ParamType, string path)
        {
            switch (ParamType.ToLower())
            {
                case "offset":
                    return (IGenericParam<T, U>)OffsetParamCollection.LoadingLocalParam(path);

                default:
                    throw new InvalidOperationException("未知的方式");
            }
        }
    }
}