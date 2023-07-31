using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;

namespace AssemblyLibrary.Dissasembling
{
    public class Disassembler
    {
        public static StringBuilder Dissasemble(string filePath)
        {
            byte[] binFile = File.ReadAllBytes(filePath);

            StringBuilder disassembledBytes = new();

            for (int i = 0; i < binFile.Length;)
            {
                byte[] instruction = new byte[4];

                for (int j = 0; j < instruction.Length; j++, i++)
                {
                    instruction[j] = binFile[i];
                }

                OpCodeToLayout[instruction[0]].UnParse(instruction, ref disassembledBytes);
            }


            return disassembledBytes;
        }
    }
}