using DDD.Domain.Helpers;
using DDD.WinForm.Common;

namespace DDD.Domain.ValueObjects
{
    public sealed class Temperature : ValueObject<Temperature>
    {
        //private readonly float _value;
        public const string UNIT_NAME = "℃";
        public const int DECIMAL_POINT = 2;

        public Temperature(float value)
        {
            //_value = value;
            Value = value;
        }

        //昔の書き方
        //public float Value
        //{
        //    get
        //    {
        //        return _value;
        //    }
        //}

        //今の書き方
        public float Value { get; }
        public string DisplayValue 
        {
            get 
            {
                //このほうが考え方がよい
                return Value.RoundString(DECIMAL_POINT);
                //return FloatHelper.RoundString(Value, DECIMAL_POINT);
            }
        }
        public string DisplayValueWithUnit
        {
            get
            {
                return Value.RoundString(DECIMAL_POINT) + UNIT_NAME;
                //return FloatHelper.RoundString(Value, DECIMAL_POINT) + UNIT_NAME;
            }
        }
        public string DisplayValueWithUnitSpace
        {
            get
            {
                return Value.RoundString(DECIMAL_POINT) + " " + UNIT_NAME;
                //return FloatHelper.RoundString(Value, DECIMAL_POINT) + " " + UNIT_NAME;
            }
        }

        protected override bool EqualsCore(Temperature other)
        {
            //クラスごとで作成する
            return Value == other.Value;
        }
    }
}
