using GalaSoft.MvvmLight;
using System;
using System.Globalization;
using System.Windows.Interop;

namespace NModbus.Tools.SlaveExplorer.ViewModel
{
    public class FloatViewModel : ViewModelBase, IPointViewModel<uint>
    {
        private uint _value;
        private bool _isDirty;
        private ushort _address;
        //private byte[] bytes = new byte[8];

        public FloatViewModel()
        {
        }

        public FloatViewModel(ushort address)
        {
            Address = address;
        }

        public FloatViewModel(ushort address, uint value)
            : this(address)
        {
            _value = value;
        }

        public virtual uint Value 
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;

                    OnValueUpdated();

                    IsDirty = true;
                }
            }
        }

        public ushort Address
        {
            get { return _address; }
            set
            {
                _address = value;
                RaisePropertyChanged();
            }
        }

        public bool IsDirty
        {
            get { return _isDirty; }
            set
            {
                if (_isDirty != value)
                {
                    _isDirty = value;
                    RaisePropertyChanged(() => IsDirty);
                }
            }
        }

        public void Initialize(ushort address, uint value)
        {
            Address = address;
            Value = value;
            IsDirty = false;
        }

        public void SetValue(uint value)
        {
            Value = value;
            IsDirty = false;
        }

        protected void OnValueUpdated()
        {
            RaisePropertyChanged(() => Value);
            RaisePropertyChanged(() => Hex);
            RaisePropertyChanged(() => F1234);
            RaisePropertyChanged(() => F3412);
            RaisePropertyChanged(() => F4321);
            RaisePropertyChanged(() => F2143);
        }

        public string Hex
        {
            get { return $"0x{Value:x8}"; }
            set
            {

                if (value != null)
                {
                    value = value.Replace("0x", "");
                }

                if (uint.TryParse(value, NumberStyles.AllowHexSpecifier | NumberStyles.HexNumber, null, out uint converted))
                {
                    Value = converted;
                }
                else
                {
                    RaisePropertyChanged();
                }
            }
        }

        public float F4321
        {
            get
            {
                // Convert the uint to a byte array
                byte[] bytes = BitConverter.GetBytes(Value);

                // Reorder bytes
                byte[] orderedbytes = new byte[4];
                orderedbytes[0] = bytes[0];
                orderedbytes[1] = bytes[1];
                orderedbytes[2] = bytes[2];
                orderedbytes[3] = bytes[3];

                // Convert the byte array back to a float
                return BitConverter.ToSingle(orderedbytes, 0);
            }
            set
            {
                // Convert the float to a byte array
                byte[] bytes = BitConverter.GetBytes(value);

                // Reorder bytes
                byte[] orderedbytes = new byte[4];
                orderedbytes[0] = bytes[0];
                orderedbytes[1] = bytes[1];
                orderedbytes[2] = bytes[2];
                orderedbytes[3] = bytes[3];

                // Convert the byte array back to a uint
                Value = BitConverter.ToUInt32(orderedbytes, 0);
            }
        }
        public float F2143
        {
            get
            {
                // Convert the uint to a byte array
                byte[] bytes = BitConverter.GetBytes(Value);

                // Reorder bytes
                byte[] orderedbytes = new byte[4];
                orderedbytes[0] = bytes[2];
                orderedbytes[1] = bytes[3];
                orderedbytes[2] = bytes[0];
                orderedbytes[3] = bytes[1];

                // Convert the byte array back to a float
                return BitConverter.ToSingle(orderedbytes, 0);
            }
            set
            {
                // Convert the float to a byte array
                byte[] bytes = BitConverter.GetBytes(value);

                // Reorder bytes
                byte[] orderedbytes = new byte[4];
                orderedbytes[0] = bytes[2];
                orderedbytes[1] = bytes[3];
                orderedbytes[2] = bytes[0];
                orderedbytes[3] = bytes[1];

                // Convert the byte array back to a uint
                Value = BitConverter.ToUInt32(orderedbytes, 0);
            }
        }

        public float F1234
        {
            get
            {
                // Convert the uint to a byte array
                byte[] bytes = BitConverter.GetBytes(Value);

                // Reorder bytes
                byte[] orderedbytes = new byte[4];
                orderedbytes[0] = bytes[3];
                orderedbytes[1] = bytes[2];
                orderedbytes[2] = bytes[1];
                orderedbytes[3] = bytes[0];

                // Convert the byte array back to a float
                return BitConverter.ToSingle(orderedbytes, 0);
            }
            set
            {
                // Convert the float to a byte array
                byte[] bytes = BitConverter.GetBytes(value);

                // Reorder bytes
                byte[] orderedbytes = new byte[4];
                orderedbytes[0] = bytes[3];
                orderedbytes[1] = bytes[2];
                orderedbytes[2] = bytes[1];
                orderedbytes[3] = bytes[0];

                // Convert the byte array back to a uint
                Value = BitConverter.ToUInt32(orderedbytes, 0);
            }
        }
        public float F3412
        {
            get
            {
                // Convert the uint to a byte array
                byte[] bytes = BitConverter.GetBytes(Value);

                // Reorder bytes
                byte[] orderedbytes = new byte[4];
                orderedbytes[0] = bytes[1];
                orderedbytes[1] = bytes[0];
                orderedbytes[2] = bytes[3];
                orderedbytes[3] = bytes[2];

                // Convert the byte array back to a float
                return BitConverter.ToSingle(orderedbytes, 0);
            }
            set
            {
                // Convert the float to a byte array
                byte[] bytes = BitConverter.GetBytes(value);

                // Reorder bytes
                byte[] orderedbytes = new byte[4];
                orderedbytes[0] = bytes[1];
                orderedbytes[1] = bytes[0];
                orderedbytes[2] = bytes[3];
                orderedbytes[3] = bytes[2];

                // Convert the byte array back to a uint
                Value = BitConverter.ToUInt32(orderedbytes, 0);
            }
        }
    }
}