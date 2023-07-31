global using static Globals;
using AssemblyLibrary.Shared;

static class Globals
{
    public static Dictionary<string, ushort> Labels = new();

    public const byte Pad = 0x00;
    public static ushort InstructionPointer = 0;
    public static Random RandomGen = new Random();

    public static MathAndLogic MathAndLogic = new();
    public static RegRegVal RegRegVal = new();
    public static RegHighLow RegHighLow = new();
    public static FlowControl FlowControl = new();

    public static ushort[] RAM = new ushort[0xFFFF];
    public static ushort[] RegistersArray = new ushort[32];

    public static HashSet<byte> PaddedOpCodes = new HashSet<byte> { 0x26, 0x30, 0x32, 0x42, 0x44};

    public static Dictionary<string, byte> OpCodes = new()
    {
        ["NOP"] = 0x00,
        ["ADD"] = 0x10,
        ["SUB"] = 0x11,
        ["MUL"] = 0x12,
        ["DIV"] = 0x13,
        ["MOD"] = 0x14,
        ["AND"] = 0x21,
        ["OR"] = 0x22,
        ["XOR"] = 0x23,
        ["EQ"] = 0x24,
        ["GT"] = 0x25,
        ["NOT"] = 0x26,
        ["SHFTL"] = 0x27,
        ["SHFTR"] = 0x28,
        ["JMP"] = 0x30,
        ["JMPT"] = 0x31,
        ["JMPi"] = 0x32,
        ["SET"] = 0x40,
        ["STR"] = 0x41,
        ["COPY"] = 0x42,
        ["LOAD"] = 0x43,
        ["STRi"] = 0x44
    };

    public static Dictionary<byte, string> KeysToOpCodes = new()
    {
        [0x00] = "NOP",
        [0x10] = "ADD",
        [0x11] = "SUB",
        [0x12] = "MUL",
        [0x13] = "DIV",
        [0x14] = "MOD",
        [0x21] = "AND",
        [0x22] = "OR",
        [0x23] = "XOR",
        [0x24] = "EQ",
        [0x25] = "GT",
        [0x26] = "NOT",
        [0x27] = "SHFTL",
        [0x28] = "SHFTR",
        [0x30] = "JMP",
        [0x31] = "JMPT",
        [0x32] = "JMPi",
        [0x40] = "SET",
        [0x41] = "STR",
        [0x42] = "COPY",
        [0x43] = "LOAD",
        [0x44] = "STRi"
    };

    public static Dictionary<byte, Instruction> OpCodeToLayout = new()
    {
        [0x10] = MathAndLogic,
        [0x11] = MathAndLogic,
        [0x12] = MathAndLogic,
        [0x13] = MathAndLogic,
        [0x14] = MathAndLogic,
        [0x21] = MathAndLogic,
        [0x22] = MathAndLogic,
        [0x23] = MathAndLogic,
        [0x24] = MathAndLogic,
        [0x25] = MathAndLogic,
        [0x26] = RegRegVal,
        [0x27] = RegRegVal,
        [0x28] = RegRegVal,
        [0x30] = FlowControl,
        [0x31] = FlowControl,
        [0x32] = FlowControl,
        [0x40] = RegHighLow,
        [0x41] = RegHighLow,
        [0x42] = RegRegVal,
        [0x43] = RegHighLow,
        [0x44] = RegRegVal
    };

    public static Dictionary<string, byte> Registers = new()
    {
        ["R0"] = 0x00,
        ["R1"] = 0x01,
        ["R2"] = 0x02,
        ["R3"] = 0x03,
        ["R4"] = 0x04,
        ["R5"] = 0x05,
        ["R6"] = 0x06,
        ["R7"] = 0x07,
        ["R8"] = 0x08,
        ["R9"] = 0x09,
        ["R10"] = 0x0A,
        ["R11"] = 0x0B,
        ["R12"] = 0x0C,
        ["R13"] = 0x0D,
        ["R14"] = 0x0E,
        ["R15"] = 0x0F,
        ["R16"] = 0x10,
        ["R17"] = 0x11,
        ["R18"] = 0x12,
        ["R19"] = 0x13,
        ["R20"] = 0x14,
        ["R21"] = 0x15,
        ["R22"] = 0x16,
        ["R23"] = 0x17,
        ["R24"] = 0x18,
        ["R25"] = 0x19,
        ["R26"] = 0x1A,
        ["R27"] = 0x1B,
        ["R28"] = 0x1C,
        ["R29"] = 0x1D,
        ["R30"] = 0x1E,
        ["R31"] = 0x1F,
        ["R32"] = 0x20
    };
}