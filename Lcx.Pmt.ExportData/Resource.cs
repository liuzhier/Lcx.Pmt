using System;
using System.Collections.Generic;
using System.Text;

namespace Lcx.Pmt.ExportData
{
    public class Resource : IDisposable
    {
        public Mkf BaseData { get; set; }
        public Mkf CoreData { get; set; }
        public Mkf Palette { get; set; }

        public Resource()
        {
            BaseData = new($@"{GoMain.GamePath}\DATA.MKF");
            CoreData = new($@"{GoMain.GamePath}\SSS.MKF");
            Palette = new($@"{GoMain.GamePath}\PAT.MKF");
        }

        ~Resource()
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

            BaseData.Dispose();
            CoreData.Dispose();
            Palette.Dispose();
        }
    }
}
