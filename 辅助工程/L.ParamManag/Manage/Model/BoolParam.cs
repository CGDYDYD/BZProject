namespace LParamManag.Manage.Model
{
    public class OffsetCompenParam
    {
        private double _value_x;
        private double _value_y;
        private double _value_r;
        private double _value_z;

        public int Index { get; set; }

        public string Name { get; set; }

        public double Value_X
        {
            get { return _value_x; }
            set
            {
                if (MinValue_X <= value && value <= MaxValue_X)
                {
                    _value_x = value;
                }
            }
        }

        public double Value_Y
        {
            get { return _value_y; }
            set
            {
                if (MinValue_Y <= value && value <= MaxValue_Y)
                {
                    _value_y = value;
                }
            }
        }

        public double Value_Z
        {
            get { return _value_z; }
            set
            {
                if (MinValue_Z <= value && value <= MaxValue_Z)
                {
                    _value_z = value;
                }
            }
        }

        public double Value_R
        {
            get { return _value_r; }
            set
            {
                if (MinValue_R <= value && value <= MaxValue_R)
                {
                    _value_r = value;
                }
            }
        }

        public double MaxValue_X { get; set; }
        public double MinValue_X { get; set; }
        public double MaxValue_Y { get; set; }
        public double MinValue_Y { get; set; }
        public double MaxValue_R { get; set; }
        public double MinValue_R { get; set; }
        public double MaxValue_Z { get; set; }
        public double MinValue_Z { get; set; }

        public OffsetCompenParam()
        {
            MaxValue_X = 20;
            MinValue_X = -20;
            MaxValue_Y = 20;
            MinValue_Y = -20;
            MaxValue_R = 360;
            MinValue_R = -360;
            MaxValue_Z = 20;
            MinValue_Z = -20;
        }
    }
}