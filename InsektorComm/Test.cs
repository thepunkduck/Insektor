using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsektorComm
{
    public class InsektorCommTest
    {
        static Random rand = new Random(17);
        public static void Test()
        {
            List<NOMPT> points;
            var run = Snapshot.IsRunningViewerStatus();

            Snapshot.WriteRunningViewerStatus();

            points = _randomPoints();
            Snapshot.Store(points, "random:points");
            points = _randomPoints();
            Snapshot.Store(points, "random:points");
            points = _randomPoints();
            Snapshot.Store(points, "random:points");

            points = _randomPoints();
            Snapshot.Store(points, "more random/^%@#$%points");
            points = _randomPoints();
            Snapshot.Store(points, "more random/^%@#$%points");
            points = _randomPoints();
            Snapshot.Store(points, "more random/^%@#$%points");


            Snapshot.LimitHistory();
            List<SnapshotCategory> all = Snapshot.GetCollection();



            all[0].Selected = all[0].Collection[0];
            var headers = all[0].GetSelectedSnapshotHeaderTitles();
            var types = all[0].GetSelectedSnapshotHeaderTypes();

            string name = all[0].Name;
            SnapshotItem sItem = all[0].GetSelectedItem();


            for (int i = 0; i < headers.Count; i++)
            {
                string header = headers[i];
                var typ = types[i];

                switch (typ)
                {
                    case TypeCode.Boolean:
                        break;
                    case TypeCode.Char:
                        break;
                    case TypeCode.SByte:
                        break;
                    case TypeCode.Byte:
                        break;
                    case TypeCode.Int16:
                        break;
                    case TypeCode.UInt16:
                        break;
                    case TypeCode.Int32:
                        List<int> iList = sItem.GetIntegerArray(header);
                        break;
                    case TypeCode.UInt32:
                        break;
                    case TypeCode.Int64:
                        break;
                    case TypeCode.UInt64:
                        break;
                    case TypeCode.Single:
                        List<float> flist = sItem.GetFloatArray(header);
                        break;
                    case TypeCode.Double:
                        List<double> dList =  sItem.GetDoubleArray(header);
                        break;
                    case TypeCode.Decimal:
                        break;
                    case TypeCode.DateTime:
                        break;
                    case TypeCode.String:
                        List<string> sList = sItem.GetStringArray(header);
                        break;
                    default:
                        break;
                }
            }

            foreach (var item in all) { item.LineColor = Color.Red; }
            Snapshot.WriteSettings(all);

            run = Snapshot.IsRunningViewerStatus();
        }




        static List<NOMPT> _randomPoints()
        {
            List<NOMPT> points = new List<NOMPT>();
            for (int i = 0; i < 100; i++)
            {
                string name = _randStr();
                points.Add(new NOMPT(name, (float)i, (float)rand.NextDouble() * 200f, rand.NextDouble() * 10, rand.Next(6)));
            }
            return (points);
        }

        private static string _randStr()
        {
            string str = "";
            for (int i = 0; i < 5; i++)
            {
                char c = (char)(rand.Next(65, 75));
                str += c;

            }
            return (str);
        }


    }



    class NOMPT
    {
        public NOMPT(string name, float x, float y, double z, int num)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.Zdble = z;
            this.Number = num;
            Color = Color.Red;
        }

        public string Name { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public double Zdble { get; set; }
        public int Number { get; set; }
        public Color Color { get; set; }
    }


}
