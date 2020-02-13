using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace InsektorComm
{
    public enum Polarity
    {
        Normal,
        Reverse
    }

    public enum ChartStyle
    {
        Linear,
        Curve,
        HistoX,
        HistoY
    }
    public class SnapshotUtil
    {
        //  static Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
        static Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"])*\"|[^,]*)", RegexOptions.Compiled);
        public static string[] SplitCSV(string input)
        {

            List<string> list = new List<string>();
            string curr = null;
            foreach (Match match in csvSplit.Matches(input))
            {
                curr = match.Value;
                if (0 == curr.Length)
                {
                    list.Add("");
                }

                list.Add(curr.TrimStart(','));
            }

            return list.ToArray();
        }
    }



    public class SnapshotItem
    {
        public static string MOSTRECENT = "Most Recent";
        public SnapshotItem(FileInfo fileInfo)
        {
            FileInfo = fileInfo;
        }
        public SnapshotItem(string specialStr)
        {
            Special = specialStr;
        }
        public FileInfo FileInfo { get; }
        public string FullName { get { return (FileInfo != null ? FileInfo.FullName : Special); } }

        public string Special { get; set; }
        public string Name
        {
            get
            {
                if (FileInfo == null) return (Special);

                try
                {
                    string niceName = Path.GetFileNameWithoutExtension(FileInfo.FullName);
                    var parts = niceName.Split(" ".ToCharArray());
                    parts[0] = parts[0].Replace("_", ":");
                    parts[1] = parts[1].Replace("_", "/");
                    niceName = parts[0] + " " + parts[1];
                    return (niceName);
                }
                catch
                {
                    return (Path.GetFileNameWithoutExtension(FileInfo.FullName));
                }
            }
        }

        public string FormattedTime
        {
            get
            {
                if (FileInfo == null) return (Special);
                return (FileInfo.LastWriteTime.ToString("hh:mm:sstt dd/MM/yyyy"));
            }
        }

        internal static string getfilename(string dir, string sub)
        {
            DateTime dt = DateTime.Now;
            string timeStr = dt.ToString("hh_mm_sstt dd_MM_yy");
            string name;
            if (sub != null) name = sub.Trim() + " " + timeStr + ".dat";
            else name = timeStr + ".dat";
            string filename = Path.Combine(dir, name);
            return (filename);
        }

        public override string ToString()
        {
            return (Name);
        }

        public List<string> GetHeaderTitles()
        {
            var topLines = File.ReadLines(FullName).Take(2);
            var headerLine = topLines.ElementAt(1);

            List<string> headers = new List<string>();
            var parts = headerLine.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                // <> 
                int idx = part.IndexOf("><");
                string title = part.Substring(idx);
                title = title.Trim("<>".ToCharArray());
                headers.Add(title);
            }

            return (headers);
        }

        public int GetIndexOf(string headerTitle)
        {
            var allTitles = GetHeaderTitles();
            return (allTitles.IndexOf(headerTitle));
        }


        public List<TypeCode> GetHeaderTypes()
        {
            var topLines = File.ReadLines(FullName).Take(2);
            var headerLine = topLines.ElementAt(1);

            List<TypeCode> headers = new List<TypeCode>();
            var parts = headerLine.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                // <> 
                int idx = part.IndexOf("><");
                string typeStr = part.Substring(0, idx);
                typeStr = typeStr.Trim("<>".ToCharArray());

                TypeCode typeCode = (TypeCode)Enum.Parse(typeof(TypeCode), typeStr);
                headers.Add(typeCode);
            }

            return (headers);
        }

        public List<double> GetDoubleArray(string headerTitle)
        {
            int idxOf = GetIndexOf(headerTitle);
            try
            {
                List<double> ret = new List<double>();
                var topLines = File.ReadLines(FullName);

                int ic = -1;
                foreach (var part in topLines)
                {
                    ic++;
                    if (ic < 2) continue;
                    string[] splitPart = SnapshotUtil.SplitCSV(part);
                    double d;
                    if (!double.TryParse(splitPart[idxOf], out d)) d = double.NaN;
                    ret.Add(d);
                }
                return (ret);
            }
            catch
            {

            }
            return (null);
        }



        public List<float> GetFloatArray(string headerTitle)
        {
            int idxOf = GetIndexOf(headerTitle);
            try
            {
                List<float> ret = new List<float>();
                var topLines = File.ReadLines(FullName);

                int ic = -1;
                foreach (var part in topLines)
                {
                    ic++;
                    if (ic < 2) continue;
                    string[] splitPart = SnapshotUtil.SplitCSV(part);
                    float d;
                    if (!float.TryParse(splitPart[idxOf], out d)) d = float.NaN;
                    ret.Add(d);
                }
                return (ret);
            }
            catch
            {

            }
            return (null);
        }




        public List<int> GetIntegerArray(string headerTitle)
        {
            int idxOf = GetIndexOf(headerTitle);
            try
            {
                List<int> ret = new List<int>();
                var topLines = File.ReadLines(FullName);

                int ic = -1;
                foreach (var part in topLines)
                {
                    ic++;
                    if (ic < 2) continue;
                    string[] splitPart = SnapshotUtil.SplitCSV(part);
                    int d;
                    if (!int.TryParse(splitPart[idxOf], out d)) d = 0;
                    ret.Add(d);
                }
                return (ret);
            }
            catch
            {

            }
            return (null);
        }


        public List<string> GetStringArray(string headerTitle)
        {
            int idxOf = GetIndexOf(headerTitle);
            try
            {
                List<string> ret = new List<string>();
                var topLines = File.ReadLines(FullName);

                int ic = -1;
                foreach (var part in topLines)
                {
                    ic++;
                    if (ic < 2) continue;
                    string[] splitPart = SnapshotUtil.SplitCSV(part);
                    ret.Add(splitPart[idxOf]);
                }
                return (ret);
            }
            catch
            {

            }
            return (null);
        }


    }
    public class SnapshotCategory
    {
        static string NAMEFILE = "name.txt";
        static string SETTTINGSFILE = "settings.txt";

        public SnapshotCategory()
        {
        }

        public SnapshotCategory(string directory)
        {
            this.Directory = directory;
            State = false;

            if (System.IO.Directory.Exists(directory))
            {
                Name = File.ReadAllText(Path.Combine(directory, NAMEFILE));

                var sortedFiles = new DirectoryInfo(directory).GetFiles("*.dat")
                                                  .OrderByDescending(f => f.LastWriteTime)
                                                  .ToList();



                Collection.Add(new SnapshotItem(SnapshotItem.MOSTRECENT));
                foreach (var fi in sortedFiles) Collection.Add(new SnapshotItem(fi));
                State = true;

                ReadSettings();
            }
        }

        public override string ToString()
        {
            return (Name);
        }
        public static string GetDirectory(string name)
        {
            try
            {
                var rpath = Snapshot.RepositoryPath;
                // sanitize name
                string fname = sanitize(name);
                string dir = Path.Combine(rpath, fname);
                System.IO.Directory.CreateDirectory(dir);

                string namePath = Path.Combine(dir, NAMEFILE);

                if (!File.Exists(namePath))
                {
                    File.WriteAllText(namePath, name);
                    SnapshotCategory sC = new SnapshotCategory(dir);
                    sC.WriteSettings();
                }

                return (dir);
            }
            catch (Exception)
            {
                return (null);
            }
        }




        public void WriteSettings()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(JsonConvert.SerializeObject(_serialize(LineColor)));
            sb.AppendLine(JsonConvert.SerializeObject(_serialize(PointColor)));
            sb.AppendLine(JsonConvert.SerializeObject(_serialize(LineWidth)));
            sb.AppendLine(JsonConvert.SerializeObject(_serialize(PointSize)));
            sb.AppendLine(JsonConvert.SerializeObject(XAxis));
            sb.AppendLine(JsonConvert.SerializeObject(YAxis));
            sb.AppendLine(JsonConvert.SerializeObject(Selected != null ? Selected.FullName : null));
            sb.AppendLine(JsonConvert.SerializeObject(XPolarity.ToString()));
            sb.AppendLine(JsonConvert.SerializeObject(YPolarity.ToString()));
            sb.AppendLine(JsonConvert.SerializeObject(ChartStyle.ToString()));
            sb.AppendLine(JsonConvert.SerializeObject(_serialize(XAxisAuto)));
            sb.AppendLine(JsonConvert.SerializeObject(_serialize(XAxisMin)));
            sb.AppendLine(JsonConvert.SerializeObject(_serialize(XAxisMax)));
            sb.AppendLine(JsonConvert.SerializeObject(_serialize(YAxisAuto)));
            sb.AppendLine(JsonConvert.SerializeObject(_serialize(YAxisMin)));
            sb.AppendLine(JsonConvert.SerializeObject(_serialize(YAxisMax)));

            string str = sb.ToString();
            string settingsPath = Path.Combine(Directory, SETTTINGSFILE);
            File.WriteAllText(settingsPath, str);
        }




        private void ReadSettings()
        {
            string settingsPath = Path.Combine(Directory, SETTTINGSFILE);
            if (!File.Exists(settingsPath)) return;

            try
            {
                var allText = File.ReadAllText(settingsPath);
                var part = allText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                int i = 0;
                LineColor = _deserializeColor(part[i++]);
                PointColor = _deserializeColor(part[i++]);
                LineWidth = _deserializeInt(part[i++]);
                PointSize = _deserializeInt(part[i++]);
                XAxis = (string)JsonConvert.DeserializeObject(part[i++]);
                YAxis = (string)JsonConvert.DeserializeObject(part[i++]);
                var selFullName = (string)JsonConvert.DeserializeObject(part[i++]);
                Selected = GetSnapshotItem(selFullName);

                XPolarity = (Polarity)Enum.Parse(typeof(Polarity), part[i++].Trim("\"".ToCharArray()));
                YPolarity = (Polarity)Enum.Parse(typeof(Polarity), part[i++].Trim("\"".ToCharArray()));
                ChartStyle = (ChartStyle)Enum.Parse(typeof(ChartStyle), part[i++].Trim("\"".ToCharArray()));

                XAxisAuto = _deserializeBool(part[i++]);
                XAxisMin = _deserializeDouble(part[i++]);
                XAxisMax = _deserializeDouble(part[i++]);
                YAxisAuto = _deserializeBool(part[i++]);
                YAxisMin = _deserializeDouble(part[i++]);
                YAxisMax = _deserializeDouble(part[i++]);
            }
            catch (Exception ex)
            {

            }
        }


        private static string _serialize(Color color)
        {
            return (color.A + "," + color.R + "," + color.G + "," + color.B);
        }
        private static string _serialize(int i)
        {
            return (i.ToString());
        }
        private static string _serialize(double d)
        {
            return (d.ToString());
        }
        private static string _serialize(bool d)
        {
            return (d.ToString());
        }
        private static Color _deserializeColor(string v)
        {
            try
            {
                var str = (String)JsonConvert.DeserializeObject(v);

                var part = str.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                int i = 0;
                int A = int.Parse(part[i++]);
                int R = int.Parse(part[i++]);
                int G = int.Parse(part[i++]);
                int B = int.Parse(part[i++]);

                Color color = Color.FromArgb(A, R, G, B);
                return (color);
            }
            catch
            {
                return (Color.Black);
            }
        }

        private static int _deserializeInt(string v)
        {
            try
            {
                var str = (String)JsonConvert.DeserializeObject(v);
                int A = int.Parse(str);
                return (A);
            }
            catch
            {
                return (0);
            }
        }

        private static double _deserializeDouble(string v)
        {
            try
            {
                var str = (String)JsonConvert.DeserializeObject(v);
                double A = double.Parse(str);
                return (A);
            }
            catch
            {
                return (double.NaN);
            }
        }
        private static bool _deserializeBool(string v)
        {
            try
            {
                var str = (String)JsonConvert.DeserializeObject(v);
                bool A = bool.Parse(str);
                return (A);
            }
            catch
            {
                return (false);
            }
        }

        private static string sanitize(string name)
        {
            //string illegal = "\"M\"\\a/ry/ h**ad:>> a\\/:*?\"| li*tt|le|| la\"mb.?";
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            name = r.Replace(name, "");
            return (name);
        }



        public string Name { get; private set; }
        public string Directory { get; private set; }
        public bool State { get; private set; }

        public Color LineColor { get; set; } = Color.SteelBlue;
        public Color PointColor { get; set; } = Color.SteelBlue;

        public int LineWidth { get; set; } = 1;
        public int PointSize { get; set; } = 3;

        public string XAxis { get; set; }
        public string YAxis { get; set; }

        public Polarity XPolarity { get; set; } = Polarity.Normal;
        public Polarity YPolarity { get; set; } = Polarity.Normal;

        public bool XAxisAuto { get; set; } = true;
        public bool YAxisAuto { get; set; } = true;

        public double XAxisMin { get; set; } = 0;
        public double XAxisMax { get; set; } = 1000;

        public double YAxisMin { get; set; } = 0;
        public double YAxisMax { get; set; } = 1000;

        public ChartStyle ChartStyle { get; set; } = ChartStyle.Linear;

        public SnapshotItem Selected { get; set; }

        public List<SnapshotItem> Collection { get; set; } = new List<SnapshotItem>();

        public List<string> GetSelectedSnapshotHeaderTitles()
        {
            if (Selected == null) return (null);
            if (Selected.Special == SnapshotItem.MOSTRECENT)
            {
                var rnt = GetMostRecentItem();
                return (rnt != null ? rnt.GetHeaderTitles() : null);
            }
            return (Selected.GetHeaderTitles());
        }

        public List<TypeCode> GetSelectedSnapshotHeaderTypes()
        {
            if (Selected == null) return (null);
            if (Selected.Special == SnapshotItem.MOSTRECENT)
            {
                var rnt = GetMostRecentItem();
                return (rnt != null ? rnt.GetHeaderTypes() : null);
            }
            return (Selected.GetHeaderTypes());
        }
        public SnapshotItem GetSelectedItem()
        {
            if (Selected == null) return (null);
            if (Selected.Special == SnapshotItem.MOSTRECENT) return (GetMostRecentItem());
            return (Selected);
        }

        public SnapshotItem GetMostRecentItem()
        {
            foreach (var sItem in Collection)
            {
                if (sItem.Special == SnapshotItem.MOSTRECENT) continue;
                return (sItem);
            }
            return (null);
        }

        public SnapshotItem GetSnapshotItem(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return (null);
            foreach (var sItem in Collection)
                if (sItem.FullName == fullName) return (sItem);
            return (null);
        }
        public void Clear()
        {
            Selected = null;
            Collection.Clear();
            var files = System.IO.Directory.GetFiles(Directory, "*.dat");
            foreach (var file in files) { try { File.Delete(file); } catch { } }
        }
        public void Delete()
        {
            Selected = null;
            System.IO.Directory.Delete(Directory, true);
        }
        public static string Store<T>(T[] data, string name, string sub)
        {
            if (!Snapshot.IsRunningViewerStatus()) return (null);
            List<T> cnvList = new List<T>(data);
            return (Store(cnvList, name, sub));
        }

        public static string Store<T>(List<T> data, string name, string sub)
        {
            if (!Snapshot.IsRunningViewerStatus()) return (null);

            if (string.IsNullOrWhiteSpace(name)) return (null);

            string dir = GetDirectory(name);

            // data
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(name);

            // [name0, type0],  [name1, type1],  etc....
            var fObj = data.First();
            var fields = fObj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo[] properties = fObj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            List<FieldInfo> outFields = new List<FieldInfo>();
            List<PropertyInfo> outProps = new List<PropertyInfo>();
            string str = "";
            string[] permitted = new string[] { "String", "Single", "Double", "Int32" };

            str += ("<Int32>" + "<[*]>,");

            foreach (var field in fields)
            {
                if (permitted.Contains(field.FieldType.Name))
                {
                    outFields.Add(field);
                    str += ("<" + field.FieldType.Name + ">" + "<" + field.Name + ">,");
                }
            }


            foreach (PropertyInfo property in properties)
            {
                if (permitted.Contains(property.PropertyType.Name))
                {
                    outProps.Add(property);
                    str += ("<" + property.PropertyType.Name + ">" + "<" + property.Name + ">,");
                }
            }

            Type type = fObj.GetType();
            if (type.Name == "Double")
            {
                str += ("<Double>" + "<" + name + ">,");
            }
            else if (type.Name == "Single")
            {
                str += ("<Single>" + "<" + name + ">,");
            }
            else if (type.Name == "Int32")
            {
                str += ("<Int32>" + "<" + name + ">,");
            }
            sb.AppendLine(str);



            // < Name >< String >, < X >< Single >, < Y >< Single >, < Zdble >< Double >, < Number >< Int32 >
            int ic = -1;
            foreach (var obj in data)
            {
                ic++;
                // value.. matching
                str = ic.ToString() + ", ";

                foreach (FieldInfo field in outFields)
                {
                    object value = field.GetValue(obj);
                    if (field.FieldType.Name == "String")
                    {
                        str += ("\"" + value + "\", ");
                    }
                    else
                    {
                        str += (value != null) ? value.ToString() : "";
                        str += ", ";
                    }
                }

                foreach (PropertyInfo property in outProps)
                {
                    object value = property.GetValue(obj);
                    if (property.PropertyType.Name == "String")
                    {
                        str += ("\"" + value + "\", ");
                    }
                    else
                    {
                        str += (value != null) ? value.ToString() : "";
                        str += ", ";
                    }
                }


                if (type.Name == "Double")
                {
                    str += obj.ToString();
                    str += ", ";
                }
                else if (type.Name == "Single")
                {
                    str += obj.ToString();
                    str += ", ";
                }
                else if (type.Name == "Int32")
                {
                    str += obj.ToString();
                    str += ", ";
                }

                sb.AppendLine(str);
            }

            string astr = sb.ToString();

            string filename = SnapshotItem.getfilename(dir, sub);
            File.WriteAllText(filename, astr);
            Snapshot.LimitHistory();
            return (filename);
        }


    }

    public static class Snapshot
    {
        static string RUNNINGVIEWER = "viewerRun.txt";
        static int MaximumHistory = 20;

        static FileSystemWatcher watcher;

        public static void Initialize()
        {
            if (watcher == null)
            {
                watcher = new FileSystemWatcher(RepositoryPath);
                watcher.NotifyFilter = NotifyFilters.LastWrite;

                // Only watch .dat files.
                watcher.Filter = "*.dat";
                watcher.IncludeSubdirectories = true;

                // Add event handlers.
                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;

                // Begin watching.
                watcher.EnableRaisingEvents = true;
            }
        }

        static private void OnChanged(object sender, FileSystemEventArgs e)
        {
            DataAdded?.Invoke(null, EventArgs.Empty);
        }

        static public event EventHandler<EventArgs> DataAdded;

        public static void WriteRunningViewerStatus()
        {
            DateTime dT = DateTime.Now;

            string path = Path.Combine(RepositoryPath, RUNNINGVIEWER);

            File.WriteAllText(path, dT.ToString());
        }

        public static bool IsRunningViewerStatus()
        {
            try
            {
                string path = Path.Combine(RepositoryPath, RUNNINGVIEWER);
                string str = File.ReadAllText(path);
                DateTime dT = DateTime.Parse(str);
                DateTime dTnow = DateTime.Now;

                if (((TimeSpan)(dTnow - dT)).TotalMinutes > 1) // no longer running
                    return (false);
            }
            catch
            {
                return (false);
            }
            return (true);
        }


        //public static List<double> GetDoubleArray(SnapshotContainer sC, string xTitle)
        //{
        //    throw new NotImplementedException();
        //}
        //public static List<double> GetDoubleArray(List<SnapshotCategory> all, string name, SnapshotItem sItem, string header)
        //{
        //    SnapshotCategory sC = _getSnapshotContainer(all, name);
        //    if (sC == null) return (null);
        //    return (sC.GetDoubleArray(sItem, header));
        //}

        //public static List<float> GetFloatArray(List<SnapshotCategory> all, string name, SnapshotItem sItem, string header)
        //{
        //    SnapshotCategory sC = _getSnapshotContainer(all, name);
        //    if (sC == null) return (null);
        //    return (sC.GetFloatArray(sItem, header));
        //}

        //public static List<int> GetIntegerArray(List<SnapshotCategory> all, string name, SnapshotItem sItem, string header)
        //{
        //    SnapshotCategory sC = _getSnapshotContainer(all, name);
        //    if (sC == null) return (null);
        //    return (sC.GetIntegerArray(sItem, header));
        //}
        //public static List<string> GetStringArray(List<SnapshotCategory> all, string name, SnapshotItem sItem, string header)
        //{
        //    SnapshotCategory sC = _getSnapshotContainer(all, name);
        //    if (sC == null) return (null);
        //    return (sC.GetStringArray(sItem, header));
        //}

        private static SnapshotCategory _getSnapshotContainer(List<SnapshotCategory> all, string name)
        {
            if (all == null) return (null);
            foreach (var sC in all)
            {
                if (sC.Name == name) return (sC);
            }
            return (null);
        }


        // organize
        // by name
        // per name, max number of

        public static List<SnapshotCategory> GetCollection()
        {
            var subPaths = Directory.GetDirectories(RepositoryPath);

            List<SnapshotCategory> ret = new List<SnapshotCategory>();

            foreach (var subPath in subPaths)
            {
                SnapshotCategory sC = new SnapshotCategory(subPath);
                if (sC.State) ret.Add(sC);
            }


            return (ret);

        }


        public static void LimitHistory()
        {
            var subPaths = Directory.GetDirectories(RepositoryPath);
            foreach (var subPath in subPaths)
            {
                if (!Directory.Exists(subPath)) continue;

                var sortedFiles = new DirectoryInfo(subPath).GetFiles("*.dat")
                                                .OrderByDescending(f => f.LastWriteTime)
                                                .ToList();

                for (int i = MaximumHistory; i < sortedFiles.Count; i++)
                {
                    try { sortedFiles[i].Delete(); } catch { }
                }
            }

        }


        public static string RepositoryPath
        {
            get
            {
                try
                {
                    string result = Path.GetTempPath();
                    string repPath = Path.Combine(result, "Insektor");
                    Directory.CreateDirectory(repPath);
                    return (repPath);

                }
                catch (Exception)
                {
                    return (null);
                }
            }
        }

        public static string Store<T>(List<T> data, string name, string sub = null)
        {
            string filename = SnapshotCategory.Store(data, name, sub);
            if (filename == null) return (null);
            return (filename);
        }
        public static string Store<T>(T[] data, string name, string sub = null)
        {
            string filename = SnapshotCategory.Store(data, name, sub);
            if (filename == null) return (null);
            return (filename);
        }


        public static void WriteSettings(List<SnapshotCategory> all)
        {
            foreach (var sC in all)
                sC.WriteSettings();
        }

        public static object GetSnapshotCategory(List<SnapshotCategory> all, string name)
        {
            foreach (var sC in all)
                if (sC.Name == name) return (sC);
            return (null);
        }

        public static void Delete(SnapshotCategory sC)
        {
            if (sC != null) sC.Delete();
        }
    }
}
