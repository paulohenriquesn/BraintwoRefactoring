using System;

namespace BaintwoRefactoring
{
    class Braintwo
    {
        enum typeErrors
        {
            ERROR_TO_READ_FILE,
            ERROR_TO_INTERPRETER_CHAR
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
            //
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
