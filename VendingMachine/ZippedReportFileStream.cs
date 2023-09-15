using System;
using System.IO;

namespace iQuest.VendingMachine
{
    internal class ZippedReportFileStream : Stream
    {
        private Stream stream;

        private readonly string path;
        public override bool CanRead => CheckCanRead();

        public override bool CanSeek => CheckCanSeek();

        public override bool CanWrite => CheckCanWrite();

        public override long Length => GetLength();

        public override long Position { get => stream.Position; set => stream.Position = value; }

        public ZippedReportFileStream(string path)
        {
            this.path = path;
        }
        public override void Flush()
        {
            using (stream = new FileStream(path, FileMode.Create))
            {
                stream.Flush();
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            int sum = 0;

            using (stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                int length = (int)stream.Length;
                buffer = new byte[length];

                while ((count = stream.Read(buffer, sum, length - sum)) > 0)
                {
                    sum += count;
                }
            }

            return sum;
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            using (stream = new FileStream(path, FileMode.Create))
            {
                return stream.Seek(offset, origin);
            }
        }
        public override void SetLength(long value)
        {
            using (stream = new FileStream(path, FileMode.Create))
            {
                if (stream.Length > 500000)
                {
                    Byte[] bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, (int)stream.Length);
                    stream.Close();

                    FileStream fs2 = new FileStream(path, FileMode.Create);
                    fs2.Write(bytes, bytes.Length - 250000, 250000);
                    fs2.Flush();
                }
            }
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            using (stream = new FileStream(path, FileMode.Create))
            {
                stream.Write(buffer, offset, count);
            }
        }
        private long GetLength()
        {
            using (stream = new FileStream(path, FileMode.Create))
            {
                return stream.Length;
            }
        }
        private bool CheckCanRead()
        {
            using (stream = new FileStream(path, FileMode.Create))
            {
                return stream.CanRead;
            }
        }
        private bool CheckCanSeek()
        {
            using (stream = new FileStream(path, FileMode.Create))
            {
                return stream.CanSeek;
            }
        }
        private bool CheckCanWrite()
        {
            using (stream = new FileStream(path, FileMode.Create))
            {
                return stream.CanWrite;
            }
        }
    }
}
