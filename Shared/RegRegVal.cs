using System.Text;

namespace AssemblyLibrary.Shared
{
    public class RegRegVal : Instruction
    {

        public override void Parse(string[] instruction, ref List<byte> assembeledBytes)
        {
            assembeledBytes.Add(OpCodes[instruction[0]]);
            assembeledBytes.Add(Registers[instruction[1]]);
            assembeledBytes.Add(Registers[instruction[2]]);
            switch (instruction.Length)
            {
                case 3:
                    assembeledBytes.Add(Pad);
                    break;
                case 4:
                    assembeledBytes.Add(byte.Parse(instruction[3], System.Globalization.NumberStyles.HexNumber));
                    break;
            }

        }
        public override void Do(byte[] instruction)
        {
            switch (instruction[0])
            {
                case 0x26:
                    RegistersArray[instruction[1]] = (ushort)~RegistersArray[instruction[2]];
                    break;
                case 0x27:
                    RegistersArray[instruction[1]] = (ushort)(RegistersArray[instruction[2]] << instruction[3]);
                    break;
                case 0x28:
                    RegistersArray[instruction[1]] = (ushort)(RegistersArray[instruction[2]] >> instruction[3]);
                    break;
                case 0x42:
                    RegistersArray[instruction[1]] = RegistersArray[instruction[2]];
                    break;
                case 0x44:
                    RAM[RegistersArray[instruction[1]]] = RegistersArray[instruction[2]];
                    break;
            }
        }

        public override void UnParse(byte[] instruction, ref StringBuilder disassembledBytes)
        {
            //SHFTR R1 R2 8

            disassembledBytes.Append($" {KeysToOpCodes[instruction[0]]}");
            disassembledBytes.Append($" R{instruction[1]}");
            disassembledBytes.Append($" R{instruction[2]}");

            if (!PaddedOpCodes.Contains(instruction[0]))
            {
                disassembledBytes.Append($" {instruction[3]}");
            }

            disassembledBytes.Append("\n");
        }
    }
}
