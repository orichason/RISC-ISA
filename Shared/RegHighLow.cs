using System.Text;

namespace AssemblyLibrary.Shared
{
    public class RegHighLow : Instruction
    {

        public override void Parse(string[] instruction, ref List<byte> assembeledBytes)
        {
            assembeledBytes.Add(OpCodes[instruction[0]]);

            if (Registers.ContainsKey(instruction[1]))
            {
                assembeledBytes.Add(Registers[instruction[1]]);
            }
            else
            {
                assembeledBytes.Add(byte.Parse(instruction[1]));
            }

            switch (instruction.Length)
            {
                case 3:
                    short byteToAdd = Convert.ToInt16(instruction[2], 16);
                    assembeledBytes.Add((byte)(byteToAdd >> 8));
                    assembeledBytes.Add((byte)byteToAdd);
                    break;
                case 4:
                    assembeledBytes.Add(byte.Parse(instruction[2], System.Globalization.NumberStyles.HexNumber));
                    assembeledBytes.Add(byte.Parse(instruction[3], System.Globalization.NumberStyles.HexNumber));
                    break;
            }
        }
        public override void Do(byte[] instruction)
        {
            switch (instruction[0])
            {
                case 0x40:
                    RegistersArray[instruction[1]] = (ushort)((instruction[2] << 8) + instruction[3]);
                    break;
                case 0x41:
                    RAM[instruction[1] + instruction[2]] = RegistersArray[instruction[1]];
                    break;
                case 0x43:
                    RegistersArray[instruction[1]] = RAM[(instruction[2] << 8) + instruction[3]];
                    break;
            }
        }

        public override void UnParse(byte[] instruction, ref StringBuilder disassembledBytes)
        {
            disassembledBytes.Append($" {KeysToOpCodes[instruction[0]]}");
            disassembledBytes.Append($" R{instruction[1]}");
            disassembledBytes.Append($" {Convert.ToString((instruction[2] << 8) | instruction[3], 16)}");

            disassembledBytes.Append("\n");
        }
    }
}
