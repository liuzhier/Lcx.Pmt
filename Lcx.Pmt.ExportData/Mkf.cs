using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lcx.Pmt.ExportData
{
    public unsafe class Mkf : IDisposable
    {
        public void*[] ChunkData { get; set; }
        public int[] ChunkLen { get; set; }

        public Mkf(string path)
        {
            InitChunk(path);
        }

        ~Mkf()
        {
            Dispose();
        }

        bool IsDisposed = false;
        public void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            IsDisposed = true;
            GC.SuppressFinalize(this);

            FreeChunk();
        }

        public void InitChunk(string path)
        {
            int len, i, offset, offsetNext;

            using FileStream fsMkf = File.OpenRead(path);
            using BinaryReader brMkf = new(fsMkf);

            offsetNext = brMkf.ReadInt32();
            len = offsetNext / sizeof(int) - 1;
            ChunkData = new void*[len];
            ChunkLen = new int[len];

            for (i = 0; i < len; i++)
            {
                offset = offsetNext;
                offsetNext = brMkf.ReadInt32();

                ChunkLen[i] = offsetNext - offset;
                ChunkData[i] = NativeMemory.Alloc((nuint)ChunkLen[i]);

                brMkf.ReadExactly(new Span<byte>(ChunkData[i], ChunkLen[i]));
            }
        }

        public void FreeChunk()
        {
            int i;

            if (ChunkData == null) return;

            for (i = 0; i < ChunkData.Length; i++)
            {
                NativeMemory.Free(ChunkData[i]);
                ChunkData[i] = null;
            }

            ChunkData = null;
            ChunkLen = null;
        }
    }
}
