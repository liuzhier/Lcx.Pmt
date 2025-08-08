using Lcx.Pmt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using static Lcx.Pmt.Entity.All;

namespace Lcx.Pmt.ExportData
{
    public unsafe class Data
    {
        public static void Init()
        {

        }

        public static void GoShop()
        {
            Shop* pShop;
            int i, len;

            pShop = (Shop*)GoMain.Resource.BaseData.ChunkData[0];
            len = GoMain.Resource.BaseData.ChunkLen[0] / sizeof(Shop);

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve // 处理循环引用
            };

            for (i = 0; i < len; i++)
            {
                string json;

                json = JsonSerializer.Serialize(*pShop, options);
                File.WriteAllText($@"{GoMain.ModPath}\Data\Shop\{i}.json", json);
            }
        }

        public static void Go()
        {
            GoShop();
        }

        public static void Free()
        {

        }
    }
}
