using System.Collections.Generic;

namespace L_MyCTRLData_name
{
    public enum nType
    {
        _USER_STRING, _USER_INT, _USER_DOUBLE, _USER_BOOL, _USER_COMBOX, _USER_SIGNAL, _USER_SIGNALBTN, _USER_CHECK
    }

    internal class LMColType
    {
        public LMColType()
        {
            columType = nType._USER_STRING;
            ReadOnly = true;
            m_nWidth = 60;
            m_ComboStr.Clear();
        }

        public nType columType;
        public bool ReadOnly;
        public int m_nWidth;
        public List<string> m_ComboStr = new List<string>();
    }
}