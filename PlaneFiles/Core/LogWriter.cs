using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class LogWriter:IDisposable
    {
        private readonly StreamWriter _writer;
        public LogWriter(string path)
        {
            _writer = new StreamWriter(path, append: true)
            {
                AutoFlush = true
            };
            
        }

        public void WriteLog(string level, string messege)
        {
            var timeStamp = DateTime.Now.ToString("s");//ISO 8601 format
            var logEntry = $"{timeStamp}[{level}]{messege}";
            _writer.WriteLine(logEntry);
        }

        public void Dispose() 
        {
            _writer.Dispose();
        }
    }
}
