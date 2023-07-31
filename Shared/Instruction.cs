using System.Text;

namespace AssemblyLibrary.Shared
{
    public abstract class Instruction
    {
        public abstract void Parse(string[] instruction, ref List<byte> assembeledBytes);

        public abstract void UnParse(byte[] instruction, ref StringBuilder disassembledBytes);
        public abstract void Do(byte[] instruction);
    }
}
