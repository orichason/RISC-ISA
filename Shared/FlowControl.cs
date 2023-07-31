using System.Text;

namespace AssemblyLibrary.Shared
{
    public class FlowControl : Instruction
    {

        public override void Parse(string[] instruction, ref List<byte> assembeledBytes)
        {
            switch (instruction[0])
            {
                case "JMP":
                    assembeledBytes.Add(OpCodes[instruction[0]]);
                    assembeledBytes.Add((byte)(Labels[instruction[1]] >> 8));
                    assembeledBytes.Add((byte)Labels[instruction[1]]);
                    assembeledBytes.Add(Pad);
                    break;
                case "JMPT":
                    assembeledBytes.Add(OpCodes[instruction[0]]);
                    assembeledBytes.Add(Registers[instruction[1]]);
                    assembeledBytes.Add((byte)(Labels[instruction[2]] >> 8));
                    assembeledBytes.Add((byte)Labels[instruction[2]]);
                    break;
                case "JMPi":
                    assembeledBytes.Add(OpCodes[instruction[0]]);
                    assembeledBytes.Add(Registers[instruction[1]]);
                    assembeledBytes.Add(Pad);
                    assembeledBytes.Add(Pad);
                    break;
            }
        }

        public override void Do(byte[] instruction)
        {
            switch (instruction[0])
            {
                case 0x30:
                    InstructionPointer = (ushort)(((instruction[1] << 8) + instruction[2]) * 4);
                    break;
                case 0x31:
                    if (RegistersArray[instruction[1]] != 0)
                    {
                        InstructionPointer = (ushort)(((instruction[2] << 8) + instruction[3]) * 4);
                    }
                    else
                    {
                        InstructionPointer += 4;
                    }
                    break;
                case 0x32:
                    InstructionPointer = (ushort)(RegistersArray[instruction[1]]);
                    break;
            }
        }
        public override void UnParse(byte[] instruction, ref StringBuilder disassembledBytes)
        {
            disassembledBytes.Append($" {KeysToOpCodes[instruction[0]]}");

            switch(instruction[0])
            {
                case 0x30:
                    disassembledBytes.Append($" {Convert.ToString((instruction[1] << 8) | instruction[2], 16)}");
                    break;
                case 0x31:
                    disassembledBytes.Append($" R{instruction[1]}");
                    disassembledBytes.Append($" {Convert.ToString((instruction[2] << 8) | instruction[3], 16)}");
                    break;
                case 0x32:
                    disassembledBytes.Append($" R{instruction[1]}");
                    break;
            }

            disassembledBytes.Append("\n");
        }
    }
}
