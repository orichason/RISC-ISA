using System.Text;

namespace AssemblyLibrary.Shared
{
    public class MathAndLogic : Instruction
    {
        public override void Parse(string[] instruction, ref List<byte> assembeledBytes)
        {
            for (int i = 0; i < instruction.Length; i++)
            {
                if (i == 0)
                {
                    assembeledBytes.Add(OpCodes[instruction[i]]);
                }
                else
                {
                    assembeledBytes.Add(Registers[instruction[i]]);
                }
            }
        }

        public override void Do(byte[] instruction)
        {
            switch (instruction[0])
            {
                case 0x10:
                    RegistersArray[instruction[1]] = (ushort)(RegistersArray[instruction[2]] + RegistersArray[instruction[3]]);
                    break;
                case 0x11:
                    RegistersArray[instruction[1]] = (ushort)(RegistersArray[instruction[2]] - RegistersArray[instruction[3]]);
                    break;
                case 0x12:
                    RegistersArray[instruction[1]] = (ushort)(RegistersArray[instruction[2]] * RegistersArray[instruction[3]]);
                    break;
                case 0x13:
                    RegistersArray[instruction[1]] = (ushort)(RegistersArray[instruction[2]] / RegistersArray[instruction[3]]);
                    break;
                case 0x14:
                    RegistersArray[instruction[1]] = (ushort)(RegistersArray[instruction[2]] % RegistersArray[instruction[3]]);
                    break;
                case 0x21:
                    RegistersArray[instruction[1]] = (ushort)(RegistersArray[instruction[2]] & RegistersArray[instruction[3]]);
                    break;
                case 0x22:
                    RegistersArray[instruction[1]] = (ushort)(RegistersArray[instruction[2]] | RegistersArray[instruction[3]]);
                    break;
                case 0x23:
                    RegistersArray[instruction[1]] = (ushort)(RegistersArray[instruction[2]] ^ RegistersArray[instruction[3]]);
                    break;
                case 0x24:
                    if(RegistersArray[instruction[2]] == RegistersArray[instruction[3]])
                    {
                        RegistersArray[instruction[1]] = 1;
                    }
                    else
                        RegistersArray[instruction[1]] = 0;
                    break;
                case 0x25:
                    if (RegistersArray[instruction[2]] > RegistersArray[instruction[3]])
                    {
                        RegistersArray[instruction[1]] = 1;
                    }
                    else
                        RegistersArray[instruction[1]] = 0;
                    break;
            }
        }
        public override void UnParse(byte[] instruction, ref StringBuilder disassembledBytes)
        {
            disassembledBytes.Append($" {KeysToOpCodes[instruction[0]]}");
            for (int i = 1; i < 4; i++)
            {
                disassembledBytes.Append($" R{instruction[i]}");
            }

            disassembledBytes.Append("\n");
        }
    }
}
