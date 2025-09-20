using System;

namespace NModbus.Tools.SlaveExplorer.ViewModel
{
    public class FloatRegistersViewModel : PointsViewModelBase<FloatViewModel, uint>
    {
        public FloatRegistersViewModel(ISlaveExplorerContext context) : base(context)
        {
        }

        protected override uint[] ReadCore(IModbusMaster modbusMaster, byte slaveId, ushort startAddress, ushort numberOfPoints)
        {
            uint[] result = new uint[numberOfPoints];
            ushort[] values = modbusMaster.ReadHoldingRegisters(slaveId, startAddress, (ushort)(numberOfPoints * 2));

            for (int index = 0; index < numberOfPoints; index++)
            {
                result[index] = (uint)values[(index*2)] | ((uint)values[(index*2) + 1] << 16);

            }
            return result;

        }

        protected override void WriteCore(IModbusMaster modbusMaster, byte slaveId, ushort startAddress, uint[] values)
        {
            ushort[] registers = new ushort[values.Length*2];

            for (int index = 0; index < (values.Length); index++)
            {
                // Convert the uint to a byte array
                byte[] bytes = new byte[4];
                bytes = BitConverter.GetBytes(values[index]);


                // Reorder bytes
                byte[] orderedbytes = new byte[4];
                orderedbytes[0] = bytes[0];
                orderedbytes[1] = bytes[1];
                orderedbytes[2] = bytes[2];
                orderedbytes[3] = bytes[3];

                // Convert the byte array back to a ushort
                registers[(index*2)] = BitConverter.ToUInt16(orderedbytes, 0);
                registers[(index*2)+1] = BitConverter.ToUInt16(orderedbytes, 2);


            }


            modbusMaster.WriteMultipleRegisters(slaveId, startAddress, registers);
        }

        public override bool IsWriteable
        {
            get { return true; }
        }

        public override bool SupportsBlockSize
        {
            get { return true; }
        }

    }
}