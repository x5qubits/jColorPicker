using JCommon.FileDatabase.Containers;
using JCommon.FileDatabase.IO;
using System.IO;

namespace JCommon.FileDatabase
{        
    /// <summary>
    /// A class that allows you to nest properties into List -> Items -> Rows
    /// </summary>
    public class NestedFileDatabase
    {
        bool _IsLoaded = false;
        FileListColection lists = new FileListColection();
        private static object s_Sync = new object();
        static volatile NestedFileDatabase s_Instance;
        public static NestedFileDatabase Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_Sync)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new NestedFileDatabase();
                        }
                    }
                }
                return s_Instance;
            }
        }

        public static bool IsLoaded => Instance._IsLoaded;
        public static FileListColection Collection => Instance.lists;

        public static void ReadFile(string path)
        {
            Instance.MReadFile(path);
        }

        public static void SaveFile(string path)
        {
            Instance.MSaveFile(path);
        }

        public static void AddNew(int listId)
        {
            Instance.MAddNew(listId);
        }
        public static int ItemCount(int listId)
        {
            return Collection.GetItemCount(listId);
        }

        internal void MReadFile(string path)
        {
            lists = new FileListColection();
            if (File.Exists(path))
            {
                DataReader reader = new DataReader(File.ReadAllBytes(path));
                int listscount = reader.ReadInt32();
                for (int l = 0; l < listscount; l++)
                {
                    int listId = reader.ReadInt32();
                    string ListName = reader.ReadString();
                    int ItemCount = reader.ReadInt32();
                    for (int i = 0; i < ItemCount; i++)
                    {
                        int itemId = reader.ReadInt32();
                        string itemtName = reader.ReadString();
                        int itemRowCount = reader.ReadInt32();
                        
                        FileItem item = new FileItem()
                        {
                            ItemId = itemId,
                            ItemName = itemtName
                        };
                        for (int r = 0; r < itemRowCount; r++)
                        {
                            FileRow row = new FileRow
                            {
                                RowIndex = reader.ReadInt32(),
                                RowName = reader.ReadString(),
                                RowType = (FileRowType)reader.ReadByte()
                            };
                            switch (row.RowType)
                            {
                                case FileRowType.Byte:
                                    row.RowValue = reader.ReadByte();
                                    break;
                                case FileRowType.Int:
                                    row.RowValue = reader.ReadInt32();
                                    break;
                                case FileRowType.Short:
                                    row.RowValue = reader.ReadInt16();
                                    break;
                                case FileRowType.Float:
                                    row.RowValue = reader.ReadSingle();
                                    break;
                                case FileRowType.Double:
                                    row.RowValue = reader.ReadDouble();
                                    break;
                                case FileRowType.Boolean:
                                    row.RowValue = reader.ReadBoolean();
                                    break;
                                case FileRowType.String:
                                    row.RowValue = reader.ReadString();
                                    break;
                            }
                            item.SetRow(row);
                        }
                        lists.SetItem(listId, item);
                        lists.SetListName(listId, ListName);
                    }
                }
                _IsLoaded = true;
                return;
            }

            _IsLoaded = false;
        }

        internal void MSaveFile(string path)
        {
            FileItems[] all = lists.GetLists();
            DataWriter writer = new DataWriter();
            writer.Write(all.Length);
            for (int l = 0; l < all.Length; l++)
            {
                FileItems list = all[l];
                writer.Write(list.ListId);
                writer.Write(list.ListName);
                FileItem[] items = list.GetItems();
                writer.Write(items.Length);
                for (int i = 0; i < items.Length; i++)
                {
                    FileItem item = items[i];
                    
                    FileRow[] rows = item.GetRows();

                    writer.Write(item.ItemId);
                    writer.Write(item.ItemName);
                    writer.Write(rows.Length);

                    for (int r = 0; r < rows.Length; r++)
                    {
                        writer.Write(rows[r].RowIndex);
                        writer.Write(rows[r].RowName);
                        writer.Write((byte)rows[r].RowType);
                        switch(rows[r].RowType)
                        {
                            case FileRowType.Byte:
                                writer.Write((byte)rows[r].RowValue);
                                break;
                            case FileRowType.Int:
                                writer.Write((int)rows[r].RowValue);
                                break;
                            case FileRowType.Short:
                                writer.Write((short)rows[r].RowValue);
                                break;
                            case FileRowType.Float:
                                writer.Write((float)rows[r].RowValue);
                                break;
                            case FileRowType.Double:
                                writer.Write((double)rows[r].RowValue);
                                break;
                            case FileRowType.Boolean:
                                writer.Write((bool)rows[r].RowValue);
                                break;
                            case FileRowType.String:
                                writer.Write((string)rows[r].RowValue);
                                break;
                        }
                        
                    }
                }
            }
            File.WriteAllBytes(path, writer.ToArray());
        }

        internal void MAddNew(int ListId)
        {
            lists.AddNew(ListId);
        }

        internal T GetValue<T>(int ListId, int ItemId, int RowIndex)
        {
            FileRow row = Collection.GetValue(ListId, ItemId, RowIndex);
            if(row != null)
            {
                return (T)row.RowValue;
            }
            return default;
        }
    }
}
