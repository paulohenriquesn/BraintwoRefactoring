using System;

namespace BaintwoRefactoring
{
    class Braintwo
    {

        //Int16
        internal Int16 currentMemory = 0;
        internal Int16[] Memory = new Int16[2] { 0, 0 };
        internal Int16 pointerMemory = 0;

        internal string Output = String.Empty;


        enum typeErrors
        {
            ERROR_TO_READ_FILE,
            ERROR_TO_INTERPRETER_CHAR,
            SYNTAX_ERROR
        };

        public string CodeToRun { get; set; } = String.Empty;
        public Braintwo(string code_)
        {
            if (!string.IsNullOrWhiteSpace(code_))
            {
                this.CodeToRun = code_;
                RunCode();
            }
            else
                throw new Exception(typeErrors.ERROR_TO_READ_FILE.ToString());
        }

        private void InterpreterChar(char Char_)
        {
            string numbers = "123456789";
            string x = String.Empty;
            string detect = String.Empty;

            detect = detect + Char_;
            for (int i = 0; i < numbers.Length; i++)
            {
                x = String.Empty;
                x = x + numbers[i];
                if (detect.Contains(x))
                {
                    currentMemory = Int16.Parse(x);
                }
            }


            switch (Char_)
            {
                case '+':
                    currentMemory++;
                    break;
                case '-':
                    currentMemory--;
                    break;
                case '>':
                    if (pointerMemory < 1)
                        pointerMemory++;
                    else
                        throw new Exception(typeErrors.SYNTAX_ERROR.ToString());
                    break;
                case '<':
                    if (pointerMemory > 0)
                        pointerMemory--;
                    else
                        throw new Exception(typeErrors.SYNTAX_ERROR.ToString());
                    break;
                case ']':
                    Memory[pointerMemory] = currentMemory;
                    currentMemory = 0;
                    break;
                case '[':
                    currentMemory = Memory[pointerMemory];
                    break;
                case '*':
                    currentMemory = (Int16)(Memory[0] * Memory[1]);
                    break;
                case '/':
                    currentMemory = (Int16)(Memory[0] / Memory[1]);
                    break;
                case '^':
                    currentMemory = (Int16)(Math.Pow(Memory[0], Memory[1]));
                    break;
                case '.':
                    Output = Output + ((char)currentMemory);
                    break;
                case '?':
                    if (currentMemory == 0)
                        currentMemory = 1;
                    else
                        currentMemory = 0;
                    break;
                case 'R':
                    Memory[0] = 0;
                    Memory[1] = 0;
                    break;
                case 'P':
                    Console.WriteLine(Output);
                    break;
                case '0':
                    currentMemory = 0;
                    break;
                case '~':
                    currentMemory = (Int16)(currentMemory * Memory[pointerMemory]);
                    break;
                case '@':
                    Memory[pointerMemory] = 0;
                    break;
                case 'C':
                    currentMemory = (Int16)(Memory[0] + Memory[1]);
                    break;
                case ';':
                    Int16 backup = 0;
                    backup = Memory[0];
                    Memory[0] = Memory[1];
                    Memory[1] = backup;
                    backup = 0;
                    break;
                case ':':
                    Memory[pointerMemory] = (Int16)(Memory[0] - Memory[1]);
                    break;
                case '=':
                    currentMemory *= 2;
                    break;
                case '_':
                    currentMemory = (Int16)new Random().Next(0, 248);
                    break;
                case 'X':
                    currentMemory += 10;
                    break;
                case 'Y':
                    currentMemory -= 10;
                    break;
                case '&':
                    Console.WriteLine(currentMemory);
                    break;
                case '\'':
                    Memory[pointerMemory] = (Int16)(Memory[pointerMemory] * -1);
                    break;
                case '\\':
                    Memory[pointerMemory] = (Int16)(Memory[0] * Memory[1]);
                    break;
                case 'p':
                    Memory[pointerMemory] = (Int16)(Math.Pow(Memory[0], Memory[1]));
                    break;
                case '!':
                    Memory[pointerMemory] *= Memory[pointerMemory];
                    break;
                case '|':
                    Memory[pointerMemory] = (Int16)(Memory[0] + Memory[1]);
                    break;
                case ')':
                    Int16 readValue = Int16.Parse(Console.ReadLine());
                    currentMemory = readValue;
                    break;
                case 'ç':
                    Int16 backupX = 0;
                    backup = currentMemory;
                    currentMemory = Memory[pointerMemory];
                    Memory[pointerMemory] = backupX;
                    break;
                case 'i':
                    currentMemory = (Int16)(Memory[pointerMemory] + currentMemory);
                    break;
                case 'v':
                    Memory[pointerMemory] = (Int16)(Memory[0] - Memory[1]);
                    break;
                case '%':
                    currentMemory = (Int16)(Memory[0] % Memory[1]);
                    break;
                case 'm':
                    Memory[pointerMemory] = (Int16)Math.Sqrt(currentMemory);
                    break;
            }
        }
        private void RunCode()
        {
            if (CodeToRun != String.Empty)
                for (int x = 0; x < CodeToRun.Length; x++)
                { InterpreterChar(CodeToRun[x]); }
            else
                throw new Exception(typeErrors.ERROR_TO_INTERPRETER_CHAR.ToString());
        }
    }
}
