namespace LParamManag.Interface
{
    public interface IGenericParam<T, U>
    {
        T GetValue(string Key, int index);

        bool SetValue(string Key, int index, T value);

        void Save();

        void Clear();
    }
}