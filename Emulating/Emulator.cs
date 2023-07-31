namespace AssemblyLibrary.Emulating
{
    public class Emulator
    {
        static void GetKeyPress()
        {
            if (RegistersArray[26] != 0)
            {
                if (Console.KeyAvailable)
                {
                    char readMe = Console.ReadKey().KeyChar;
                    RegistersArray[27] = (ushort)(readMe - '0');
                    RegistersArray[26] = 0;
                }
            }
        }

        static void Print()
        {
            if (RegistersArray[29] != 0)
            {
                Console.Write((char)RegistersArray[28]);
                RegistersArray[29] = 0;
            }
        }

        static void GuessingGame()
        {
            GetKeyPress();
            Print();
        }

        static void GenerateScreen()
        {
            for (int i = 0; i < 124; i++)
            {
                char value = ' ';
                Console.BackgroundColor = (ConsoleColor)(RAM[i] >> 4);
                Console.ForegroundColor = (ConsoleColor)(RAM[i] >> 4);
                Console.Write(value);
            }
           //Console.WriteLine();
        }
        public static void Emulate(string path)
        {
            byte[] binFile = File.ReadAllBytes(path);

            while (true)
            {
                RegistersArray[25] = (ushort)RandomGen.Next();

                bool setScreen = true;
                for (int i = 0; i < 124; i++)
                {
                    if (RAM[i] != 0xBB)
                        setScreen = false;
                }

                if (setScreen)
                {
                    GenerateScreen();
                }

                byte[] instruction = new byte[4];

                for (int i = 0, j = InstructionPointer; j < InstructionPointer + 4; i++, j++)
                {
                    instruction[i] = binFile[j];
                }
                OpCodeToLayout[instruction[0]].Do(instruction);
                if (OpCodeToLayout[instruction[0]] != FlowControl)
                {
                    InstructionPointer += 4;
                }
            }
        }
    }
}
