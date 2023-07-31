namespace AssemblyLibrary.Assembling
{
    public class Assembler
    {
        public static List<byte> Assemble(string filePath)
        {
            string file = File.ReadAllText(filePath);

            string[] lines = file.Split("\r\n");

            ushort instructionCounter = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                bool labelFound = false;
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == ':')
                    {
                        Labels.Add(lines[i].Trim(new char[] { ':' }), instructionCounter);
                        labelFound = true;
                    }
                }

                if (!labelFound)
                {
                    instructionCounter++;
                }
            }

            List<byte> assembledBytes = new();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] instructions = lines[i].Split(' ');

                var opCode = instructions[0];

                if (OpCodes.TryGetValue(opCode, out var layout))
                {
                    OpCodeToLayout[layout].Parse(instructions, ref assembledBytes);
                }
            }

            return assembledBytes;
        }
    }
}
 